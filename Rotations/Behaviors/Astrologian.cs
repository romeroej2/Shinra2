using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Astrologian : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            switch (ShinraEx.Settings.RotationMode)
            {
                case Modes.Smart:
                {
                    Helpers.Debug("Combat - smart ...");
                    if (await EarthlyStar()) return true;
                    if (await Gravity()) return true;
                    if (await CombustIII()) return true;
                    if (await CombustII()) return true;
                    if (await Combust()) return true;
                    if (await MaleficIV()) return true;
                    if (await MaleficIII()) return true;
                    if (await MaleficII()) return true;
                    return await Malefic();
                }

                case Modes.Single:
                {
                    Helpers.Debug("Combat - single ...");
                    if (await CombustIII()) return true;
                    if (await CombustII()) return true;
                    if (await Combust()) return true;
                    if (await MaleficIV()) return true;
                    if (await MaleficIII()) return true;
                    if (await MaleficII()) return true;
                    return await Malefic();
                }

                case Modes.Multi:
                {
                    Helpers.Debug("Combat - multi...");
                    if (await EarthlyStar()) return true;
                    if (await Gravity()) return true;
                    if (await CombustII()) return true;
                    return await Combust();
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
            if (await Play()) return true;
            if (await Divination()) return true;
            if (await CelestialOpposition()) return true;
            if (await LucidDreaming()) return true;
            if (await NeutralSect()) return true;

            if (ShinraEx.Settings.AstrologianDraw)
            {
                if (await LordOfCrowns()) return true;
                if (await SleeveDraw()) return true;
                if (await Draw()) return true;

                if (await Redraw()) return true;
                if (await MinorArcana()) return true;
                if (await Undraw()) return true;

                if (await DrawTargetted()) return true;
            }

            return false;
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            if (await UpdateHealing()) return true;
            if (await StopCasting()) return true;
            if (await EssentialDignity()) return true;
            if (await CelestialIntersection()) return true;
            if (await Lightspeed()) return true;
            if (await Synastry()) return true;
            // if (await EyeForAnEye()) return true;

            if (await LadyOfCrowns()) return true;
            if (await AspectedHelios()) return true;
            if (await Horoscope()) return true;
            if (await Helios()) return true;
            if (await BeneficII()) return true;
            if (await Benefic()) return true;
            if (await AspectedBenefic()) return true;
            if (await Ascend()) return true;
            return await Esuna();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await NocturnalSect()) return true;
            if (await DiurnalSect()) return true;
            if (ShinraEx.Settings.AstrologianDraw && ShinraEx.Settings.AstrologianCardPreCombat)
            {
                if (await Draw()) return true;
                if (await Redraw()) return true;
                if (await MinorArcana()) return true;
                if (await Undraw()) return true;
            }

            return false;
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            Helpers.Debug("Pull...");
            if (await CombustII()) return true;
            if (await Combust()) return true;
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