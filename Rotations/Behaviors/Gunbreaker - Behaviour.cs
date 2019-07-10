using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Gunbreaker : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
          if (await WickedTalon()) return true;
          if (await SavageClaw()) return true;
          if (await GnashingFang()) return true;
          if (await FatedCircle()) return true;
          if (await DemonSlaughter()) return true;
          if (await DemonSlice()) return true;
          if (await SonicBreak()) return true;
          if (await BurstStrike()) return true;
          if (await SolidBarrel()) return true;
          if (await BrutalShell()) return true;
          return await KeenEdge();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await NoMercy()) return true;
            if (await EyeGouge()) return true;
            if (await AbdomenTear()) return true;
            if (await JugularRip()) return true;
            if (await BowShock()) return true;
            return await BlastingZone();
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
            if (await ShinraEx.SummonChocobo()) return true;
            return false;
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            //if (Shinra.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await LightningShot()) return true;
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
