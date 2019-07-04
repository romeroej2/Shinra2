using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Samurai : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            switch (ShinraEx.Settings.RotationMode)
            {
                case Modes.Smart:
                {
                    Helpers.Debug("Combat - smart...");
                    if (ShinraEx.Settings.SamuraiOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await MidareSetsugekka()) return true;
                    if (await TenkaGoken()) return true;
                    if (await Higanbana()) return true;
                    if (await Kaiten()) return true;
                    if (await Meikyo()) return true;
                    if (await Kasha()) return true;
                    if (await Gekko()) return true;
                    if (await ShifuBuff()) return true;
                    if (await JinpuBuff()) return true;
                    if (await Mangetsu()) return true;
                    if (await Oka()) return true;
                    if (await Fuga()) return true;
                    if (await YukikazeDebuff()) return true;
                    if (await Shifu()) return true;
                    if (await Jinpu()) return true;
                    if (await Yukikaze()) return true;
                    if (await Enpi()) return true;
                    return await Hakaze();
                }

                case Modes.Single:
                {
                    Helpers.Debug("Combat - single...");
                    if (ShinraEx.Settings.SamuraiOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await MidareSetsugekka()) return true;
                    if (await Higanbana()) return true;
                    if (await Kaiten()) return true;
                    if (await Meikyo()) return true;
                    if (await Kasha()) return true;
                    if (await Gekko()) return true;
                    if (await ShifuBuff()) return true;
                    if (await JinpuBuff()) return true;
                    if (await YukikazeDebuff()) return true;
                    if (await Shifu()) return true;
                    if (await Jinpu()) return true;
                    if (await Yukikaze()) return true;
                    if (await Enpi()) return true;
                    return await Hakaze();
                }

                case Modes.Multi:
                {
                    Helpers.Debug("Combat - multi...");
                    if (await MidareSetsugekka()) return true;
                    if (await TenkaGoken()) return true;
                    if (await Kaiten()) return true;
                    if (await Meikyo()) return true;
                    if (await Kasha()) return true;
                    if (await Gekko()) return true;
                    if (await ShifuBuff()) return true;
                    if (await JinpuBuff()) return true;
                    if (await Mangetsu()) return true;
                    if (await Oka()) return true;
                    if (await Fuga()) return true;
                    if (await Enpi()) return true;
                    return await Hakaze();
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
            if (ShinraEx.Settings.SamuraiOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Meditate()) return true;
            if (await HissatsuKaiten()) return true;
            if (await HissatsuGyoten()) return true;
            if (await TrueNorth()) return true;
            if (await MeikyoShisui()) return true;
            if (await HissatsuGuren()) return true;
            if (await HissatsuKyuten()) return true;
            if (await HissatsuSeigan()) return true;
            if (await HissatsuShinten()) return true;
            if (await Hagakure()) return true;
            if (await Ageha()) return true;
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
            if (await MercifulEyes()) return true;
            return await Bloodbath();
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
            if (await HissatsuGyoten()) return true;
            if (await Enpi()) return true;
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            Helpers.Debug("CombatPVP...");
            if (await MeikyoShisuiPVP()) return true;
            if (await HissatsuShintenPVP()) return true;
            if (await MidareSetsugekkaPVP()) return true;
            if (await HiganbanaPVP()) return true;
            if (await YukikazePVP()) return true;
            if (await GekkoPVP()) return true;
            if (await KashaPVP()) return true;
            return await EnpiPVP();
        }

        #endregion
    }
}