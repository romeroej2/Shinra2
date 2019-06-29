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
            if (ActionManager.LastSpell.Name == MySpells.ImpulseDrive.Name)
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

        private async Task<bool> HeavyThrust()
        {
            if (!Core.Player.HasAura(MySpells.HeavyThrust.Name, true, 6000))
            {
                return await MySpells.HeavyThrust.Cast();
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
            if (Core.Player.CurrentTPPercent > 30 && Core.Player.HasAura(MySpells.HeavyThrust.Name))
            {
                var count = Shinra.Settings.CustomAoE ? Shinra.Settings.CustomAoECount : 3;

                if (Shinra.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(5) >= count)
                {
                    return await MySpells.DoomSpike.Cast();
                }
            }
            return false;
        }

        private async Task<bool> SonicThrust()
        {
            if (ActionManager.LastSpell.Name == MySpells.DoomSpike.Name && Core.Player.CurrentTPPercent > 30 &&
                Core.Player.HasAura(MySpells.HeavyThrust.Name))
            {
                var count = Shinra.Settings.CustomAoE ? Shinra.Settings.CustomAoECount : 3;

                if (Shinra.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(5) >= count)
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
            if (Shinra.Settings.DragoonJump && !MovementManager.IsMoving && !RecentJump && UseJump &&
                Core.Player.HasAura(MySpells.HeavyThrust.Name))
            {
                return await MySpells.Jump.Cast();
            }
            return false;
        }

        private async Task<bool> SpineshatterDive()
        {
            if (Shinra.Settings.DragoonSpineshatter && !MovementManager.IsMoving && !RecentJump && UseJump &&
                Core.Player.HasAura(MySpells.HeavyThrust.Name))
            {
                return await MySpells.SpineshatterDive.Cast();
            }
            return false;
        }

        private async Task<bool> DragonfireDive()
        {
            if (Shinra.Settings.DragoonDragonfire && !MovementManager.IsMoving && !RecentJump &&
                Core.Player.HasAura(MySpells.HeavyThrust.Name))
            {
                return await MySpells.DragonfireDive.Cast();
            }
            return false;
        }

        private async Task<bool> Geirskogul()
        {
            if (Shinra.Settings.DragoonGeirskogul && Core.Player.HasAura(MySpells.HeavyThrust.Name))
            {
                if (Resource.DragonGaze == 3 || !RecentJump && !Core.Player.HasAura(1243) && JumpCooldown > 25 && SpineCooldown > 25 ||
                    Core.Player.ClassLevel < 70)
                {
                    return await MySpells.Geirskogul.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Nastrond()
        {
            if (Shinra.Settings.DragoonGeirskogul && Core.Player.HasAura(MySpells.HeavyThrust.Name))
            {
                return await MySpells.Nastrond.Cast();
            }
            return false;
        }

        private async Task<bool> MirageDive()
        {
            if (Shinra.Settings.DragoonMirage && !MovementManager.IsMoving && !RecentJump && Core.Player.HasAura(MySpells.HeavyThrust.Name))
            {
                return await MySpells.MirageDive.Cast();
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> LifeSurge()
        {
            if (Shinra.Settings.DragoonLifeSurge && ActionManager.LastSpell.Name == MySpells.VorpalThrust.Name)
            {
                return await MySpells.LifeSurge.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Shinra.Settings.DragoonBloodForBlood)
            {
                return await MySpells.BloodForBlood.Cast();
            }
            return false;
        }

        private async Task<bool> BattleLitany()
        {
            if (Shinra.Settings.DragoonBattleLitany)
            {
                return await MySpells.BattleLitany.Cast();
            }
            return false;
        }

        private async Task<bool> BloodOfTheDragon()
        {
            if (Shinra.Settings.DragoonBloodOfTheDragon && !BloodActive &&
                (ActionManager.LastSpell.Name == MySpells.VorpalThrust.Name || ActionManager.LastSpell.Name == MySpells.Disembowel.Name))
            {
                return await MySpells.BloodOfTheDragon.Cast();
            }
            return false;
        }

        private async Task<bool> DragonSight()
        {
            if (!Shinra.Settings.DragoonDragonSight) return false;

            var target = !PartyManager.IsInParty && ChocoboManager.Summoned ? ChocoboManager.Object
                : Managers.DragonSight.FirstOrDefault();

            if (target == null) return false;

            return await MySpells.DragonSight.Cast(target);
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (Shinra.Settings.DragoonSecondWind && Core.Player.CurrentHealthPercent < Shinra.Settings.DragoonSecondWindPct)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Shinra.Settings.DragoonInvigorate && Core.Player.CurrentTPPercent < Shinra.Settings.DragoonInvigoratePct)
            {
                return await MySpells.Role.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Shinra.Settings.DragoonBloodbath && Core.Player.CurrentHealthPercent < Shinra.Settings.DragoonBloodbathPct)
            {
                return await MySpells.Role.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> Goad()
        {
            if (Shinra.Settings.DragoonGoad)
            {
                var target = Helpers.GoadManager.FirstOrDefault(gm => gm.CurrentTPPercent < Shinra.Settings.DragoonGoadPct);

                if (target != null)
                {
                    return await MySpells.Role.Goad.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> TrueNorth()
        {
            if (Shinra.Settings.DragoonTrueNorth)
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
