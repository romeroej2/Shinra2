using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Ninja;

namespace ShinraCo.Rotations
{
    public sealed partial class Ninja
    {
        private NinjaSpells MySpells { get; } = new NinjaSpells();

        #region Damage

        private async Task<bool> SpinningEdge()
        {
            return await MySpells.SpinningEdge.Cast();
        }

        private async Task<bool> GustSlash()
        {
            if (ActionManager.LastSpell.Name == MySpells.SpinningEdge.Name)
            {
                return await MySpells.GustSlash.Cast();
            }
            return false;
        }

        private async Task<bool> AeolianEdge()
        {
            if (ActionManager.LastSpell.Name != MySpells.GustSlash.Name) return false;

            return await MySpells.AeolianEdge.Cast();
        }

        private async Task<bool> ArmorCrush()
        {
            if (ActionManager.LastSpell.Name != MySpells.GustSlash.Name || !UseArmorCrush) return false;

            return await MySpells.ArmorCrush.Cast();
        }

        private async Task<bool> DualityActive()
        {
            if (ShinraEx.LastSpell.Name != MySpells.Duality.Name && !Core.Player.HasAura(MySpells.Duality.Name))
                return false;

            return await MySpells.AeolianEdge.Cast();
        }

        #endregion

        #region DoT

        private async Task<bool> ShadowFang()
        {
            if (ActionManager.LastSpell.Name != MySpells.GustSlash.Name || !UseShadowFang) return false;

            return await MySpells.ShadowFang.Cast();
        }

        #endregion

        #region AoE

