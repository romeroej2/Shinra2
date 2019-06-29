using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;

namespace ShinraCo.Rotations
{
    public sealed partial class WhiteMage
    {
        private WhiteMageSpells MySpells { get; } = new WhiteMageSpells();

        #region Damage

        private async Task<bool> Stone()
        {
            if (!ActionManager.HasSpell(MySpells.StoneII.Name) && !StopDamage)
            {
                return await MySpells.Stone.Cast();
            }
            return false;
        }

        private async Task<bool> StoneII()
        {
            if (!ActionManager.HasSpell(MySpells.StoneIII.Name) && !StopDamage)
            {
                return await MySpells.StoneII.Cast();
            }
            return false;
        }

        private async Task<bool> StoneIII()
        {
            if (!ActionManager.HasSpell(MySpells.StoneIV.Name) && !StopDamage)
            {
                return await MySpells.StoneIII.Cast();
            }
            return false;
        }

        private async Task<bool> StoneIV()
        {
            if (!StopDamage)
            {
                return await MySpells.StoneIV.Cast();
            }
            return false;
        }

        #endregion

        #region DoT

        private async Task<bool> Aero()
        {
            if (!ActionManager.HasSpell(MySpells.AeroII.Name) && !StopDots &&
                !Core.Player.CurrentTarget.HasAura(MySpells.Aero.Name, true, 3000))
            {
                return await MySpells.Aero.Cast();
            }
            return false;
        }

        private async Task<bool> AeroII()
        {
            if (!StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.AeroII.Name, true, 3000))
            {
                return await MySpells.AeroII.Cast();
            }
            return false;
        }

