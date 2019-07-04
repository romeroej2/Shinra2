using System.Threading.Tasks;

namespace ShinraCo.Rotations
{
    public sealed partial class Scholar : Rotation
    {
        #region Combat
		
        public override async Task<bool> Combat()
        {
            Helpers.Debug("Combat...");
            if (await Biolysis()) return true;
            if (await BioII()) return true;
            if (await Bio()) return true;
            if (await BroilIII()) return true;
            if (await BroilII()) return true;
            if (await Broil()) return true;
            return await Ruin();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            Helpers.Debug("CombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
            // if (await SummonII()) return true;
            // if (await Summon()) return true;
            if (await Aetherflow()) return true;
            if (await LucidDreaming()) return true;
            // if (await Rouse()) return true;
            if (await ChainStrategem()) return true;
            // if (await ClericStance()) return true;
            // if (await Bane()) return true;
            // if (await EnergyDrain()) return true;
            return await ChainStrategem();//await ShadowFlare();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            if (await UpdateHealing()) return true;
            if (await StopCasting()) return true;
            if (await Lustrate()) return true;
            // if (await Largesse()) return true;
            // if (await EyeForAnEye()) return true;
            if (await Aetherpact()) return true;
            if (await Indomitability()) return true;
            if (await Succor()) return true;
            if (await Adloquium()) return true;
            if (await Excogitation()) return true;
            if (await Physick()) return true;
            if (await Resurrection()) return true;
            if (await Esuna()) return true;
            return false; //await Protect();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await Aetherflow()) return true;
            // if (await SummonII()) return true;
            return false; //await Summon();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            Helpers.Debug("Pull...");
			if (await Biolysis()) return true;
            if (await BioII()) return true;
            if (await Bio()) return true;
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