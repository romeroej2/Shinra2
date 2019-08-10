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
            if (CurrentForm.Equals(SummonerForm.DreadwormTrance)|| CurrentForm.Equals(SummonerForm.FirebirdTrance))
                return false;
            

            if (MovementManager.IsMoving ||
                //Core.Player.HasAura("Further Ruin") ||
                UseBane ||
                UseFester ||
                UsePainflare ||
                UseTriDisaster || 
                (CurrentForm.Equals(SummonerForm.Bahamut) && Resource.Timer.TotalMilliseconds <= 5000)  || //Maximize primal attacks
                (ResourceArcanist.Aetherflow == 0 && MySpells.EnergyDrain.Cooldown() <= 0) ||
                ActionManager.CanCast(MySpells.EnkindleBahamut.Name, Core.Player) ||
                ActionManager.CanCast(MySpells.EnkindlePhoenix.Name, Core.Player) ||
                ActionManager.CanCast(MySpells.SummonBahamut.Name, Core.Player) ||
                ActionManager.CanCast(MySpells.DreadwyrmTrance.Name, Core.Player) ||
                ActionManager.CanCast(MySpells.FirebirdTrance.Name, Core.Player)                )
            {
                return await MySpells.RuinII.Cast();
            }
            return false;
        }

        private async Task<bool> RuinIII()
        {
            return await MySpells.RuinIII.Cast();
        }

        private async Task<bool> FountainOfFire()
        {
            if (CurrentForm.Equals(SummonerForm.FirebirdTrance))
            {
                return await MySpells.BrandOfPurgatory.Cast();
            }
            return false;
        }

        private async Task<bool> BrandOfPurgatory()
        {
            if (Core.Player.HasAura("Hellish Conduit") && Resource.DreadwyrmTrance)
            {
                CurrentForm = SummonerForm.FirebirdTrance;
                return await MySpells.BrandOfPurgatory.Cast();
            }
            return false;
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
            if (!ActionManager.HasSpell(MySpells.MiasmaIII.Name) &&
                !RecentDoT &&
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

        private async Task<bool> Outburst()
        {
            if (ShinraEx.Settings.RotationMode == Modes.Single || (Resource.DreadwyrmTrance && Resource.Timer.TotalMilliseconds < 3500))
                return false;

            if (ShinraEx.Settings.RotationMode == Modes.Multi ||
                (Resource.DreadwyrmTrance && Helpers.EnemiesNearTarget(5) >= 3) ||
                Helpers.EnemiesNearTarget(5) >= 3)
            {
                return await MySpells.Outburst.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> EnergyDrain()
        {
            if (ResourceArcanist.Aetherflow == 0)
            {
                return await MySpells.EnergyDrain.Cast();
            }
            return false;
        }

        private async Task<bool> EnergySiphon()
        {
            if (ShinraEx.Settings.RotationMode != Modes.Single && ResourceArcanist.Aetherflow == 0 && Helpers.EnemiesNearTarget(5) >= 3)
            {
                return await MySpells.EnergySiphon.Cast();
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

        private async Task<bool> Enkindle()
        {
            if (ShinraEx.Settings.SummonerEnkindle && PetExists)
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
            if (Resource.DreadwyrmTrance && Resource.Timer.TotalMilliseconds < 2500)
            {
                return await MySpells.Deathflare.Cast();
            }
            return false;
        }

        private async Task<bool> EnkindleBahamut()
        {
            if (ShinraEx.Settings.SummonerEnkindleBahamut)
            {
                return await MySpells.EnkindleBahamut.Cast();
            }
            return false;
        }
        private async Task<bool> EnkindlePhoenix()
        {
            return await MySpells.EnkindlePhoenix.Cast();
        }

        #endregion

        #region Buff

        private async Task<bool> DreadwyrmTrance()
        {
            if (ShinraEx.Settings.SummonerDreadwyrmTrance && !PreviousTrance.Equals(SummonerForm.DreadwormTrance))
            {
                if (await MySpells.DreadwyrmTrance.Cast())
                {
                    CurrentForm = PreviousTrance = SummonerForm.DreadwormTrance;
                    SetCurrentFormTimer(TimeSpan.FromSeconds(15));
                    return true;
                }
            }
            return false;
        }
        private async Task<bool> FirebirdTrance()
        {
            if (ShinraEx.Settings.SummonerDreadwyrmTrance && !PreviousTrance.Equals(SummonerForm.FirebirdTrance))
            {
                if (await MySpells.FirebirdTrance.Cast())
                {
                    CurrentForm = PreviousTrance = SummonerForm.FirebirdTrance;
                    SetCurrentFormTimer(TimeSpan.FromSeconds(20));
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> Aetherpact()
        {
            if (ShinraEx.Settings.SummonerAetherpact && PetExists)
            {
                return await MySpells.Aetherpact.Cast();
            }
            return false;
        }

        private async Task<bool> SummonBahamut()
        {
            if (ShinraEx.Settings.SummonerSummonBahamut)
            {
                if (await MySpells.SummonBahamut.Cast())
                {
                    Spell.RecentSpell.Add("Summon Bahamut", DateTime.UtcNow + TimeSpan.FromMilliseconds(22000));
                    SetCurrentFormTimer(TimeSpan.FromSeconds(20));
                    CurrentForm = SummonerForm.Bahamut;
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> EgiAssault()
        {
            if (PetExists && 
                (!CurrentForm.Equals(SummonerForm.Bahamut) || !CurrentForm.Equals(SummonerForm.FirebirdTrance)) && 
                ActionManager.CanCast(MySpells.EgiAssault.Name, Core.Player) && 
                (ActionManager.LastSpell.Name == "Ruin II" || ActionManager.LastSpell.Name == "Ruin IV"))
            {
                return await MySpells.EgiAssault.Cast();
            }
            return false;
        }

        private async Task<bool> EgiAssaultII()
        {
            if (PetExists &&
                (!CurrentForm.Equals(SummonerForm.Bahamut) || !CurrentForm.Equals(SummonerForm.FirebirdTrance)) &&
                ActionManager.CanCast(MySpells.EgiAssaultII.Name, Core.Player) && 
                (ActionManager.LastSpell.Name == "Ruin II" || ActionManager.LastSpell.Name == "Ruin IV"))
            {
                return await MySpells.EgiAssaultII.Cast();
            }
            return false;
        }
        #endregion

        #region Heal

        private async Task<bool> UpdateHealing()
        {
            if (ShinraEx.Settings.SummonerResurrection && ShinraEx.Settings.SummonerSwiftcast)
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
            if (ShinraEx.Settings.SummonerPhysick && Core.Player.CurrentHealthPercent < ShinraEx.Settings.SummonerPhysickPct)
            {
                var target = Core.Player;

                if (target != null)
                {
                    return await MySpells.Physick.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Resurrection()
        {
            if (ShinraEx.Settings.SummonerResurrection && ShinraEx.Settings.SummonerSwiftcast && Core.Player.CurrentManaPercent > 50 &&
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
            if (!ShinraEx.Settings.SummonerOpener || !ShinraEx.Settings.SummonerOpenerGaruda || Helpers.OpenerFinished)
            {
                if (ShinraEx.Settings.SummonerPet == SummonerPets.None ||
                    ShinraEx.Settings.SummonerPet == SummonerPets.Titan && ActionManager.HasSpell(MySpells.SummonII.Name) ||
                    ShinraEx.Settings.SummonerPet == SummonerPets.Ifrit && ActionManager.HasSpell(MySpells.SummonIII.Name))
                {
                    return false;
                }
            }

            if (PetManager.ActivePetType != PetType.Emerald_Carbuncle && PetManager.ActivePetType != PetType.Garuda_Egi && !RecentBahamut)
            {
                return await MySpells.Summon.Cast();
            }
            return false;
        }

        private async Task<bool> SummonII()
        {
            if (ShinraEx.Settings.SummonerOpener && ShinraEx.Settings.SummonerOpenerGaruda && !Helpers.OpenerFinished)
            {
                return false;
            }

            if (ShinraEx.Settings.SummonerPet == SummonerPets.Titan && PetManager.ActivePetType != PetType.Topaz_Carbuncle &&
                PetManager.ActivePetType != PetType.Titan_Egi && !RecentBahamut)
            {

                return await MySpells.SummonII.Cast();
            }
            return false;
        }

        private async Task<bool> SummonIII()
        {
            if (ShinraEx.Settings.SummonerOpener && ShinraEx.Settings.SummonerOpenerGaruda && !Helpers.OpenerFinished)
            {
                return false;
            }

            if (ShinraEx.Settings.SummonerPet == SummonerPets.Ifrit && PetManager.ActivePetType != PetType.Ifrit_Egi && !RecentBahamut)
            {
                return await MySpells.SummonIII.Cast();
            }
            return false;
        }

        private async Task<bool> Sic()
        {
            if (PetManager.PetMode != PetMode.Sic)
            {
                if (await Coroutine.Wait(1000, () => PetManager.DoAction("Sic", Core.Player)))
                {
                    Logging.Write(Colors.GreenYellow, @"[ShinraEx] Casting >>> Sic");
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
                    Logging.Write(Colors.GreenYellow, @"[ShinraEx] Casting >>> Obey");
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
            if (ShinraEx.Settings.SummonerDrain && Core.Player.CurrentHealthPercent < ShinraEx.Settings.SummonerDrainPct)
            {
                return await MySpells.Role.Drain.Cast();
            }
            return false;
        }

        private async Task<bool> LucidDreaming()
        {
            if (ShinraEx.Settings.SummonerLucidDreaming && Core.Player.CurrentManaPercent < ShinraEx.Settings.SummonerLucidDreamingPct)
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

        public enum SummonerForm : byte
        {
            Normal = 0,
            DreadwormTrance = 1,
            Bahamut = 2,
            FirebirdTrance = 3
        }

        public static SummonerForm PreviousTrance { get; set; }
        public static SummonerForm CurrentForm { get; set; }
        public static DateTime CurrentFormExpireTime { get; set; }

        private void CheckCurrentFormState()
        {

            Helpers.Debug("Form:  " +CurrentForm.ToString());

            if (!PreviousTrance.Equals(SummonerForm.FirebirdTrance) && Core.Player.HasAura("Everlasting Flight"))
                PreviousTrance = SummonerForm.FirebirdTrance;

            if (!CurrentForm.Equals(SummonerForm.Normal) && IsCurrentFormExpired() && (!ShinraEx.Settings.SummonerOpener || Helpers.OpenerFinished))
            {
                Helpers.Debug("Set form to Normal");
                CurrentForm = SummonerForm.Normal;
            }
        }

        private void SetCurrentFormTimer(TimeSpan duration)
        {
            CurrentFormExpireTime = DateTime.UtcNow + duration;
        }

        public bool IsCurrentFormExpired()
        {
            return DateTime.UtcNow > CurrentFormExpireTime;
        }

        private static int AoECount => ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 2;
        private static string BioDebuff => Core.Player.ClassLevel >= 66 ? "Bio III" : Core.Player.ClassLevel >= 26 ? "Bio II" : "Bio";
        private static string MiasmaDebuff => Core.Player.ClassLevel >= 66 ? "Miasma III" : "Miasma";
        private static bool RecentDoT { get { return Spell.RecentSpell.Keys.Any(key => key.Contains("Tri-disaster")); } }
        private static bool RecentBahamut => Spell.RecentSpell.ContainsKey("Summon Bahamut"); //|| (int)PetManager.ActivePetType == 10;
        private static bool PetExists => Core.Player.Pet != null;

        private  bool UseTriDisaster => ShinraEx.Settings.SummonerTriDisaster &&
                                              (!Core.Player.CurrentTarget.HasAura(BioDebuff, true, 3000) ||
                                               !Core.Player.CurrentTarget.HasAura(MiasmaDebuff, true, 3000) ||
                                                (MySpells.DreadwyrmTrance.Cooldown()  < 10) || MySpells.FirebirdTrance.Cooldown() < 10);

        private bool AetherLow => ResourceArcanist.Aetherflow == 1 &&
                                    DataManager.GetSpellData(166).Cooldown.TotalMilliseconds > 8000;

        private bool UseBane => ShinraEx.Settings.RotationMode != Modes.Single &&
                                ShinraEx.Settings.SummonerBane &&
                                ActionManager.CanCast(MySpells.Bane.Name, Core.Player.CurrentTarget) &&
                                (ShinraEx.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(8) >= AoECount) &&
                                Core.Player.CurrentTarget.HasAura(BioDebuff, true, 17000) &&
                                Core.Player.CurrentTarget.HasAura(MiasmaDebuff, true, 17000);

        private bool UseFester => (ShinraEx.Settings.RotationMode == Modes.Single ||
                                   ShinraEx.Settings.RotationMode == Modes.Smart &&
                                   Helpers.EnemiesNearTarget(5) < AoECount) &&
                                  ActionManager.CanCast(MySpells.Fester.Name, Core.Player.CurrentTarget) &&
                                  Core.Player.CurrentTarget.HasAura(BioDebuff, true) &&
                                  Core.Player.CurrentTarget.HasAura(MiasmaDebuff, true);

        private bool UsePainflare => ShinraEx.Settings.RotationMode != Modes.Single &&
                                     (ShinraEx.Settings.RotationMode == Modes.Multi ||
                                        Helpers.EnemiesNearTarget(5) >= AoECount) &&
                                     ActionManager.CanCast(MySpells.Painflare.Name, Core.Player.CurrentTarget);

        private bool UseAddle => ShinraEx.Settings.SummonerAddle &&
            ActionManager.CanCast(MySpells.Role.Addle.Name, Core.Player.CurrentTarget);

        #endregion
    }
}