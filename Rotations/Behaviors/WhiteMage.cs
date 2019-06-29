using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class WhiteMage : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (Shinra.Settings.RotationMode == Modes.Smart)
            {
                if (await AeroIII()) return true;
                if (await Holy()) return true;
                if (await AeroII()) return true;
                if (await Aero()) return true;
                if (await StoneIV()) return true;
                if (await StoneIII()) return true;
                if (await StoneII()) return true;
                return await Stone();
            }
            if (Shinra.Settings.RotationMode == Modes.Single)
            {
                if (await AeroIII()) return true;
                if (await AeroII()) return true;
                if (await Aero()) return true;
                if (await StoneIV()) return true;
                if (await StoneIII()) return true;
                if (await StoneII()) return true;
                return await Stone();
            }
            if (Shinra.Settings.RotationMode == Modes.Multi)
            {
                if (await AeroIII()) return true;
                return await Holy();
            }
            return false;
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Shinra.ChocoboStance()) return true;
            if (await LucidDreaming()) return true;
            return await ClericStance();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            if (await UpdateHealing()) return true;
            if (await StopCasting()) return true;
            if (await Benediction()) return true;
            if (await Tetragrammaton()) return true;
            if (await PresenceOfMind()) return true;
            if (await Largesse()) return true;
            if (await EyeForAnEye()) return true;
            if (await PlenaryIndulgence()) return true;
            if (await Assize()) return true;
            if (await MedicaII()) return true;
            if (await Medica()) return true;
            if (await CureII()) return true;
            if (await Cure()) return true;
            if (await Regen()) return true;
            if (await Raise()) return true;
            if (await Esuna()) return true;
            return await Protect();
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
            if (await AeroII()) return true;
            if (await Aero()) return true;
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