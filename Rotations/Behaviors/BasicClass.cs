using System.Threading.Tasks;

namespace ShinraCo.Rotations
{
    public sealed partial class BasicClass : Rotation
    {
        #region Combat

        public override async Task<bool> Combat()
        {
            Helpers.Debug("Combat...");
            if (await Drain()) return true;
            // Arcanist
            if (await Miasma()) return true;
            if (await BioII()) return true;
            if (await Bio()) return true;
            if (await Ruin()) return true;
            // Archer
            if (await VenomousBite()) return true;
            if (await StraightShot()) return true;
            if (await HeavyShot()) return true;
            // Conjurer
            if (await AeroII()) return true;
            if (await Aero()) return true;
            if (await StoneII()) return true;
            if (await Stone()) return true;
            // Gladiator
            if (await RiotBlade()) return true;
            if (await FastBlade()) return true;
            // Lancer
            if (await FullThrust()) return true;
            if (await VorpalThrust()) return true;
            if (await HeavyThrust()) return true;
            if (await TrueThrust()) return true;
            // Marauder
            if (await Overpower()) return true;
            if (await StormsPath()) return true;
            if (await Maim()) return true;
            if (await ButchersBlock()) return true;
            if (await SkullSunder()) return true;
            if (await HeavySwing()) return true;
            // Pugilist
            if (await SnapPunch()) return true;
            if (await TwinSnakes()) return true;
            if (await TrueStrike()) return true;
            if (await Bootshine()) return true;
            // Rogue
            if (await AeolianEdge()) return true;
            if (await GustSlash()) return true;
            if (await SpinningEdge()) return true;
            // Thaumaturge
            if (await FireIII()) return true;
            if (await Fire()) return true;
            if (await Blizzard()) return true;
            return await Scathe();
        }

        #endregion

        #region CombatBuff

        public override async Task<bool> CombatBuff()
        {
            Helpers.Debug("CombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            if (await ShinraEx.ChocoboStance()) return true;
            // Arcanist
            if (await SummonII()) return true;
            if (await Summon()) return true;
            if (await EnergyDrain()) return true;
            // Archer
            if (await Bloodletter()) return true;
            if (await MiserysEnd()) return true;
            if (await RagingStrikes()) return true;
            // Gladiator
            if (await FightOrFlight()) return true;
            // Lancer
            if (await BloodForBlood()) return true;
            if (await LifeSurge()) return true;
            // Marauder
            if (await Berserk()) return true;
            // Pugilist
            if (await FistsOfEarth()) return true;
            if (await InternalRelease()) return true;
            // Rogue
            if (await ShadeShift()) return true;
            if (await Assassinate()) return true;
            if (await Mug()) return true;
            // Thaumaturge
            return await Transpose();
        }

        #endregion

        #region Heal

        public override async Task<bool> Heal()
        {
            Helpers.Debug("Heal...");
            // Arcanist
            if (await Physick()) return true;
            // Conjurer
            if (await CureII()) return true;
            if (await Cure()) return true;
            // Role
            return await SecondWind();
        }

        #endregion

        #region PreCombatBuff

        public override async Task<bool> PreCombatBuff()
        {
            Helpers.Debug("PreCombatBuff...");
            if (await ShinraEx.SummonChocobo()) return true;
            // Arcanist
            if (await SummonII()) return true;
            if (await Summon()) return true;
            // Pugilist
            return await FistsOfEarth();
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