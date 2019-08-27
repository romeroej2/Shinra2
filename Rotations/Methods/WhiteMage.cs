using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.WhiteMage;

namespace ShinraCo.Rotations
{
    public sealed partial class WhiteMage
    {
        private WhiteMageSpells MySpells { get; } = new WhiteMageSpells();

        #region Damage

        private async Task<bool> FluidAura()
        {
            if (!StopDamage && !Core.Player.CurrentTarget.IsBoss() && 
                !Core.Player.CurrentTarget.HasAura("Bind", false, 600))
            {
                return await MySpells.FluidAura.Cast();
            }
            return false;
        }
        
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
            if (!ActionManager.HasSpell(MySpells.Glare.Name) && !StopDamage)
            {
                return await MySpells.StoneIV.Cast();
            }
            return false;
        }

        private async Task<bool> Glare()
        {
            if (!StopDamage)
            {
                return await MySpells.Glare.Cast();
            }
            return false;
        }
        
        #endregion

        #region DoT

        private async Task<bool> Aero()
        {
            if (!ActionManager.HasSpell(MySpells.AeroII.Name) && !StopDots &&
                !Core.Player.CurrentTarget.HasAura(143, true, 3000))
            {
                return await MySpells.Aero.Cast();
            }
            return false;
        }

        private async Task<bool> AeroII()
        {
            if (!StopDots && !Core.Player.CurrentTarget.HasAura(144, true, 3000))
            {
                return await MySpells.AeroII.Cast();
            }
            return false;
        }

        private async Task<bool> Dia()
        {
            if (!StopDots && !Core.Player.CurrentTarget.HasAura(1871, true, 3000))
            {
                return await MySpells.Dia.Cast();
            }
            return false;
        }
        
        #endregion

        #region AoE

