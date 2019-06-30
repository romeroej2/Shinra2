using System;
using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Samurai;

namespace ShinraCo.Rotations
{
    public sealed partial class Samurai
    {
        private SamuraiSpells MySpells { get; } = new SamuraiSpells();

        #region Damage

        private async Task<bool> Hakaze()
        {
            return await MySpells.Hakaze.Cast();
        }

        private async Task<bool> Jinpu()
        {
            if (ActionManager.LastSpell.Name == MySpells.Hakaze.Name && !GetsuActive)
            {
                return await MySpells.Jinpu.Cast();
            }
            return false;
        }

        private async Task<bool> JinpuBuff()
        {
            if (ActionManager.LastSpell.Name == MySpells.Hakaze.Name && !Core.Player.HasAura(MySpells.Jinpu.Name, true, 8000))
            {
                return await MySpells.Jinpu.Cast();
            }
            return false;
        }

        private async Task<bool> Gekko()
        {
            if (ActionManager.LastSpell.Name == MySpells.Jinpu.Name)
            {
                return await MySpells.Gekko.Cast();
            }
            return false;
        }

        private async Task<bool> Shifu()
        {
            if (ActionManager.LastSpell.Name == MySpells.Hakaze.Name && !KaActive)
            {
                return await MySpells.Shifu.Cast();
            }
            return false;
        }

        private async Task<bool> ShifuBuff()
        {
            if (ActionManager.LastSpell.Name == MySpells.Hakaze.Name && !Core.Player.HasAura(MySpells.Shifu.Name, true, 8000))
            {
                return await MySpells.Shifu.Cast();
            }
            return false;
        }

        private async Task<bool> Kasha()
        {
            if (ActionManager.LastSpell.Name == MySpells.Shifu.Name)
            {
                return await MySpells.Kasha.Cast();
            }
            return false;
        }

        private async Task<bool> Yukikaze()
        {
            if (ActionManager.LastSpell.Name == MySpells.Hakaze.Name)
            {
                return await MySpells.Yukikaze.Cast();
            }
            return false;
        }

        private async Task<bool> YukikazeDebuff()
        {
            if (ActionManager.LastSpell.Name == MySpells.Hakaze.Name && !Core.Player.CurrentTarget.HasAura(819, false, 8000))
            {
                return await MySpells.Yukikaze.Cast();
            }
            return false;
        }

        private async Task<bool> Meikyo()
        {
            if (Core.Player.HasAura(1233))
            {
                if (!GetsuActive)
                {
                    return await MySpells.Gekko.Cast();
                }
                if (!KaActive)
                {
                    return await MySpells.Kasha.Cast();
                }
                if (!SetsuActive)
                {
                    return await MySpells.Yukikaze.Cast();
                }
            }
            return false;
        }

        private async Task<bool> MidareSetsugekka()
        {
            if (!UseMidare) return false;

            if (!Core.Player.HasAura(1229) && ActionManager.CanCast(MySpells.MidareSetsugekka.Name, Core.Player.CurrentTarget))
            {
                if (await MySpells.HissatsuKaiten.Cast(null, false))
                {
                    await Coroutine.Wait(3000, () => Core.Player.HasAura(1229));
                }
            }
            return await MySpells.MidareSetsugekka.Cast();
        }

        private async Task<bool> HissatsuShinten()
        {
            if (Resource.Kenki >= 45 && (!PoolKenki || MySpells.Hagakure.Cooldown() == 0))
            {
                return await MySpells.HissatsuShinten.Cast();
            }
            return false;
        }

        private async Task<bool> HissatsuSeigan()
        {
            if (ShinraEx.LastSpell.Name != MySpells.HissatsuKaiten.Name && Resource.Kenki >= 35 && !PoolKenki)
            {
                return await MySpells.HissatsuSeigan.Cast();
            }
            return false;
        }

        private async Task<bool> Enpi()
        {
            if (Core.Player.HasAura("Enhanced Enpi") && Core.Player.TargetDistance(10))
            {
                return await MySpells.Enpi.Cast();
            }
            return false;
        }

        #endregion

        #region DoT

        private async Task<bool> Higanbana()
        {
            if (!UseHiganbana) return false;

            if (!Core.Player.HasAura(1229) && ActionManager.CanCast(MySpells.Higanbana.Name, Core.Player.CurrentTarget))
            {
                if (await MySpells.HissatsuKaiten.Cast(null, false))
                {
                    await Coroutine.Wait(3000, () => Core.Player.HasAura(1229));
                }
            }
            return await MySpells.Higanbana.Cast();
        }

        #endregion

        #region AoE

