using System;
using System.Linq;
using System.Threading.Tasks;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Dragoon;

namespace ShinraCo.Rotations
{
    public sealed partial class Dragoon
    {
        private DragoonSpells MySpells { get; } = new DragoonSpells();

        #region Damage

        private async Task<bool> TrueThrust()
        {
            return await MySpells.TrueThrust.Cast();
        }

        private async Task<bool> VorpalThrust()
        {
            if (ActionManager.LastSpell.Name == MySpells.TrueThrust.Name)
            {
                return await MySpells.VorpalThrust.Cast();
            }
            return false;
        }

        private async Task<bool> FullThrust()
        {
            if (ActionManager.LastSpell.Name == MySpells.VorpalThrust.Name)
            {
                return await MySpells.FullThrust.Cast();
            }
            return false;
        }

        private async Task<bool> ImpulseDrive()
        {
            if (ActionManager.HasSpell(MySpells.ChaosThrust.Name) &&
                !Core.Player.CurrentTarget.HasAura(MySpells.ChaosThrust.Name, true, 12000) ||
                ActionManager.HasSpell(MySpells.Disembowel.Name) && !Core.Player.CurrentTarget.HasAura(820))
            {
                return await MySpells.ImpulseDrive.Cast();
            }
            return false;
        }

        private async Task<bool> Disembowel()
        {
            if ((ActionManager.LastSpell.Name == MySpells.TrueThrust.Name || ActionManager.LastSpell.Name == MySpells.RaidenThrust.Name) &&!Core.Player.HasAura(MySpells.Disembowel.Name, true, 6000))
            {
                return await MySpells.Disembowel.Cast();
            }
            return false;
        }

        private async Task<bool> ChaosThrust()
        {
            if (ActionManager.LastSpell.Name == MySpells.Disembowel.Name)
            {
                return await MySpells.ChaosThrust.Cast();
            }
            return false;
        }

        private async Task<bool> FangAndClaw()
        {
            return await MySpells.FangAndClaw.Cast();
        }

        private async Task<bool> WheelingThrust()
        {
            return await MySpells.WheelingThrust.Cast();
        }

        #endregion

        #region AoE

        private async Task<bool> DoomSpike()
        {
            if (Core.Player.HasAura(MySpells.Disembowel.Name))
            {
                var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;

                if (ShinraEx.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(5) >= count)
                {
                    return await MySpells.DoomSpike.Cast();
                }
            }
            return false;
        }

