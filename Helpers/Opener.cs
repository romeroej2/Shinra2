using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells;
using ShinraCo.Spells.Main;
using ShinraCo.Spells.Opener;
using Resource = ff14bot.Managers.ActionResourceManager;
using static ShinraCo.Constants;

namespace ShinraCo
{
    public static partial class Helpers
    {
        public static int OpenerStep;
        public static bool OpenerFinished;

        private static List<Spell> current;
        private static bool usePotion;
        private static int potionStep;
        private static HashSet<uint> potionType;
        private static DateTime resetTime;

        private static BardSpells Bard { get; } = new BardSpells();
        private static BlackMageSpells BlackMage { get; } = new BlackMageSpells();
        private static DarkKnightSpells DarkKnight { get; } = new DarkKnightSpells();
        private static DragoonSpells Dragoon { get; } = new DragoonSpells();
        private static MachinistSpells Machinist { get; } = new MachinistSpells();
        private static MonkSpells Monk { get; } = new MonkSpells();
        private static NinjaSpells Ninja { get; } = new NinjaSpells();
        private static RedMageSpells RedMage { get; } = new RedMageSpells();
        private static SamuraiSpells Samurai { get; } = new SamuraiSpells();
        private static SummonerSpells Summoner { get; } = new SummonerSpells();
        private static WarriorSpells Warrior { get; } = new WarriorSpells();