        private async Task<bool> DeathBlossom()
        {
            if (Core.Player.CurrentTPPercent > 40)
            {
                return await MySpells.DeathBlossom.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> Assassinate()
        {
            if (ShinraEx.Settings.NinjaAssassinate && UseOffGCD)
            {
                return await MySpells.Assassinate.Cast();
            }
            return false;
        }

        private async Task<bool> Mug()
        {
            if (ShinraEx.Settings.NinjaMug && UseOffGCD)
            {
                if (Resource.NinkiGauge <= 70 || Core.Player.ClassLevel < 66)
                {
                    return await MySpells.Mug.Cast();
                }
            }
            return false;
        }

        private async Task<bool> TrickAttack()
        {
            if (ShinraEx.Settings.NinjaTrickAttack && UseOffGCD && !Core.Player.CurrentTarget.HasAura(638, false, 3000))
            {
                if (Core.Player.CurrentTarget.IsBehind || BotManager.Current.IsAutonomous ||
                    Core.Player.HasAura(MySpells.Role.TrueNorth.Name) || Core.Player.HasAura(MySpells.Suiton.Name, false, 100) &&
                    !Core.Player.HasAura(MySpells.Suiton.Name, false, 4000))
                {
                    return await MySpells.TrickAttack.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Jugulate()
        {
            if (ShinraEx.Settings.NinjaJugulate && UseOffGCD)
            {
                return await MySpells.Jugulate.Cast();
            }
            return false;
        }

        private async Task<bool> Shukuchi()
        {
            if (ShinraEx.Settings.NinjaShukuchi && Core.Player.TargetDistance(10))
            {
                return await MySpells.Shukuchi.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> DreamWithinADream()
        {
            if (ShinraEx.Settings.NinjaDreamWithin && UseOffGCD && TrickAttackActive)
            {
                return await MySpells.DreamWithinADream.Cast();
            }
            return false;
        }

        private async Task<bool> HellfrogMedium()
        {
            if (ShinraEx.Settings.NinjaHellfrogMedium && UseOffGCD)
            {
                if (ShinraEx.Settings.RotationMode == Modes.Multi || !ActionManager.HasSpell(MySpells.Bhavacakra.Name) || UseHellfrog ||
                    ShinraEx.Settings.RotationMode == Modes.Smart && Helpers.EnemiesNearTarget(6) >= AoECount)
                {
                    return await MySpells.HellfrogMedium.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Bhavacakra()
        {
            if (ShinraEx.Settings.NinjaBhavacakra && UseOffGCD)
            {
                if (ShinraEx.Settings.RotationMode == Modes.Single || ShinraEx.Settings.RotationMode == Modes.Smart &&
                    Helpers.EnemiesNearTarget(6) < AoECount)
                {
                    return await MySpells.Bhavacakra.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> ShadeShift()
        {
            if (ShinraEx.Settings.NinjaShadeShift && Core.Player.CurrentHealthPercent < ShinraEx.Settings.NinjaShadeShiftPct)
            {
                return await MySpells.ShadeShift.Cast();
            }
            return false;
        }

        private async Task<bool> Kassatsu()
        {
            if (ShinraEx.Settings.NinjaKassatsu && UseOffGCD)
            {
                if (TrickAttackActive || ShinraEx.Settings.RotationMode == Modes.Multi || TrickCooldown > 30000 ||
                    ShinraEx.Settings.RotationMode == Modes.Smart && Helpers.EnemiesNearTarget(5) >= AoECount)
                {
                    return await MySpells.Kassatsu.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Duality()
        {
            if (!ShinraEx.Settings.NinjaDuality || ShinraEx.LastSpell.Name != MySpells.GustSlash.Name || UseArmorCrush || UseShadowFang)
                return false;

            return await MySpells.Duality.Cast();
        }

        private async Task<bool> TenChiJin()
        {
            if (ShinraEx.Settings.NinjaTenChiJin && UseOffGCD && !MovementManager.IsMoving)
            {
                return await MySpells.TenChiJin.Cast();
            }
            return false;
        }

        #endregion

        #region Ninjutsu

        private static bool UseNinjutsu(bool targetSelf = false, int range = 15)
        {
            return Core.Player.HasAura(496) ||
                   (NinjutsuGcd > 1000 || NinjutsuGcd <= 0 && !ActionManager.CanCast(2240, Core.Player.CurrentTarget)) &&
                   (targetSelf || Core.Player.HasTarget && Core.Player.CurrentTarget.CanAttack &&
                    Core.Player.TargetDistance(range, false) && Core.Player.CurrentTarget.InLineOfSight());
        }

        #region Fuma

        private async Task<bool> FumaShuriken()
        {
            if (ShinraEx.Settings.NinjaFuma && UseNinjutsu() && ActionManager.CanCast(MySpells.Ten.Name, null) &&
                (MySpells.TrickAttack.Cooldown() > 22000 || !ActionManager.HasSpell(MySpells.Suiton.Name)))
            {
                if (!CanNinjutsu)
                {
                    if (await MySpells.Ten.Cast())
                    {
                        await Coroutine.Wait(2000, () => CanNinjutsu);
                    }
                }
                if (CanNinjutsu && LastTen)
                {
                    if (await MySpells.FumaShuriken.Cast())
                    {
                        await Coroutine.Wait(2000, () => !Core.Player.HasAura("Mudra"));
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region Katon

        private async Task<bool> Katon()
        {
            if (ShinraEx.Settings.NinjaKaton && UseNinjutsu() && ActionManager.CanCast(MySpells.Chi.ID, null))
            {
                if (ShinraEx.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(5) >= AoECount)
                {
                    if (!CanNinjutsu)
                    {
                        if (await MySpells.Chi.Cast())
                        {
                            await Coroutine.Wait(2000, () => CanNinjutsu);
                        }
                    }
                    if (LastChi)
                    {
                        if (await MySpells.Ten.Cast())
                        {
                            await Coroutine.Wait(2000, () => CanNinjutsu);
                        }
                    }
                    if (LastTen)
                    {
                        if (await MySpells.Katon.Cast())
                        {
                            await Coroutine.Wait(2000, () => !Core.Player.HasAura(496));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region Raiton

        private async Task<bool> Raiton()
        {
            if (ShinraEx.Settings.NinjaRaiton && UseNinjutsu() && ActionManager.CanCast(MySpells.Chi.ID, null) &&
                (MySpells.TrickAttack.Cooldown() > 22000 || !ActionManager.HasSpell(MySpells.Suiton.Name)))
            {
                if (!CanNinjutsu)
                {
                    if (await MySpells.Ten.Cast())
                    {
                        await Coroutine.Wait(2000, () => CanNinjutsu);
                    }
                }
                if (LastTen)
                {
                    if (await MySpells.Chi.Cast())
                    {
                        await Coroutine.Wait(2000, () => CanNinjutsu);
                    }
                }
                if (LastChi)
                {
                    if (await MySpells.Raiton.Cast())
                    {
                        await Coroutine.Wait(2000, () => !Core.Player.HasAura(496));
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region Huton

        private async Task<bool> Huton()
        {
            if (ShinraEx.Settings.NinjaHuton && UseNinjutsu(true) && ActionManager.CanCast(MySpells.Jin.ID, null) &&
                Resource.HutonTimer.TotalMilliseconds < 20000)
            {
                if (Core.Player.InCombat || Core.Player.HasTarget && Core.Player.CurrentTarget.CanAttack)
                {
                    if (!CanNinjutsu)
                    {
                        if (await MySpells.Jin.Cast())
                        {
                            await Coroutine.Wait(2000, () => CanNinjutsu);
                        }
                    }
                    if (LastJin)
                    {
                        if (await MySpells.Chi.Cast())
                        {
                            await Coroutine.Wait(2000, () => CanNinjutsu);
                        }
                    }
                    if (LastChi)
                    {
                        if (await MySpells.Ten.Cast())
                        {
                            await Coroutine.Wait(2000, () => CanNinjutsu);
                        }
                    }
                    if (LastTen)
                    {
                        if (await MySpells.Huton.Cast())
                        {
                            await Coroutine.Wait(2000, () => !Core.Player.HasAura(496));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region Doton

        private async Task<bool> Doton()
        {
            if (ShinraEx.Settings.NinjaDoton && UseNinjutsu() && ActionManager.CanCast(MySpells.Jin.ID, null) && !MovementManager.IsMoving &&
                !Core.Player.HasAura(MySpells.Doton.Name, true, 5000))
            {
                if (ShinraEx.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(5) >= AoECount)
                {
                    if (!CanNinjutsu)
                    {
                        if (await MySpells.Ten.Cast())
                        {
                            await Coroutine.Wait(2000, () => CanNinjutsu);
                        }
                    }
                    if (LastTen)
                    {
                        if (await MySpells.Jin.Cast())
                        {
                            await Coroutine.Wait(2000, () => CanNinjutsu);
                        }
                    }
                    if (LastJin)
                    {
                        if (await MySpells.Chi.Cast())
                        {
                            await Coroutine.Wait(2000, () => CanNinjutsu);
                        }
                    }
                    if (LastChi)
                    {
                        if (await MySpells.Doton.Cast())
                        {
                            await Coroutine.Wait(2000, () => !Core.Player.HasAura(496));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region Suiton

        private async Task<bool> Suiton()
        {
            if (ShinraEx.Settings.NinjaSuiton && UseNinjutsu() && ActionManager.CanCast(MySpells.Jin.ID, null) &&
                !Core.Player.HasAura(MySpells.Suiton.Name) && TrickCooldown < 9000)
            {
                if (!CanNinjutsu)
                {
                    if (await MySpells.Ten.Cast())
                    {
                        await Coroutine.Wait(2000, () => CanNinjutsu);
                    }
                }
                if (LastTen)
                {
                    if (await MySpells.Chi.Cast())
                    {
                        await Coroutine.Wait(2000, () => CanNinjutsu);
                    }
                }
                if (LastChi)
                {
                    if (await MySpells.Jin.Cast())
                    {
                        await Coroutine.Wait(2000, () => CanNinjutsu);
                    }
                }
                if (LastJin)
                {
                    if (await MySpells.Suiton.Cast())
                    {
                        await Coroutine.Wait(2000, () => !Core.Player.HasAura(496));
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        private async Task<bool> TenChiJinBuff()
        {
            if (!Core.Player.HasAura(MySpells.TenChiJin.Name)) return false;

            #region Fuma

            if (!Core.Player.HasAura("Mudra"))
            {
                if (TrickCooldown > 9000 && await MySpells.Jin.Cast() || await MySpells.Ten.Cast())
                    await Coroutine.Wait(2000, () => CanNinjutsu);
            }

            if (LastJin || LastTen)
            {
                if (await MySpells.FumaShuriken.Cast())
                    await Coroutine.Wait(2000, () => !CanNinjutsu);
            }

            #endregion

            #region Raiton / Katon

            if (ShinraEx.LastSpell.ID == MySpells.FumaShuriken.ID)
            {
                if (TrickCooldown > 9000 && await MySpells.Ten.Cast() || await MySpells.Chi.Cast())
                    await Coroutine.Wait(2000, () => CanNinjutsu);
            }

            if (LastChi && await MySpells.Raiton.Cast())
                await Coroutine.Wait(2000, () => !CanNinjutsu);

            if (LastTen && await MySpells.Katon.Cast())
                await Coroutine.Wait(2000, () => !CanNinjutsu);

            #endregion

            #region Suiton / Doton

            if (ShinraEx.LastSpell.ID == MySpells.Raiton.ID && await MySpells.Jin.Cast())
                await Coroutine.Wait(2000, () => CanNinjutsu);

            if (ShinraEx.LastSpell.ID == MySpells.Katon.ID && await MySpells.Chi.Cast())
                await Coroutine.Wait(2000, () => CanNinjutsu);

            if (LastJin && await MySpells.Suiton.Cast())
                await Coroutine.Wait(2000, () => !CanNinjutsu);

            if (LastChi && await MySpells.Doton.Cast())
                await Coroutine.Wait(2000, () => !CanNinjutsu);

            #endregion

            return true;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (ShinraEx.Settings.NinjaSecondWind && Core.Player.CurrentHealthPercent < ShinraEx.Settings.NinjaSecondWindPct)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (ShinraEx.Settings.NinjaInvigorate && Core.Player.CurrentTPPercent < ShinraEx.Settings.NinjaInvigoratePct)
            {
                return await MySpells.Role.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (ShinraEx.Settings.NinjaBloodbath && Core.Player.CurrentHealthPercent < ShinraEx.Settings.NinjaBloodbathPct)
            {
                return await MySpells.Role.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> Goad()
        {
            if (ShinraEx.Settings.NinjaGoad)
            {
                var target = Helpers.GoadManager.FirstOrDefault(gm => gm.CurrentTPPercent < ShinraEx.Settings.NinjaGoadPct);

                if (target != null)
                {
                    return await MySpells.Role.Goad.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> TrueNorth()
        {
            if (ShinraEx.Settings.NinjaTrueNorth)
            {
                return await MySpells.Role.TrueNorth.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static int AoECount => ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 2;
        private static bool TrickAttackActive => Core.Player.CurrentTarget.HasAura(638);
        private static bool UseOffGCD => DataManager.GetSpellData(2260).Cooldown.TotalMilliseconds > 1000 || Core.Player.ClassLevel < 30;
        private static bool UseHellfrog => Resource.NinkiGauge == 100 && BhavacakraCooldown > 10000 && TenChiJinCooldown > 10000;
        private static bool UseArmorCrush => Resource.HutonTimer.TotalMilliseconds > 0 && Resource.HutonTimer.TotalMilliseconds < 40000;
        private static bool UseShadowFang => ShinraEx.Settings.NinjaShadowFang && !Core.Player.CurrentTarget.HasAura(508, true, 6000) &&
                                             (Core.Player.CurrentTarget.IsBoss() ||
                                              Core.Player.CurrentTarget.CurrentHealth >
                                              ShinraEx.Settings.NinjaShadowFangHP);

        private static double TrickCooldown => DataManager.GetSpellData(2258).Cooldown.TotalMilliseconds;
        private static double NinjutsuGcd => DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds;
        private static double BhavacakraCooldown => ActionManager.HasSpell(7402) ? DataManager.GetSpellData(7402).Cooldown.TotalMilliseconds
            : 50000;
        private static double TenChiJinCooldown => ActionManager.HasSpell(7403) ? DataManager.GetSpellData(7403).Cooldown.TotalMilliseconds
            : 100000;

        private bool CanNinjutsu => ActionManager.CanCast(MySpells.Ninjutsu.ID, null);
        private bool LastTen => ShinraEx.LastSpell.ID == MySpells.Ten.ID;
        private bool LastChi => ShinraEx.LastSpell.ID == MySpells.Chi.ID;
        private bool LastJin => ShinraEx.LastSpell.ID == MySpells.Jin.ID;

        #endregion
    }
}