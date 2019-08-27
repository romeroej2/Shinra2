using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class DarkKnight : Rotation
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
                Helpers.EnemiesNearTarget(5) >= 2)
            {
                return await Multi();
            }
            return await Single();
        }



        private async Task<bool> Single()
        {
            Helpers.Debug("Combat - single...");
          
            if (ShinraEx.Settings.DarkKnightOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Interject()) return true;
            if (await Bloodspiller()) return true;
            if (await EdgeOfDarkness()) return true;
            if (await FloodOfDarkness()) return true;
            if (await CarveAndSpit()) return true;
            if (await Plunge()) return true;
            if (await AbyssalDrain()) return true;


            //if (await SpinningSlash()) return true;
            
            //if (await Unmend()) return true;
            //if (await LowBlow()) return true;
            //if (await Interject()) return true;
            //if (await Quietus()) return true;
            //if (await Unleash()) return true;

            if (await Souleater()) return true;
            if (await SyphonStrike()) return true;

          

            return await HardSlash();
        }

        private async Task<bool> Multi()
        {
            Helpers.Debug("Combat - multi...");
            if (await Interject()) return true;
            if (await Unleash()) return true;
            if (await StalwartSoul()) return true;
            if (await Quietus()) return true;
            //if (await Bloodspiller()) return true;
            if (await EdgeOfDarkness()) return true;
            if (await FloodOfDarkness()) return true;
            if (await CarveAndSpit()) return true;
            if (await Plunge()) return true;
            if (await AbyssalDrain()) return true;


            //if (await SpinningSlash()) return true;

            //if (await Unmend()) return true;
            //if (await LowBlow()) return true;
            
            
            

            if (await Souleater()) return true;
            if (await SyphonStrike()) return true;



            return await HardSlash();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            Helpers.Debug("CombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
            if (ShinraEx.Settings.DarkKnightOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await LivingShadow()) return true;
            if (await ArmsLength()) return true;
            if (await Grit()) return true;
            if (await LivingDead()) return true;
            if (await ShadowWall()) return true;
            if (await BlackestNight()) return true;
            if (await Rampart()) return true;
            if (await ArmsLength()) return true;
            if (await Delirium()) return true;
            if (await Reprisal()) return true;            
            if (await BloodWeapon()) return true;
            return await SaltedEarth();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            if (await Helpers.UseHealthPotion()) return true;
            return false;
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await Grit()) return true;
            // return await Darkside();
            return false;
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            Helpers.Debug("Pull...");
            if (await Plunge()) return true;
            if (await Provoke()) return true;
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