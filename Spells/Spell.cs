using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using Clio.Utilities;
using ff14bot;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using ff14bot.Pathing;
using ShinraCo.Settings;

namespace ShinraCo.Spells
{
    #region Enums

    public enum CastType
    {
        Target,
        Self,
        TargetLocation,
        SelfLocation
    }

    public enum GCDType
    {
        On,
        Off
    }

    public enum SpellType
    {
        Damage,
        DoT,
        AoE,
        Cooldown,
        Buff,
        Heal,
        Pet,
        Ninjutsu,
        Mudra,
        Card,
        PVP
    }

    #endregion

    public class Spell
    {
        public static readonly Dictionary<string, DateTime> RecentSpell = new Dictionary<string, DateTime>();

        private readonly Random _rand = new Random();
        public string Name { get; set; }
        public uint ID { get; set; }
        public uint Combo { get; set; }
        public byte Level { get; set; }
        public GCDType GCDType { private get; set; }
        public SpellType SpellType { private get; set; }
        public CastType CastType { private get; set; }

        private int GetMultiplier() => _rand.NextDouble() < .5 ? 1 : -1;

        public async Task<bool> Cast(GameObject target = null, bool checkGCDType = true)
        {
            #region Target

            if (target == null)
                switch (CastType)
                {
                    case CastType.Target:
                    case CastType.TargetLocation:
                        if (!Core.Player.HasTarget) return false;
                        target = Core.Player.CurrentTarget;
                        break;
                    default:
                        target = Core.Player;
                        break;
                }

            #endregion

            #region RecentSpell

            RecentSpell.RemoveAll(t => DateTime.UtcNow > t);
            if (RecentSpell.ContainsKey(target.ObjectId.ToString("X") + "-" + Name)) return false;

            #endregion

            #region CapabilityManager

            if (RoutineManager.IsAnyDisallowed(CapabilityFlags.Movement | CapabilityFlags.Facing)) return false;

            #endregion

            #region Cooldown

            if (ShinraEx.Settings.CooldownMode == CooldownModes.Disabled)
                if ((SpellType == SpellType.Buff || SpellType == SpellType.Cooldown) && Cooldown(true) > 2500)
                    return false;

            #endregion

            #region AoE

            if (SpellType == SpellType.AoE && ShinraEx.Settings.RotationMode != Modes.Multi)
            {
                if (RoutineManager.IsAnyDisallowed(CapabilityFlags.Aoe)) return false;

                var enemyCount =
                    Helpers.Enemies.Count(eu => eu.Distance2D(target) - eu.CombatReach - target.CombatReach <=
                                                DataManager.GetSpellData(ID).Radius);

                if (ShinraEx.Settings.CustomAoE)
                {
                    if (enemyCount < ShinraEx.Settings.CustomAoECount) return false;
                }
                else
                {
                    switch (Core.Player.CurrentJob)
                    {
                        case ClassJobType.Arcanist:
                        case ClassJobType.Summoner:
                            if (enemyCount < 2) return false;
                            break;
                        default:
                            if (enemyCount < 3) return false;
                            break;
                    }
                }
            }

            #endregion

            #region Directional

            switch (ID)
            {
                // Cone
                case 41:
                case 70:
                case 106:
                case 7483:
                case 7488:
                {
                    if (!Helpers.InView(Core.Player.Location, Core.Player.Heading, target.Location))
                        return false;
                    break;
                }

                // Line
                case 86:
                case 7496:
                {
                    if (!Core.Player.IsFacing(target))
                        return false;
                    break;
                }
            }

            #endregion

            #region Pet

            switch (SpellType)
            {
                case SpellType.Pet when Core.Player.Pet == null:
                case SpellType.Pet when PetManager.PetMode != PetMode.Obey:
                case SpellType.Pet when Core.Player.IsMounted:
                case SpellType.Pet when !PetManager.CanCast(Name, target):
                case SpellType.Pet when !await Coroutine.Wait(5000, () => PetManager.DoAction(Name, target)):
                    return false;
                case SpellType.Pet:
                {
                    ShinraEx.LastSpell = this;

                    #region AddRecent

                    var key = target.ObjectId.ToString("X") + "-" + Name;
                    var val = DateTime.UtcNow + TimeSpan.FromSeconds(3);
                    RecentSpell.Add(key, val);

                    #endregion

                    Logging.Write(Colors.GreenYellow, $@"[ShinraEx] Casting >>> {Name}");
                    return true;
                }

                case SpellType.Card when Core.Player.IsMounted:
                case SpellType.Card when !ActionManager.CanCast(ID, target) || RecentSpell.ContainsKey("Card"):
                case SpellType.Card when !await Coroutine.Wait(1000, () => ActionManager.DoAction(ID, target)):
                    return false;
                case SpellType.Card:
                {
                    ShinraEx.LastSpell = this;

                    #region AddRecent

                    var val = DateTime.UtcNow + TimeSpan.FromSeconds(.5);

                    if (ID == 3593) val += TimeSpan.FromSeconds(2);
                    RecentSpell.Add("Card", val);

                    #endregion

                    Logging.Write(Colors.GreenYellow, $@"[ShinraEx] Casting >>> {Name}");
                    return true;
                }
            }

            #endregion

            #region Card

            if (ShinraEx.Settings.AstrologianCardOnly && Core.Player.CurrentJob == ClassJobType.Astrologian)
                return false;

            #endregion

            #region Ninjutsu

            if (SpellType == SpellType.Ninjutsu || SpellType == SpellType.Mudra)
            {
                #region Movement

                if (BotManager.Current.IsAutonomous)
                    switch (ActionManager.InSpellInRangeLOS(2247, target))
                    {
                        case SpellRangeCheck.ErrorNotInLineOfSight:
                            await CommonTasks.MoveAndStop(new MoveToParameters(target.Location), 0f);
                            return false;
                        case SpellRangeCheck.ErrorNotInRange:
                            await CommonTasks.MoveAndStop(new MoveToParameters(target.Location), 0f);
                            return false;
                        case SpellRangeCheck.ErrorNotInFront:
                            if (!target.InLineOfSight())
                            {
                                await CommonTasks.MoveAndStop(new MoveToParameters(target.Location), 0f);
                                return false;
                            }

                            target.Face();
                            return false;
                        case SpellRangeCheck.Success:
                            if (MovementManager.IsMoving) Navigator.PlayerMover.MoveStop();
                            break;
                    }

                #endregion

                #region IsMounted

                if (Core.Player.IsMounted) return false;

                #endregion

                #region CanCast

                if (ShinraEx.Settings.QueueSpells &&
                    !ActionManager.CanCastOrQueue(DataManager.GetSpellData(ID), target) ||
                    !ActionManager.CanCast(ID, target))
                    return false;

                #endregion

                #region DoAction

                if (!await Coroutine.Wait(1000, () => ActionManager.DoAction(ID, target))) return false;

                #endregion

                #region Wait

                await Coroutine.Wait(2000, () => !ActionManager.CanCast(ID, target));

                #endregion

                ShinraEx.LastSpell = this;

                #region AddRecent

                if (SpellType == SpellType.Mudra)
                {
                    var key = target.ObjectId.ToString("X") + "-" + Name;
                    var val = DateTime.UtcNow + TimeSpan.FromSeconds(1);
                    RecentSpell.Add(key, val);
                }

                #endregion

                Logging.Write(Colors.GreenYellow, $@"[ShinraEx] Casting >>> {Name}");
                return true;
            }

            #endregion

            #region CanAttack

            var bc = target as BattleCharacter;

            if (!target.CanAttack && CastType != CastType.Self && CastType != CastType.SelfLocation &&
                (bc == null || !bc.IsFate))
                switch (SpellType)
                {
                    case SpellType.Damage:
                    case SpellType.DoT:
                    case SpellType.Cooldown:
                        return false;
                }

            #endregion

            #region HasSpell

            if (!ActionManager.HasSpell(ID)) return false;

            #endregion

            #region Movement

            if (BotManager.Current.IsAutonomous)
            {
                switch (ActionManager.InSpellInRangeLOS(ID, target))
                {
                    case SpellRangeCheck.ErrorNotInLineOfSight:
                        await CommonTasks.MoveAndStop(new MoveToParameters(target.Location), 0f);
                        Helpers.Debug($"LineOfSight >>> {Name}");
                        return false;
                    case SpellRangeCheck.ErrorNotInRange:
                        await CommonTasks.MoveAndStop(new MoveToParameters(target.Location), 0f);
                        Helpers.Debug($"Range >>> {Name}");
                        return false;
                    case SpellRangeCheck.ErrorNotInFront:
                        if (!target.InLineOfSight())
                        {
                            await CommonTasks.MoveAndStop(new MoveToParameters(target.Location), 0f);
                            Helpers.Debug($"Facing >>> {Name}");
                            return false;
                        }

                        target.Face();
                        return false;
                    case SpellRangeCheck.Success:
                        if (CastType == CastType.TargetLocation && Core.Player.Distance2D(target) +
                            Core.Player.CombatReach +
                            target.CombatReach > 25)
                        {
                            await CommonTasks.MoveAndStop(new MoveToParameters(target.Location), 0f);
                            await Coroutine.Wait(1000,
                                () => Core.Player.Distance2D(target) + Core.Player.CombatReach + target.CombatReach <=
                                      25);
                            return false;
                        }

                        Navigator.PlayerMover.MoveStop();
                        break;
                }

                if (Core.Player.HasTarget && !MovementManager.IsMoving && Core.Player.IsMounted)
                {
                    Logging.Write(Colors.Yellow, @"[ShinraEx] Dismounting...");
                    ActionManager.Dismount();
                    await Coroutine.Sleep(1000);
                }
            }

            #endregion

            #region IsMounted

            if (Core.Player.IsMounted) return false;

            #endregion

            #region StopCasting

            if (SpellType == SpellType.Heal)
                if (Core.Player.IsCasting && !Helpers.HealingSpells.Contains(Core.Player.SpellCastInfo.Name))
                {
                    var stopCasting = false;
                    switch (Core.Player.CurrentJob)
                    {
                        case ClassJobType.Astrologian:
                            stopCasting = ShinraEx.Settings.AstrologianInterruptDamage;
                            break;
                        case ClassJobType.Scholar:
                            stopCasting = ShinraEx.Settings.ScholarInterruptDamage;
                            break;
                        case ClassJobType.WhiteMage:
                            stopCasting = ShinraEx.Settings.WhiteMageInterruptDamage;
                            break;
                    }

                    if (stopCasting)
                    {
                        Helpers.Debug($@"Trying to cast {Name}");
                        Logging.Write(Colors.Yellow, $@"[ShinraEx] Interrupting >>> {Core.Player.SpellCastInfo.Name}");
                        ActionManager.StopCasting();
                        await Coroutine.Wait(500, () => !Core.Player.IsCasting);
                    }
                }

            #endregion

            #region CanCast

            switch (CastType)
            {
                case CastType.TargetLocation:
                case CastType.SelfLocation:
                    if (!ActionManager.CanCastLocation(ID, target.Location) || Core.Player.IsCasting) return false;
                    break;
                default:
                    if (ShinraEx.Settings.QueueSpells && GCDType == GCDType.On)
                    {
                        if (!ActionManager.CanCastOrQueue(DataManager.GetSpellData(ID), target)) return false;
                    }
                    else
                    {
                        if (!ActionManager.CanCast(ID, target)) return false;
                    }

                    break;
            }

            if (MovementManager.IsMoving && DataManager.GetSpellData(ID).AdjustedCastTime.TotalMilliseconds > 0)
            {
                if (!BotManager.Current.IsAutonomous) return false;
                Navigator.PlayerMover.MoveStop();
            }

            #endregion

            #region InView

            if (GameSettingsManager.FaceTargetOnAction == false && CastType == CastType.Target &&
                SpellType != SpellType.Heal &&
                SpellType != SpellType.Buff &&
                !Helpers.InView(Core.Player.Location, Core.Player.Heading, target.Location))
                return false;

            #endregion

            #region GCD

            if (GCDType == GCDType.Off && checkGCDType)
                switch (Core.Player.CurrentJob)
                {
                    case ClassJobType.Arcanist:
                    case ClassJobType.Scholar:
                    case ClassJobType.Summoner:
                        if (DataManager.GetSpellData(163).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Archer:
                    case ClassJobType.Bard:
                        if (DataManager.GetSpellData(97).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Astrologian:
                        if (DataManager.GetSpellData(3594).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Conjurer:
                    case ClassJobType.WhiteMage:
                        if (DataManager.GetSpellData(119).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Dancer:
                        if (DataManager.GetSpellData(15989).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.DarkKnight:
                       // if (DataManager.GetSpellData(3617).Cooldown.TotalMilliseconds < 1000) return false;
                       // break;
                    case ClassJobType.Gladiator:
                    case ClassJobType.Paladin:
                        if (DataManager.GetSpellData(9).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Lancer:
                    case ClassJobType.Dragoon:
                        if (ID == 8801 || ID == 8802)
                            if (DataManager.GetSpellData(75).Cooldown.TotalMilliseconds < 1500) return false;
                        else if (DataManager.GetSpellData(75).Cooldown.TotalMilliseconds < 1000)
                            return false;

                        break;
                    case ClassJobType.Gunbreaker:
                        if (DataManager.GetSpellData(16137).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Machinist:
                        if (DataManager.GetSpellData(2866).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Marauder:
                    case ClassJobType.Warrior:
                        if (DataManager.GetSpellData(31).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Pugilist:
                    case ClassJobType.Monk:
                        if (DataManager.GetSpellData(53).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.RedMage:
                        if (DataManager.GetSpellData(7504).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Rogue:
                    case ClassJobType.Ninja:
                        if (DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Samurai:
                        if (DataManager.GetSpellData(7477).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                    case ClassJobType.Thaumaturge:
                    case ClassJobType.BlackMage:
                        if (DataManager.GetSpellData(142).Cooldown.TotalMilliseconds < 1000) return false;
                        break;
                   

                }

            #endregion

            #region DoAction

            switch (CastType)
            {
                case CastType.TargetLocation:
                    if (ShinraEx.Settings.RandomCastLocations)
                    {
                        var randX = target.CombatReach * _rand.NextDouble() * GetMultiplier();
                        var randZ = target.CombatReach * _rand.NextDouble() * GetMultiplier();
                        var randXYZ = new Vector3((float) randX, 0f, (float) randZ);
                        var newLocation = target.Location + randXYZ;

                        if (!await Coroutine.Wait(1000, () => ActionManager.DoActionLocation(ID, newLocation)))
                            return false;
                    }
                    else
                    {
                        if (!await Coroutine.Wait(1000, () => ActionManager.DoActionLocation(ID, target.Location)))
                            return false;
                    }

                    break;
                case CastType.SelfLocation:
                    if (ShinraEx.Settings.RandomCastLocations)
                    {
                        var randX = (1f * _rand.NextDouble() + 1f) * GetMultiplier();
                        var randZ = (1f * _rand.NextDouble() + 1f) * GetMultiplier();
                        var randXYZ = new Vector3((float) randX, 0f, (float) randZ);
                        var newLocation = target.Location + randXYZ;

                        if (!await Coroutine.Wait(1000, () => ActionManager.DoActionLocation(ID, newLocation)))
                            return false;
                    }
                    else
                    {
                        if (!await Coroutine.Wait(1000, () => ActionManager.DoActionLocation(ID, target.Location)))
                            return false;
                    }

                    break;
                default:
                    if (SpellType == SpellType.PVP)
                    {
                        if (!await Coroutine.Wait(1000, () => ActionManager.DoPvPCombo(Combo, target))) return false;
                        Logging.Write(Colors.Orange, $@"DoAction Combo {Combo} 0x{target.ObjectId:X}");
                    }
                    else
                    {
                        if (!await Coroutine.Wait(1000, () => ActionManager.DoAction(ID, target))) return false;
                    }

                    break;
            }

            #endregion

            #region Wait

            switch (CastType)
            {
                case CastType.SelfLocation:
                case CastType.TargetLocation:
                    await Coroutine.Wait(3000, () => !ActionManager.CanCastLocation(ID, target.Location));
                    break;
                default:
                    await Coroutine.Wait(3000, () => !ActionManager.CanCast(ID, target));
                    break;
            }

            #endregion

            ShinraEx.LastSpell = this;
            Logging.Write(Colors.GreenYellow,
                $@"[ShinraEx] Casting >>> {Name}{(SpellType == SpellType.PVP ? " Combo" : "")}");

            #region AddRecent

            if (SpellType != SpellType.Damage && SpellType != SpellType.AoE && SpellType != SpellType.Heal &&
                SpellType != SpellType.PVP &&
                await CastComplete(this))
            {
                var key = target.ObjectId.ToString("X") + "-" + Name;
                var val = DateTime.UtcNow + DataManager.GetSpellData(ID).AdjustedCastTime + TimeSpan.FromSeconds(3);
                RecentSpell.Add(key, val);
            }

            if (SpellType == SpellType.Damage || SpellType == SpellType.DoT)
            {
                if (!Helpers.OpenerFinished && !RecentSpell.ContainsKey("Opener") && await CastComplete(this, true))
                {
                    var val = DateTime.UtcNow + DataManager.GetSpellData(ID).AdjustedCastTime + TimeSpan.FromSeconds(3);
                    RecentSpell.Add("Opener", val);
                }
            }

            #endregion

            return true;
        }

        #region CastComplete

        private static async Task<bool> CastComplete(Spell spell, bool opener = false)
        {
            if (spell.SpellType == SpellType.DoT || opener)
            {
                var castTime = DataManager.GetSpellData(spell.ID).AdjustedCastTime;
                if (castTime.TotalMilliseconds > 0)
                {
                    var timer = new Stopwatch();
                    timer.Start();
                    await Coroutine.Wait(castTime, () => Core.Player.IsCasting);
                    while (timer.ElapsedMilliseconds < castTime.TotalMilliseconds - 100)
                    {
                        if (!Core.Player.IsCasting) return false;
                        await Coroutine.Yield();
                    }
                }
            }

            return true;
        }

        #endregion

        public double Cooldown(bool adjusted = false)
        {
            return adjusted
                ? DataManager.GetSpellData(ID).AdjustedCooldown.TotalMilliseconds
                : DataManager.GetSpellData(ID).Cooldown.TotalMilliseconds;
        }
    }
}