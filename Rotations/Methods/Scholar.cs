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
using Resource = ff14bot.Managers.ActionResourceManager.Scholar;
using ResourceArcanist = ff14bot.Managers.ActionResourceManager.Arcanist;

namespace ShinraCo.Rotations
{
    public sealed partial class Scholar
    {
        private ScholarSpells MySpells { get; } = new ScholarSpells();

        #region Damage

        private async Task<bool> Ruin()
        {
            if (!ActionManager.HasSpell(MySpells.Broil.Name) && !StopDamage)
            {
				// Logging.Write(Colors.Pink, @"[ShinraEx] Ruin Cast...");
                return await MySpells.Ruin.Cast();
            }
            return false;
        }

        private async Task<bool> Broil()
        {
            if (!ActionManager.HasSpell(MySpells.BroilII.Name) && !StopDamage)
            {
				// Logging.Write(Colors.Pink, @"[ShinraEx] BroilII Cast...");
                return await MySpells.Broil.Cast();
            }
            return false;
        }

        private async Task<bool> BroilII()
        {
            if (!ActionManager.HasSpell(MySpells.BroilIII.Name) && !StopDamage)
            {
				// Logging.Write(Colors.Pink, @"[ShinraEx] BroilII Cast...");
                return await MySpells.BroilII.Cast();
            }
            return false;
        }
		
        private async Task<bool> BroilIII()
        {
            if (!StopDamage)
            {
				// Logging.Write(Colors.Pink, @"[ShinraEx] BroilIII Cast...");
                return await MySpells.BroilIII.Cast();
            }
            return false;
        }

        #endregion

        #region DoT

        private async Task<bool> Bio()
        {
            if (!ActionManager.HasSpell(MySpells.BioII.Name) && !StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 3000))
            {
				// Logging.Write(Colors.Pink, @"[ShinraEx] Bio Cast...");
                return await MySpells.Bio.Cast();
            }
            return false;
        }