        public static async Task<bool> ExecuteOpener()
        {
            if (OpenerFinished || Me.ClassLevel < 70) return false;

            if (Shinra.Settings.CooldownMode == CooldownModes.Disabled)
            {
                AbortOpener("Please enable cooldown mode to use an opener.");
                return false;
            }

            #region GetOpener

            switch (Me.CurrentJob)
            {
                case ClassJobType.Bard:
                    current = BardOpener.List;
                    usePotion = Shinra.Settings.BardPotion;
                    potionStep = 0;
                    potionType = PotionIds.Dex;
                    break;

                case ClassJobType.BlackMage:
                    current = BlackMageOpener.List;
                    usePotion = Shinra.Settings.BlackMagePotion;
                    potionStep = 7;
                    potionType = PotionIds.Int;
                    break;

                case ClassJobType.DarkKnight:
                    current = DarkKnightOpener.List;
                    usePotion = Shinra.Settings.DarkKnightPotion;
                    potionStep = 3;
                    potionType = PotionIds.Str;
                    break;

                case ClassJobType.Dragoon:
                    current = DragoonOpener.List;
                    usePotion = Shinra.Settings.DragoonPotion;
                    potionStep = 7;
                    potionType = PotionIds.Str;
                    break;

                case ClassJobType.Machinist:
                    current = MachinistOpener.List;
                    usePotion = Shinra.Settings.MachinistPotion;
                    potionStep = 0;
                    potionType = PotionIds.Dex;
                    break;

                case ClassJobType.Monk:
                    current = MonkOpener.List;
                    usePotion = Shinra.Settings.MonkPotion;
                    potionStep = 4;
                    potionType = PotionIds.Str;
                    break;

                case ClassJobType.Ninja:
                    current = NinjaOpener.List;
                    usePotion = Shinra.Settings.NinjaPotion;
                    potionStep = 7;
                    potionType = PotionIds.Dex;
                    break;

                case ClassJobType.Paladin:
                    current = PaladinOpener.List;
                    usePotion = Shinra.Settings.PaladinPotion;
                    potionStep = 8;
                    potionType = PotionIds.Str;
                    break;

                case ClassJobType.RedMage:
                    current = RedMageOpener.List;
                    usePotion = Shinra.Settings.RedMagePotion;
                    potionStep = 3;
                    potionType = PotionIds.Int;
                    break;

                case ClassJobType.Samurai:
                    current = SamuraiOpener.List;
                    usePotion = Shinra.Settings.SamuraiPotion;
                    potionStep = 4;
                    potionType = PotionIds.Str;
                    break;

                case ClassJobType.Summoner:
                    current = SummonerOpener.List;
                    usePotion = Shinra.Settings.SummonerPotion;
                    potionStep = 2;
                    potionType = PotionIds.Int;
                    break;

                case ClassJobType.Warrior:
                    current = WarriorOpener.List;
                    usePotion = Shinra.Settings.WarriorPotion;
                    potionStep = 5;
                    potionType = PotionIds.Str;
                    break;

                default:
                    current = null;
                    break;
            }

            if (current == null) return false;

            #endregion

            if (OpenerStep >= current.Count)
            {
                AbortOpener("Shinra >>> Opener Finished");
                return false;
            }

            if (usePotion && OpenerStep == potionStep)
            {
                if (await UsePotion(potionType)) return true;
            }

            var spell = current.ElementAt(OpenerStep);
            resetTime = DateTime.Now.AddSeconds(10);

            #region Job-Specific

            switch (Me.CurrentJob)
            {
                case ClassJobType.Bard:
                    if (Resource.Bard.Repertoire == 3)
                    {
                        await Bard.PitchPerfect.Cast(null, false);
                    }
                    break;

                case ClassJobType.BlackMage:
                    if ((spell.Name == BlackMage.BlizzardIV.Name || spell.Name == BlackMage.FireIV.Name) && !Resource.BlackMage.Enochian)
                    {
                        AbortOpener("Aborted opener due to Enochian.");
                        return true;
                    }
                    break;

                case ClassJobType.DarkKnight:
                    if (spell.Name == DarkKnight.DarkArts.Name && !Me.HasAura(DarkKnight.Darkside.Name))
                    {
                        AbortOpener("Aborted opener due to Darkside.");
                        return true;
                    }
                    if (spell.Name == DarkKnight.BloodWeapon.Name && Me.HasAura(DarkKnight.Grit.Name))
                    {
                        Debug($"Skipping opener step {OpenerStep} due to Grit >>> {spell.Name}");
                        OpenerStep++;
                        return true;
                    }
                    if ((spell.Name == DarkKnight.Bloodspiller.Name || spell.Name == DarkKnight.Delirium.Name) &&
                        Resource.DarkKnight.BlackBlood < 50)
                    {
                        Debug($"Skipping opener step {OpenerStep} due to Blood >>> {spell.Name}");
                        OpenerStep++;
                        return true;
                    }
                    if (spell.Name == DarkKnight.BlackestNight.Name && Shinra.Settings.DarkKnightOffTank)
                    {
                        await UpdateHealManager();

                        var target = HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.IsMe);

                        if (target != null && await DarkKnight.BlackestNight.Cast(target, false))
                        {
                            Debug($"Casting opener step {OpenerStep} on the main tank >>> {spell.Name}");
                            OpenerStep++;
                            return true;
                        }
                    }
                    break;

                case ClassJobType.Dragoon:
                    if (OpenerStep > 4 && Resource.Dragoon.Timer == TimeSpan.Zero)
                    {
                        AbortOpener("Aborted opener due to Blood of the Dragon.");
                        return true;
                    }
                    if (spell.Name == Dragoon.DragonSight.Name)
                    {
                        var target = Managers.DragonSight.FirstOrDefault();

                        if (target == null) break;

                        if (await Dragoon.DragonSight.Cast(target, false))
                        {
                            Debug($"Executed opener step {OpenerStep} >>> {spell.Name}");
                            OpenerStep++;
                            return true;
                        }
                    }
                    break;

                case ClassJobType.Machinist:
                    if (PetManager.ActivePetType != PetType.Rook_Autoturret)
                    {
                        var castLocation = Shinra.Settings.MachinistTurretLocation == CastLocations.Self ? Me : Target;

                        if (await Machinist.RookAutoturret.Cast(castLocation, false))
                        {
                            return true;
                        }
                    }
                    if (Pet != null)
                    {
                        if (await Machinist.Hypercharge.Cast(null, false))
                        {
                            return true;
                        }
                    }
                    break;

                case ClassJobType.Monk:
                    if (OpenerStep == 0)
                    {
                        if (!Me.HasAura(109))
                        {
                            if (Me.HasAura(108)) await Monk.TwinSnakes.Cast();
                            await Monk.Bootshine.Cast();
                            return true;
                        }
                        if (!Me.HasAura(105))
                        {
                            await Monk.FistsOfWind.Cast(null, false);
                            return true;
                        }
                    }
                    if (spell.Name == Monk.RiddleOfWind.Name && Monk.RiddleOfWind.Cooldown() > 0)
                    {
                        return true;
                    }
                    if (spell.Name == Monk.ForbiddenChakra.Name && Resource.Monk.FithChakra != 5)
                    {
                        Debug($"Skipping opener step {OpenerStep} due to Chakras >>> {spell.Name}");
                        OpenerStep++;
                        return true;
                    }
                    if (spell.Name == Monk.TornadoKick.Name && Resource.Monk.GreasedLightning != 3)
                    {
                        Debug($"Skipping opener step {OpenerStep} due to Greased Lightning >>> {spell.Name}");
                        OpenerStep++;
                        return true;
                    }
                    if (spell.Name == Monk.PerfectBalance.Name)
                    {
                        if (Monk.PerfectBalance.Cooldown() <= 0)
                        {
                            AbortOpener("Aborted opener due to Perfect Balance.");
                            return true;
                        }
                        if (Monk.Bootshine.Cooldown() > 700)
                        {
                            return true;
                        }
                    }
                    if (Shinra.LastSpell.Name != Monk.PerfectBalance.Name && Monk.PerfectBalance.Cooldown() > 0 &&
                        ActionManager.CanCast(Monk.Bootshine.Name, Target) && !ActionManager.CanCast(spell.Name, Target) &&
                        !ActionManager.CanCast(spell.Name, Me))
                    {
                        AbortOpener("Aborted opener due to Perfect Balance.");
                        return true;
                    }
                    break;

                case ClassJobType.Ninja:
                    if (OpenerStep == 1 && (Resource.Ninja.HutonTimer == TimeSpan.Zero || Ninja.Ninjutsu.Cooldown() > 0))
                    {
                        AbortOpener("Aborted opener due to Ninjutsu.");
                        return true;
                    }
                    if (spell.Name == Ninja.Kassatsu.Name && Ninja.Kassatsu.Cooldown() > 0)
                    {
                        AbortOpener("Aborted opener due to Kassatsu.");
                        return true;
                    }
                    if (spell.Name == Ninja.TrickAttack.Name && !Me.HasAura(Ninja.Suiton.Name))
                    {
                        Debug($"Skipping opener step {OpenerStep} due to Suiton >>> {spell.Name}");
                        OpenerStep++;
                        return true;
                    }
                    break;

                case ClassJobType.RedMage:
                    if (!ActionManager.HasSpell("Swiftcast"))
                    {
                        AbortOpener("Aborting opener as Swiftcast is not set.");
                        return false;
                    }
                    if (spell.Name == RedMage.Verstone.Name && !Me.HasAura("Verstone Ready"))
                    {
                        AbortOpener("Aborting opener due to cooldowns.");
                        return false;
                    }
                    if (spell.Name == RedMage.EnchantedRiposte.Name && (Resource.RedMage.WhiteMana < 80 || Resource.RedMage.BlackMana < 80))
                    {
                        AbortOpener("Aborted opener due to mana levels.");
                        return true;
                    }
                    break;

                case ClassJobType.Samurai:
                    if (spell.Name == Samurai.MeikyoShisui.Name && Samurai.MeikyoShisui.Cooldown() > 0 ||
                        OpenerStep > 9 && !Me.HasAura(Samurai.MeikyoShisui.Name))
                    {
                        AbortOpener("Aborted opener due to Meikyo Shisui.");
                        return true;
                    }
                    if (spell.Name == Samurai.HissatsuGuren.Name && Resource.Samurai.Kenki < 70)
                    {
                        Debug($"Skipping opener step {OpenerStep} due to Kenki >>> {spell.Name}");
                        OpenerStep++;
                        return true;
                    }
                    if (spell.Name == Samurai.Higanbana.Name && MovementManager.IsMoving)
                    {
                        return true;
                    }
                    break;

                case ClassJobType.Summoner:
                    if (!ActionManager.HasSpell("Swiftcast"))
                    {
                        AbortOpener("Aborting opener as Swiftcast is not set.");
                        return false;
                    }
                    if (PetManager.ActivePetType == PetType.Ifrit_Egi && PetManager.PetMode != PetMode.Sic)
                    {
                        if (await Coroutine.Wait(1000, () => PetManager.DoAction("Sic", Me)))
                        {
                            Logging.Write(Colors.GreenYellow, @"[Shinra] Casting >>> Sic");
                            return await Coroutine.Wait(3000, () => PetManager.PetMode == PetMode.Sic);
                        }
                    }
                    if (OpenerStep == 1)
                    {
                        if (PetManager.ActivePetType == PetType.Garuda_Egi && PetManager.PetMode == PetMode.Obey)
                        {
                            if (await Summoner.Contagion.Cast())
                            {
                                return true;
                            }
                        }
                        if (Resource.Arcanist.Aetherflow < 3 && Summoner.Aetherflow.Cooldown() > 15000)
                        {
                            AbortOpener("Aborting opener due to Aetherflow charges.");
                            return false;
                        }
                    }
                    if (spell.Name == Summoner.SummonIII.Name)
                    {
                        if (!Shinra.Settings.SummonerOpenerGaruda || PetManager.ActivePetType == PetType.Ifrit_Egi ||
                            !Me.HasAura(Summoner.Role.Swiftcast.Name))
                        {
                            Debug($"Skipping opener step {OpenerStep} due to Swiftcast/not using Garuda >>> {spell.Name}");
                            OpenerStep++;
                            return true;
                        }
                    }
                    if (spell.Name == Summoner.Fester.Name)
                    {
                        if (Resource.Arcanist.Aetherflow > 0 && spell.Cooldown() > 0)
                        {
                            return true;
                        }
                        if (Resource.Arcanist.Aetherflow == 0)
                        {
                            Debug($"Skipping opener step {OpenerStep} due to Aetherflow charges >>> {spell.Name}");
                            OpenerStep++;
                            return true;
                        }
                    }
                    if (spell.Name == Summoner.DreadwyrmTrance.Name && Resource.Arcanist.AetherAttunement < 3)
                    {
                        await Coroutine.Wait(2000, () => Resource.Arcanist.AetherAttunement == 3);
                        if (Resource.Arcanist.AetherAttunement < 3)
                        {
                            AbortOpener("Aborting opener due to Aethertrail Attunement.");
                            return false;
                        }
                    }
                    break;

                case ClassJobType.Warrior:
                    if (OpenerStep == 0 && !Me.HasAura(Warrior.Deliverance.Name))
                    {
                        if (Shinra.LastSpell.Name != Warrior.Deliverance.Name && Warrior.Deliverance.Cooldown() > 3000)
                        {
                            AbortOpener("Aborting opener due to Deliverance cooldown.");
                            return false;
                        }
                        await Warrior.Deliverance.Cast();
                        return true;
                    }
                    if (spell.Name == Warrior.FellCleave.Name)
                    {
                        if (Resource.Warrior.BeastGauge < 50 && !Me.HasAura(1177))
                        {
                            Debug($"Skipping opener step {OpenerStep} due to Beast Gauge >>> {spell.Name}");
                            OpenerStep++;
                            return true;
                        }
                    }
                    if (spell.Name == Warrior.InnerRelease.Name)
                    {
                        if (DataManager.GetSpellData(31).Cooldown.TotalMilliseconds > 700)
                        {
                            return true;
                        }
                    }
                    break;
            }

