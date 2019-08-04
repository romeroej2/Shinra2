using System.Threading.Tasks;

namespace ShinraCo.Rotations
{
    public sealed partial class Machinist : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (await CleanShot()) return true;
            if (await SlugShot()) return true;

            if (await HeatBlast()) return true;
            if (await Bioblaster()) return true;
			if (await Crossbow()) return true;
			if (await SpreadShot()) return true;
			if (await Drill()) return true;
			if (await HotShot()) return true;
            return await SplitShot();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
			if (await Reassemble()) return true;
			if (await GaussRound()) return true;
            if (await Ricochet()) return true;
            if (await RookAutoturret()) return true;
            if (await RookOverdrive()) return true;
			if (await BarrelStabilizer()) return true;
			if (await Wildfire()) return true;
            if (await Hypercharge()) return true;
            return false;
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            return await SecondWind();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            if (await ShinraEx.SummonChocobo()) return true;
			return false;
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
        {;
            return false;
        }

        #endregion
    }
}