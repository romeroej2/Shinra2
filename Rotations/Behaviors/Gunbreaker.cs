using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Gunbreaker : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            Helpers.Debug("Combat...");
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
            Helpers.Debug("CombatBuff...");
            if (await Bloodfest()) return true;
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
            Helpers.Debug("Heal...");
            return false;
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
            //if (Shinra.Settings.GunbreakerOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await LightningShot()) return true;
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