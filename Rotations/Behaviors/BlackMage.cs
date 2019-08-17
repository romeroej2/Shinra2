using System.Threading.Tasks;
using System.Windows.Media;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class BlackMage : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            Helpers.Debug("Combat...");

            /*
            if (MovementManager.IsMoving)
            {
                Logging.Write(Colors.Yellow, @"[ShinraEx] Debug: Skiping Combat because we are moving!...");                
                return false;
            }*/

            if (ShinraEx.Settings.RotationMode == Modes.Multi || ShinraEx.Settings.RotationMode == Modes.Smart &&
                Helpers.EnemiesNearTarget(5) > 2)
            {
                return await Multi();
            }
            return await Single();
        }

        private async Task<bool> Single()
        {
            Helpers.Debug("Combat - single...");
            if (ShinraEx.Settings.BlackMageOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Transpose()) return true;
            if (await Triplecast()) return true;
            if (await Swiftcast()) return true;
            if (await Sharpcast()) return true;
            if (await MaintainPoliglot()) return true;

            if (await Thundercloud()) return true;                       
            if (await Xenoglossy()) return true;
            if (await Foul()) return true;
            if (await ThunderIII()) return true;
            if (await Thunder()) return true;
            if (await BlizzardIV()) return true;
            if (await Despair()) return true;
            if (await FireIV()) return true;
            if (await FireIII()) return true;
            if (await Fire()) return true;
            if (await BlizzardIII()) return true;
            if (await Blizzard()) return true;
            return await Scathe();
        }

        private async Task<bool> Multi()
        {
            Helpers.Debug("Combat - multi...");
            //if (await Drain()) return true; //Deprecated
            //if (await Xenoglossy()) return true;
            if (await Foul()) return true;
            if (await ThunderIV()) return true;
            if (await ThunderII()) return true;
            if (await BlizzardIV()) return true;
            if (await FireIIIMulti()) return true;
            if (await Flare()) return true;
            if (await FireII()) return true;
            if (await BlizzardIII()) return true;
            if (await TransposeMulti()) return true;
            if (await FireMulti()) return true;
            return await BlizzardMulti();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            Helpers.Debug("CombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
            if (ShinraEx.Settings.BlackMageOpener) { if (await Helpers.ExecuteOpener()) return true; }
            
            if (await BetweenTheLines()) return true;
            if (await UmbralSoul()) return true;
            if (await Convert()) return true;
            if (await Enochian()) return true;
            
            if (await LeyLines()) return true;
            return await LucidDreaming();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            if ( await Helpers.UseHealthPotion()) return true;
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
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            Helpers.Debug("CombatPVP...");
            if (await ThunderIIIPVP()) return true;
            if (await ThunderPVP()) return true;
            if (await FlarePVP()) return true;
            if (await FoulPVP()) return true;
            if (await FireIVPVP()) return true;
            if (await EnochianPVP()) return true;
            if (await FirePVP()) return true;
            if (await BlizzardIVPVP()) return true;
            return await BlizzardPVP();
        }

        #endregion
    }
}