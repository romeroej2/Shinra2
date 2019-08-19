using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class WhiteMage : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            switch (ShinraEx.Settings.RotationMode)
            {
                case Modes.Smart:
                {
                    Helpers.Debug("Combat - smart...");
                    if (await AfflatusMisery()) return true;
                    if (await Holy()) return true;
                    if (await Dia()) return true;
                    if (await AeroII()) return true;
                    if (await Aero()) return true;
                    if (await Glare()) return true;
                    if (await StoneIV()) return true;
                    if (await StoneIII()) return true;
                    if (await StoneII()) return true;
                    if (await Stone()) return true;
                    return await FluidAura();
                }

                case Modes.Single:
                {
                    Helpers.Debug("Combat - single...");
                    if (await Dia()) return true;
                    if (await AeroII()) return true;
                    if (await Aero()) return true;
                    if (await Glare()) return true;
                    if (await StoneIV()) return true;
                    if (await StoneIII()) return true;
                    if (await StoneII()) return true;
                    if (await Stone()) return true;
                    return await FluidAura();
                }

                case Modes.Multi:
                {
                    Helpers.Debug("Combat - multi...");
                    if (await AfflatusMisery()) return true;
                    return await Holy();
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
            if (await Temperance()) return true;
            return await LucidDreaming();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            if (await UpdateHealing()) return true;
            if (await StopCasting()) return true;
            if (await Benediction()) return true;
            if (await Tetragrammaton()) return true;
            if (await PresenceOfMind()) return true;
            if (await PlenaryIndulgence()) return true;
            if (await Assize()) return true;
            if (await AfflatusRapture()) return true;
            if (await MedicaII()) return true;
            if (await Asylum()) return true;
            if (await Medica()) return true;
            if (await CureIII()) return true;
            if (await AfflatusSolace()) return true;
            if (await CureII()) return true;
            if (await DivineBenison()) return true;
            if (await Cure()) return true;
            if (await Regen()) return true;
            if (await Raise()) return true;
            return await Esuna();
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
            if (await Dia()) return true;
            if (await AeroII()) return true;
            if (await Aero()) return true;
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