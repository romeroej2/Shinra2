using System.Threading.Tasks;

namespace ShinraCo.Rotations
{
    public sealed partial class Summoner : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (ShinraEx.Settings.SummonerOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await MiasmaIII()) return true;
            if (await Miasma()) return true;
            if (await BioIII()) return true;
            if (await BioII()) return true;
            if (await Bio()) return true;
            if (await BrandOfPurgatory()) return true;
            if (await FountainOfFire()) return true;
            if (await RuinII()) return true;
            if (await Outburst()) return true;
            if (await RuinIII()) return true;
            return await Ruin();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
            if (ShinraEx.Settings.SummonerOpener) { if (await Helpers.ExecuteOpener()) return true; }
            //Pets
            if (await Sic()) return true;
            if (await SummonIII()) return true;
            if (await SummonII()) return true;
            if (await Summon()) return true;
            //Dot Refresh
            if (await TriDisaster()) return true;
            //Bahamut
            if (await EnkindleBahamut()) return true;
            if (await SummonBahamut()) return true;
            //Phoenix
            if (await EnkindlePhoenix()) return true;
            if (await FirebirdTrance()) return true;
            //Dread Trance
            if (await Deathflare()) return true;
            if (await DreadwyrmTrance()) return true;
            //General
            if (await Bane()) return true;
            if (await Aetherpact()) return true;
            if (await Painflare()) return true;
            if (await Fester()) return true;
            if (await EnergySiphon()) return true;
            if (await EnergyDrain()) return true;
            if (await Enkindle()) return true;
            if (await Addle()) return true;
            return await LucidDreaming();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            if (await UpdateHealing()) return true;
            if (await Resurrection()) return true;
            return await Physick();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            return await ShinraEx.SummonChocobo();
            //if (await SummonIII()) return true;
            //if (await SummonII()) return true;
            //if (await Summon()) return true;
            //return await Obey();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            if (ShinraEx.Settings.SummonerOpener) { if (await Helpers.ExecuteOpener()) return true; }
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