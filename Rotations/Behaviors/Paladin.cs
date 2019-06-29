using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Paladin : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            if (Shinra.Settings.RotationMode == Modes.Smart)
            {
                if (Shinra.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await TotalEclipse()) return true;
                if (await Flash()) return true;
                if (await HolySpirit()) return true;
                if (await GoringBlade()) return true;
                if (await RoyalAuthority()) return true;
                if (await RiotBlade()) return true;
                if (await RageOfHalone()) return true;
                if (await SavageBlade()) return true;
                return await FastBlade();
            }
            if (Shinra.Settings.RotationMode == Modes.Single)
            {
                if (Shinra.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
                if (await HolySpirit()) return true;
                if (await GoringBlade()) return true;
                if (await RoyalAuthority()) return true;
                if (await RiotBlade()) return true;
                if (await RageOfHalone()) return true;
                if (await SavageBlade()) return true;
                return await FastBlade();
            }
            if (Shinra.Settings.RotationMode == Modes.Multi)
            {
                if (await TotalEclipse()) return true;
                return await Flash();
            }
            return false;
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await Shinra.ChocoboStance()) return true;
            if (await PassageOfArms()) return true;
            if (await SwordOath()) return true;
            if (await ShieldOath()) return true;
            if (await HallowedGround()) return true;
            if (await Sentinel()) return true;
            if (await Bulwark()) return true;
            if (await Rampart()) return true;
            if (await Convalescence()) return true;
            if (await Anticipation()) return true;
            if (await Awareness()) return true;
            if (await Reprisal()) return true;
            if (Shinra.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Sheltron()) return true;
            if (await Requiescat()) return true;
            if (await FightOrFlight()) return true;
            if (await ShieldSwipe()) return true;
            if (await CircleOfScorn()) return true;
            return await SpiritsWithin();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            return await Clemency();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            if (await Shinra.SummonChocobo()) return true;
            if (await SwordOath()) return true;
            return await ShieldOath();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            if (Shinra.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await ShieldLob()) return true;
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            if (await RequiescatPVP()) return true;
            if (await HolySpiritPVP()) return true;
            if (await RageOfHalonePVP()) return true;
            return await RoyalAuthorityPVP();
        }

        #endregion
    }
}