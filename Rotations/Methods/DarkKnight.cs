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

       

        private async Task<bool> SyphonStrike()
        {
            if (ActionManager.LastSpell.Name == MySpells.HardSlash.Name)
            {
                if (ShinraEx.Settings.TankMode == TankModes.DPS && ActionManager.HasSpell(MySpells.Souleater.Name) ||
                    Core.Player.CurrentManaPercent < 40)
                {
                    return await MySpells.SyphonStrike.Cast();
                }
            }
            return false;
        }


        private async Task<bool> StalwartSoul()
        {
            if (ActionManager.LastSpell.Name == MySpells.Unleash.Name)
            {
                
                    return await MySpells.StalwartSoul.Cast();
                
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

        private async Task<bool> FloodOfDarkness()
        {
            if (Core.Player.ClassLevel >= 74 && Core.Player.CurrentMana > 3500)
            {
                return await MySpells.FloodOfShadow.Cast();
            }

            if (Core.Player.CurrentMana > 3500 && ActionManager.LastSpell.Name != MySpells.FloodOfDarkness.Name)
            {
                return await MySpells.FloodOfDarkness.Cast();
            }
            return false;
        }

        private async Task<bool> EdgeOfDarkness()
        {

            if (Core.Player.ClassLevel >= 74 && Core.Player.CurrentMana > 3500)
            {
                return await MySpells.EdgeOfShadow.Cast();
            }

            //if ()
            {
                return await MySpells.EdgeOfDarkness.Cast();
            }
            //return false;
        }


        private async Task<bool> Unmend()
        {
            if (ActionManager.LastSpell.Name != MySpells.Unmend.Name)    
            {
                return await MySpells.Unmend.Cast();
            }
            return false;
        }

        
        private async Task<bool> Bloodspiller()
        {

            if (  ActionManager.CanCast(MySpells.Delirium.Name, Core.Player) )
            {
                if (await MySpells.Delirium.Cast(null, false))
                {
                    await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Delirium.Name));
                }
            }

            if (ShinraEx.Settings.DarkKnightBloodspiller && BloodValue >= 50 || Core.Player.HasAura(MySpells.Delirium.Name) )
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
            if (Core.Player.CurrentManaPercent > 30 || Core.Player.CurrentHealthPercent < 30)
            {
                          
                return await MySpells.AbyssalDrain.Cast();
            }
            return false;
        }



        private async Task<bool> LivingShadow()
        {
            if (BloodValue >= 50)
            {
               
                return await MySpells.LivingShadow.Cast();
            }
            return false;
        }

        private async Task<bool> Quietus()
        {
            if (ShinraEx.Settings.DarkKnightQuietus && Core.Player.CurrentManaPercent < 70 && BloodValue >= 50)
            {
                var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;

                if (ShinraEx.Settings.DarkKnightQuietusArts && Core.Player.CurrentManaPercent > 40 &&
                    ActionManager.CanCast(MySpells.Delirium.Name, Core.Player) && Helpers.EnemiesNearPlayer(5) >= count)
                {
                    if (await MySpells.Delirium.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Delirium.Name));
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
            if (ShinraEx.Settings.DarkKnightSaltedEarth && !MovementManager.IsMoving)
            {
                return await MySpells.SaltedEarth.Cast();
            }
            return false;
        }

        private async Task<bool> Plunge()
        {
            if (ShinraEx.Settings.DarkKnightPlunge )//&& Core.Player.TargetDistance(10))
            {
                return await MySpells.Plunge.Cast(null, false);
            }
            return false;
        }

        
        private async Task<bool> CarveAndSpit()
        {
            if (ShinraEx.Settings.DarkKnightCarveAndSpit)
            {
               

                if (Core.Player.CurrentManaPercent < 70)
                {
                    return await MySpells.CarveAndSpit.Cast(null, false);
                }
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> BloodWeapon()
        {
            if (ShinraEx.Settings.DarkKnightBloodWeapon)
            {
                return await MySpells.BloodWeapon.Cast();
            }
            return false;
        }

        /*
        private async Task<bool> BloodPrice()
        {
            if (ShinraEx.Settings.DarkKnightBloodPrice && Core.Player.CurrentManaPercent < ShinraEx.Settings.DarkKnightBloodPricePct)
            {
                return await MySpells.BloodPrice.Cast();
            }
            return false;
        }*/

        /*
        private async Task<bool> DarkArts()
        {
            if (!Core.Player.HasAura(MySpells.DarkArts.Name))
            {
                // Bloodspiller
                if (ShinraEx.Settings.DarkKnightBloodspillerArts && Resource.BlackBlood >= 50 && ActionManager.HasSpell(MySpells.Bloodspiller.Name))
                {
                    return await MySpells.DarkArts.Cast();
                }

                if (Core.Player.CurrentManaPercent < 70) return false;

                // Souleater
                if (ShinraEx.Settings.DarkKnightSouleaterArts && ActionManager.LastSpell.Name == MySpells.SyphonStrike.Name)
                {
                    return await MySpells.DarkArts.Cast();
                }
                // Syphon Strike
                if (ShinraEx.Settings.TankMode == TankModes.DPS && ActionManager.LastSpell.Name == MySpells.HardSlash.Name &&
                    Core.Player.CurrentManaPercent > 90)
                {
                    return await MySpells.DarkArts.Cast();
                }
            }
            return false;
        }*/

        private async Task<bool> ShadowWall()
        {
            if (ShinraEx.Settings.DarkKnightShadowWall && Core.Player.CurrentHealthPercent < ShinraEx.Settings.DarkKnightShadowWallPct)
            {
                return await MySpells.ShadowWall.Cast();
            }
            return false;
        }

        private async Task<bool> LivingDead()
        {
            if (ShinraEx.Settings.DarkKnightLivingDead && Core.Player.CurrentHealthPercent < ShinraEx.Settings.DarkKnightLivingDeadPct)
            {
                return await MySpells.LivingDead.Cast(null, false);
            }
            return false;
        }

        
        private async Task<bool> Delirium()
        {
            if (!ShinraEx.Settings.DarkKnightDelirium) return false;

            if (Core.Player.HasAura(MySpells.BloodWeapon.Name) )
            {
                return await MySpells.Delirium.Cast();
            }
            return false;
        }

        private async Task<bool> BlackestNight()
        {
            if (ShinraEx.Settings.DarkKnightBlackestNight && Core.Player.CurrentHealthPercent < ShinraEx.Settings.DarkKnightBlackestNightPct)
            {
                return await MySpells.BlackestNight.Cast();
            }
            return false;
        }

        #endregion

        #region Aura

        private async Task<bool> Grit()
        {
            if (ShinraEx.Settings.DarkKnightGrit && !Core.Player.HasAura(MySpells.Grit.Name))
            {
                return await MySpells.Grit.Cast();
            }
            return false;
        }

        /*
        private async Task<bool> Darkside()
        {
            if (ShinraEx.Settings.DarkKnightDarkside && !Core.Player.HasAura(MySpells.Darkside.Name))
            {
                return await MySpells.Darkside.Cast(null, false);
            }
            return false;
        }*/

        #endregion

        #region Role

        private async Task<bool> Rampart()
        {
            if (ShinraEx.Settings.DarkKnightRampart && Core.Player.CurrentHealthPercent < ShinraEx.Settings.DarkKnightRampartPct)
            {
                return await MySpells.Role.Rampart.Cast();
            }
            return false;
        }

        private async Task<bool> LowBlow()
        {
            if (ShinraEx.Settings.DarkKnightLowBlow && (Core.Player.CurrentTarget.IsInterruptible() || 
                                                        Core.Player.CurrentTarget.IsInterruptibleSpell()))
            {
                return await MySpells.Role.LowBlow.Cast();
            }
            return false;
        }
        
        private async Task<bool> Provoke()
        {
            if (ShinraEx.Settings.DarkKnightProvoke)
            {
                return await MySpells.Role.Provoke.Cast();
            }
            return false;
        }
        
        private async Task<bool> Interject()
        {
            if (ShinraEx.Settings.DarkKnightInterject && (Core.Player.CurrentTarget.IsInterruptible() || 
                                                          Core.Player.CurrentTarget.IsInterruptibleSpell()))
            {
                return await MySpells.Role.Interject.Cast();
            }
            return false;
        }
        
        private async Task<bool> Reprisal()
        {
            if (ShinraEx.Settings.DarkKnightReprisal)
            {
                return await MySpells.Role.Reprisal.Cast();
            }
            return false;
        }

        private async Task<bool> ArmsLength()
        {
            if (ShinraEx.Settings.DarkKnightArmsLength)
            {
                return await MySpells.Role.ArmsLength.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static int BloodValue => Resource.BlackBlood;

        #endregion
    }
}