        private async Task<bool> SonicThrust()
        {
            if (ActionManager.LastSpell.Name == MySpells.DoomSpike.Name && Core.Player.HasAura(MySpells.Disembowel.Name))
            {
                var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;

                if (ShinraEx.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(5) >= count)
                {
                    return await MySpells.SonicThrust.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> Jump()
        {
            if (ShinraEx.Settings.DragoonJump && !MovementManager.IsMoving && !RecentJump && UseJump &&
                Core.Player.HasAura(MySpells.Disembowel.Name))
            {
                return await MySpells.Jump.Cast();
            }
            return false;
        }

        private async Task<bool> SpineshatterDive()
        {
            if (ShinraEx.Settings.DragoonSpineshatter && !MovementManager.IsMoving && !RecentJump && UseJump &&
                Core.Player.HasAura(MySpells.Disembowel.Name))
            {
                return await MySpells.SpineshatterDive.Cast();
            }
            return false;
        }

        private async Task<bool> DragonfireDive()
        {
            if (ShinraEx.Settings.DragoonDragonfire && !MovementManager.IsMoving && !RecentJump &&
                Core.Player.HasAura(MySpells.Disembowel.Name))
            {
                return await MySpells.DragonfireDive.Cast();
            }
            return false;
        }

        private async Task<bool> Geirskogul()
        {
            if (ShinraEx.Settings.DragoonGeirskogul && Core.Player.HasAura(MySpells.Disembowel.Name))
            {
                if (Resource.DragonGaze == 2 || !RecentJump && !Core.Player.HasAura(1243) && JumpCooldown > 25 && SpineCooldown > 25 ||
                    Core.Player.ClassLevel < 70)
                {
                    return await MySpells.Geirskogul.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Nastrond()
        {
            if (ShinraEx.Settings.DragoonGeirskogul && Core.Player.HasAura(MySpells.Disembowel.Name))
            {
                return await MySpells.Nastrond.Cast();
            }
            return false;
        }

        private async Task<bool> MirageDive()
        {
            if (ShinraEx.Settings.DragoonMirage && !MovementManager.IsMoving && !RecentJump && Core.Player.HasAura(MySpells.Disembowel.Name))
            {
                return await MySpells.MirageDive.Cast();
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> LifeSurge()
        {
            if (ShinraEx.Settings.DragoonLifeSurge && ActionManager.LastSpell.Name == MySpells.VorpalThrust.Name)
            {
                return await MySpells.LifeSurge.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (ShinraEx.Settings.DragoonBloodForBlood)
            {
                return await MySpells.BloodForBlood.Cast();
            }
            return false;
        }

        private async Task<bool> BattleLitany()
        {
            if (ShinraEx.Settings.DragoonBattleLitany)
            {
                return await MySpells.BattleLitany.Cast();
            }
            return false;
        }

        private async Task<bool> BloodOfTheDragon()
        {
            if (ShinraEx.Settings.DragoonBloodOfTheDragon && !BloodActive &&
                (ActionManager.LastSpell.Name == MySpells.VorpalThrust.Name || ActionManager.LastSpell.Name == MySpells.Disembowel.Name))
            {
                return await MySpells.BloodOfTheDragon.Cast();
            }
            return false;
        }

        private async Task<bool> DragonSight()
        {
            if (!ShinraEx.Settings.DragoonDragonSight) return false;

            var target = !PartyManager.IsInParty && ChocoboManager.Summoned ? ChocoboManager.Object
                : Managers.DragonSight.FirstOrDefault();

            if (target != null && ActionManager.CanCast(MySpells.DragonSight.Name, Core.Player))
            {
                Helpers.Debug("Dragon Sight Target:" + target.Name);

                return await MySpells.DragonSight.Cast(target);
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (ShinraEx.Settings.DragoonSecondWind && Core.Player.CurrentHealthPercent < ShinraEx.Settings.DragoonSecondWindPct)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (ShinraEx.Settings.DragoonBloodbath && Core.Player.CurrentHealthPercent < ShinraEx.Settings.DragoonBloodbathPct)
            {
                return await MySpells.Role.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> TrueNorth()
        {
            if (ShinraEx.Settings.DragoonTrueNorth)
            {
                return await MySpells.Role.TrueNorth.Cast();
            }
            return false;
        }

        #endregion

        #region PVP

        private async Task<bool> FullThrustPVP()
        {
            return await MySpells.PVP.FullThrust.Cast();
        }

        private async Task<bool> ChaosThrustPVP()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.ChaosThrust.Name, true, 10000) &&
                ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.FangAndClaw.Combo) == MySpells.PVP.TrueThrust.ID)
            {
                return await MySpells.PVP.ChaosThrust.Cast();
            }
            return false;
        }

        private async Task<bool> WheelingThrustPVP()
        {
            if (ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.WheelingThrust.Combo) == MySpells.PVP.WheelingThrust.ID)
            {
                return await MySpells.PVP.WheelingThrust.Cast();
            }
            return false;
        }

        private async Task<bool> SkewerPVP()
        {
            if (!RecentJump)
            {
                return await MySpells.PVP.Skewer.Cast();
            }
            return false;
        }

        private async Task<bool> JumpPVP()
        {
            if (!MovementManager.IsMoving && !RecentJump && Resource.DragonGaze < 2)
            {
                return await MySpells.PVP.Jump.Cast();
            }
            return false;
        }

        private async Task<bool> SpineshatterDivePVP()
        {
            if (!MovementManager.IsMoving && !RecentJump && Resource.DragonGaze < 2)
            {
                return await MySpells.PVP.SpineshatterDive.Cast();
            }
            return false;
        }

        private async Task<bool> BloodOfTheDragonPVP()
        {
            if (!RecentJump)
            {
                return await MySpells.PVP.BloodOfTheDragon.Cast();
            }
            return false;
        }

        private async Task<bool> GeirskogulPVP()
        {
            if (!RecentJump)
            {
                return await MySpells.PVP.Geirskogul.Cast();
            }
            return false;
        }

        private async Task<bool> NastrondPVP()
        {
            if (!RecentJump)
            {
                return await MySpells.PVP.Nastrond.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static bool RecentJump { get { return Spell.RecentSpell.Keys.Any(rs => rs.Contains("Dive") || rs.Contains("Jump")); } }
        private static bool BloodActive => Resource.Timer != TimeSpan.Zero;
        private static double JumpCooldown => DataManager.GetSpellData(92).Cooldown.TotalSeconds;
        private static double SpineCooldown => DataManager.GetSpellData(95).Cooldown.TotalSeconds;
        private bool UseJump => BloodActive || !ActionManager.HasSpell(MySpells.BloodOfTheDragon.Name);

        #endregion
    }
}