        private async Task<bool> Holy()
        {
            var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;

            if (!MovementManager.IsMoving && (ShinraEx.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearPlayer(8) >= count))
            {
                if (ShinraEx.Settings.WhiteMageThinAir && ActionManager.CanCast(MySpells.Holy.Name, Core.Player))
                {
                    if (await MySpells.ThinAir.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(1217, true));
                    }
                }
                if (!StopDamage) return await MySpells.Holy.Cast();
            }
            return false;
        }
        
        private async Task<bool> AfflatusMisery()
        {
            var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;
            
            if (ActionResourceManager.WhiteMage.BloodLily >=1 &&  !MovementManager.IsMoving && Helpers.EnemiesNearPlayer(5) >= count )
            {
                if (!StopDamage) return await MySpells.AfflatusMisery.Cast();
            }
            
            return false;
        }



        #endregion

        #region Buff

        private async Task<bool> PresenceOfMind()
        {
            if (ShinraEx.Settings.WhiteMagePartyHeal && ShinraEx.Settings.WhiteMagePresenceOfMind &&
                Helpers.HealManager.Count(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMagePresenceOfMindPct)
                >= ShinraEx.Settings.WhiteMagePresenceOfMindCount)
            { 
                return await MySpells.PresenceOfMind.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Temperance()
        {
            if (ShinraEx.Settings.WhiteMagePartyHeal && ShinraEx.Settings.WhiteMageTemperance &&
                Helpers.HealManager.Count(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageTemperancePct) 
                >= ShinraEx.Settings.WhiteMageTemperanceCount)
            {
                return await MySpells.Temperance.Cast(null, false);
            }
            return false;
        }
        
        #endregion

        #region Heal

        private static async Task<bool> UpdateHealing()
        {
            return ShinraEx.Settings.WhiteMagePartyHeal && !await Helpers.UpdateHealManager();
        }

        private async Task<bool> StopCasting()
        {
            if (ShinraEx.Settings.WhiteMageInterruptOverheal && Core.Player.IsCasting)
            {
                var target = GameObjectManager.GetObjectByObjectId(Core.Player.SpellCastInfo.TargetId);
                var spellName = Core.Player.SpellCastInfo.Name;
                var freeCure = Core.Player.HasAura(155, true) ? ShinraEx.Settings.WhiteMageCurePct : ShinraEx.Settings.WhiteMageCureIIPct;

                UpdateHealing();

                if ( (target != null && Helpers.HealManager.Contains(target)))
                {
                    if ( (spellName == MySpells.Cure.Name && target.CurrentHealthPercent >= ShinraEx.Settings.WhiteMageCurePct + 10)
                                     || (spellName == MySpells.CureII.Name && target.CurrentHealthPercent >= freeCure + 10)
                                     || (spellName == MySpells.Raise.Name && target.HasAura(148)))
                    {

                        Logging.Write(Colors.Yellow, $@"[ShinraEx] freeCurePct {freeCure} -- spell {spellName}");
                        Logging.Write(Colors.Yellow, $@"[ShinraEx] {target.Name} {target.CurrentHealthPercent} >>> {ShinraEx.Settings.WhiteMageCurePct}");

                        var debugSetting = spellName == MySpells.Cure.Name ? ShinraEx.Settings.WhiteMageCurePct
                                : ShinraEx.Settings.WhiteMageCureIIPct;
                        Logging.Write($@"Target HP: {target.CurrentHealthPercent}, Setting: {debugSetting}, Adjusted: {debugSetting + 10}");
                        Logging.Write(Colors.Yellow, $@"[ShinraEx] Interrupting >>> {spellName}");
                        ActionManager.StopCasting();
                        UpdateHealing();
                        await Coroutine.Wait(500, () => !Core.Player.IsCasting);
                    }
                }
            }
            return false;
        }

        private async Task<bool> Cure()
        {
            if (ShinraEx.Settings.WhiteMageCure)
            {
               
                
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCurePct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCurePct ? Core.Player : null;

                if (target != null)
                    Logging.Write($@"Target HP Cure: {target.Name} {target.CurrentHealthPercent} < {ShinraEx.Settings.WhiteMageCurePct} Cure2Aura {Core.Player.HasAura(155, true)}");
                

                if (target != null && ShinraEx.Settings.WhiteMageCureII && Core.Player.HasAura(155, true))
                {
                    
                    return await MySpells.CureII.Cast(target);
                }
                if (target != null)
                {
                    
                    return await MySpells.Cure.Cast(target);
                }
            }
            return false;
        }



        private async Task<bool> DivineBenison()
        {
            if (ShinraEx.Settings.WhiteMageCure)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCureIIPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCureIIPct ? Core.Player : null;

                if (target != null)
                    Logging.Write($@"Target HP DivineBenison: {target.Name} {target.CurrentHealthPercent} < {ShinraEx.Settings.WhiteMageCure}");

                if (target != null)
                {
                    return await MySpells.DivineBenison.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> CureII()
        {
            if (ShinraEx.Settings.WhiteMageCureII)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCureIIPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCureIIPct ? Core.Player : null;

                if (target != null)
                    Logging.Write($@"Target HP Cure2: {target.Name} {target.CurrentHealthPercent} < {ShinraEx.Settings.WhiteMageCureIIPct}");

                if (target != null)
                {
                    return await MySpells.CureII.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> CureIII()
        {
            if (ShinraEx.Settings.WhiteMageCureIII && ShinraEx.Settings.WhiteMagePartyHeal && UseAoEHeals)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCureIIIPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCureIIIPct ? Core.Player : null;

                if (target != null && Helpers.FriendsNearPlayer(ShinraEx.Settings.WhiteMageCureIIIPct) > 2)
                {
                    return await MySpells.CureIII.Cast(target);
                }
            }
            return false;
        }
        
        private async Task<bool> Tetragrammaton()
        {
            if (ShinraEx.Settings.WhiteMageTetragrammaton)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageTetragrammatonPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageTetragrammatonPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Tetragrammaton.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Benediction()
        {
            if (ShinraEx.Settings.WhiteMageBenediction)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageBenedictionPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageBenedictionPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Benediction.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Regen()
        {
            if (ShinraEx.Settings.WhiteMageRegen)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageRegenPct &&
                                                               !hm.HasAura(158, true))
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageRegenPct 
                      && !Core.Player.HasAura(158, true) ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Regen.Cast(target);
                }
            }
            return false;
        }


        private async Task<bool> Asylum()
        {
            if (ShinraEx.Settings.WhiteMageMedica &&
                ShinraEx.Settings.WhiteMagePartyHeal && UseAoEHeals &&
                Helpers.FriendsNearPlayer(ShinraEx.Settings.WhiteMageMedicaPct) > 2)
            {
                return await MySpells.Asylum.Cast();
            }
            return false;
        }

        private async Task<bool> Medica()
        {
            if (ShinraEx.Settings.WhiteMageMedica && 
                ShinraEx.Settings.WhiteMagePartyHeal && UseAoEHeals && 
                Helpers.FriendsNearPlayer(ShinraEx.Settings.WhiteMageMedicaPct) > 2)
            {
                return await MySpells.Medica.Cast();
            }
            return false;
        }

        private async Task<bool> MedicaII()
        {
            if (ShinraEx.Settings.WhiteMageMedicaII && 
                ShinraEx.Settings.WhiteMagePartyHeal && UseAoEHeals &&
                !Core.Player.HasAura(150, true) 
                && Helpers.FriendsNearPlayer(ShinraEx.Settings.WhiteMageMedicaIIPct) > 2)
            {
                return await MySpells.MedicaII.Cast();
            }
            return false;
        }

        private async Task<bool> AfflatusSolace()
        {
            if (ShinraEx.Settings.WhiteMageAfflatusSolace && ShinraEx.Settings.WhiteMagePartyHeal && Resource.Lily >= 1)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageAfflatusSolacePct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageAfflatusSolacePct ? Core.Player : null;
                
                if (target != null)
                {
                    return await MySpells.AfflatusSolace.Cast(target);
                }
            }
            return false;
        }
        
        private async Task<bool> AfflatusRapture()
        {
            if (ShinraEx.Settings.WhiteMageAfflatusRapture && ShinraEx.Settings.WhiteMagePartyHeal && UseAoEHeals &&
                Resource.Lily >= 1)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageAfflatusRapturePct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.WhiteMageAfflatusRapturePct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.AfflatusRapture.Cast(target);
                }
            }
            return false;
        }
        

        
        private async Task<bool> Assize()
        {
            if (ShinraEx.Settings.WhiteMageAssize && 
                ShinraEx.Settings.WhiteMagePartyHeal && UseAoEHeals && 
                Core.Player.CurrentManaPercent <= 75 && 
                Helpers.FriendsNearPlayer(ShinraEx.Settings.WhiteMageAssizePct) > 2)
            { 
                return await MySpells.Assize.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> PlenaryIndulgence()
        {
            if (ShinraEx.Settings.WhiteMagePlenary && ShinraEx.Settings.WhiteMagePartyHeal && UseAoEHeals)
            {
                if (Helpers.FriendsNearPlayer(ShinraEx.Settings.WhiteMagePlenaryPct) > 2)
                {
                    return await MySpells.PlenaryIndulgence.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> Raise()
        {

           

            if (ShinraEx.Settings.WhiteMageRaise &&
                (ShinraEx.Settings.WhiteMageSwiftcast && ActionManager.CanCast(MySpells.Role.Swiftcast.Name, Core.Player) ||
                 !Helpers.HealManager.Any(hm => hm.CurrentHealthPercent < ShinraEx.Settings.WhiteMageCurePct)))
            {

                var target = Helpers.RessManager.FirstOrDefault(pm => !pm.HasAura(148));


                if (target != null || ShinraEx.Settings.WhiteMageSwiftcast && ActionManager.CanCast(MySpells.Raise.Name, target) && Helpers.HealManager.Contains(target))
                {
                    if (await MySpells.Role.Swiftcast.Cast(null, false)) {
                        await Coroutine.Wait(1000, () => Core.Player.HasAura(167, true));
                    }
                }
                if (target != null)
                {
                    return await MySpells.Raise.Cast(target);
                }
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> Esuna()
        {
            if (ShinraEx.Settings.WhiteMageEsuna)
            {
                var target = ShinraEx.Settings.WhiteMagePartyHeal ? Helpers.HealManager.FirstOrDefault(hm => hm.HasDispellable())
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
            if (ShinraEx.Settings.WhiteMageLucidDreaming && Core.Player.CurrentManaPercent < ShinraEx.Settings.WhiteMageLucidDreamingPct)
            {
                return await MySpells.Role.LucidDreaming.Cast(null, false);
            }
            return false;
        }
        
        #endregion

        #region Custom

        private bool StopDamage => ShinraEx.Settings.WhiteMageStopDamage && !Core.Player.HasAura(MySpells.ThinAir.Name) &&
                                   Core.Player.CurrentManaPercent <= ShinraEx.Settings.WhiteMageStopDamagePct;

        private bool StopDots => ShinraEx.Settings.WhiteMageStopDots && !Core.Player.HasAura(MySpells.ThinAir.Name) &&
                                 Core.Player.CurrentManaPercent <= ShinraEx.Settings.WhiteMageStopDotsPct;

        private bool UseAoEHeals => ShinraEx.LastSpell.Name != MySpells.Medica.Name && ShinraEx.LastSpell.Name != MySpells.MedicaII.Name &&
                                    ShinraEx.LastSpell.Name != MySpells.Assize.Name &&
                                    ShinraEx.LastSpell.Name != MySpells.PlenaryIndulgence.Name;

        #endregion
    }
}