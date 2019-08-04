using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Dancer : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (await Emboite()) return true;
            if (await Entrechat()) return true;
            if (await Jete()) return true;
            if (await Pirouette()) return true;
            if (await StandardStep()) return true;
            if (await StandardFinish()) return true;
            if (await TechnicalStep()) return true;
            if (await TechnicalFinish()) return true;
            if (await SaberDance()) return true;
            if (await RisingWindmill()) return true;
            if (await Fountainfall()) return true;
            if (await ReverseCascade()) return true;
            if (await Bloodshower()) return true;
            if (await Bladeshower()) return true;
            if (await Windmill()) return true;
            if (await Fountain()) return true;
            return await Cascade();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Devilment()) return true;
            if (await Flourish()) return true;
            if (await FanDanceIII()) return true;
            if (await FanDanceII()) return true;
            return await FanDanceI();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            if (await CuringWaltz()) return true;
            return await SecondWind();
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
            return false;
        }

        #endregion
    }
}
