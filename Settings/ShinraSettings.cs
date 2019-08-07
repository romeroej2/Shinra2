using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ff14bot.Helpers;
using Newtonsoft.Json;

namespace ShinraCo.Settings
{
    #region Enums

    public enum CastLocations
    {
        Self,
        Target
    }

    public enum Modes
    {
        Smart,
        Single,
        Multi
    }

    public enum CooldownModes
    {
        Enabled,
        Disabled
    }

    public enum TankModes
    {
        DPS,
        Enmity
    }

    public enum Stances
    {
        Free,
        Attacker,
        Healer,
        Defender
    }

    public enum AstrologianSects
    {
        None,
        Diurnal,
        Nocturnal
    }

    public enum MachinistTurrets
    {
        None,
        Rook,
        Bishop
    }

    public enum MonkFists
    {
        None,
        Earth,
        Wind,
        Fire
    }

    public enum ScholarPets
    {
        None,
        Eos,
        Selene
    }

    public enum SummonerPets
    {
        None,
        Garuda,
        Titan,
        Ifrit
    }

    public enum WarriorStances
    {
        None,
        Defiance,
        Deliverance
    }

    #endregion

    public class ShinraSettings : JsonSettings
    {
        [JsonIgnore]
        public static ShinraSettings Instance { get; } = new ShinraSettings("ShinraSettings");
        private ShinraSettings(string filename) : base(Path.Combine(CharacterSettingsDirectory, filename + ".json")) { }

        #region Form Settings

        [Setting]
        public Point WindowLocation { get; set; }

        [Setting]
        public Point OverlayLocation { get; set; }

        #endregion

        #region Main Settings

        #region Rotation

        [Setting, DefaultValue(true)]
        public bool RotationOverlay { get; set; }

        [Setting, DefaultValue(true)]
        public bool RotationMessages { get; set; }

        [Setting, DefaultValue(Modes.Smart)]
        public Modes RotationMode { get; set; }

        [Setting, DefaultValue(Keys.None)]
        public Keys RotationHotkey { get; set; }

        [Setting, DefaultValue(CooldownModes.Enabled)]
        public CooldownModes CooldownMode { get; set; }

        [Setting, DefaultValue(Keys.None)]
        public Keys CooldownHotkey { get; set; }

        [Setting, DefaultValue(TankModes.DPS)]
        public TankModes TankMode { get; set; }

        [Setting, DefaultValue(Keys.None)]
        public Keys TankHotkey { get; set; }

        #endregion

        #region Chocobo

        [Setting, DefaultValue(true)]
        public bool SummonChocobo { get; set; }

        [Setting, DefaultValue(true)]
        public bool ChocoboStanceDance { get; set; }

        [Setting, DefaultValue(70)]
        public int ChocoboStanceDancePct { get; set; }

        [Setting, DefaultValue(Stances.Free)]
        public Stances ChocoboStance { get; set; }

        #endregion

        #region Rest

        [Setting, DefaultValue(true)]
        public bool RestHealth { get; set; }


        [Setting, DefaultValue(true)]
        public bool UseHealthPotion { get; set; }

        [Setting, DefaultValue(true)]
        public bool RestEnergy { get; set; }

        [Setting, DefaultValue(70)]
        public int RestHealthPct { get; set; }

        [Setting, DefaultValue(50)]
        public int RestEnergyPct { get; set; }

        #endregion

        #region Spell

        [Setting, DefaultValue(true)]
        public bool RandomCastLocations { get; set; }

        [Setting, DefaultValue(true)]
        public bool CustomAoE { get; set; }

        [Setting, DefaultValue(3)]
        public int CustomAoECount { get; set; }

