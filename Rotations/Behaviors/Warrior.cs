using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Warrior : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            switch (ShinraEx.Settings.RotationMode)
            {
                case Modes.Smart:
                {
                    Helpers.Debug("Combat - smart...");
                    if (ShinraEx.Settings.WarriorOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await LowBlow()) return true;
                    if (await Interject()) return true;
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

                case Modes.Single:
                {
                    Helpers.Debug("Combat - single...");
                    if (ShinraEx.Settings.WarriorOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await LowBlow()) return true;
                    if (await Interject()) return true;
                    if (await FellCleave()) return true;
                    if (await InnerBeast()) return true;
                    if (await StormsEye()) return true;
                    if (await StormsPath()) return true;
                    if (await Maim()) return true;
                    if (await ButchersBlock()) return true;
                    if (await SkullSunder()) return true;
                    return await HeavySwing();
                }

                case Modes.Multi:
                {
                    Helpers.Debug("Combat - multi...");
                    if (await Decimate()) return true;
                    if (await SteelCyclone()) return true;
                    if (await Overpower()) return true;
                    if (await StormsEye()) return true;
                    if (await StormsPath()) return true;
                    if (await Maim()) return true;
                    return await HeavySwing();
                }
            }

            return false;
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            Helpers.Debug("CombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
            if (ShinraEx.Settings.WarriorOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await ArmsLength()) return true;
            if (await Deliverance()) return true;
            if (await Defiance()) return true;
            if (await ThrillOfBattle()) return true;
            if (await Vengeance()) return true;
            if (await ShakeItOff()) return true;
            if (await Rampart()) return true;
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
            Helpers.Debug("Heal...");
            return await Equilibrium();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await Deliverance()) return true;
            return await Defiance();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            Helpers.Debug("Pull...");
            if (await Provoke()) return true;
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            Helpers.Debug("CombatPVP...");
            return false;
        }

        #endregion
    }
}