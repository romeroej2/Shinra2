using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Gunbreaker : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {

            if (await FatedCircle()) return true;
            if (await DemonSlaughter()) return true;
            if (await WickedTalon()) return true;
            if (await SavageClaw()) return true;
            if (await SolidBarrel()) return true;
            if (await BrutalShell()) return true;
     
            if (await BurstStrike()) return true;
            if (await SonicBreak()) return true;
            if (await DemonSlice()) return true;
            if (await GnashingFang()) return true;
            return await KeenEdge();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
			if (await Superbolide()) return true;
			if (await Nebula()) return true;
			if (await Rampart()) return true;
			if (await Camouflage()) return true;
			if (await Aurora()) return true;

            if (await AbdomenTear()) return true;
            if (await JugularRip()) return true;

            if (await Bloodfest()) return true;
            if (await NoMercy()) return true;

            if (await BowShock()) return true;
            if (await DangerZone()) return true;
            return await EyeGouge();
 
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
            return await ShinraEx.SummonChocobo();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
           if (await LightningShot()) return true;
           if (await RoughDivide()) return true;
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