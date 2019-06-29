using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Summoner;
using ResourceArcanist = ff14bot.Managers.ActionResourceManager.Arcanist;

namespace ShinraCo.Rotations
{
    public sealed partial class Summoner
    {
        private SummonerSpells MySpells { get; } = new SummonerSpells();

        #region Damage

        private async Task<bool> Ruin()
        {
            if (!ActionManager.HasSpell(MySpells.RuinIII.Name))
            {
                return await MySpells.Ruin.Cast();
            }
            return false;
        }

        private async Task<bool> RuinII()
        {
            if (Resource.DreadwyrmTrance && !Core.Player.HasAura("Further Ruin") && !RecentBahamut)
                return false;

            if (MovementManager.IsMoving ||
                Core.Player.HasAura("Further Ruin") ||
                RecentBahamut ||
                UseBane ||
                UseFester ||
                UsePainflare ||
                UseAddle ||
                UsePet ||
                UseShadowFlare ||
                UseTriDisaster ||
                ResourceArcanist.Aetherflow == 0 && MySpells.Aetherflow.Cooldown() <= 0 ||
                ResourceArcanist.Aetherflow == 3 && ActionManager.CanCast(MySpells.SummonBahamut.Name, Core.Player) ||
                ActionManager.CanCast(MySpells.DreadwyrmTrance.Name, Core.Player))
            {
                return await MySpells.RuinII.Cast();
            }
            return false;
        }

        private async Task<bool> RuinIII()
        {
            return await MySpells.RuinIII.Cast();
        }

        #endregion

        #region DoT

        private async Task<bool> Bio()
        {
            if (!ActionManager.HasSpell(MySpells.BioII.Name) && !Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 3000))
            {
                return await MySpells.Bio.Cast();
            }
            return false;
        }

