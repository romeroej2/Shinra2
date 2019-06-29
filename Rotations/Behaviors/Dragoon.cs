using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Dragoon : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (Shinra.Settings.RotationMode == Modes.Smart)
            {
                if (Shinra.Settings.DragoonOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await SonicThrust()) return true;
                if (await DoomSpike()) return true;
                if (await WheelingThrust()) return true;
                if (await FangAndClaw()) return true;
                if (await ChaosThrust()) return true;
                if (await Disembowel()) return true;
                if (await FullThrust()) return true;
                if (await VorpalThrust()) return true;
                if (await HeavyThrust()) return true;
                if (await ImpulseDrive()) return true;
                return await TrueThrust();
            }
            if (Shinra.Settings.RotationMode == Modes.Single)
            {
                if (Shinra.Settings.DragoonOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await WheelingThrust()) return true;
                if (await FangAndClaw()) return true;
                if (await ChaosThrust()) return true;
                if (await Disembowel()) return true;
                if (await FullThrust()) return true;
                if (await VorpalThrust()) return true;
                if (await HeavyThrust()) return true;
                if (await ImpulseDrive()) return true;
                return await TrueThrust();
            }
            if (Shinra.Settings.RotationMode == Modes.Multi)
            {
                if (await SonicThrust()) return true;
                if (await DoomSpike()) return true;
                return await HeavyThrust();
            }
            return false;
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Shinra.ChocoboStance()) return true;
            if (Shinra.Settings.DragoonOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await BloodOfTheDragon()) return true;
            if (await DragonSight()) return true;
            if (await BloodForBlood()) return true;
            if (await TrueNorth()) return true;
            if (await BattleLitany()) return true;
            if (await LifeSurge()) return true;
            if (await Nastrond()) return true;
            if (await MirageDive()) return true;
            if (await Geirskogul()) return true;
            if (await DragonfireDive()) return true;
            if (await SpineshatterDive()) return true;
            if (await Jump()) return true;
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
            return await Shinra.SummonChocobo();
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
            if (await NastrondPVP()) return true;
            if (await GeirskogulPVP()) return true;
            if (await BloodOfTheDragonPVP()) return true;
            if (await SpineshatterDivePVP()) return true;
            if (await JumpPVP()) return true;
            if (await SkewerPVP()) return true;
            if (await WheelingThrustPVP()) return true;
            if (await ChaosThrustPVP()) return true;
            return await FullThrustPVP();
        }

        #endregion
    }
}