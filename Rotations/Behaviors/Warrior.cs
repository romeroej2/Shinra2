using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Warrior : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (Shinra.Settings.RotationMode == Modes.Smart)
            {
                if (Shinra.Settings.WarriorOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await Decimate()) return true;
                if (await SteelCyclone()) return true;
                if (await FellCleave()) return true;
                if (await InnerBeast()) return true;
                if (await Overpower()) return true;
                if (await StormsEye()) return true;
                if (await StormsPath()) return true;
                if (await Maim()) return true;
                if (await ButchersBlock()) return true;
                if (await SkullSunder()) return true;
                return await HeavySwing();
            }
            if (Shinra.Settings.RotationMode == Modes.Single)
            {
                if (Shinra.Settings.WarriorOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await FellCleave()) return true;
                if (await InnerBeast()) return true;
                if (await StormsEye()) return true;
                if (await StormsPath()) return true;
                if (await Maim()) return true;
                if (await ButchersBlock()) return true;
                if (await SkullSunder()) return true;
                return await HeavySwing();
            }
            if (Shinra.Settings.RotationMode == Modes.Multi)
            {
                if (await Decimate()) return true;
                if (await SteelCyclone()) return true;
                if (await Overpower()) return true;
                if (await StormsEye()) return true;
                if (await StormsPath()) return true;
                if (await Maim()) return true;
                return await HeavySwing();
            }
            return false;
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Shinra.ChocoboStance()) return true;
            if (Shinra.Settings.WarriorOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Deliverance()) return true;
            if (await Defiance()) return true;
            if (await ThrillOfBattle()) return true;
            if (await Vengeance()) return true;
            if (await ShakeItOff()) return true;
            if (await Rampart()) return true;
            if (await Convalescence()) return true;
            if (await Anticipation()) return true;
            if (await Awareness()) return true;
            if (await Reprisal()) return true;
            if (await Onslaught()) return true;
            if (await EquilibriumTP()) return true;
            if (await InnerRelease()) return true;
            if (await Unchained()) return true;
            if (await Berserk()) return true;
            if (await Upheaval()) return true;
            return await Infuriate();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            return await Equilibrium();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Deliverance()) return true;
            return await Defiance();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            return false;
        }

        #endregion
    }
}