        private async Task<bool> BioII()
        {
            if (!ActionManager.HasSpell(MySpells.Biolysis.Name) && !StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.Biolysis.Name, true, 3000))
            {
				// Logging.Write(Colors.Pink, @"[ShinraEx] BioII Cast...");
                return await MySpells.BioII.Cast();
            }
            return false;
        }

        private async Task<bool> Biolysis()
        {
            if (!StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.Biolysis.Name, true, 3000))
            {
				// Logging.Write(Colors.Pink, @"[ShinraEx] Biolysis Cast...");
                return await MySpells.Biolysis.Cast();
            }
            return false;
        }
        // private async Task<bool> Miasma()
        // {
            // if (!StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 4000))
            // {
                // return await MySpells.Miasma.Cast();
            // }
            // return false;
        // }

        #endregion

        #region AoE

        // private async Task<bool> Bane()
        // {
            // if (ShinraEx.Settings.RotationMode != Modes.Single && ShinraEx.Settings.ScholarBane &&
                // Core.Player.CurrentTarget.HasAura(BioDebuff, true, 20000) &&
                // Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 14000))
            // {
                // return await MySpells.Bane.Cast(null, false);
            // }
            // return false;
        // }

        // private async Task<bool> MiasmaII()
        // {
            // if (ShinraEx.Settings.RotationMode != Modes.Single && !StopDamage &&
                // !Core.Player.CurrentTarget.HasAura(MySpells.MiasmaII.Name, true, 3000))
            // {
                // return await MySpells.MiasmaII.Cast();
            // }
            // return false;
        // }

        #endregion

        #region Cooldown

        private async Task<bool> EnergyDrain()
        {
            if (ShinraEx.Settings.ScholarEnergyDrain)
            {
                if (Core.Player.CurrentManaPercent < ShinraEx.Settings.ScholarEnergyDrainPct && MySpells.Aetherflow.Cooldown() == 0)
                {
                    return await MySpells.EnergyDrain.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> ChainStrategem()
        {
            if (ShinraEx.Settings.ScholarChainStrategem)
            {
                return await MySpells.ChainStrategem.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> Aetherflow()
        {
            if (ResourceArcanist.Aetherflow == 0)
            {
                return await MySpells.Aetherflow.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Heal

        private async Task<bool> UpdateHealing()
        {
            if (ShinraEx.Settings.ScholarPartyHeal && !await Helpers.UpdateHealManager())
            {
                return true;
            }
            return false;
        }

        private async Task<bool> StopCasting()
        {
            if (ShinraEx.Settings.ScholarInterruptOverheal && Core.Player.IsCasting)
            {
                var target = GameObjectManager.GetObjectByObjectId(Core.Player.SpellCastInfo.TargetId);
                var spellName = Core.Player.SpellCastInfo.Name;

                if (target != null)
                {
                    if (spellName == MySpells.Physick.Name && target.CurrentHealthPercent >= ShinraEx.Settings.ScholarPhysickPct + 10 ||
                        spellName == MySpells.Adloquium.Name && target.CurrentHealthPercent >= ShinraEx.Settings.ScholarAdloquiumPct + 10)
                    {
                        var debugSetting = spellName == MySpells.Physick.Name ? ShinraEx.Settings.ScholarPhysickPct
                            : ShinraEx.Settings.ScholarAdloquiumPct;
                        Helpers.Debug($@"Target HP: {target.CurrentHealthPercent}, Setting: {debugSetting}, Adjusted: {debugSetting + 10}");

                        Logging.Write(Colors.Yellow, $@"[ShinraEx] Interrupting >>> {spellName}");
                        ActionManager.StopCasting();
                        await Coroutine.Wait(500, () => !Core.Player.IsCasting);
                    }
                }
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (ShinraEx.Settings.ScholarPhysick)
            {
                var target = ShinraEx.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.ScholarPhysickPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.ScholarPhysickPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Physick.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Adloquium()
        {
            if (ShinraEx.Settings.ScholarAdloquium)
            {
                var target = ShinraEx.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.ScholarAdloquiumPct &&
                                                               !hm.HasAura("Galvanize"))
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.ScholarAdloquiumPct && !Core.Player.HasAura("Galvanize")
                        ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Adloquium.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Aetherpact()
        {
            if (ShinraEx.Settings.ScholarAetherpact && Resource.FaerieGauge > 30)
            {
                var target = ShinraEx.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.HasAura("Fey Union") &&
                                                               hm.CurrentHealthPercent < ShinraEx.Settings.ScholarAetherpactPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.ScholarAetherpactPct && !Core.Player.HasAura("Fey Union")
                        ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Aetherpact.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Lustrate()
        {
            if (ShinraEx.Settings.ScholarLustrate)
            {
                var target = ShinraEx.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.ScholarLustratePct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.ScholarLustratePct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Lustrate.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Excogitation()
        {
            if (ShinraEx.Settings.ScholarExcogitation)
            {
                var target = ShinraEx.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.IsTank() &&
                                                               hm.CurrentHealthPercent < ShinraEx.Settings.ScholarExcogitationPct &&
                                                               !hm.HasAura(MySpells.Excogitation.Name, true)) : null;

                if (target != null)
                {
                    return await MySpells.Excogitation.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Succor()
        {
            if (ShinraEx.Settings.ScholarSuccor && ShinraEx.Settings.ScholarPartyHeal && UseAoEHeals)
            {
                var count = Helpers.FriendsNearPlayer(ShinraEx.Settings.ScholarSuccorPct);
                var emergencyTactics = ShinraEx.Settings.ScholarEmergencyTactics &&
                                       ActionManager.CanCast(MySpells.EmergencyTactics.Name, Core.Player);

                if (count > 2 && (emergencyTactics || !Core.Player.HasAura("Galvanize")))
                {
                    if (ShinraEx.Settings.ScholarEmergencyTactics && ActionManager.CanCast(MySpells.Succor.Name, Core.Player))
                    {
                        if (await MySpells.EmergencyTactics.Cast(null, false))
                        {
                            await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.EmergencyTactics.Name));
                        }
                    }
                    return await MySpells.Succor.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Indomitability()
        {
            if (ShinraEx.Settings.ScholarIndomitability && ShinraEx.Settings.ScholarPartyHeal && UseAoEHeals)
            {
                var count = Helpers.FriendsNearPlayer(ShinraEx.Settings.ScholarIndomitabilityPct);

                if (count > 2)
                {
                    return await MySpells.Indomitability.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> Resurrection()
        {
            if (ShinraEx.Settings.ScholarResurrection &&
                (ShinraEx.Settings.ScholarSwiftcast && ActionManager.CanCast(MySpells.Role.Swiftcast.Name, Core.Player) ||
                 !Helpers.HealManager.Any(hm => hm.CurrentHealthPercent < ShinraEx.Settings.ScholarPhysickPct)))
            {
                var target = Helpers.RessManager.FirstOrDefault(pm => !pm.HasAura("Raise"));

                if (target != null)
                {
                    if (ShinraEx.Settings.ScholarSwiftcast && ActionManager.CanCast(MySpells.Resurrection.Name, target))
                    {
                        if (await MySpells.Role.Swiftcast.Cast(null, false))
                        {
                            await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Role.Swiftcast.Name));
                        }
                    }
                    return await MySpells.Resurrection.Cast(target);
                }
            }
            return false;
        }

        #endregion

        #region Pet

        private async Task<bool> Summon()
        {
            if (ShinraEx.Settings.ScholarPet == ScholarPets.None || ShinraEx.Settings.ScholarPet == ScholarPets.Selene &&
                ActionManager.HasSpell(MySpells.SummonII.Name))
            {
                return false;
            }

            if (PetManager.ActivePetType != PetType.Eos)
            {
                if (ShinraEx.Settings.ScholarSwiftcast && ActionManager.CanCast(MySpells.Summon.Name, Core.Player))
                {
                    if (await MySpells.Role.Swiftcast.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Role.Swiftcast.Name));
                    }
                }
                return await MySpells.Summon.Cast();
            }
            return false;
        }

        private async Task<bool> SummonII()
        {
            if (ShinraEx.Settings.ScholarPet == ScholarPets.Selene && PetManager.ActivePetType != PetType.Selene)
            {
                if (ShinraEx.Settings.ScholarSwiftcast && ActionManager.CanCast(MySpells.SummonII.Name, Core.Player))
                {
                    if (await MySpells.Role.Swiftcast.Cast(null, false))
                    {
                        await Coroutine.Wait(1000, () => Core.Player.HasAura(MySpells.Role.Swiftcast.Name));
                    }
                }
                return await MySpells.SummonII.Cast();
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> Esuna()
        {
            if (ShinraEx.Settings.ScholarEsuna)
            {
                var target = ShinraEx.Settings.ScholarPartyHeal ? Helpers.HealManager.FirstOrDefault(hm => hm.HasDispellable())
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
            if (ShinraEx.Settings.ScholarLucidDreaming && Core.Player.CurrentManaPercent < ShinraEx.Settings.ScholarLucidDreamingPct)
            {
                return await MySpells.Role.LucidDreaming.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Custom

        private static bool StopDamage => ShinraEx.Settings.ScholarStopDamage && Core.Player.CurrentManaPercent <= ShinraEx.Settings.ScholarStopDamagePct;
        private static bool StopDots => ShinraEx.Settings.ScholarStopDots && Core.Player.CurrentManaPercent <= ShinraEx.Settings.ScholarStopDotsPct;

        private static string BioDebuff => Core.Player.ClassLevel >= 26 ? "Bio II" : "Bio";
        private static bool PetExists => Core.Player.Pet != null;

        private bool UseAoEHeals => ShinraEx.LastSpell.Name != MySpells.Succor.Name && ShinraEx.LastSpell.Name != MySpells.Indomitability.Name;

        #endregion
    }
}