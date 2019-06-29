using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.DarkKnight;

namespace ShinraCo.Rotations
{
    public sealed partial class DarkKnight
    {
        private DarkKnightSpells MySpells { get; } = new DarkKnightSpells();

        #region Damage

        private async Task<bool> HardSlash()
        {
            return await MySpells.HardSlash.Cast();
        }

        private async Task<bool> SpinningSlash()
        {
            if (ActionManager.LastSpell.Name == MySpells.HardSlash.Name)
            {
                return await MySpells.SpinningSlash.Cast();
            }
            return false;
        }

        private async Task<bool> PowerSlash()
        {
            if (ActionManager.LastSpell.Name == MySpells.SpinningSlash.Name)
            {
                return await MySpells.PowerSlash.Cast();
            }
            return false;
        }

        private async Task<bool> SyphonStrike()
        {
            if (ActionManager.LastSpell.Name == MySpells.HardSlash.Name)
            {
                if (Shinra.Settings.TankMode == TankModes.DPS && ActionManager.HasSpell(MySpells.Souleater.Name) ||
                    Core.Player.CurrentManaPercent < 40)
                {
                    return await MySpells.SyphonStrike.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Souleater()
        {
            if (ActionManager.LastSpell.Name == MySpells.SyphonStrike.Name)
            {
                return await MySpells.Souleater.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodspiller()
        {
            if (Shinra.Settings.DarkKnightBloodspiller && BloodValue >= 50 && Core.Player.HasAura(MySpells.DarkArts.Name))
            {
                return await MySpells.Bloodspiller.Cast();
            }
            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> Unleash()
        {
            if (Core.Player.CurrentManaPercent > 30)
            {
                return await MySpells.Unleash.Cast();
            }
            return false;
        }

        private async Task<bool> AbyssalDrain()
        {
            if (Core.Player.CurrentManaPercent > 30)
            {
                var count = Shinra.Settings.CustomAoE ? Shinra.Settings.CustomAoECount : 3;

                if (Shinra.Settings.DarkKnightAbyssalArts && Core.Player.CurrentHealthPercent < 70 && Core.Player.CurrentManaPercent > 60 &&
                    ActionManager.CanCast(MySpells.AbyssalDrain.Name, Core.Player.CurrentTarget) && Helpers.EnemiesNearTarget(5) >= count)
                {
                    if (await MySpells.DarkArts.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.DarkArts.Name));
                    }
                }
                return await MySpells.AbyssalDrain.Cast();
            }
            return false;
        }

        private async Task<bool> Quietus()
        {
            if (Shinra.Settings.DarkKnightQuietus && Core.Player.CurrentManaPercent < 70 && BloodValue >= 50)
            {
                var count = Shinra.Settings.CustomAoE ? Shinra.Settings.CustomAoECount : 3;

                if (Shinra.Settings.DarkKnightQuietusArts && Core.Player.CurrentManaPercent > 40 &&
                    ActionManager.CanCast(MySpells.Quietus.Name, Core.Player) && Helpers.EnemiesNearPlayer(5) >= count)
                {
                    if (await MySpells.DarkArts.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.DarkArts.Name));
                    }
                }
                return await MySpells.Quietus.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> SaltedEarth()
        {
            if (Shinra.Settings.DarkKnightSaltedEarth && !MovementManager.IsMoving)
            {
                return await MySpells.SaltedEarth.Cast();
            }
            return false;
        }

        private async Task<bool> Plunge()
        {
            if (Shinra.Settings.DarkKnightPlunge && Core.Player.TargetDistance(10))
            {
                return await MySpells.Plunge.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> CarveAndSpit()
        {
            if (Shinra.Settings.DarkKnightCarveAndSpit)
            {
                if (Shinra.Settings.DarkKnightCarveArts && ActionManager.CanCast(MySpells.CarveAndSpit.Name, Core.Player.CurrentTarget))
                {
                    if (await MySpells.DarkArts.Cast())
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.DarkArts.Name));
                    }
                }

                if (Core.Player.HasAura(MySpells.DarkArts.Name) || Core.Player.CurrentManaPercent < 30 ||
                    !Shinra.Settings.DarkKnightCarveArts && Core.Player.CurrentManaPercent < 70)
                {
                    return await MySpells.CarveAndSpit.Cast(null, !Core.Player.HasAura(MySpells.DarkArts.Name));
                }
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> BloodWeapon()
        {
            if (Shinra.Settings.DarkKnightBloodWeapon)
            {
                return await MySpells.BloodWeapon.Cast();
            }
            return false;
        }

        private async Task<bool> BloodPrice()
        {
            if (Shinra.Settings.DarkKnightBloodPrice && Core.Player.CurrentManaPercent < Shinra.Settings.DarkKnightBloodPricePct)
            {
                return await MySpells.BloodPrice.Cast();
            }
            return false;
        }

        private async Task<bool> DarkArts()
        {
            if (!Core.Player.HasAura(MySpells.DarkArts.Name))
            {
                // Bloodspiller
                if (Shinra.Settings.DarkKnightBloodspillerArts && Resource.BlackBlood >= 50 && ActionManager.HasSpell(MySpells.Bloodspiller.Name))
                {
                    return await MySpells.DarkArts.Cast();
                }

                if (Core.Player.CurrentManaPercent < 70) return false;

                // Souleater
                if (Shinra.Settings.DarkKnightSouleaterArts && ActionManager.LastSpell.Name == MySpells.SyphonStrike.Name)
                {
                    return await MySpells.DarkArts.Cast();
                }
                // Syphon Strike
                if (Shinra.Settings.TankMode == TankModes.DPS && ActionManager.LastSpell.Name == MySpells.HardSlash.Name &&
                    Core.Player.CurrentManaPercent > 90)
                {
                    return await MySpells.DarkArts.Cast();
                }
            }
            return false;
        }

        private async Task<bool> ShadowWall()
        {
            if (Shinra.Settings.DarkKnightShadowWall && Core.Player.CurrentHealthPercent < Shinra.Settings.DarkKnightShadowWallPct)
            {
                return await MySpells.ShadowWall.Cast();
            }
            return false;
        }

        private async Task<bool> LivingDead()
        {
            if (Shinra.Settings.DarkKnightLivingDead && Core.Player.CurrentHealthPercent < Shinra.Settings.DarkKnightLivingDeadPct)
            {
                return await MySpells.LivingDead.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Delirium()
        {
            if (!Shinra.Settings.DarkKnightDelirium) return false;

            if (Core.Player.HasAura(MySpells.BloodWeapon.Name) || Core.Player.HasAura(MySpells.BloodPrice.Name))
            {
                return await MySpells.Delirium.Cast();
            }
            return false;
        }

        private async Task<bool> BlackestNight()
        {
            if (Shinra.Settings.DarkKnightBlackestNight && Core.Player.CurrentHealthPercent < Shinra.Settings.DarkKnightBlackestNightPct)
            {
                return await MySpells.BlackestNight.Cast();
            }
            return false;
        }

        #endregion

        #region Aura

        private async Task<bool> Grit()
        {
            if (Shinra.Settings.DarkKnightGrit && !Core.Player.HasAura(MySpells.Grit.Name))
            {
                return await MySpells.Grit.Cast();
            }
            return false;
        }

        private async Task<bool> Darkside()
        {
            if (Shinra.Settings.DarkKnightDarkside && !Core.Player.HasAura(MySpells.Darkside.Name))
            {
                return await MySpells.Darkside.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> Rampart()
        {
            if (Shinra.Settings.DarkKnightRampart && Core.Player.CurrentHealthPercent < Shinra.Settings.DarkKnightRampartPct)
            {
                return await MySpells.Role.Rampart.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Shinra.Settings.DarkKnightConvalescence && Core.Player.CurrentHealthPercent < Shinra.Settings.DarkKnightConvalescencePct)
            {
                return await MySpells.Role.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Anticipation()
        {
            if (Shinra.Settings.DarkKnightAnticipation && Core.Player.CurrentHealthPercent < Shinra.Settings.DarkKnightAnticipationPct)
            {
                return await MySpells.Role.Anticipation.Cast();
            }
            return false;
        }

        private async Task<bool> Reprisal()
        {
            if (Shinra.Settings.DarkKnightReprisal)
            {
                return await MySpells.Role.Reprisal.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Shinra.Settings.DarkKnightAwareness && Core.Player.CurrentHealthPercent < Shinra.Settings.DarkKnightAwarenessPct)
            {
                return await MySpells.Role.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static int BloodValue => Resource.BlackBlood;

        #endregion
    }
}