        private async Task<bool> AeroIII()
        {
            if (!StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.AeroIII.Name, true, 4000))
            {
                return await MySpells.AeroIII.Cast();
            }
            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> Holy()
        {
            var count = Shinra.Settings.CustomAoE ? Shinra.Settings.CustomAoECount : 3;

            if (!MovementManager.IsMoving && (Shinra.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearPlayer(8) >= count))
            {
                if (Shinra.Settings.WhiteMageThinAir && ActionManager.CanCast(MySpells.Holy.Name, Core.Player))
                {
                    if (await MySpells.ThinAir.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.ThinAir.Name));
                    }
                }
                if (!StopDamage)
                {
                    return await MySpells.Holy.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> PresenceOfMind()
        {
            if (Shinra.Settings.WhiteMagePartyHeal && Shinra.Settings.WhiteMagePresenceOfMind)
            {
                if (Helpers.HealManager.Count(hm => hm.CurrentHealthPercent < Shinra.Settings.WhiteMagePresenceOfMindPct) >=
                    Shinra.Settings.WhiteMagePresenceOfMindCount)
                {
                    return await MySpells.PresenceOfMind.Cast(null, false);
                }
            }
            return false;
        }

        #endregion

        #region Heal

        private async Task<bool> UpdateHealing()
        {
            if (Shinra.Settings.WhiteMagePartyHeal && !await Helpers.UpdateHealManager())
            {
                return true;
            }
            return false;
        }

        private async Task<bool> StopCasting()
        {
            if (Shinra.Settings.WhiteMageInterruptOverheal && Core.Player.IsCasting)
            {
                var target = GameObjectManager.GetObjectByObjectId(Core.Player.SpellCastInfo.TargetId);
                var spellName = Core.Player.SpellCastInfo.Name;
                var freeCure = Core.Player.HasAura(155) ? Shinra.Settings.WhiteMageCurePct : Shinra.Settings.WhiteMageCureIIPct;

                if (target != null)
                {
                    if (spellName == MySpells.Cure.Name && target.CurrentHealthPercent >= Shinra.Settings.WhiteMageCurePct + 10 ||
                        spellName == MySpells.CureII.Name && target.CurrentHealthPercent >= freeCure + 10)
                    {
                        var debugSetting = spellName == MySpells.Cure.Name ? Shinra.Settings.WhiteMageCurePct
                            : Shinra.Settings.WhiteMageCureIIPct;
                        Helpers.Debug($@"Target HP: {target.CurrentHealthPercent}, Setting: {debugSetting}, Adjusted: {debugSetting + 10}");

                        Logging.Write(Colors.Yellow, $@"[Shinra] Interrupting >>> {spellName}");
                        ActionManager.StopCasting();
                        await Coroutine.Wait(500, () => !Core.Player.IsCasting);
                    }
                }
            }
            return false;
        }

        private async Task<bool> Cure()
        {
            if (Shinra.Settings.WhiteMageCure)
            {
                var target = Shinra.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < Shinra.Settings.WhiteMageCurePct)
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.WhiteMageCurePct ? Core.Player : null;

                if (target != null)
                {
                    if (Shinra.Settings.WhiteMageCureII && Core.Player.HasAura(155))
                    {
                        return await MySpells.CureII.Cast(target);
                    }
                    return await MySpells.Cure.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> CureII()
        {
            if (Shinra.Settings.WhiteMageCureII)
            {
                var target = Shinra.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < Shinra.Settings.WhiteMageCureIIPct)
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.WhiteMageCureIIPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.CureII.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Tetragrammaton()
        {
            if (Shinra.Settings.WhiteMageTetragrammaton)
            {
                var target = Shinra.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < Shinra.Settings.WhiteMageTetragrammatonPct)
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.WhiteMageTetragrammatonPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Tetragrammaton.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Benediction()
        {
            if (Shinra.Settings.WhiteMageBenediction)
            {
                var target = Shinra.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < Shinra.Settings.WhiteMageBenedictionPct)
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.WhiteMageBenedictionPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Benediction.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Regen()
        {
            if (Shinra.Settings.WhiteMageRegen)
            {
                var target = Shinra.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < Shinra.Settings.WhiteMageRegenPct &&
                                                               !hm.HasAura(MySpells.Regen.Name))
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.WhiteMageRegenPct && !Core.Player.HasAura(MySpells.Regen.Name)
                        ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Regen.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Medica()
        {
            if (Shinra.Settings.WhiteMageMedica && Shinra.Settings.WhiteMagePartyHeal && UseAoEHeals)
            {
                var count = Helpers.FriendsNearPlayer(Shinra.Settings.WhiteMageMedicaPct);

                if (count > 2)
                {
                    return await MySpells.Medica.Cast();
                }
            }
            return false;
        }

        private async Task<bool> MedicaII()
        {
            if (Shinra.Settings.WhiteMageMedicaII && Shinra.Settings.WhiteMagePartyHeal && UseAoEHeals &&
                !Core.Player.HasAura(MySpells.MedicaII.Name, true))
            {
                var count = Helpers.FriendsNearPlayer(Shinra.Settings.WhiteMageMedicaIIPct);

                if (count > 2)
                {
                    return await MySpells.MedicaII.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Assize()
        {
            if (Shinra.Settings.WhiteMageAssize && Shinra.Settings.WhiteMagePartyHeal && UseAoEHeals && Core.Player.CurrentManaPercent < 85)
            {
                var count = Helpers.FriendsNearPlayer(Shinra.Settings.WhiteMageAssizePct);

                if (count > 2)
                {
                    return await MySpells.Assize.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> PlenaryIndulgence()
        {
            if (Shinra.Settings.WhiteMagePlenary && Shinra.Settings.WhiteMagePartyHeal && UseAoEHeals)
            {
                var count = Helpers.FriendsNearPlayer(Shinra.Settings.WhiteMagePlenaryPct);

                if (count > 2)
                {
                    return await MySpells.PlenaryIndulgence.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Shinra.Settings.WhiteMageRaise &&
                (Shinra.Settings.WhiteMageSwiftcast && ActionManager.CanCast(MySpells.Role.Swiftcast.Name, Core.Player) ||
                 !Helpers.HealManager.Any(hm => hm.CurrentHealthPercent < Shinra.Settings.WhiteMageCurePct)))
            {
                var target = Helpers.RessManager.FirstOrDefault(pm => !pm.HasAura("Raise"));

                if (target != null)
                {
                    if (Shinra.Settings.WhiteMageSwiftcast && ActionManager.CanCast(MySpells.Raise.Name, target))
                    {
                        if (await MySpells.Role.Swiftcast.Cast(null, false))
                        {
                            await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Role.Swiftcast.Name));
                        }
                    }
                    return await MySpells.Raise.Cast(target);
                }
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> ClericStance()
        {
            if (Shinra.Settings.WhiteMageClericStance)
            {
                return await MySpells.Role.ClericStance.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Shinra.Settings.WhiteMageProtect)
            {
                var target = Shinra.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => !hm.HasAura(MySpells.Role.Protect.Name) && hm.Type == GameObjectType.Pc)
                    : !Core.Player.HasAura(MySpells.Role.Protect.Name) ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Role.Protect.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Esuna()
        {
            if (Shinra.Settings.WhiteMageEsuna)
            {
                var target = Shinra.Settings.WhiteMagePartyHeal ? Helpers.HealManager.FirstOrDefault(hm => hm.HasDispellable())
                    : Core.Player.HasDispellable() ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Role.Esuna.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> LucidDreaming()
        {
            if (Shinra.Settings.WhiteMageLucidDreaming && Core.Player.CurrentManaPercent < Shinra.Settings.WhiteMageLucidDreamingPct)
            {
                return await MySpells.Role.LucidDreaming.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Shinra.Settings.WhiteMagePartyHeal && Shinra.Settings.WhiteMageEyeForAnEye)
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.IsTank() &&
                                                                      hm.CurrentHealthPercent < Shinra.Settings.WhiteMageEyeForAnEyePct &&
                                                                      !hm.HasAura("Eye for an Eye"));

                if (target != null)
                {
                    return await MySpells.Role.EyeForAnEye.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Largesse()
        {
            if (Shinra.Settings.WhiteMagePartyHeal && Shinra.Settings.WhiteMageLargesse)
            {
                if (Helpers.HealManager.Count(hm => hm.CurrentHealthPercent < Shinra.Settings.WhiteMageLargessePct) >=
                    Shinra.Settings.WhiteMageLargesseCount)
                {
                    return await MySpells.Role.Largesse.Cast(null, false);
                }
            }
            return false;
        }

        #endregion

        #region Custom

        private bool StopDamage => Shinra.Settings.WhiteMageStopDamage && !Core.Player.HasAura(MySpells.ThinAir.Name) &&
                                   Core.Player.CurrentManaPercent <= Shinra.Settings.WhiteMageStopDamagePct;

        private bool StopDots => Shinra.Settings.WhiteMageStopDots && !Core.Player.HasAura(MySpells.ThinAir.Name) &&
                                 Core.Player.CurrentManaPercent <= Shinra.Settings.WhiteMageStopDotsPct;

        private bool UseAoEHeals => Shinra.LastSpell.Name != MySpells.Medica.Name && Shinra.LastSpell.Name != MySpells.MedicaII.Name &&
                                    Shinra.LastSpell.Name != MySpells.Assize.Name &&
                                    Shinra.LastSpell.Name != MySpells.PlenaryIndulgence.Name;

        #endregion
    }
}