            #endregion

            if (await spell.Cast(null, false))
            {
                Debug($"Executed opener step {OpenerStep} >>> {spell.Name}");
                OpenerStep++;
                if (spell.Name == "Swiftcast")
                {
                    await Coroutine.Wait(3000, () => Me.HasAura("Swiftcast"));
                }

                if (OpenerStep == 1)
                {
                    DisplayToast("Shinra >>> Opener Started", 2500);
                }

                #region Job-Specific

                // Bard
                if (spell.Name == Bard.IronJaws.Name)
                {
                    DotManager.Add(Target);
                }

                // Machinist
                if (spell.Name == Machinist.Flamethrower.Name)
                {
                    await Coroutine.Wait(3000, () => Me.HasAura(Machinist.Flamethrower.Name));
                    await Coroutine.Wait(5000, () => Resource.Machinist.Heat == 100 || !Me.HasAura(Machinist.Flamethrower.Name));
                }

                // Red Mage
                if (spell.Name == RedMage.Manafication.Name)
                {
                    await Coroutine.Wait(3000, () => ActionManager.CanCast(RedMage.CorpsACorps.Name, Target));
                }

                #endregion
            }
            else if (spell.Cooldown(true) > 3000 && spell.Cooldown() > 500 && !Me.IsCasting)
            {
                Debug($"Skipped opener step {OpenerStep} due to cooldown >>> {spell.Name}");
                OpenerStep++;
            }
            return true;
        }

        public static void AbortOpener(string msg)
        {
            Debug(msg);
            OpenerFinished = true;
            DisplayToast("Opener finished!", 2500);
        }

        public static void ResetOpener()
        {
            if (Me.InCombat || DateTime.Now < resetTime) return;

            OpenerStep = 0;
            OpenerFinished = false;
        }
    }
}
