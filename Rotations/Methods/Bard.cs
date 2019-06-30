using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Bard;
using static ShinraCo.Constants;

namespace ShinraCo.Rotations
{
    public sealed partial class Bard
    {
        private BardSpells MySpells { get; } = new BardSpells();

        #region Damage

        private async Task<bool> HeavyShot()
        {
            return await MySpells.HeavyShot.Cast();
        }

        private async Task<bool> StraightShotBuff()
        {
            if (!Core.Player.HasAura(MySpells.StraightShot.Name, true, 6000))
            {
                return await MySpells.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> StraightShot()
        {
            if (Core.Player.HasAura("Straighter Shot") && !ActionManager.HasSpell(MySpells.RefulgentArrow.Name))
            {
                return await MySpells.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> MiserysEnd()
        {
            return await MySpells.MiserysEnd.Cast();
        }

        private async Task<bool> Bloodletter()
        {
            return await MySpells.Bloodletter.Cast();
        }

        private async Task<bool> PitchPerfect()
        {
            if (!ShinraEx.Settings.BardPitchPerfect) return false;

            var critBonus = DotManager.Check(Target, true);

            if (NumRepertoire >= ShinraEx.Settings.BardRepertoireCount || MinuetActive && SongTimer < 2000 ||
                critBonus >= 20 && NumRepertoire >= 2)
            {
                return await MySpells.PitchPerfect.Cast();
            }
            return false;
        }

        private async Task<bool> RefulgentArrow()
        {
            if (Core.Player.HasAura(122) && (!ShinraEx.Settings.BardBarrage || MySpells.Barrage.Cooldown() > 7000 ||
                                             !Core.Player.HasAura(MySpells.StraightShot.Name, true, 6000)))
            {
                return await MySpells.RefulgentArrow.Cast();
            }
            return false;
        }

        private async Task<bool> BarrageActive()
        {
            if (Core.Player.HasAura(MySpells.Barrage.Name))
            {
                if (await MySpells.RefulgentArrow.Cast())
                {
                    return true;
                }
                if (ActionManager.LastSpell.Name == MySpells.HeavyShot.Name)
                {
                    await Coroutine.Wait(1000, () => Core.Player.HasAura(122));
                }
                if (!Core.Player.HasAura(122))
                {
                    return await MySpells.EmpyrealArrow.Cast(null, false);
                }
            }
            return false;
        }

        #endregion

        #region DoT

        private async Task<bool> VenomousBite()
        {
            if (!ShinraEx.Settings.BardUseDots || Target.HasAura(VenomDebuff, true, 4000) || !await MySpells.VenomousBite.Cast())
                return false;

            DotManager.Add(Target);
            return true;
        }

        private async Task<bool> Windbite()
        {
            if (!ShinraEx.Settings.BardUseDots || Target.HasAura(WindDebuff, true, 4000) || !await MySpells.Windbite.Cast())
                return false;

            DotManager.Add(Target);
            return true;
        }

        private async Task<bool> IronJaws()
        {
            if (!Target.HasAura(VenomDebuff, true) || !Target.HasAura(WindDebuff, true) ||
                Target.HasAura(VenomDebuff, true, 5000) && Target.HasAura(WindDebuff, true, 5000) || !await MySpells.IronJaws.Cast())
            {
                return false;
            }

            DotManager.Add(Target);
            return true;
        }

        private async Task<bool> DotSnapshot()
        {
            if (!ShinraEx.Settings.BardDotSnapshot ||
                !Core.Player.CurrentTarget.HasAura(VenomDebuff, true) ||
                !Core.Player.CurrentTarget.HasAura(WindDebuff, true) ||
                DotManager.Recent(Target))
            {
                return false;
            }

            var crit = DotManager.Difference(Target, true);
            var damage = crit + DotManager.Difference(Target);

            // Prioritise 30% crit buff
            if (crit >= 30 || crit >= 0 && damage >= 0 && (DotManager.CritExpiring || DotManager.DamageExpiring))
            {
                if (await MySpells.IronJaws.Cast())
                {
                    DotManager.Add(Target);
                    return true;
                }
            }

            if (DotManager.Check(Target, true) >= 30) return false;

            // Refresh during damage buffs
            if (damage >= 20 || damage >= 10 && Target.AuraExpiring(WindDebuff, true, 10000) || damage >= 0 && DotManager.BuffExpiring)
            {
                if (await MySpells.IronJaws.Cast())
                {
                    DotManager.Add(Target);
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> QuickNock()
        {
            if (ShinraEx.Settings.BardUseDotsAoe && (!Core.Player.CurrentTarget.HasAura(VenomDebuff, true, 4000) ||
                                                   !Core.Player.CurrentTarget.HasAura(WindDebuff, true, 4000)))
            {
                return false;
            }

            if (Core.Player.CurrentTPPercent > 40)
            {
                var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;

                if (ShinraEx.Settings.RotationMode == Modes.Multi || ShinraEx.Settings.RotationMode == Modes.Smart &&
                    Helpers.EnemiesNearTarget(5) >= count)
                {
                    return await MySpells.QuickNock.Cast();
                }
            }
            return false;
        }

        private async Task<bool> RainOfDeath()
        {
            if (ShinraEx.Settings.RotationMode == Modes.Multi || ShinraEx.Settings.RotationMode == Modes.Smart &&
                Helpers.EnemiesNearTarget(5) > 1)
            {
                return await MySpells.RainOfDeath.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> MagesBallad()
        {
            if (ShinraEx.Settings.BardSongs &&
                !RecentSong &&
                (NoSong ||
                 PaeonActive && DataManager.GetSpellData(3559).Cooldown.TotalSeconds < 30 ||
                 MinuetActive && SongTimer < 2000 && MySpells.PitchPerfect.Cooldown() > 0))
            {
                return await MySpells.MagesBallad.Cast();
            }
            return false;
        }

        private async Task<bool> ArmysPaeon()
        {
            if (ShinraEx.Settings.BardSongs && !RecentSong && NoSong)
            {
                return await MySpells.ArmysPaeon.Cast();
            }
            return false;
        }

        private async Task<bool> WanderersMinuet()
        {
            if (ShinraEx.Settings.BardSongs && !RecentSong &&
                (NoSong || PaeonActive && DataManager.GetSpellData(114).Cooldown.TotalSeconds < 30))
            {
                return await MySpells.WanderersMinuet.Cast();
            }
            return false;
        }

        private async Task<bool> EmpyrealArrow()
        {
            if (ShinraEx.Settings.BardEmpyrealArrow)
            {
                return await MySpells.EmpyrealArrow.Cast();
            }
            return false;
        }

        private async Task<bool> Sidewinder()
        {
            if (ShinraEx.Settings.BardSidewinder && Core.Player.CurrentTarget.HasAura(VenomDebuff, true) &&
                Core.Player.CurrentTarget.HasAura(WindDebuff, true))
            {
                return await MySpells.Sidewinder.Cast();
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> RagingStrikes()
        {
            if (ShinraEx.Settings.BardRagingStrikes)
            {
                if (MinuetActive || !ActionManager.HasSpell(MySpells.WanderersMinuet.ID))
                {
                    return await MySpells.RagingStrikes.Cast();
                }
            }
            return false;
        }

        private async Task<bool> FoeRequiem()
        {
            if (ShinraEx.Settings.BardFoeRequiem && !Core.Player.HasAura(MySpells.FoeRequiem.Name) &&
                Core.Player.CurrentManaPercent >= ShinraEx.Settings.BardFoeRequiemPct)
            {
                return await MySpells.FoeRequiem.Cast();
            }
            return false;
        }

        private async Task<bool> Barrage()
        {
            if (ShinraEx.Settings.BardBarrage && Core.Player.HasAura(MySpells.RagingStrikes.Name))
            {
                if (MySpells.EmpyrealArrow.Cooldown() < 500 ||
                    Core.Player.HasAura(122) && ActionManager.HasSpell(MySpells.RefulgentArrow.Name) ||
                    !ActionManager.HasSpell(MySpells.EmpyrealArrow.Name))
                {
                    if (await MySpells.Barrage.Cast())
                    {
                        return await Coroutine.Wait(2000, () => Core.Player.HasAura(MySpells.Barrage.Name));
                    }
                }
            }
            return false;
        }

        private async Task<bool> BattleVoice()
        {
            if (ShinraEx.Settings.BardBattleVoice)
            {
                return await MySpells.BattleVoice.Cast();
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (ShinraEx.Settings.BardSecondWind && Core.Player.CurrentHealthPercent < ShinraEx.Settings.BardSecondWindPct)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Peloton()
        {
            if (ShinraEx.Settings.BardPeloton && !Core.Player.HasAura(MySpells.Role.Peloton.Name) && !Core.Player.HasTarget &&
                (MovementManager.IsMoving || BotManager.Current.EnglishName == "DeepDive"))
            {
                return await MySpells.Role.Peloton.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (ShinraEx.Settings.BardInvigorate && Core.Player.CurrentTPPercent < ShinraEx.Settings.BardInvigoratePct)
            {
                return await MySpells.Role.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> Tactician()
        {
            if (ShinraEx.Settings.BardTactician)
            {
                var target = Core.Player.CurrentTPPercent < ShinraEx.Settings.BardTacticianPct ? Core.Player
                    : Helpers.GoadManager.FirstOrDefault(gm => gm.CurrentTPPercent < ShinraEx.Settings.BardTacticianPct);

                if (target != null)
                {
                    return await MySpells.Role.Tactician.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Refresh()
        {
            if (ShinraEx.Settings.BardRefresh)
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.CurrentManaPercent < ShinraEx.Settings.BardRefreshPct &&
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
            if (ShinraEx.Settings.BardPalisade)
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.BardPalisadePct &&
                                                                      hm.IsTank());

                if (target != null)
                {
                    return await MySpells.Role.Palisade.Cast(target);
                }
            }
            return false;
        }

        #endregion

        #region PVP

        private async Task<bool> StraightShotPVP()
        {
            return await MySpells.PVP.StraightShot.Cast();
        }

        private async Task<bool> StormbitePVP()
        {
            if (!Core.Player.CurrentTarget.HasAura("Caustic Bite", true, 4000) ||
                !Core.Player.CurrentTarget.HasAura("Stormbite", true, 4000))
            {
                return await MySpells.PVP.Stormbite.Cast();
            }
            return false;
        }

        private async Task<bool> SidewinderPVP()
        {
            if (Core.Player.CurrentTarget.HasAura("Caustic Bite", true, 1000) && Core.Player.CurrentTarget.HasAura("Stormbite", true, 1000))
            {
                return await MySpells.PVP.Sidewinder.Cast();
            }
            return false;
        }

        private async Task<bool> EmpyrealArrowPVP()
        {
            return await MySpells.PVP.EmpyrealArrow.Cast();
        }

        private async Task<bool> BloodletterPVP()
        {
            if (!MinuetActive || NumRepertoire == 3 || MinuetActive && SongTimer < 3000)
            {
                return await MySpells.PVP.Bloodletter.Cast();
            }
            return false;
        }

        private async Task<bool> WanderersMinuetPVP()
        {
            if (!MinuetActive)
            {
                return await MySpells.PVP.WanderersMinuet.Cast();
            }
            return false;
        }

        private async Task<bool> ArmysPaeonPVP()
        {
            if (NoSong)
            {
                return await MySpells.PVP.ArmysPaeon.Cast();
            }
            return false;
        }

        private async Task<bool> BarragePVP()
        {
            if (ShinraEx.LastSpell.Name != MySpells.PVP.StraightShot.Name &&
                ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.StraightShot.Combo) == MySpells.PVP.StraightShot.ID)
            {
                return await MySpells.PVP.Barrage.Cast();
            }
            return false;
        }

        private async Task<bool> TroubadourPVP()
        {
            if (MinuetActive)
            {
                return await MySpells.PVP.Troubadour.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static string VenomDebuff => Core.Player.ClassLevel < 64 ? "Venomous Bite" : "Caustic Bite";
        private static string WindDebuff => Core.Player.ClassLevel < 64 ? "Windbite" : "Stormbite";
        private static double SongTimer => Resource.Timer.TotalMilliseconds;
        private static int NumRepertoire => Resource.Repertoire;
        private static bool NoSong => Resource.ActiveSong == Resource.BardSong.None;
        private static bool MinuetActive => Resource.ActiveSong == Resource.BardSong.WanderersMinuet;
        private static bool PaeonActive => Resource.ActiveSong == Resource.BardSong.ArmysPaeon;

        private static bool RecentSong
        {
            get { return Spell.RecentSpell.Keys.Any(rs => rs.Contains("Minuet") || rs.Contains("Ballad") || rs.Contains("Paeon")); }
        }

        #endregion
    }
}