        [Setting, DefaultValue(false)]
        public bool QueueSpells { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool IgnoreSmart { get; set; }

        [Setting, DefaultValue(true)]
        public bool DisableDebug { get; set; }


        [Setting, DefaultValue(false)]
        public bool CrPaused { get; set; }
        #endregion

        #endregion

        #region Job Settings

        #region Astrologian

        #region Role

        [Setting, DefaultValue(true)]
        public bool AstrologianRepose { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianEsuna { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianLucidDreaming { get; set; }

        [Setting, DefaultValue(60)]
        public int AstrologianLucidDreamingPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianSwiftcast { get; set; }

        #endregion

        #region Damage

        [Setting, DefaultValue(true)]
        public bool AstrologianStopDamage { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianStopDots { get; set; }

        [Setting, DefaultValue(40)]
        public int AstrologianStopDamagePct { get; set; }

        [Setting, DefaultValue(20)]
        public int AstrologianStopDotsPct { get; set; }

        #endregion

        #region AoE

        [Setting, DefaultValue(true)]
        public bool AstrologianEarthlyStar { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianStellarDetonation { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool AstrologianLightspeed { get; set; }

        [Setting, DefaultValue(2)]
        public int AstrologianLightspeedCount { get; set; }

        [Setting, DefaultValue(50)]
        public int AstrologianLightspeedPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianSynastry { get; set; }

        [Setting, DefaultValue(2)]
        public int AstrologianSynastryCount { get; set; }

        [Setting, DefaultValue(60)]
        public int AstrologianSynastryPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianTimeDilation { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianCelestialOpposition { get; set; }

        #endregion

        #region Heal

        [Setting, DefaultValue(true)]
        public bool AstrologianPartyHeal { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianInterruptDamage { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianInterruptOverheal { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianBenefic { get; set; }

        [Setting, DefaultValue(50)]
        public int AstrologianBeneficPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianBeneficII { get; set; }

        [Setting, DefaultValue(40)]
        public int AstrologianBeneficIIPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianEssDignity { get; set; }

        [Setting, DefaultValue(30)]
        public int AstrologianEssDignityPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianAspBenefic { get; set; }

        [Setting, DefaultValue(70)]
        public int AstrologianAspBeneficPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianHelios { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianAspHelios { get; set; }

        [Setting, DefaultValue(60)]
        public int AstrologianHeliosPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianAscend { get; set; }

        [Setting, DefaultValue(60)]
        public int AstrologianAspHeliosPct { get; set; }

        #endregion

        #region Card

        [Setting, DefaultValue(true)]
        public bool AstrologianDraw { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianSleeveDraw { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianCardPreCombat { get; set; }

        #endregion

        #region Sect

        [Setting, DefaultValue(AstrologianSects.Diurnal)]
        public AstrologianSects AstrologianSect { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool AstrologianCardOnly { get; set; }

        #endregion

        #endregion

        #region Bard

        #region Role

        [Setting, DefaultValue(true)]
        public bool BardSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool BardFootGraze { get; set; }

        [Setting, DefaultValue(false)]
        public bool BardLegGraze { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardPeloton { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardTactician { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardRefresh { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardPalisade { get; set; }

        [Setting, DefaultValue(60)]
        public int BardSecondWindPct { get; set; }

        [Setting, DefaultValue(40)]
        public int BardInvigoratePct { get; set; }

        [Setting, DefaultValue(30)]
        public int BardTacticianPct { get; set; }

        [Setting, DefaultValue(50)]
        public int BardRefreshPct { get; set; }

        [Setting, DefaultValue(60)]
        public int BardPalisadePct { get; set; }

        #endregion

        #region Damage

        [Setting, DefaultValue(true)]
        public bool BardPitchPerfect { get; set; }

        [Setting, DefaultValue(3)]
        public int BardRepertoireCount { get; set; }

        #endregion

        #region DoT

        [Setting, DefaultValue(true)]
        public bool BardUseDots { get; set; }

        [Setting, DefaultValue(false)]
        public bool BardUseDotsAoe { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardDotSnapshot { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool BardSongs { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardEmpyrealArrow { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardSidewinder { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool BardRagingStrikes { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardFoeRequiem { get; set; }

        [Setting, DefaultValue(100)]
        public int BardFoeRequiemPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardBarrage { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardBattleVoice { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool BardOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool BardPotion { get; set; }

        #endregion

        #endregion

        #region Black Mage

        #region Role

        [Setting, DefaultValue(true)]
        public bool BlackMageDrain { get; set; }

        [Setting, DefaultValue(true)]
        public bool BlackMageLucidDreaming { get; set; }

        [Setting, DefaultValue(true)]
        public bool BlackMageSwiftcast { get; set; }

        [Setting, DefaultValue(50)]
        public int BlackMageDrainPct { get; set; }

        [Setting, DefaultValue(60)]
        public int BlackMageLucidDreamingPct { get; set; }

        #endregion

        #region Damage

        [Setting, DefaultValue(true)]
        public bool BlackMageScathe { get; set; }

        #endregion

        #region AoE

        [Setting, DefaultValue(true)]
        public bool BlackMageThunder { get; set; }

      

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool BlackMageConvert { get; set; }

        [Setting, DefaultValue(true)]
        public bool BlackMageLeyLines { get; set; }

        [Setting, DefaultValue(true)]
        public bool BlackMageSharpcast { get; set; }

        [Setting, DefaultValue(true)]
        public bool BlackMageEnochian { get; set; }

        [Setting, DefaultValue(true)]
        public bool BlackMageTriplecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool BlackMageBetweenTheLines { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool BlackMageOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool BlackMagePotion { get; set; }

        #endregion

        #endregion

        #region Dark Knight

        #region Role

        [Setting, DefaultValue(true)]
        public bool DarkKnightRampart { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightLowBlow { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightProvoke { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightInterject { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightReprisal { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightArmsLength { get; set; }

        [Setting, DefaultValue(60)]
        public int DarkKnightRampartPct { get; set; }

        #endregion

        #region Damage

        [Setting, DefaultValue(true)]
        public bool DarkKnightBloodspiller { get; set; }

        #endregion

        #region AoE

        [Setting, DefaultValue(true)]
        public bool DarkKnightQuietus { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool DarkKnightSaltedEarth { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightPlunge { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightCarveAndSpit { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool DarkKnightBloodWeapon { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightBloodPrice { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightShadowWall { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightLivingDead { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightDelirium { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightBlackestNight { get; set; }

        [Setting, DefaultValue(70)]
        public int DarkKnightBloodPricePct { get; set; }

        [Setting, DefaultValue(60)]
        public int DarkKnightShadowWallPct { get; set; }

        [Setting, DefaultValue(10)]
        public int DarkKnightLivingDeadPct { get; set; }

        [Setting, DefaultValue(70)]
        public int DarkKnightBlackestNightPct { get; set; }

        #endregion

        #region Dark Arts

        [Setting, DefaultValue(true)]
        public bool DarkKnightSouleaterArts { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightAbyssalArts { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightCarveArts { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightQuietusArts { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightBloodspillerArts { get; set; }

        #endregion

        #region Aura

        [Setting, DefaultValue(true)]
        public bool DarkKnightGrit { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightDarkside { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool DarkKnightOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightPotion { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightOffTank { get; set; }

        #endregion

        #endregion

        #region Dragoon

        #region Role

        [Setting, DefaultValue(true)]
        public bool DragoonSecondWind { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonGoad { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonTrueNorth { get; set; }

        [Setting, DefaultValue(50)]
        public int DragoonSecondWindPct { get; set; }

        [Setting, DefaultValue(40)]
        public int DragoonInvigoratePct { get; set; }

        [Setting, DefaultValue(70)]
        public int DragoonBloodbathPct { get; set; }

        [Setting, DefaultValue(40)]
        public int DragoonGoadPct { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool DragoonJump { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonSpineshatter { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonDragonfire { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonGeirskogul { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonMirage { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool DragoonLifeSurge { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonBloodForBlood { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonBattleLitany { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonBloodOfTheDragon { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonDragonSight { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool DragoonOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool DragoonPotion { get; set; }

        #endregion

        #endregion

        #region Machinist

        #region Role

        [Setting, DefaultValue(true)]
        public bool MachinistSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool MachinistFootGraze { get; set; }

        [Setting, DefaultValue(false)]
        public bool MachinistLegGraze { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistPeloton { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistTactician { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistRefresh { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistPalisade { get; set; }

        [Setting, DefaultValue(60)]
        public int MachinistSecondWindPct { get; set; }

        [Setting, DefaultValue(40)]
        public int MachinistInvigoratePct { get; set; }

        [Setting, DefaultValue(30)]
        public int MachinistTacticianPct { get; set; }

        [Setting, DefaultValue(50)]
        public int MachinistRefreshPct { get; set; }

        [Setting, DefaultValue(60)]
        public int MachinistPalisadePct { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool MachinistWildfire { get; set; }

        [Setting, DefaultValue(100000)]
        public int MachinistWildfireHP { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistRicochet { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistCooldown { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistFlamethrower { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool MachinistReload { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistReassemble { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistRapidFire { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistGaussBarrel { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistHypercharge { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistBarrelStabilizer { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistRookOverdrive { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistBishopOverdrive { get; set; }

        #endregion

        #region Turret

        [Setting, DefaultValue(MachinistTurrets.Rook)]
        public MachinistTurrets MachinistTurret { get; set; }

        [Setting, DefaultValue(Keys.None)]
        public Keys MachinistTurretHotkey { get; set; }

        [Setting, DefaultValue(CastLocations.Target)]
        public CastLocations MachinistTurretLocation { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool MachinistOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool MachinistPotion { get; set; }

        [Setting, DefaultValue(false)]
        public bool MachinistSyncWildfire { get; set; }

        [Setting, DefaultValue(false)]
        public bool MachinistSyncOverheat { get; set; }

        #endregion

        #endregion

        #region Monk

        #region Role

        [Setting, DefaultValue(true)]
        public bool MonkSecondWind { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkGoad { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkTrueNorth { get; set; }

        [Setting, DefaultValue(50)]
        public int MonkSecondWindPct { get; set; }

        [Setting, DefaultValue(40)]
        public int MonkInvigoratePct { get; set; }

        [Setting, DefaultValue(70)]
        public int MonkBloodbathPct { get; set; }

        [Setting, DefaultValue(40)]
        public int MonkGoadPct { get; set; }

        #endregion

        #region DoT

        [Setting, DefaultValue(true)]
        public bool MonkDemolish { get; set; }

        [Setting, DefaultValue(100000)]
        public int MonkDemolishHP { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool MonkShoulderTackle { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkSteelPeak { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkHowlingFist { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkForbiddenChakra { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkElixirField { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkFireTackle { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool MonkInternalRelease { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkPerfectBalance { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkFormShift { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkMeditation { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkRiddleOfFire { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkBrotherhood { get; set; }

        #endregion

        #region Fists

        [Setting, DefaultValue(MonkFists.Fire)]
        public MonkFists MonkFist { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool MonkOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool MonkPotion { get; set; }

        #endregion

        #endregion

        #region Ninja

        #region Role

        [Setting, DefaultValue(true)]
        public bool NinjaSecondWind { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaGoad { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaTrueNorth { get; set; }

        [Setting, DefaultValue(50)]
        public int NinjaSecondWindPct { get; set; }

        [Setting, DefaultValue(40)]
        public int NinjaInvigoratePct { get; set; }

        [Setting, DefaultValue(70)]
        public int NinjaBloodbathPct { get; set; }

        [Setting, DefaultValue(40)]
        public int NinjaGoadPct { get; set; }

        #endregion

        #region DoT

        [Setting, DefaultValue(true)]
        public bool NinjaShadowFang { get; set; }

        [Setting, DefaultValue(100000)]
        public int NinjaShadowFangHP { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool NinjaAssassinate { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaMug { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaTrickAttack { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaJugulate { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaShukuchi { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaDreamWithin { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaHellfrogMedium { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaBhavacakra { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool NinjaShadeShift { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaKassatsu { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaDuality { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaTenChiJin { get; set; }

        [Setting, DefaultValue(50)]
        public int NinjaShadeShiftPct { get; set; }

        #endregion

        #region Ninjutsu

        [Setting, DefaultValue(true)]
        public bool NinjaFuma { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaKaton { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaRaiton { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaHuton { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaDoton { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaSuiton { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool NinjaOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool NinjaPotion { get; set; }

        #endregion

        #endregion

        #region Paladin

        #region Role

        [Setting, DefaultValue(true)]
        public bool PaladinRampart { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinLowBlow { get; set; }
        
        [Setting, DefaultValue(true)]
        public bool PaladinProvoke { get; set; }
        
        [Setting, DefaultValue(true)]
        public bool PaladinInterject { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinReprisal { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinArmsLength { get; set; }

        [Setting, DefaultValue(60)]
        public int PaladinRampartPct { get; set; }

        #endregion

        #region AoE

        [Setting, DefaultValue(true)]
        public bool PaladinTotalEclipse { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinProminence { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinHolyCircle { get; set; }


        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool PaladinSpiritsWithin { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinCircleOfScorn { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinRequiescat { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool PaladinFightOrFlight { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinSentinel { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinHallowedGround { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinSheltron { get; set; }

        [Setting, DefaultValue(60)]
        public int PaladinSentinelPct { get; set; }


        [Setting, DefaultValue(10)]
        public int PaladinHallowedGroundPct { get; set; }

        #endregion

        #region Heal

        [Setting, DefaultValue(true)]
        public bool PaladinClemency { get; set; }

        [Setting, DefaultValue(50)]
        public int PaladinClemencyPct { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool PaladinOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool PaladinPotion { get; set; }

        #endregion

        #endregion

        #region Red Mage

        #region Role

        [Setting, DefaultValue(true)]
        public bool RedMageDrain { get; set; }

        [Setting, DefaultValue(true)]
        public bool RedMageLucidDreaming { get; set; }

        [Setting, DefaultValue(true)]
        public bool RedMageSwiftcast { get; set; }

        [Setting, DefaultValue(50)]
        public int RedMageDrainPct { get; set; }

        [Setting, DefaultValue(60)]
        public int RedMageLucidDreamingPct { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool RedMageCorpsACorps { get; set; }

        [Setting, DefaultValue(false)]
        public bool RedMageDisplacement { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool RedMageEmbolden { get; set; }

        [Setting, DefaultValue(true)]
        public bool RedMageManafication { get; set; }

        #endregion

        #region Heal

        [Setting, DefaultValue(true)]
        public bool RedMageVercure { get; set; }

        [Setting, DefaultValue(true)]
        public bool RedMageVerraise { get; set; }

        [Setting, DefaultValue(50)]
        public int RedMageVercurePct { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool RedMageOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool RedMagePotion { get; set; }

        #endregion

        #endregion

        #region Samurai

        #region Role

        [Setting, DefaultValue(true)]
        public bool SamuraiSecondWind { get; set; }

        [Setting, DefaultValue(true)]
        public bool SamuraiInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool SamuraiBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool SamuraiGoad { get; set; }

        [Setting, DefaultValue(true)]
        public bool SamuraiTrueNorth { get; set; }

        [Setting, DefaultValue(50)]
        public int SamuraiSecondWindPct { get; set; }

        [Setting, DefaultValue(40)]
        public int SamuraiInvigoratePct { get; set; }

        [Setting, DefaultValue(70)]
        public int SamuraiBloodbathPct { get; set; }

        [Setting, DefaultValue(40)]
        public int SamuraiGoadPct { get; set; }

        #endregion

        #region Damage

        [Setting, DefaultValue(true)]
        public bool SamuraiMidare { get; set; }

        [Setting, DefaultValue(100000)]
        public int SamuraiMidareHP { get; set; }

        #endregion

        #region DoT

        [Setting, DefaultValue(true)]
        public bool SamuraiHiganbana { get; set; }

        [Setting, DefaultValue(500000)]
        public int SamuraiHiganbanaHP { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool SamuraiGyoten { get; set; }

        [Setting, DefaultValue(true)]
        public bool SamuraiGuren { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool SamuraiMeikyo { get; set; }

        [Setting, DefaultValue(true)]
        public bool SamuraiHagakure { get; set; }

        #endregion

        #region Heal

        [Setting, DefaultValue(true)]
        public bool SamuraiMerciful { get; set; }

        [Setting, DefaultValue(50)]
        public int SamuraiMercifulPct { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool SamuraiOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool SamuraiPotion { get; set; }

        #endregion

        #endregion

        #region Scholar

        #region Role

        [Setting, DefaultValue(true)]
        public bool ScholarRepose { get; set; }
        
        [Setting, DefaultValue(true)]
        public bool ScholarEsuna { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarLucidDreaming { get; set; }

        [Setting, DefaultValue(60)]
        public int ScholarLucidDreamingPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarSwiftcast { get; set; }

        #endregion

        #region Damage

        [Setting, DefaultValue(true)]
        public bool ScholarStopDamage { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarStopDots { get; set; }

        [Setting, DefaultValue(40)]
        public int ScholarStopDamagePct { get; set; }

        [Setting, DefaultValue(20)]
        public int ScholarStopDotsPct { get; set; }

        #endregion

        #region AoE

        [Setting, DefaultValue(true)]
        public bool ScholarBane { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool ScholarEnergyDrain { get; set; }

        [Setting, DefaultValue(70)]
        public int ScholarEnergyDrainPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarShadowFlare { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarChainStrategem { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool ScholarRouse { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarEmergencyTactics { get; set; }

        #endregion

        #region Heal

        [Setting, DefaultValue(true)]
        public bool ScholarPartyHeal { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarInterruptDamage { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarInterruptOverheal { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarPhysick { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarAdloquium { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarAetherpact { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarLustrate { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarExcogitation { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarSuccor { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarIndomitability { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarResurrection { get; set; }

        [Setting, DefaultValue(50)]
        public int ScholarPhysickPct { get; set; }

        [Setting, DefaultValue(40)]
        public int ScholarAdloquiumPct { get; set; }

        [Setting, DefaultValue(30)]
        public int ScholarAetherpactPct { get; set; }

        [Setting, DefaultValue(20)]
        public int ScholarLustratePct { get; set; }

        [Setting, DefaultValue(90)]
        public int ScholarExcogitationPct { get; set; }

        [Setting, DefaultValue(60)]
        public int ScholarSuccorPct { get; set; }

        [Setting, DefaultValue(60)]
        public int ScholarIndomitabilityPct { get; set; }

        #endregion

        #region Pet

        [Setting, DefaultValue(ScholarPets.Eos)]
        public ScholarPets ScholarPet { get; set; }

        #endregion

        #endregion

        #region Summoner

        #region Role

        [Setting, DefaultValue(true)]
        public bool SummonerAddle { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerDrain { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerLucidDreaming { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerSwiftcast { get; set; }

        [Setting, DefaultValue(50)]
        public int SummonerDrainPct { get; set; }

        [Setting, DefaultValue(60)]
        public int SummonerLucidDreamingPct { get; set; }

        #endregion

        #region AoE

        [Setting, DefaultValue(true)]
        public bool SummonerBane { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool SummonerShadowFlare { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerEnkindle { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerTriDisaster { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerEnkindleBahamut { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool SummonerRouse { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerDreadwyrmTrance { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerAetherpact { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerSummonBahamut { get; set; }

        #endregion

        #region Heal

        [Setting, DefaultValue(true)]
        public bool SummonerPhysick { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerSustain { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerResurrection { get; set; }

        [Setting, DefaultValue(50)]
        public int SummonerPhysickPct { get; set; }

        [Setting, DefaultValue(50)]
        public int SummonerSustainPct { get; set; }

        #endregion

        #region Pet

        [Setting, DefaultValue(SummonerPets.Garuda)]
        public SummonerPets SummonerPet { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool SummonerOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool SummonerPotion { get; set; }

        [Setting, DefaultValue(false)]
        public bool SummonerOpenerGaruda { get; set; }

        #endregion

        #endregion

        #region Warrior

        #region Role

        [Setting, DefaultValue(true)]
        public bool WarriorRampart { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorLowBlow { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorProvoke { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorInterject { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorReprisal { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorArmsLength { get; set; }

        [Setting, DefaultValue(60)]
        public int WarriorRampartPct { get; set; }

        #endregion

        #region Damage

        [Setting, DefaultValue(true)]
        public bool WarriorMaim { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorStormsEye { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorInnerBeast { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorFellCleave { get; set; }

        #endregion

        #region AoE

        [Setting, DefaultValue(true)]
        public bool WarriorOverpower { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorSteelCyclone { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorDecimate { get; set; }

        #endregion

        #region Cooldown

        [Setting, DefaultValue(true)]
        public bool WarriorOnslaught { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorUpheaval { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool WarriorBerserk { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorThrillOfBattle { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorUnchained { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorVengeance { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorInfuriate { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorEquilibriumTP { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorShakeItOff { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorInnerRelease { get; set; }

        [Setting, DefaultValue(30)]
        public int WarriorThrillOfBattlePct { get; set; }

        [Setting, DefaultValue(60)]
        public int WarriorVengeancePct { get; set; }

        [Setting, DefaultValue(40)]
        public int WarriorEquilibriumTPPct { get; set; }

        #endregion

        #region Heal

        [Setting, DefaultValue(true)]
        public bool WarriorEquilibrium { get; set; }

        [Setting, DefaultValue(50)]
        public int WarriorEquilibriumPct { get; set; }

        #endregion

        #region Stance

        [Setting, DefaultValue(WarriorStances.Defiance)]
        public WarriorStances WarriorStance { get; set; }

        #endregion

        #region Misc

        [Setting, DefaultValue(false)]
        public bool WarriorOpener { get; set; }

        [Setting, DefaultValue(false)]
        public bool WarriorPotion { get; set; }

        #endregion

        #endregion

        #region White Mage

        #region Role

        [Setting, DefaultValue(true)]
        public bool WhiteMageRepose { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageEsuna { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageLucidDreaming { get; set; }

        [Setting, DefaultValue(60)]
        public int WhiteMageLucidDreamingPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageSwiftcast { get; set; }

        #endregion

        #region Damage

        [Setting, DefaultValue(true)]
        public bool WhiteMageStopDamage { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageStopDots { get; set; }

        [Setting, DefaultValue(40)]
        public int WhiteMageStopDamagePct { get; set; }

        [Setting, DefaultValue(20)]
        public int WhiteMageStopDotsPct { get; set; }

        #endregion

        #region Buff

        [Setting, DefaultValue(true)]
        public bool WhiteMagePresenceOfMind { get; set; }

        [Setting, DefaultValue(2)]
        public int WhiteMagePresenceOfMindCount { get; set; }

        [Setting, DefaultValue(50)]
        public int WhiteMagePresenceOfMindPct { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageTemperance { get; set; }

        [Setting, DefaultValue(2)]
        public int WhiteMageTemperanceCount { get; set; }

        [Setting, DefaultValue(50)]
        public int WhiteMageTemperancePct { get; set; }
        
        [Setting, DefaultValue(true)]
        public bool WhiteMageThinAir { get; set; }

        #endregion

        #region Heal

        [Setting, DefaultValue(true)]
        public bool WhiteMagePartyHeal { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageInterruptDamage { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageInterruptOverheal { get; set; }
        
        [Setting, DefaultValue(true)]
        public bool WhiteMageCure { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageCureII { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageCureIII { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageTetragrammaton { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageBenediction { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageRegen { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageAfflatusSolace { get; set; }
        
        [Setting, DefaultValue(50)]
        public int WhiteMageAfflatusSolacePct { get; set; }
        
        [Setting, DefaultValue(true)]
        public bool WhiteMageMedica { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageMedicaII { get; set; }
        
        [Setting, DefaultValue(true)]
        public bool WhiteMageAfflatusRapture { get; set; }
        
        [Setting, DefaultValue(50)]
        public int WhiteMageAfflatusRapturePct { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageAssize { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMagePlenary { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageRaise { get; set; }

        [Setting, DefaultValue(50)]
        public int WhiteMageCurePct { get; set; }

        [Setting, DefaultValue(40)]
        public int WhiteMageCureIIPct { get; set; }

        [Setting, DefaultValue(30)]
        public int WhiteMageCureIIIPct { get; set; }
        
        [Setting, DefaultValue(20)]
        public int WhiteMageTetragrammatonPct { get; set; }

        [Setting, DefaultValue(10)]
        public int WhiteMageBenedictionPct { get; set; }

        [Setting, DefaultValue(70)]
        public int WhiteMageRegenPct { get; set; }

        [Setting, DefaultValue(60)]
        public int WhiteMageMedicaPct { get; set; }

        [Setting, DefaultValue(60)]
        public int WhiteMageMedicaIIPct { get; set; }

        [Setting, DefaultValue(70)]
        public int WhiteMageAssizePct { get; set; }

        [Setting, DefaultValue(70)]
        public int WhiteMagePlenaryPct { get; set; }

        #endregion

        #endregion

        #endregion
    }
}