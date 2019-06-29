using System.Threading.Tasks;

namespace ShinraCo.Rotations
{
    public sealed partial class Summoner : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (Shinra.Settings.SummonerOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Drain()) return true;
            if (await MiasmaIII()) return true;
            if (await Miasma()) return true;
            if (await BioIII()) return true;
            if (await BioII()) return true;
            if (await Bio()) return true;
            if (await RuinII()) return true;
            if (await TriBind()) return true;
            if (await RuinIII()) return true;
            return await Ruin();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Shinra.ChocoboStance()) return true;
            if (Shinra.Settings.SummonerOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Sic()) return true;
            if (await SummonIII()) return true;
            if (await SummonII()) return true;
            if (await Summon()) return true;
            if (await EnkindleBahamut()) return true;
            if (await SummonBahamut()) return true;
            if (await Deathflare()) return true;
            if (await DreadwyrmTrance()) return true;
            if (await TriDisaster()) return true;
            if (await Bane()) return true;
            if (await Painflare()) return true;
            if (await Fester()) return true;
            if (await EnergyDrain()) return true;
            if (await Aetherflow()) return true;
            if (await Rouse()) return true;
            if (await Enkindle()) return true;
            if (await ShadowFlare()) return true;
            if (await Aetherpact()) return true;
            if (await Addle()) return true;
            return await LucidDreaming();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            if (await UpdateHealing()) return true;
            if (await Resurrection()) return true;
            if (await Sustain()) return true;
            return await Physick();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await AetherflowPreCombat()) return true;
            if (await SummonIII()) return true;
            if (await SummonII()) return true;
            if (await Summon()) return true;
            return await Obey();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            if (Shinra.Settings.SummonerOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await TriDisaster()) return true;
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            if (await EnkindleBahamutPVP()) return true;
            if (await SummonBahamutPVP()) return true;
            if (await DeathflarePVP()) return true;
            if (await DreadwyrmTrancePVP()) return true;
            if (await FesterPVP()) return true;
            if (await EnergyDrainPVP()) return true;
            if (await AetherflowPVP()) return true;
            if (await WitherPVP()) return true;
            if (await MiasmaIIIPVP()) return true;
            if (await BioIIIPVP()) return true;
            return await RuinIIIPVP();
        }

        #endregion
    }
}