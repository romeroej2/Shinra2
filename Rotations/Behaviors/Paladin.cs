using System.Threading.Tasks;
using ShinraCo.Settings;

namespace ShinraCo.Rotations
{
    public sealed partial class Paladin : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            switch (ShinraEx.Settings.RotationMode)
            {
                case Modes.Smart:
                {
                    Helpers.Debug("Combat - smart...");
                    if (ShinraEx.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await LowBlow()) return true;
                    if (await Interject()) return true;
                    if (await TotalEclipse()) return true;
                    if (await Prominence()) return true;
                    if (await HolyCircle()) return true;
                    if (await HolySpirit()) return true;
                    if (await Atonement()) return true;
                    if (await RiotBlade()) return true;
                    if (await GoringBlade()) return true;
                    if (await RageOfHalone()) return true;
                    if (await RoyalAuthority()) return true;
                    if (await Atonement()) return true;
                    if (await Confiteor()) return true;
                    return await FastBlade();
                }

                case Modes.Single:
                {
                    Helpers.Debug("Combat - single...");
                    if (ShinraEx.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
                    if (await LowBlow()) return true;
                    if (await Interject()) return true;
                    if (await HolySpirit()) return true;
                    if (await Atonement()) return true;
                    if (await RiotBlade()) return true;
                    if (await GoringBlade()) return true;
                    if (await RageOfHalone()) return true;
                    if (await RoyalAuthority()) return true;
                    return await FastBlade();
                }

                case Modes.Multi:
                {
                    Helpers.Debug("Combat - multi...");
                    if (await TotalEclipse()) return true;
                    if (await Prominence()) return true;
                    if (await HolyCircle()) return true;
                    return await Confiteor();
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
            if (await PassageOfArms()) return true;
            if (await HallowedGround()) return true;
            if (await Sentinel()) return true;
            if (await Rampart()) return true;
            if (await Reprisal()) return true;
            if (await ArmsLength()) return true;
            if (ShinraEx.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Sheltron()) return true;
            if (await Requiescat()) return true;
            if (await FightOrFlight()) return true;
            if (await CircleOfScorn()) return true;
            return await SpiritsWithin();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            return await Clemency();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            return await IronWill();
        }

        #endregion

        #region Pull

        public override async Task<bool> Pull()
        {
            Helpers.Debug("Pull...");
            if (ShinraEx.Settings.PaladinOpener) { if (await Helpers.ExecuteOpener()) return true; }
            if (await Provoke()) return true;
            if (await ShieldLob()) return true;
            return await Combat();
        }

        #endregion

        #region CombatPVP

        public override async Task<bool> CombatPVP()
        {
            Helpers.Debug("CombatPVP...");
            if (await RequiescatPVP()) return true;
            if (await HolySpiritPVP()) return true;
            if (await RageOfHalonePVP()) return true;
            return await RoyalAuthorityPVP();
        }

        #endregion
    }
}
