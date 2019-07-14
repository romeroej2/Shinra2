using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Dragoon : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            switch (ShinraEx.Settings.RotationMode)
            {
                case Modes.Smart:
                {
                    Helpers.Debug("Combat - smart...");
                    if (ShinraEx.Settings.DragoonOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await SonicThrust()) return true;
                    if (await DoomSpike()) return true;
                    if (await WheelingThrust()) return true;
                    if (await FangAndClaw()) return true;
                    if (await ChaosThrust()) return true;
                    if (await Disembowel()) return true;
                    if (await FullThrust()) return true;
                    if (await VorpalThrust()) return true;
                    return await TrueThrust();
                }

                case Modes.Single:
                {
                    Helpers.Debug("Combat - single...");
                    if (ShinraEx.Settings.DragoonOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await WheelingThrust()) return true;
                    if (await FangAndClaw()) return true;
                    if (await ChaosThrust()) return true;
                    if (await Disembowel()) return true;
                    if (await FullThrust()) return true;
                    if (await VorpalThrust()) return true;
                    return await TrueThrust();
                }

                case Modes.Multi:
                {
                    Helpers.Debug("Combat - multi...");
                    if (await SonicThrust()) return true;
                    return await DoomSpike();
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
            if (ShinraEx.Settings.DragoonOpener) { if (await Helpers.ExecuteOpener()) return true; }
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
            await Helpers.UpdateParty();
            return await Jump();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            if (await SecondWind()) return true;
            return await Bloodbath();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            return await ShinraEx.SummonChocobo();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            Helpers.Debug("Pull...");
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            Helpers.Debug("CombatPVP...");
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