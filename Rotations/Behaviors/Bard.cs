using System.Threading.Tasks;

namespace ShinraCo.Rotations
{
    public sealed partial class Bard : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            Helpers.Debug("Combat...");
            if (ShinraEx.Settings.BardOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await BarrageActive()) return true;
            if (await DotSnapshot()) return true;
            if (await IronJaws()) return true;
            if (await RefulgentArrow()) return true;
            if (await StraightShotBuff()) return true;
            if (await QuickNock()) return true;
            if (await Windbite()) return true;
            if (await VenomousBite()) return true;
            if (await StraightShot()) return true;
            return await HeavyShot();
        }

        #endregion
        
        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            Helpers.Debug("CombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
            if (ShinraEx.Settings.BardOpener) { if (await Helpers.ExecuteOpener()) return true; }
            // Songs
            if (await WanderersMinuet()) return true;
            if (await MagesBallad()) return true;
            if (await ArmysPaeon()) return true;
            // Buffs
            if (await BattleVoice()) return true;
            if (await RagingStrikes()) return true;
            if (await Barrage()) return true;
            // Off-GCDs
            if (await PitchPerfect()) return true;
            if (await MiserysEnd()) return true;
            if (await RainOfDeath()) return true;
            if (await Bloodletter()) return true;
            if (await EmpyrealArrow()) return true;
            if (await Sidewinder()) return true;
            // Role
            await Helpers.UpdateParty();
            if (await Palisade()) return true;
            if (await Refresh()) return true;
            if (await Tactician()) return true;
            return await Invigorate();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            return await SecondWind();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            return await Peloton();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            Helpers.Debug("Pull...");
            if (await FoeRequiem()) return true;
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            Helpers.Debug("CombatPVP...");
            if (await TroubadourPVP()) return true;
            if (await BarragePVP()) return true;
            if (await BloodletterPVP()) return true;
            if (await WanderersMinuetPVP()) return true;
            if (await ArmysPaeonPVP()) return true;
            if (await EmpyrealArrowPVP()) return true;
            if (await SidewinderPVP()) return true;
            if (await StormbitePVP()) return true;
            return await StraightShotPVP();
        }

        #endregion
    }
}