        private async Task<bool> Fuga()
        {
            if (Core.Player.HasAura(MySpells.Shifu.Name) && Core.Player.HasAura(MySpells.Jinpu.Name))
            {
                return await MySpells.Fuga.Cast();
            }
            return false;
        }

        private async Task<bool> Mangetsu()
        {
            if (ActionManager.LastSpell.Name == MySpells.Fuga.Name && !GetsuActive)
            {
                return await MySpells.Mangetsu.Cast();
            }
            return false;
        }

        private async Task<bool> Oka()
        {
            if (ActionManager.LastSpell.Name == MySpells.Fuga.Name && !KaActive)
            {
                return await MySpells.Oka.Cast();
            }
            return false;
        }

        private async Task<bool> TenkaGoken()
        {
            if (!UseTenka) return false;

            if (!Core.Player.HasAura(1229) && ActionManager.CanCast(MySpells.TenkaGoken.Name, Core.Player.CurrentTarget))
            {
                if (await MySpells.HissatsuKaiten.Cast(null, false))
                {
                    await Coroutine.Wait(3000, () => Core.Player.HasAura(1229));
                }
            }
            return await MySpells.TenkaGoken.Cast();
        }

        private async Task<bool> HissatsuKyuten()
        {
            if (ShinraEx.Settings.RotationMode != Modes.Single)
            {
                if (ShinraEx.LastSpell.Name != MySpells.HissatsuKaiten.Name && Resource.Kenki >= 45 && !PoolKenki)
                {
                    return await MySpells.HissatsuKyuten.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> Ageha()
        {
            return await MySpells.Ageha.Cast();
        }

        private async Task<bool> HissatsuGyoten()
        {
            if (ShinraEx.Settings.SamuraiGyoten && Core.Player.TargetDistance(10))
            {
                return await MySpells.HissatsuGyoten.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> HissatsuGuren()
        {
            if (ShinraEx.Settings.SamuraiGuren && Resource.Kenki >= 70)
            {
                return await MySpells.HissatsuGuren.Cast();
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> MeikyoShisui()
        {
            if (ShinraEx.Settings.SamuraiMeikyo && Core.Player.TargetDistance(5, false))
            {
                if (ActionManager.LastSpell.Name == MySpells.Gekko.Name || ActionManager.LastSpell.Name == MySpells.Kasha.Name ||
                    ActionManager.LastSpell.Name == MySpells.Yukikaze.Name)
                {
                    return await MySpells.MeikyoShisui.Cast();
                }
            }
            return false;
        }

        private static async Task<bool> Kaiten()
        {
            return Core.Player.HasAura(1229);
        }

        private async Task<bool> HissatsuKaiten()
        {
            if (ShinraEx.LastSpell.Name == MySpells.Hagakure.Name || UseHagakure || !UseHiganbana && !UseTenka && !UseMidare)
                return false;

            if (await MySpells.HissatsuKaiten.Cast())
            {
                return await Coroutine.Wait(3000, () => Core.Player.HasAura(1229));
            }
            return false;
        }

        private async Task<bool> Meditate()
        {
            return Core.Player.HasAura(MySpells.Meditate.Name);
        }

        private async Task<bool> Hagakure()
        {
            if (!UseHagakure || Core.Player.HasAura(1229)) return false;

            return await MySpells.Hagakure.Cast();
        }

        #endregion

        #region Heal

        private async Task<bool> MercifulEyes()
        {
            if (ShinraEx.Settings.SamuraiMerciful && Core.Player.CurrentHealthPercent < ShinraEx.Settings.SamuraiMercifulPct)
            {
                return await MySpells.MercifulEyes.Cast();
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (ShinraEx.Settings.SamuraiSecondWind && Core.Player.CurrentHealthPercent < ShinraEx.Settings.SamuraiSecondWindPct)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (ShinraEx.Settings.SamuraiInvigorate && Core.Player.CurrentTPPercent < ShinraEx.Settings.SamuraiInvigoratePct)
            {
                return await MySpells.Role.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (ShinraEx.Settings.SamuraiBloodbath && Core.Player.CurrentHealthPercent < ShinraEx.Settings.SamuraiBloodbathPct)
            {
                return await MySpells.Role.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> Goad()
        {
            if (ShinraEx.Settings.SamuraiGoad)
            {
                var target = Helpers.GoadManager.FirstOrDefault(gm => gm.CurrentTPPercent < ShinraEx.Settings.SamuraiGoadPct);

                if (target != null)
                {
                    return await MySpells.Role.Goad.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> TrueNorth()
        {
            if (ShinraEx.Settings.SamuraiTrueNorth && Core.Player.TargetDistance(5, false))
            {
                return await MySpells.Role.TrueNorth.Cast();
            }
            return false;
        }

        #endregion

        #region PVP

        private async Task<bool> YukikazePVP()
        {
            if (!SetsuActive && (Core.Player.HasAura(MySpells.MeikyoShisui.Name) ||
                                 ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.Gekko.Combo) == MySpells.PVP.Jinpu.ID &&
                                 ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.Kasha.Combo) == MySpells.PVP.Shifu.ID))
            {
                return await MySpells.PVP.Yukikaze.Cast();
            }
            return false;
        }

        private async Task<bool> GekkoPVP()
        {
            if (!GetsuActive && (Core.Player.HasAura(MySpells.MeikyoShisui.Name) ||
                                 ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.Kasha.Combo) == MySpells.PVP.Shifu.ID))
            {
                return await MySpells.PVP.Gekko.Cast();
            }
            return false;
        }

        private async Task<bool> KashaPVP()
        {
            return await MySpells.PVP.Kasha.Cast();
        }

        private async Task<bool> EnpiPVP()
        {
            return await MySpells.PVP.Enpi.Cast();
        }

        private async Task<bool> HissatsuShintenPVP()
        {
            if (Resource.Kenki >= 80 || Core.Player.CurrentTarget.CurrentHealthPercent < 30)
            {
                return await MySpells.PVP.HissatsuShinten.Cast();
            }
            return false;
        }

        private async Task<bool> MeikyoShisuiPVP()
        {
            if (Core.Player.CurrentTP >= 750 || !SetsuActive && !Core.Player.CurrentTarget.HasAura(MySpells.Yukikaze.Name, true, 2500))
            {
                if (ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.Yukikaze.Combo) == MySpells.PVP.Hakaze.ID &&
                    ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.Gekko.Combo) == MySpells.PVP.Jinpu.ID &&
                    ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.Kasha.Combo) == MySpells.PVP.Shifu.ID &&
                    DataManager.GetSpellData(7477).Cooldown.TotalMilliseconds < 1500)
                {
                    if (await MySpells.PVP.MeikyoShisui.Cast())
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.MeikyoShisui.Name));
                    }
                }
            }
            return false;
        }

        private async Task<bool> HiganbanaPVP()
        {
            if (NumSen == 1 && !MovementManager.IsMoving && !Core.Player.CurrentTarget.HasAura(MySpells.Higanbana.Name, true, 5000))
            {
                return await MySpells.PVP.Higanbana.Cast();
            }
            return false;
        }

        private async Task<bool> MidareSetsugekkaPVP()
        {
            if (NumSen == 3 && !MovementManager.IsMoving)
            {
                return await MySpells.PVP.MidareSetsugekka.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static bool GetsuActive => Resource.Sen.HasFlag(Resource.Iaijutsu.Getsu);
        private static bool KaActive => Resource.Sen.HasFlag(Resource.Iaijutsu.Ka);
        private static bool SetsuActive => Resource.Sen.HasFlag(Resource.Iaijutsu.Setsu);
        private static bool PoolKenki => ShinraEx.Settings.SamuraiGuren && ActionManager.HasSpell(7496) &&
                                         DataManager.GetSpellData(7496).Cooldown.TotalMilliseconds < 6000;

        private static bool UseHiganbana => ShinraEx.Settings.SamuraiHiganbana && NumSen == 1 &&
                                            !Core.Player.CurrentTarget.HasAura(1228, true, 8000) &&
                                            (Core.Player.CurrentTarget.IsBoss() ||
                                             Core.Player.CurrentTarget.CurrentHealth > ShinraEx.Settings.SamuraiHiganbanaHP);

        private static bool UseTenka => NumSen == 2 && (ShinraEx.Settings.RotationMode == Modes.Multi ||
                                                        ShinraEx.Settings.RotationMode == Modes.Smart &&
                                                        Helpers.EnemiesNearTarget(5) >= Helpers.AoECount);

        private static bool UseMidare => ShinraEx.Settings.SamuraiMidare && NumSen == 3 &&
                                         (Core.Player.CurrentTarget.IsBoss() ||
                                          Core.Player.CurrentTarget.CurrentHealth > ShinraEx.Settings.SamuraiMidareHP);

        private static bool UseHagakure => ShinraEx.Settings.SamuraiHagakure && NumSen == 3 &&
                                           DataManager.GetSpellData(7495).Cooldown == TimeSpan.Zero;

        private static int NumSen
        {
            get { return Enum.GetValues(typeof(Resource.Iaijutsu)).Cast<Enum>().Count(value => Resource.Sen.HasFlag(value)); }
        }

        #endregion
    }
}
