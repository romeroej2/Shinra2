using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class RedMage : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (ShinraEx.Settings.RotationMode == Modes.Smart)
            {
                if (ShinraEx.Settings.RedMageOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await EnchantedMoulinet()) return true;
                if (await Impact()) return true;
                if (await Scatter()) return true;
                if (await Veraero2()) return true;
                if (await Verthunder2()) return true;
                if (await Verholy()) return true;
                if (await Verflare()) return true;
                if (await EnchantedRiposte()) return true;
                if (await EnchantedZwerchhau()) return true;
                if (await EnchantedRedoublement()) return true;
                if (await Veraero()) return true;
                if (await Verthunder()) return true;
                if (await Verstone()) return true;
                if (await Verfire()) return true;
                if (await JoltII()) return true;
                if (await Jolt()) return true;
                return await Riposte();
            }
            if (ShinraEx.Settings.RotationMode == Modes.Single)
            {
                if (ShinraEx.Settings.RedMageOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await Scorch()) return true;
                if (await Verholy()) return true;
                if (await Verflare()) return true;
                if (await EnchantedRiposte()) return true;
                if (await EnchantedZwerchhau()) return true;
                if (await EnchantedRedoublement()) return true;
                if (await Veraero()) return true;
                if (await Verthunder()) return true;
                if (await Verstone()) return true;
                if (await Verfire()) return true;
                if (await Impact()) return true;
                if (await JoltII()) return true;
                if (await Jolt()) return true;
                return await Riposte();
            }
            /*
             * AoE rotation 
             * 1 - spame melee AoE cone
             * 2 - Alternate between Black & White
             * 3 - Use higher potency AoE after black/white
             */
            if (ShinraEx.Settings.RotationMode == Modes.Multi)
            {
                if (await EnchantedMoulinet()) return true;
                if (await Impact()) return true;
                if (await Scatter()) return true;
                if (await Veraero2()) return true;
                if (await Verthunder2()) return true;
                return await Riposte();
            }
            return false;
        }

        #endregion
        
        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
            if (ShinraEx.Settings.RedMageOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Embolden()) return true;
            if (await CorpsACorps()) return true;
            if (await Displacement()) return true;
            if (await Manafication()) return true;
            if (await Fleche()) return true;
            if (await ContreSixte()) return true;
            if (await Acceleration()) return true;
            if (await Swiftcast()) return true;
            return await LucidDreaming();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            if (await UpdateHealing()) return true;
            if (await Verraise()) return true;
            return await Vercure();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            return await ShinraEx.SummonChocobo();
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
            if (await CorpsACorpsPVP()) return true;
            if (await VerholyPVP()) return true;
            if (await EnchantedRedoublementPVP()) return true;
            if (await EnchantedZwerchhauPVP()) return true;
            if (await EnchantedRipostePVP()) return true;
            if (await ImpactPVP()) return true;
            if (await VeraeroPVP()) return true;
            if (await VerthunderPVP()) return true;
            if (await JoltIIPVP()) return true;
            if (await VerstonePVP()) return true;
            return await VerfirePVP();
        }

        #endregion
    }
}