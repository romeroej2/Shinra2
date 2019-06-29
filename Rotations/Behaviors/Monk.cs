using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Monk : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (Shinra.Settings.RotationMode == Modes.Smart)
            {
                if (Shinra.Settings.MonkOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await Rockbreaker()) return true;
                if (await Demolish()) return true;
                if (await SnapPunch()) return true;
                if (await DragonKick()) return true;
                if (await TwinSnakes()) return true;
                if (await TrueStrike()) return true;
                return await Bootshine();
            }
            if (Shinra.Settings.RotationMode == Modes.Single)
            {
                if (Shinra.Settings.MonkOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await Demolish()) return true;
                if (await SnapPunch()) return true;
                if (await DragonKick()) return true;
                if (await TwinSnakes()) return true;
                if (await TrueStrike()) return true;
                return await Bootshine();
            }
            if (Shinra.Settings.RotationMode == Modes.Multi)
            {
                if (await Rockbreaker()) return true;
                if (await TwinSnakes()) return true;
                if (await TrueStrike()) return true;
                if (await DragonKick()) return true;
                return await Bootshine();
            }
            return false;
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Shinra.ChocoboStance()) return true;
            if (Shinra.Settings.MonkOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await FistsOfFire()) return true;
            if (await FistsOfWind()) return true;
            if (await FistsOfEarth()) return true;
            if (await FireTackle()) return true;
            if (await ShoulderTackle()) return true;
            if (await PerfectBalance()) return true;
            if (await TrueNorth()) return true;
            if (await InternalRelease()) return true;
            if (await RiddleOfFire()) return true;
            if (await ForbiddenChakra()) return true;
            if (await Brotherhood()) return true;
            if (await ElixirField()) return true;
            if (await HowlingFist()) return true;
            if (await SteelPeak()) return true;
            if (await Invigorate()) return true;
            await Helpers.UpdateParty();
            return await Goad();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            if (await SecondWind()) return true;
            return await Bloodbath();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Meditation()) return true;
            if (await FormShift()) return true;
            if (await FistsOfFire()) return true;
            if (await FistsOfWind()) return true;
            return await FistsOfEarth();
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
            if (await RiddleOfFirePVP()) return true;
            if (await TornadoKickPVP()) return true;
            if (await TheForbiddenChakraPVP()) return true;
            if (await SomersaultPVP()) return true;
            if (await DemolishPVP()) return true;
            if (await SnapPunchPVP()) return true;
            return await FormShiftPVP();
        }

        #endregion
    }
}