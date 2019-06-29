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
                return await MySpells.Ruin.Cast();
            }
            return false;
        }

        private async Task<bool> Broil()
        {
            if (!ActionManager.HasSpell(MySpells.BroilII.Name) && !StopDamage)
            {
                return await MySpells.Broil.Cast();
            }
            return false;
        }

        private async Task<bool> BroilII()
        {
            if (!StopDamage)
            {
                return await MySpells.BroilII.Cast();
            }
            return false;
        }

        #endregion

        #region DoT

        private async Task<bool> Bio()
        {
            if (!ActionManager.HasSpell(MySpells.BioII.Name) && !StopDots &&
                !Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 3000))
            {
                return await MySpells.Bio.Cast();
            }
            return false;
        }

        private async Task<bool> BioII()
        {
            if (!StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 3000))
            {
                return await MySpells.BioII.Cast();
            }
            return false;
        }

        private async Task<bool> Miasma()
        {
            if (!StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 4000))
            {
                return await MySpells.Miasma.Cast();
            }
            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> Bane()
        {
            if (Shinra.Settings.RotationMode != Modes.Single && Shinra.Settings.ScholarBane &&
                Core.Player.CurrentTarget.HasAura(BioDebuff, true, 20000) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 14000))
            {
                return await MySpells.Bane.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> MiasmaII()
        {
            if (Shinra.Settings.RotationMode != Modes.Single && !StopDamage &&
                !Core.Player.CurrentTarget.HasAura(MySpells.MiasmaII.Name, true, 3000))
            {
                return await MySpells.MiasmaII.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> EnergyDrain()
        {
            if (Shinra.Settings.ScholarEnergyDrain)
            {
                if (Core.Player.CurrentManaPercent < Shinra.Settings.ScholarEnergyDrainPct && MySpells.Aetherflow.Cooldown() == 0)
                {
                    return await MySpells.EnergyDrain.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> ShadowFlare()
        {
            if (Shinra.Settings.ScholarShadowFlare && !MovementManager.IsMoving)
            {
                return await MySpells.ShadowFlare.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> ChainStrategem()
        {
            if (Shinra.Settings.ScholarChainStrategem)
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

        private async Task<bool> Rouse()
        {
            if (Shinra.Settings.ScholarRouse && Helpers.HealManager.Any(hm => hm.CurrentHealthPercent < 80))
            {
                return await MySpells.Rouse.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Heal

        private async Task<bool> UpdateHealing()
        {
            if (Shinra.Settings.ScholarPartyHeal && !await Helpers.UpdateHealManager())
            {
                return true;
            }
            return false;
        }

        private async Task<bool> StopCasting()
        {
            if (Shinra.Settings.ScholarInterruptOverheal && Core.Player.IsCasting)
            {
                var target = GameObjectManager.GetObjectByObjectId(Core.Player.SpellCastInfo.TargetId);
                var spellName = Core.Player.SpellCastInfo.Name;

                if (target != null)
                {
                    if (spellName == MySpells.Physick.Name && target.CurrentHealthPercent >= Shinra.Settings.ScholarPhysickPct + 10 ||
                        spellName == MySpells.Adloquium.Name && target.CurrentHealthPercent >= Shinra.Settings.ScholarAdloquiumPct + 10)
                    {
                        var debugSetting = spellName == MySpells.Physick.Name ? Shinra.Settings.ScholarPhysickPct
                            : Shinra.Settings.ScholarAdloquiumPct;
                        Helpers.Debug($@"Target HP: {target.CurrentHealthPercent}, Setting: {debugSetting}, Adjusted: {debugSetting + 10}");

                        Logging.Write(Colors.Yellow, $@"[Shinra] Interrupting >>> {spellName}");
                        ActionManager.StopCasting();
                        await Coroutine.Wait(500, () => !Core.Player.IsCasting);
                    }
                }
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Shinra.Settings.ScholarPhysick)
            {
                var target = Shinra.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < Shinra.Settings.ScholarPhysickPct)
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.ScholarPhysickPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Physick.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Adloquium()
        {
            if (Shinra.Settings.ScholarAdloquium)
            {
                var target = Shinra.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < Shinra.Settings.ScholarAdloquiumPct &&
                                                               !hm.HasAura("Galvanize"))
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.ScholarAdloquiumPct && !Core.Player.HasAura("Galvanize")
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
            if (Shinra.Settings.ScholarAetherpact && Resource.FaerieGauge > 30)
            {
                var target = Shinra.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.HasAura("Fey Union") &&
                                                               hm.CurrentHealthPercent < Shinra.Settings.ScholarAetherpactPct)
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.ScholarAetherpactPct && !Core.Player.HasAura("Fey Union")
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
            if (Shinra.Settings.ScholarLustrate)
            {
                var target = Shinra.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < Shinra.Settings.ScholarLustratePct)
                    : Core.Player.CurrentHealthPercent < Shinra.Settings.ScholarLustratePct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Lustrate.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Excogitation()
        {
            if (Shinra.Settings.ScholarExcogitation)
            {
                var target = Shinra.Settings.ScholarPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.IsTank() &&
                                                               hm.CurrentHealthPercent < Shinra.Settings.ScholarExcogitationPct &&
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
            if (Shinra.Settings.ScholarSuccor && Shinra.Settings.ScholarPartyHeal && UseAoEHeals)
            {
                var count = Helpers.FriendsNearPlayer(Shinra.Settings.ScholarSuccorPct);
                var emergencyTactics = Shinra.Settings.ScholarEmergencyTactics &&
                                       ActionManager.CanCast(MySpells.EmergencyTactics.Name, Core.Player);

                if (count > 2 && (emergencyTactics || !Core.Player.HasAura("Galvanize")))
                {
                    if (Shinra.Settings.ScholarEmergencyTactics && ActionManager.CanCast(MySpells.Succor.Name, Core.Player))
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
            if (Shinra.Settings.ScholarIndomitability && Shinra.Settings.ScholarPartyHeal && UseAoEHeals)
            {
                var count = Helpers.FriendsNearPlayer(Shinra.Settings.ScholarIndomitabilityPct);

                if (count > 2)
                {
                    return await MySpells.Indomitability.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> Resurrection()
        {
            if (Shinra.Settings.ScholarResurrection &&
                (Shinra.Settings.ScholarSwiftcast && ActionManager.CanCast(MySpells.Role.Swiftcast.Name, Core.Player) ||
                 !Helpers.HealManager.Any(hm => hm.CurrentHealthPercent < Shinra.Settings.ScholarPhysickPct)))
            {
                var target = Helpers.RessManager.FirstOrDefault(pm => !pm.HasAura("Raise"));

                if (target != null)
                {
                    if (Shinra.Settings.ScholarSwiftcast && ActionManager.CanCast(MySpells.Resurrection.Name, target))
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
            if (Shinra.Settings.ScholarPet == ScholarPets.None || Shinra.Settings.ScholarPet == ScholarPets.Selene &&
                ActionManager.HasSpell(MySpells.SummonII.Name))
            {
                return false;
            }

            if (PetManager.ActivePetType != PetType.Eos)
            {
                if (Shinra.Settings.ScholarSwiftcast && ActionManager.CanCast(MySpells.Summon.Name, Core.Player))
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
            if (Shinra.Settings.ScholarPet == ScholarPets.Selene && PetManager.ActivePetType != PetType.Selene)
            {
                if (Shinra.Settings.ScholarSwiftcast && ActionManager.CanCast(MySpells.SummonII.Name, Core.Player))
                {
                    if (await MySpells.Role.Swiftcast.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Role.Swiftcast.Name));
                    }
                }
                return await MySpells.SummonII.Cast();
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> ClericStance()
        {
            if (Shinra.Settings.ScholarClericStance)
            {
                return await MySpells.Role.ClericStance.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Shinra.Settings.ScholarProtect)
            {
                var target = Shinra.Settings.ScholarPartyHeal
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
            if (Shinra.Settings.ScholarEsuna)
            {
                var target = Shinra.Settings.ScholarPartyHeal ? Helpers.HealManager.FirstOrDefault(hm => hm.HasDispellable())
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
            if (Shinra.Settings.ScholarLucidDreaming && Core.Player.CurrentManaPercent < Shinra.Settings.ScholarLucidDreamingPct)
            {
                return await MySpells.Role.LucidDreaming.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Shinra.Settings.ScholarPartyHeal && Shinra.Settings.ScholarEyeForAnEye)
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.IsTank() &&
                                                                      hm.CurrentHealthPercent < Shinra.Settings.ScholarEyeForAnEyePct &&
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
            if (Shinra.Settings.ScholarPartyHeal && Shinra.Settings.ScholarLargesse)
            {
                if (Helpers.HealManager.Count(hm => hm.CurrentHealthPercent < Shinra.Settings.ScholarLargessePct) >=
                    Shinra.Settings.ScholarLargesseCount)
                {
                    return await MySpells.Role.Largesse.Cast(null, false);
                }
            }
            return false;
        }

        #endregion

        #region Custom

        private static bool StopDamage => Shinra.Settings.ScholarStopDamage && Core.Player.CurrentManaPercent <= Shinra.Settings.ScholarStopDamagePct;
        private static bool StopDots => Shinra.Settings.ScholarStopDots && Core.Player.CurrentManaPercent <= Shinra.Settings.ScholarStopDotsPct;

        private static string BioDebuff => Core.Player.ClassLevel >= 26 ? "Bio II" : "Bio";
        private static bool PetExists => Core.Player.Pet != null;

        private bool UseAoEHeals => Shinra.LastSpell.Name != MySpells.Succor.Name && Shinra.LastSpell.Name != MySpells.Indomitability.Name;

        #endregion
    }
}