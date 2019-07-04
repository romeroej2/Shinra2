using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Ninja : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            switch (ShinraEx.Settings.RotationMode)
            {
                case Modes.Smart:
                {
                    Helpers.Debug("Combat - smart...");
                    if (ShinraEx.Settings.NinjaOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await TenChiJinBuff()) return true;
                    if (await Huton()) return true;
                    if (await Doton()) return true;
                    if (await Katon()) return true;
                    if (await Suiton()) return true;
                    if (await FumaShuriken()) return true;
                    if (await DeathBlossom()) return true;
                    if (await Duality()) return true;
                    if (await DualityActive()) return true;
                    if (await ShadowFang()) return true;
                    if (await ArmorCrush()) return true;
                    if (await AeolianEdge()) return true;
                    if (await GustSlash()) return true;
                    return await SpinningEdge();
                }

                case Modes.Single:
                {
                    Helpers.Debug("Combat - single...");
                    if (ShinraEx.Settings.NinjaOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await TenChiJinBuff()) return true;
                    if (await Huton()) return true;
                    if (await Suiton()) return true;
                    if (await FumaShuriken()) return true;
                    if (await Duality()) return true;
                    if (await DualityActive()) return true;
                    if (await ShadowFang()) return true;
                    if (await ArmorCrush()) return true;
                    if (await AeolianEdge()) return true;
                    if (await GustSlash()) return true;
                    return await SpinningEdge();
                }

                case Modes.Multi:
                {
                    Helpers.Debug("Combat - multi...");
                    if (await TenChiJinBuff()) return true;
                    if (await Huton()) return true;
                    if (await Doton()) return true;
                    if (await Katon()) return true;
                    if (await FumaShuriken()) return true;
                    if (await DeathBlossom()) return true;
                    if (await Duality()) return true;
                    if (await DualityActive()) return true;
                    if (await ShadowFang()) return true;
                    if (await ArmorCrush()) return true;
                    if (await AeolianEdge()) return true;
                    if (await GustSlash()) return true;
                    return await SpinningEdge();
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
            if (ShinraEx.Settings.NinjaOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await ShadeShift()) return true;
            if (await Shukuchi()) return true;
            if (await Assassinate()) return true;
            if (await Mug()) return true;
            if (await Jugulate()) return true;
            if (await Kassatsu()) return true;
            if (await TrickAttack()) return true;
            if (await DreamWithinADream()) return true;
            if (await HellfrogMedium()) return true;
            if (await Bhavacakra()) return true;
            if (await TenChiJin()) return true;
            if (await TrueNorth()) return true;
            if (await Invigorate()) return true;
            await Helpers.UpdateParty();
            return await Goad();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            if (await SecondWind()) return true;
            return await Bloodbath();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            return await Huton();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            Helpers.Debug("Pull...");
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