using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class DarkKnight : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (Shinra.Settings.RotationMode == Modes.Smart)
            {
                if (Shinra.Settings.DarkKnightOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await Quietus()) return true;
                if (await AbyssalDrain()) return true;
                if (await Unleash()) return true;
                if (await Bloodspiller()) return true;
                if (await Souleater()) return true;
                if (await SyphonStrike()) return true;
                if (await PowerSlash()) return true;
                if (await SpinningSlash()) return true;
                return await HardSlash();
            }
            if (Shinra.Settings.RotationMode == Modes.Single)
            {
                if (Shinra.Settings.DarkKnightOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await Bloodspiller()) return true;
                if (await Souleater()) return true;
                if (await SyphonStrike()) return true;
                if (await PowerSlash()) return true;
                if (await SpinningSlash()) return true;
                return await HardSlash();
            }
            if (Shinra.Settings.RotationMode == Modes.Multi)
            {
                if (await Quietus()) return true;
                if (await AbyssalDrain()) return true;
                if (await Unleash()) return true;
                if (await Souleater()) return true;
                if (await SyphonStrike()) return true;
                return await HardSlash();
            }
            return false;
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Shinra.ChocoboStance()) return true;
            if (Shinra.Settings.DarkKnightOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Grit()) return true;
            if (await LivingDead()) return true;
            if (await ShadowWall()) return true;
            if (await BlackestNight()) return true;
            if (await Delirium()) return true;
            if (await Rampart()) return true;
            if (await Convalescence()) return true;
            if (await Anticipation()) return true;
            if (await Awareness()) return true;
            if (await Reprisal()) return true;
            if (await Plunge()) return true;
            if (await Darkside()) return true;
            if (await BloodPrice()) return true;
            if (await BloodWeapon()) return true;
            if (await CarveAndSpit()) return true;
            if (await SaltedEarth()) return true;
            return await DarkArts();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            return false;
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Grit()) return true;
            return await Darkside();
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