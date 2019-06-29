using System.Threading.Tasks;

namespace ShinraCo.Rotations
{
    public sealed partial class Machinist : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (Shinra.Settings.MachinistOpener) {if (await Helpers.ExecuteOpener()) return true; }
            if (await HotShot()) return true;
            if (await Flamethrower()) return true;
            if (await SpreadShot()) return true;
            if (await Cooldown()) return true;
            if (await CleanShot()) return true;
            if (await SlugShot()) return true;
            return await SplitShot();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Shinra.ChocoboStance()) return true;
            if (Shinra.Settings.MachinistOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await FlamethrowerBuff()) return true;
            if (await BarrelStabilizer()) return true;
            if (await GaussBarrel()) return true;
            if (await BishopAutoturret()) return true;
            if (await RookAutoturret()) return true;
            if (await BishopOverdrive()) return true;
            if (await RookOverdrive()) return true;
            if (await Hypercharge()) return true;
            if (await Heartbreak()) return true;
            if (await GaussRound()) return true;
            if (await Reload()) return true;
            if (await Wildfire()) return true;
            if (await Reassemble()) return true;
            if (await QuickReload()) return true;
            if (await RapidFire()) return true;
            if (await Ricochet()) return true;
            // Role
            await Helpers.UpdateParty();
            if (await Palisade()) return true;
            if (await Refresh()) return true;
            if (await Tactician()) return true;
            return await Invigorate();
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
            if (await Shinra.SummonChocobo()) return true;
            if (await QuickReloadPre()) return true;
            if (await GaussBarrel()) return true;
            return await Peloton();
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