        private async Task<bool> BioII()
        {
            if (!ActionManager.HasSpell(MySpells.BioIII.Name) && !RecentDoT &&
                !Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 3000))
            {
                if (!ActionManager.HasSpell(MySpells.TriDisaster.Name) || MySpells.TriDisaster.Cooldown() > 5000)
                {
                    return await MySpells.BioII.Cast();
                }
            }
            return false;
        }

        private async Task<bool> BioIII()
        {
            if (RecentDoT ||
                Core.Player.CurrentTarget.HasAura(MySpells.BioIII.Name, true, 3000) ||
                RecentBahamut ||
                MySpells.TriDisaster.Cooldown() < 5000)
            {
                return false;
            }

            return await MySpells.BioIII.Cast();
        }

        private async Task<bool> Miasma()
        {
            if (!ActionManager.HasSpell(MySpells.MiasmaIII.Name) && !RecentDoT &&
                !Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 5000))
            {
                if (!ActionManager.HasSpell(MySpells.TriDisaster.Name) || MySpells.TriDisaster.Cooldown() > 5000)
                {
                    return await MySpells.Miasma.Cast();
                }
            }
            return false;
        }

        private async Task<bool> MiasmaIII()
        {
            if (RecentDoT ||
                Core.Player.CurrentTarget.HasAura(MySpells.MiasmaIII.Name, true, 5000) ||
                RecentBahamut ||
                MySpells.TriDisaster.Cooldown() < 5000)
            {
                return false;
            }

            return await MySpells.MiasmaIII.Cast();
        }

        #endregion

        #region AoE

        private async Task<bool> Bane()
        {
            if (UseBane)
            {
                return await MySpells.Bane.Cast();
            }
            return false;
        }

        private async Task<bool> Painflare()
        {
            if (UsePainflare)
            {
                return await MySpells.Painflare.Cast();
            }
            return false;
        }

        private async Task<bool> TriBind()
        {
            if (Shinra.Settings.RotationMode == Modes.Single || Resource.DreadwyrmTrance && Resource.Timer.TotalMilliseconds < 3500)
                return false;

            if (Shinra.Settings.RotationMode == Modes.Multi ||
                Resource.DreadwyrmTrance && Helpers.EnemiesNearTarget(5) >= 2 ||
                Helpers.EnemiesNearTarget(5) >= 5)
            {
                return await MySpells.TriBind.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> EnergyDrain()
        {
            if (!ActionManager.HasSpell(MySpells.Fester.Name) && !AetherLow)
            {
                return await MySpells.EnergyDrain.Cast();
            }
            return false;
        }

        private async Task<bool> Fester()
        {
            if (UseFester)
            {
                return await MySpells.Fester.Cast();
            }
            return false;
        }

        private async Task<bool> ShadowFlare()
        {
            if (UseShadowFlare)
            {
                return await MySpells.ShadowFlare.Cast();
            }
            return false;
        }

        private async Task<bool> Enkindle()
        {
            if (Shinra.Settings.SummonerEnkindle && PetExists)
            {
                return await MySpells.Enkindle.Cast();
            }
            return false;
        }

        private async Task<bool> TriDisaster()
        {
            if (!UseTriDisaster) return false;

            return await MySpells.TriDisaster.Cast();
        }

        private async Task<bool> Deathflare()
        {
            if (Resource.DreadwyrmTrance && Resource.Timer.TotalMilliseconds < 2000)
            {
                return await MySpells.Deathflare.Cast();
            }
            return false;
        }

        private async Task<bool> EnkindleBahamut()
        {
            if (Shinra.Settings.SummonerEnkindleBahamut)
            {
                return await MySpells.EnkindleBahamut.Cast();
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> Aetherflow()
        {
            if (ResourceArcanist.Aetherflow > 0) return false;

            return await MySpells.Aetherflow.Cast();
        }

        private async Task<bool> AetherflowPreCombat()
        {
            if (ResourceArcanist.Aetherflow == 0 || Shinra.Settings.SummonerOpener && ResourceArcanist.Aetherflow < 3)
            {
                return await MySpells.Aetherflow.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Rouse()
        {
            if (Shinra.Settings.SummonerRouse && PetExists)
            {
                return await MySpells.Rouse.Cast();
            }
            return false;
        }

        private async Task<bool> DreadwyrmTrance()
        {
            if (Shinra.Settings.SummonerDreadwyrmTrance)
            {
                return await MySpells.DreadwyrmTrance.Cast();
            }
            return false;
        }

        private async Task<bool> Aetherpact()
        {
            if (Shinra.Settings.SummonerAetherpact && PetExists)
            {
                return await MySpells.Aetherpact.Cast();
            }
            return false;
        }

        private async Task<bool> SummonBahamut()
        {
            if (Shinra.Settings.SummonerSummonBahamut && ResourceArcanist.Aetherflow == 3)
            {
                if (await MySpells.SummonBahamut.Cast())
                {
                    Spell.RecentSpell.Add("Summon Bahamut", DateTime.UtcNow + TimeSpan.FromMilliseconds(22000));
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Heal

        private async Task<bool> UpdateHealing()
        {
            if (Shinra.Settings.SummonerResurrection && Shinra.Settings.SummonerSwiftcast)
            {
                if (!await Helpers.UpdateHealManager())
                {
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Shinra.Settings.SummonerPhysick && Core.Player.CurrentHealthPercent < Shinra.Settings.SummonerPhysickPct)
            {
                var target = Core.Player;

                if (target != null)
                {
                    return await MySpells.Physick.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Sustain()
        {
            if (Shinra.Settings.SummonerSustain && PetExists)
            {
                if (Core.Player.Pet.CurrentHealthPercent < Shinra.Settings.SummonerSustainPct &&
                    !Core.Player.Pet.HasAura(MySpells.Sustain.Name))
                {
                    return await MySpells.Sustain.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Resurrection()
        {
            if (Shinra.Settings.SummonerResurrection && Shinra.Settings.SummonerSwiftcast && Core.Player.CurrentManaPercent > 50 &&
                ActionManager.CanCast(MySpells.Role.Swiftcast.Name, Core.Player))
            {
                var target = Helpers.RessManager.FirstOrDefault(pm => !pm.HasAura("Raise"));

                if (target != null)
                {
                    if (await MySpells.Role.Swiftcast.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Role.Swiftcast.Name));
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
            if (!Shinra.Settings.SummonerOpener || !Shinra.Settings.SummonerOpenerGaruda || Helpers.OpenerFinished)
            {
                if (Shinra.Settings.SummonerPet == SummonerPets.None ||
                    Shinra.Settings.SummonerPet == SummonerPets.Titan && ActionManager.HasSpell(MySpells.SummonII.Name) ||
                    Shinra.Settings.SummonerPet == SummonerPets.Ifrit && ActionManager.HasSpell(MySpells.SummonIII.Name))
                {
                    return false;
                }
            }

            if (PetManager.ActivePetType != PetType.Emerald_Carbuncle && PetManager.ActivePetType != PetType.Garuda_Egi && !RecentBahamut)
            {
                if (Shinra.Settings.SummonerSwiftcast && !Shinra.Settings.SummonerResurrection &&
                    ActionManager.CanCast(MySpells.Summon.Name, Core.Player) &&
                    (!Shinra.Settings.SummonerOpener || !Shinra.Settings.SummonerOpenerGaruda || Helpers.OpenerFinished))
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
            if (Shinra.Settings.SummonerOpener && Shinra.Settings.SummonerOpenerGaruda && !Helpers.OpenerFinished)
            {
                return false;
            }

            if (Shinra.Settings.SummonerPet == SummonerPets.Titan && PetManager.ActivePetType != PetType.Topaz_Carbuncle &&
                PetManager.ActivePetType != PetType.Titan_Egi && !RecentBahamut)
            {
                if (Shinra.Settings.SummonerSwiftcast && !Shinra.Settings.SummonerResurrection &&
                    ActionManager.CanCast(MySpells.SummonII.Name, Core.Player))
                {
                    if (await MySpells.Role.Swiftcast.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => ActionManager.CanCast(MySpells.SummonII.Name, Core.Player));
                    }
                }
                return await MySpells.SummonII.Cast();
            }
            return false;
        }

        private async Task<bool> SummonIII()
        {
            if (Shinra.Settings.SummonerOpener && Shinra.Settings.SummonerOpenerGaruda && !Helpers.OpenerFinished)
            {
                return false;
            }

            if (Shinra.Settings.SummonerPet == SummonerPets.Ifrit && PetManager.ActivePetType != PetType.Ifrit_Egi && !RecentBahamut)
            {
                if (Shinra.Settings.SummonerSwiftcast && !Shinra.Settings.SummonerResurrection &&
                    ActionManager.CanCast(MySpells.SummonIII.Name, Core.Player))
                {
                    if (await MySpells.Role.Swiftcast.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => ActionManager.CanCast(MySpells.SummonIII.Name, Core.Player));
                    }
                }
                return await MySpells.SummonIII.Cast();
            }
            return false;
        }

        private async Task<bool> Sic()
        {
            if (PetManager.ActivePetType == PetType.Ifrit_Egi && PetManager.PetMode != PetMode.Sic)
            {
                if (await Coroutine.Wait(1000, () => PetManager.DoAction("Sic", Core.Player)))
                {
                    Logging.Write(Colors.GreenYellow, @"[Shinra] Casting >>> Sic");
                    return await Coroutine.Wait(3000, () => PetManager.PetMode == PetMode.Sic);
                }
            }
            return false;
        }

        private async Task<bool> Obey()
        {
            if (PetManager.ActivePetType == PetType.Garuda_Egi && PetManager.PetMode != PetMode.Obey)
            {
                if (await Coroutine.Wait(1000, () => PetManager.DoAction("Obey", Core.Player)))
                {
                    Logging.Write(Colors.GreenYellow, @"[Shinra] Casting >>> Obey");
                    return await Coroutine.Wait(3000, () => PetManager.PetMode == PetMode.Obey);
                }
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> Addle()
        {
            if (UseAddle)
            {
                return await MySpells.Role.Addle.Cast();
            }
            return false;
        }

        private async Task<bool> Drain()
        {
            if (Shinra.Settings.SummonerDrain && Core.Player.CurrentHealthPercent < Shinra.Settings.SummonerDrainPct)
            {
                return await MySpells.Role.Drain.Cast();
            }
            return false;
        }

        private async Task<bool> LucidDreaming()
        {
            if (Shinra.Settings.SummonerLucidDreaming && Core.Player.CurrentManaPercent < Shinra.Settings.SummonerLucidDreamingPct)
            {
                return await MySpells.Role.LucidDreaming.Cast();
            }
            return false;
        }

        #endregion

        #region PVP

        private async Task<bool> RuinIIIPVP()
        {
            return await MySpells.PVP.RuinIII.Cast();
        }

        private async Task<bool> BioIIIPVP()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.PVP.BioIII.Name, true, 3000))
            {
                return await MySpells.PVP.BioIII.Cast();
            }
            return false;
        }

        private async Task<bool> MiasmaIIIPVP()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.PVP.MiasmaIII.Name, true, 4000))
            {
                return await MySpells.PVP.MiasmaIII.Cast();
            }
            return false;
        }

        private async Task<bool> WitherPVP()
        {
            if (Core.Player.CurrentTarget.HasAura(MySpells.PVP.BioIII.Name, true) &&
                Core.Player.CurrentTarget.HasAura(MySpells.PVP.MiasmaIII.Name, true))
            {
                if (!Core.Player.CurrentTarget.HasAura(MySpells.PVP.BioIII.Name, true, 5000) ||
                    !Core.Player.CurrentTarget.HasAura(MySpells.PVP.MiasmaIII.Name, true, 5000))
                {
                    return await MySpells.PVP.Wither.Cast();
                }
            }
            return false;
        }

        private async Task<bool> AetherflowPVP()
        {
            if (ResourceArcanist.Aetherflow == 0)
            {
                return await MySpells.PVP.Aetherflow.Cast();
            }
            return false;
        }

        private async Task<bool> EnergyDrainPVP()
        {
            if (Core.Player.CurrentMana < 3000)
            {
                return await MySpells.PVP.EnergyDrain.Cast();
            }
            return false;
        }

        private async Task<bool> FesterPVP()
        {
            if (Core.Player.CurrentTarget.HasAura(MySpells.PVP.BioIII.Name, true) &&
                Core.Player.CurrentTarget.HasAura(MySpells.PVP.MiasmaIII.Name, true))
            {
                return await MySpells.PVP.Fester.Cast();
            }
            return false;
        }

        private async Task<bool> DreadwyrmTrancePVP()
        {
            return await MySpells.PVP.DreadwyrmTrance.Cast();
        }

        private async Task<bool> SummonBahamutPVP()
        {
            if (ResourceArcanist.Aetherflow > 0)
            {
                return await MySpells.PVP.SummonBahamut.Cast();
            }
            return false;
        }

        private async Task<bool> DeathflarePVP()
        {
            if (Resource.DreadwyrmTrance && Resource.Timer.TotalMilliseconds < 2000)
            {
                return await MySpells.PVP.Deathflare.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> EnkindleBahamutPVP()
        {
            return await MySpells.PVP.EnkindleBahamut.Cast();
        }

        #endregion

        #region Custom

        private static int AoECount => Shinra.Settings.CustomAoE ? Shinra.Settings.CustomAoECount : 2;
        private static string BioDebuff => Core.Player.ClassLevel >= 66 ? "Bio III" : Core.Player.ClassLevel >= 26 ? "Bio II" : "Bio";
        private static string MiasmaDebuff => Core.Player.ClassLevel >= 66 ? "Miasma III" : "Miasma";
        private static bool RecentDoT { get { return Spell.RecentSpell.Keys.Any(key => key.Contains("Tri-disaster")); } }
        private static bool RecentBahamut => Spell.RecentSpell.ContainsKey("Summon Bahamut") || (int)PetManager.ActivePetType == 10;
        private static bool PetExists => Core.Player.Pet != null;

        private static bool UseTriDisaster => Shinra.Settings.SummonerTriDisaster &&
                                              (!Core.Player.CurrentTarget.HasAura(BioDebuff, true, 3000) ||
                                               !Core.Player.CurrentTarget.HasAura(MiasmaDebuff, true, 3000));

        private bool AetherLow => !ActionManager.HasSpell(MySpells.DreadwyrmTrance.Name) && ResourceArcanist.Aetherflow == 1 &&
                                  DataManager.GetSpellData(166).Cooldown.TotalMilliseconds > 8000;

        private bool UseBane => Shinra.Settings.RotationMode != Modes.Single && Shinra.Settings.SummonerBane &&
                                ActionManager.CanCast(MySpells.Bane.Name, Core.Player.CurrentTarget) &&
                                (Shinra.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(5) >= AoECount) &&
                                Core.Player.CurrentTarget.HasAura(BioDebuff, true, 20000) &&
                                Core.Player.CurrentTarget.HasAura(MiasmaDebuff, true, 14000);

        private bool UseFester => (Shinra.Settings.RotationMode == Modes.Single ||
                                   Shinra.Settings.RotationMode == Modes.Smart && Helpers.EnemiesNearTarget(5) < AoECount) &&
                                  ActionManager.CanCast(MySpells.Fester.Name, Core.Player.CurrentTarget) && !AetherLow &&
                                  Core.Player.CurrentTarget.HasAura(BioDebuff, true) &&
                                  Core.Player.CurrentTarget.HasAura(MiasmaDebuff, true);

        private bool UsePainflare => Shinra.Settings.RotationMode != Modes.Single &&
                                     (Shinra.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(5) >= AoECount) &&
                                     ActionManager.CanCast(MySpells.Painflare.Name, Core.Player.CurrentTarget) && !AetherLow;

        private bool UsePet => PetExists && (Shinra.Settings.SummonerRouse && ActionManager.CanCast(MySpells.Rouse.Name, Core.Player) ||
                                             Shinra.Settings.SummonerEnkindle &&
                                             ActionManager.CanCast(MySpells.Enkindle.Name, Core.Player.CurrentTarget));

        private bool UseShadowFlare => Shinra.Settings.SummonerShadowFlare && !MovementManager.IsMoving &&
                                       ActionManager.CanCastLocation(MySpells.ShadowFlare.Name, Core.Player.CurrentTarget.Location);

        private bool UseAddle => Shinra.Settings.SummonerAddle && RecentBahamut &&
                                 ActionManager.CanCast(MySpells.Role.Addle.Name, Core.Player.CurrentTarget);

        #endregion
    }
}