using System;
using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Machinist;

namespace ShinraCo.Rotations
{
    public sealed partial class Machinist
    {
        private MachinistSpells MySpells { get; } = new MachinistSpells();

        #region Damage

        private async Task<bool> SplitShot()
        {
            return await MySpells.SplitShot.Cast();
        }

        private async Task<bool> SlugShot()
        {
            if (ShinraEx.Settings.MachinistSyncWildfire && !Core.Player.HasAura("Cleaner Shot") && WildfireCooldown <= 8000)
            {
                return await MySpells.SlugShot.Cast();
            }
            if (Core.Player.HasAura("Enhanced Slug Shot") && (!ShinraEx.Settings.MachinistSyncWildfire ||
                                                              Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true) ||
                                                              WildfireCooldown > 8000))
            {
                return await MySpells.SlugShot.Cast();
            }
            return false;
        }

        private async Task<bool> CleanShot()
        {
            if (Core.Player.HasAura("Cleaner Shot") && (!ShinraEx.Settings.MachinistSyncWildfire ||
                                                        Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true) ||
                                                        WildfireCooldown > 8000))
            {
                return await MySpells.CleanShot.Cast();
            }
            return false;
        }

        private async Task<bool> HotShot()
        {
            if (!Core.Player.HasAura(MySpells.HotShot.Name, true, 6000) ||
                !Core.Player.HasAura(MySpells.HotShot.Name, true, 55000) && Resource.Heat == 0 &&
                Resource.Timer < TimeSpan.FromMilliseconds(3000))
            {
                return await MySpells.HotShot.Cast();
            }
            return false;
        }

        private async Task<bool> Cooldown()
        {
            if (!ShinraEx.Settings.MachinistCooldown) return false;

            if (Overheated && !Core.Player.HasAura("Enhanced Slug Shot") && !Core.Player.HasAura("Cleaner Shot") && Resource.Ammo < 2)
                return await MySpells.Cooldown.Cast();

            if (Overheated || Resource.Heat < 95 || Resource.Ammo > 0) return false;

            if (!ActionManager.CanCast(MySpells.BarrelStabilizer.Name, Core.Player) || !UseWildfire || WildfireCooldown > 3000)
                return await MySpells.Cooldown.Cast();

            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> SpreadShot()
        {
            if (Core.Player.CurrentTPPercent > 40)
            {
                if (ShinraEx.Settings.RotationMode == Modes.Multi || ShinraEx.Settings.RotationMode == Modes.Smart &&
                    Helpers.EnemiesNearTarget(5) >= AoECount)
                {
                    return await MySpells.SpreadShot.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> Heartbreak()
        {
            return await MySpells.Heartbreak.Cast();
        }

        private async Task<bool> Wildfire()
        {
            if (UseWildfire && (!ShinraEx.Settings.MachinistSyncOverheat || Overheated))
            {
                return await MySpells.Wildfire.Cast();
            }
            return false;
        }

        private async Task<bool> GaussRound()
        {
            if (!ShinraEx.Settings.MachinistSyncWildfire || MySpells.Wildfire.Cooldown() > 15000)
            {
                return await MySpells.GaussRound.Cast();
            }
            return false;
        }

        private async Task<bool> Ricochet()
        {
            if (ShinraEx.Settings.MachinistRicochet)
            {
                if (!ShinraEx.Settings.MachinistSyncWildfire || Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true))
                {
                    return await MySpells.Ricochet.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Flamethrower()
        {
            if (ShinraEx.Settings.MachinistFlamethrower && Resource.Heat < 100 && !MovementManager.IsMoving)
            {
                if (BarrelCooldown < 30000 && UseWildfire && WildfireCooldown < 3000 || UseFlamethrower)
                {
                    if (await MySpells.Flamethrower.Cast())
                    {
                        return await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Flamethrower.Name));
                    }
                }
            }
            return false;
        }

        private async Task<bool> FlamethrowerBuff()
        {
            if (Core.Player.HasAura(MySpells.Flamethrower.Name) &&
                (!ShinraEx.Settings.MachinistFlamethrower || Resource.Heat < 100 || UseFlamethrower))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> Reload()
        {
            if (!ShinraEx.Settings.MachinistReload || ShinraEx.LastSpell.Name == MySpells.QuickReload.Name || Resource.Ammo > 0)
                return false;

            return await MySpells.Reload.Cast();
        }

        private async Task<bool> Reassemble()
        {
            if (ShinraEx.Settings.MachinistReassemble)
            {
                if (!ShinraEx.Settings.MachinistSyncWildfire || Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true))
                {
                    if (Core.Player.HasAura("Cleaner Shot") && ShinraEx.LastSpell.Name != MySpells.CleanShot.Name ||
                        !ActionManager.HasSpell(MySpells.CleanShot.Name) && Core.Player.HasAura("Enhanced Slug Shot") &&
                        ShinraEx.LastSpell.Name != MySpells.SlugShot.Name)
                    {
                        return await MySpells.Reassemble.Cast();
                    }
                }
            }
            return false;
        }

        private async Task<bool> QuickReload()
        {
            if (ShinraEx.LastSpell.Name == MySpells.Reload.Name || Resource.Ammo == 3) return false;

            return await MySpells.QuickReload.Cast();
        }

        private async Task<bool> QuickReloadPre()
        {
            if (Resource.Ammo < 2 && ShinraEx.LastSpell.Name != MySpells.HotShot.Name && ShinraEx.LastSpell.Name != MySpells.GaussRound.Name)
            {
                return await MySpells.QuickReload.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> RapidFire()
        {
            if (ShinraEx.Settings.MachinistRapidFire)
            {
                if (!ShinraEx.Settings.MachinistSyncWildfire || Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true))
                {
                    return await MySpells.RapidFire.Cast();
                }
            }
            return false;
        }

        private async Task<bool> GaussBarrel()
        {
            if (ShinraEx.Settings.MachinistGaussBarrel && !Resource.GaussBarrel)
            {
                return await MySpells.GaussBarrel.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Hypercharge()
        {
            if (ShinraEx.Settings.MachinistHypercharge && TurretExists)
            {
                return await MySpells.Hypercharge.Cast();
            }
            return false;
        }

        private async Task<bool> BarrelStabilizer()
        {
            if (ShinraEx.Settings.MachinistBarrelStabilizer)
            {
                if (Resource.Heat < 30 && (!ShinraEx.Settings.MachinistFlamethrower || !ActionManager.HasSpell(MySpells.Flamethrower.Name) ||
                                           FlamethrowerCooldown > 3000))
                {
                    return await MySpells.BarrelStabilizer.Cast();
                }
            }
            return false;
        }

        private async Task<bool> RookOverdrive()
        {
            if (ShinraEx.Settings.MachinistRookOverdrive && TurretExists && PetManager.ActivePetType == PetType.Rook_Autoturret)
            {
                if (Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true) &&
                    !Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true, 4000))
                {
                    return await MySpells.RookOverdrive.Cast();
                }
            }
            return false;
        }

        private async Task<bool> BishopOverdrive()
        {
            if (ShinraEx.Settings.MachinistBishopOverdrive && TurretExists && PetManager.ActivePetType == PetType.Bishop_Autoturret)
            {
                if (Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true) &&
                    !Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true, 4000))
                {
                    return await MySpells.BishopOverdrive.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Turret

        private async Task<bool> RookAutoturret()
        {
            if (ShinraEx.Settings.MachinistTurret == MachinistTurrets.Rook || ShinraEx.Settings.MachinistTurret == MachinistTurrets.Bishop &&
                !ActionManager.HasSpell(MySpells.BishopAutoturret.Name))
            {
                if (!Core.Player.HasAura("Turret Reset"))
                {
                    if (PetManager.ActivePetType != PetType.Rook_Autoturret || TurretDistance > 23)
                    {
                        var castLocation = ShinraEx.Settings.MachinistTurretLocation == CastLocations.Self ? Core.Player
                            : Core.Player.CurrentTarget;

                        return await MySpells.RookAutoturret.Cast(castLocation);
                    }
                }
            }
            return false;
        }

        private async Task<bool> BishopAutoturret()
        {
            if (ShinraEx.Settings.MachinistTurret == MachinistTurrets.Bishop)
            {
                if (!Core.Player.HasAura("Turret Reset"))
                {
                    if (PetManager.ActivePetType != PetType.Bishop_Autoturret || TurretDistance > 23)
                    {
                        var castLocation = ShinraEx.Settings.MachinistTurretLocation == CastLocations.Self ? Core.Player
                            : Core.Player.CurrentTarget;

                        return await MySpells.BishopAutoturret.Cast(castLocation);
                    }
                }
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (ShinraEx.Settings.MachinistSecondWind && Core.Player.CurrentHealthPercent < ShinraEx.Settings.MachinistSecondWindPct)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Peloton()
        {
            if (ShinraEx.Settings.MachinistPeloton && !Core.Player.HasAura(MySpells.Role.Peloton.Name) && !Core.Player.HasTarget &&
                (MovementManager.IsMoving || BotManager.Current.EnglishName == "DeepDive"))
            {
                return await MySpells.Role.Peloton.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (ShinraEx.Settings.MachinistInvigorate && Core.Player.CurrentTPPercent < ShinraEx.Settings.MachinistInvigoratePct)
            {
                return await MySpells.Role.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> Tactician()
        {
            if (ShinraEx.Settings.MachinistTactician)
            {
                var target = Core.Player.CurrentTPPercent < ShinraEx.Settings.MachinistTacticianPct ? Core.Player
                    : Helpers.GoadManager.FirstOrDefault(gm => gm.CurrentTPPercent < ShinraEx.Settings.MachinistTacticianPct);

                if (target != null)
                {
                    return await MySpells.Role.Tactician.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Refresh()
        {
            if (ShinraEx.Settings.MachinistRefresh)
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.CurrentManaPercent < ShinraEx.Settings.MachinistRefreshPct &&
                                                                      hm.IsHealer());

                if (target != null)
                {
                    return await MySpells.Role.Refresh.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Palisade()
        {
            if (ShinraEx.Settings.MachinistPalisade)
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.MachinistPalisadePct &&
                                                                      hm.IsTank());

                if (target != null)
                {
                    return await MySpells.Role.Palisade.Cast(target);
                }
            }
            return false;
        }

        #endregion

        #region Custom

        private static int AoECount => ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;
        private static double FlamethrowerCooldown => DataManager.GetSpellData(7418).Cooldown.TotalMilliseconds;
        private static double WildfireCooldown => DataManager.GetSpellData(2878).Cooldown.TotalMilliseconds;
        private static double BarrelCooldown => DataManager.GetSpellData(7414).Cooldown.TotalMilliseconds;
        private static bool Overheated => Resource.Heat == 100 && Resource.Timer.TotalMilliseconds > 0;
        private static bool UseFlamethrower => ShinraEx.Settings.RotationMode == Modes.Multi ||
                                               ShinraEx.Settings.RotationMode == Modes.Smart && Helpers.EnemiesNearTarget(5) >= AoECount;

        private static bool UseWildfire => ShinraEx.Settings.MachinistWildfire &&
                                           (Core.Player.CurrentTarget.IsBoss() ||
                                            Core.Player.CurrentTarget.CurrentHealth > ShinraEx.Settings.MachinistWildfireHP);

        private static bool TurretExists => Core.Player.Pet != null;
        private static float TurretDistance => TurretExists && Core.Player.HasTarget && Core.Player.CurrentTarget.CanAttack
            ? Core.Player.Pet.Distance2D(Core.Player.CurrentTarget) - Core.Player.CurrentTarget.CombatReach : 0;

        #endregion
    }
}