using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ShinraCo.Properties;

namespace ShinraCo.Settings.Forms
{
    public partial class ShinraForm : Form
    {
        private readonly Image _shinraBanner = Resources.ShinraBanner;

        public ShinraForm() => InitializeComponent();

        #region Draggable

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        private void ShinraForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
        }

        #endregion

        private void ShinraForm_Load(object sender, EventArgs e)
        {
            ShinraBanner.Image = _shinraBanner;
          
            ShinraEx.UnregisterHotkeys();
            Location = ShinraEx.Settings.WindowLocation;
            var kc = new KeysConverter();

            #region Main Settings

            #region Rotation

            RotationOverlay.Checked = ShinraEx.Settings.RotationOverlay;
            RotationMessages.Checked = ShinraEx.Settings.RotationMessages;
            userHealthPotion.Checked = ShinraEx.Settings.UseHealthPotion;

            RotationMode.Text = Convert.ToString(ShinraEx.Settings.RotationMode);
            CooldownMode.Text = Convert.ToString(ShinraEx.Settings.CooldownMode);
            TankMode.Text = Convert.ToString(ShinraEx.Settings.TankMode);

            RotationHotkey.Text = kc.ConvertToString(ShinraEx.Settings.RotationHotkey);
            CooldownHotkey.Text = kc.ConvertToString(ShinraEx.Settings.CooldownHotkey);
            TankHotkey.Text = kc.ConvertToString(ShinraEx.Settings.TankHotkey);


            #endregion

            #region Chocobo

            ChocoboSummon.Checked = ShinraEx.Settings.SummonChocobo;
            ChocoboStanceDance.Checked = ShinraEx.Settings.ChocoboStanceDance;
            ChocoboStanceDancePct.Value = ShinraEx.Settings.ChocoboStanceDancePct;
            ChocoboStance.Text = Convert.ToString(ShinraEx.Settings.ChocoboStance);

            #endregion

            #region Rest

            RestHealth.Checked = ShinraEx.Settings.RestHealth;
            RestEnergy.Checked = ShinraEx.Settings.RestEnergy;

            RestHealthPct.Value = ShinraEx.Settings.RestHealthPct;
            RestEnergyPct.Value = ShinraEx.Settings.RestEnergyPct;

            #endregion

            #region Spell

            RandomCastLocations.Checked = ShinraEx.Settings.RandomCastLocations;
            CustomAoE.Checked = ShinraEx.Settings.CustomAoE;
            QueueSpells.Checked = ShinraEx.Settings.QueueSpells;

            CustomAoECount.Value = ShinraEx.Settings.CustomAoECount;

            #endregion

            #region Misc

            IgnoreSmart.Checked = ShinraEx.Settings.IgnoreSmart;
            DisableDebug.Checked = ShinraEx.Settings.DisableDebug;

            #endregion

            #endregion

            #region Job Settings

            #region Astrologian

            #region Role

            AstrologianEsuna.Checked = ShinraEx.Settings.AstrologianEsuna;
            AstrologianLucidDreaming.Checked = ShinraEx.Settings.AstrologianLucidDreaming;
            AstrologianLucidDreamingPct.Value = ShinraEx.Settings.AstrologianLucidDreamingPct;
            AstrologianSwiftcast.Checked = ShinraEx.Settings.AstrologianSwiftcast;

            #endregion

            #region Damage

            AstrologianStopDamage.Checked = ShinraEx.Settings.AstrologianStopDamage;
            AstrologianStopDots.Checked = ShinraEx.Settings.AstrologianStopDots;

            AstrologianStopDamagePct.Value = ShinraEx.Settings.AstrologianStopDamagePct;
            AstrologianStopDotsPct.Value = ShinraEx.Settings.AstrologianStopDotsPct;

            #endregion

            #region AoE

            AstrologianEarthlyStar.Checked = ShinraEx.Settings.AstrologianEarthlyStar;
            AstrologianStellarDetonation.Checked = ShinraEx.Settings.AstrologianStellarDetonation;

            #endregion

            #region Buff

            AstrologianLightspeed.Checked = ShinraEx.Settings.AstrologianLightspeed;
            AstrologianLightspeedCount.Value = ShinraEx.Settings.AstrologianLightspeedCount;
            AstrologianLightspeedPct.Value = ShinraEx.Settings.AstrologianLightspeedPct;
            AstrologianSynastry.Checked = ShinraEx.Settings.AstrologianSynastry;
            AstrologianSynastryCount.Value = ShinraEx.Settings.AstrologianSynastryCount;
            AstrologianSynastryPct.Value = ShinraEx.Settings.AstrologianSynastryPct;
            AstrologianTimeDilation.Checked = ShinraEx.Settings.AstrologianTimeDilation;
            AstrologianCelestialOpposition.Checked = ShinraEx.Settings.AstrologianCelestialOpposition;

            #endregion

            #region Heal

            AstrologianPartyHeal.Checked = ShinraEx.Settings.AstrologianPartyHeal;
            AstrologianInterruptDamage.Checked = ShinraEx.Settings.AstrologianInterruptDamage;
            AstrologianInterruptOverheal.Checked = ShinraEx.Settings.AstrologianInterruptOverheal;
            AstrologianBenefic.Checked = ShinraEx.Settings.AstrologianBenefic;
            AstrologianBeneficII.Checked = ShinraEx.Settings.AstrologianBeneficII;
            AstrologianEssDignity.Checked = ShinraEx.Settings.AstrologianEssDignity;
            AstrologianAspBenefic.Checked = ShinraEx.Settings.AstrologianAspBenefic;
            AstrologianHelios.Checked = ShinraEx.Settings.AstrologianHelios;
            AstrologianAspHelios.Checked = ShinraEx.Settings.AstrologianAspHelios;
            AstrologianAscend.Checked = ShinraEx.Settings.AstrologianAscend;

            AstrologianBeneficPct.Value = ShinraEx.Settings.AstrologianBeneficPct;
            AstrologianBeneficIIPct.Value = ShinraEx.Settings.AstrologianBeneficIIPct;
            AstrologianEssDignityPct.Value = ShinraEx.Settings.AstrologianEssDignityPct;
            AstrologianAspBeneficPct.Value = ShinraEx.Settings.AstrologianAspBeneficPct;
            AstrologianHeliosPct.Value = ShinraEx.Settings.AstrologianHeliosPct;
            AstrologianAspHeliosPct.Value = ShinraEx.Settings.AstrologianAspHeliosPct;

            #endregion

            #region Card

            AstrologianDraw.Checked = ShinraEx.Settings.AstrologianDraw;
            AstrologianSleeveDraw.Checked = ShinraEx.Settings.AstrologianSleeveDraw;
            AstrologianCardPreCombat.Checked = ShinraEx.Settings.AstrologianCardPreCombat;

            #endregion

            #region Sect

            AstrologianSect.Text = Convert.ToString(ShinraEx.Settings.AstrologianSect);

            #endregion

            #region Misc

            AstrologianCardOnly.Checked = ShinraEx.Settings.AstrologianCardOnly;

            #endregion

            #endregion

            #region Bard

            #region Role

            BardSecondWind.Checked = ShinraEx.Settings.BardSecondWind;
            BardPeloton.Checked = ShinraEx.Settings.BardPeloton;
            BardInvigorate.Checked = ShinraEx.Settings.BardInvigorate;
            BardTactician.Checked = ShinraEx.Settings.BardTactician;
            BardRefresh.Checked = ShinraEx.Settings.BardRefresh;
            BardPalisade.Checked = ShinraEx.Settings.BardPalisade;

            BardSecondWindPct.Value = ShinraEx.Settings.BardSecondWindPct;
            BardInvigoratePct.Value = ShinraEx.Settings.BardInvigoratePct;
            BardTacticianPct.Value = ShinraEx.Settings.BardTacticianPct;
            BardRefreshPct.Value = ShinraEx.Settings.BardRefreshPct;
            BardPalisadePct.Value = ShinraEx.Settings.BardPalisadePct;

            #endregion

            #region Damage

            BardPitchPerfect.Checked = ShinraEx.Settings.BardPitchPerfect;
            BardRepertoireCount.Value = ShinraEx.Settings.BardRepertoireCount;

            #endregion

            #region DoT

            BardUseDots.Checked = ShinraEx.Settings.BardUseDots;
            BardUseDotsAoe.Checked = ShinraEx.Settings.BardUseDotsAoe;
            BardDotSnapshot.Checked = ShinraEx.Settings.BardDotSnapshot;

            #endregion

            #region Cooldown

            BardSongs.Checked = ShinraEx.Settings.BardSongs;
            BardEmpyrealArrow.Checked = ShinraEx.Settings.BardEmpyrealArrow;
            BardSidewinder.Checked = ShinraEx.Settings.BardSidewinder;

            #endregion

            #region Buff

            BardRagingStrikes.Checked = ShinraEx.Settings.BardRagingStrikes;
            BardFoeRequiem.Checked = ShinraEx.Settings.BardFoeRequiem;
            BardFoeRequiemPct.Value = ShinraEx.Settings.BardFoeRequiemPct;
            BardBarrage.Checked = ShinraEx.Settings.BardBarrage;
            BardBattleVoice.Checked = ShinraEx.Settings.BardBattleVoice;

            #endregion

            #region Misc

            BardOpener.Checked = ShinraEx.Settings.BardOpener;
            BardPotion.Checked = ShinraEx.Settings.BardPotion;

            #endregion

            #endregion

            #region Black Mage

            #region Role

           
            BlackMageLucidDreaming.Checked = ShinraEx.Settings.BlackMageLucidDreaming;
            BlackMageSwiftcast.Checked = ShinraEx.Settings.BlackMageSwiftcast;

          
            BlackMageLucidDreamingPct.Value = ShinraEx.Settings.BlackMageLucidDreamingPct;

            #endregion

            #region Damage

            BlackMageScathe.Checked = ShinraEx.Settings.BlackMageScathe;

            #endregion

            #region AoE

            BlackMageThunder.Checked = ShinraEx.Settings.BlackMageThunder;

            #endregion

            #region Buff

            BlackMageConvert.Checked = ShinraEx.Settings.BlackMageConvert;
            BlackMageLeyLines.Checked = ShinraEx.Settings.BlackMageLeyLines;
            BlackMageSharpcast.Checked = ShinraEx.Settings.BlackMageSharpcast;
            BlackMageEnochian.Checked = ShinraEx.Settings.BlackMageEnochian;
            BlackMageTriplecast.Checked = ShinraEx.Settings.BlackMageTriplecast;

            #endregion

            #region Misc

            BlackMageOpener.Checked = ShinraEx.Settings.BlackMageOpener;
            BlackMagePotion.Checked = ShinraEx.Settings.BlackMagePotion;

            #endregion

            #endregion

            #region Dark Knight

            #region Role

            DarkKnightRampart.Checked = ShinraEx.Settings.DarkKnightRampart;
            DarkKnightLowBlow.Checked = ShinraEx.Settings.DarkKnightLowBlow;
            DarkKnightProvoke.Checked = ShinraEx.Settings.DarkKnightProvoke;
            DarkKnightInterject.Checked = ShinraEx.Settings.DarkKnightInterject;
            DarkKnightReprisal.Checked = ShinraEx.Settings.DarkKnightReprisal;
            DarkKnightArmsLength.Checked = ShinraEx.Settings.DarkKnightArmsLength;
            DarkKnightRampartPct.Value = ShinraEx.Settings.DarkKnightRampartPct;

            #endregion

            #region Damage

            DarkKnightBloodspiller.Checked = ShinraEx.Settings.DarkKnightBloodspiller;

            #endregion

            #region AoE

            DarkKnightQuietus.Checked = ShinraEx.Settings.DarkKnightQuietus;

            #endregion

            #region Cooldown

            DarkKnightSaltedEarth.Checked = ShinraEx.Settings.DarkKnightSaltedEarth;
            DarkKnightPlunge.Checked = ShinraEx.Settings.DarkKnightPlunge;
            DarkKnightCarveAndSpit.Checked = ShinraEx.Settings.DarkKnightCarveAndSpit;

            #endregion

            #region Buff

            DarkKnightBloodWeapon.Checked = ShinraEx.Settings.DarkKnightBloodWeapon;
            DarkKnightBloodPrice.Checked = ShinraEx.Settings.DarkKnightBloodPrice;
            DarkKnightShadowWall.Checked = ShinraEx.Settings.DarkKnightShadowWall;
            DarkKnightLivingDead.Checked = ShinraEx.Settings.DarkKnightLivingDead;
            DarkKnightDelirium.Checked = ShinraEx.Settings.DarkKnightDelirium;
            DarkKnightBlackestNight.Checked = ShinraEx.Settings.DarkKnightBlackestNight;

            DarkKnightBloodPricePct.Value = ShinraEx.Settings.DarkKnightBloodPricePct;
            DarkKnightShadowWallPct.Value = ShinraEx.Settings.DarkKnightShadowWallPct;
            DarkKnightLivingDeadPct.Value = ShinraEx.Settings.DarkKnightLivingDeadPct;
            DarkKnightBlackestNightPct.Value = ShinraEx.Settings.DarkKnightBlackestNightPct;

            #endregion

            #region Dark Arts

            DarkKnightSouleaterArts.Checked = ShinraEx.Settings.DarkKnightSouleaterArts;
            DarkKnightAbyssalArts.Checked = ShinraEx.Settings.DarkKnightAbyssalArts;
            DarkKnightCarveArts.Checked = ShinraEx.Settings.DarkKnightCarveArts;
            DarkKnightQuietusArts.Checked = ShinraEx.Settings.DarkKnightQuietusArts;
            DarkKnightBloodspillerArts.Checked = ShinraEx.Settings.DarkKnightBloodspillerArts;

            #endregion

            #region Aura

            DarkKnightGrit.Checked = ShinraEx.Settings.DarkKnightGrit;
            DarkKnightDarkside.Checked = ShinraEx.Settings.DarkKnightDarkside;

            #endregion

            #region Misc

            DarkKnightOpener.Checked = ShinraEx.Settings.DarkKnightOpener;
            DarkKnightPotion.Checked = ShinraEx.Settings.DarkKnightPotion;
            DarkKnightOffTank.Checked = ShinraEx.Settings.DarkKnightOffTank;

            #endregion

            #endregion

            #region Dragoon

            #region Role

            DragoonSecondWind.Checked = ShinraEx.Settings.DragoonSecondWind;
            DragoonInvigorate.Checked = ShinraEx.Settings.DragoonInvigorate;
            DragoonBloodbath.Checked = ShinraEx.Settings.DragoonBloodbath;
            DragoonGoad.Checked = ShinraEx.Settings.DragoonGoad;
            DragoonTrueNorth.Checked = ShinraEx.Settings.DragoonTrueNorth;

            DragoonSecondWindPct.Value = ShinraEx.Settings.DragoonSecondWindPct;
            DragoonInvigoratePct.Value = ShinraEx.Settings.DragoonInvigoratePct;
            DragoonBloodbathPct.Value = ShinraEx.Settings.DragoonBloodbathPct;
            DragoonGoadPct.Value = ShinraEx.Settings.DragoonGoadPct;

            #endregion

            #region Cooldown

            DragoonJump.Checked = ShinraEx.Settings.DragoonJump;
            DragoonSpineshatter.Checked = ShinraEx.Settings.DragoonSpineshatter;
            DragoonDragonfire.Checked = ShinraEx.Settings.DragoonDragonfire;
            DragoonGeirskogul.Checked = ShinraEx.Settings.DragoonGeirskogul;
            DragoonMirage.Checked = ShinraEx.Settings.DragoonMirage;

            #endregion

            #region Buff

            DragoonLifeSurge.Checked = ShinraEx.Settings.DragoonLifeSurge;
            DragoonBloodForBlood.Checked = ShinraEx.Settings.DragoonBloodForBlood;
            DragoonBattleLitany.Checked = ShinraEx.Settings.DragoonBattleLitany;
            DragoonBloodOfTheDragon.Checked = ShinraEx.Settings.DragoonBloodOfTheDragon;
            DragoonDragonSight.Checked = ShinraEx.Settings.DragoonDragonSight;

            #endregion

            #region Misc

            DragoonOpener.Checked = ShinraEx.Settings.DragoonOpener;
            DragoonPotion.Checked = ShinraEx.Settings.DragoonPotion;

            #endregion

            #endregion

            #region Machinist

            #region Role

            MachinistSecondWind.Checked = ShinraEx.Settings.MachinistSecondWind;
            MachinistPeloton.Checked = ShinraEx.Settings.MachinistPeloton;
            MachinistInvigorate.Checked = ShinraEx.Settings.MachinistInvigorate;
            MachinistTactician.Checked = ShinraEx.Settings.MachinistTactician;
            MachinistRefresh.Checked = ShinraEx.Settings.MachinistRefresh;
            MachinistPalisade.Checked = ShinraEx.Settings.MachinistPalisade;

            MachinistSecondWindPct.Value = ShinraEx.Settings.MachinistSecondWindPct;
            MachinistInvigoratePct.Value = ShinraEx.Settings.MachinistInvigoratePct;
            MachinistTacticianPct.Value = ShinraEx.Settings.MachinistTacticianPct;
            MachinistRefreshPct.Value = ShinraEx.Settings.MachinistRefreshPct;
            MachinistPalisadePct.Value = ShinraEx.Settings.MachinistPalisadePct;

            #endregion

            #region Cooldown

            MachinistWildfire.Checked = ShinraEx.Settings.MachinistWildfire;
            MachinistRicochet.Checked = ShinraEx.Settings.MachinistRicochet;
            MachinistCooldown.Checked = ShinraEx.Settings.MachinistCooldown;
            MachinistFlamethrower.Checked = ShinraEx.Settings.MachinistFlamethrower;

            MachinistWildfireHP.Value = ShinraEx.Settings.MachinistWildfireHP;

            #endregion

            #region Buff

            MachinistReload.Checked = ShinraEx.Settings.MachinistReload;
            MachinistReassemble.Checked = ShinraEx.Settings.MachinistReassemble;
            MachinistRapidFire.Checked = ShinraEx.Settings.MachinistRapidFire;
            MachinistGaussBarrel.Checked = ShinraEx.Settings.MachinistGaussBarrel;
            MachinistHypercharge.Checked = ShinraEx.Settings.MachinistHypercharge;
            MachinistBarrelStabilizer.Checked = ShinraEx.Settings.MachinistBarrelStabilizer;
            MachinistRookOverdrive.Checked = ShinraEx.Settings.MachinistRookOverdrive;
            MachinistBishopOverdrive.Checked = ShinraEx.Settings.MachinistBishopOverdrive;

            #endregion

            #region Turret

            MachinistTurret.Text = Convert.ToString(ShinraEx.Settings.MachinistTurret);
            MachinistTurretHotkey.Text = kc.ConvertToString(ShinraEx.Settings.MachinistTurretHotkey);
            MachinistTurretLocation.Text = Convert.ToString(ShinraEx.Settings.MachinistTurretLocation);

            #endregion

            #region Misc

            MachinistOpener.Checked = ShinraEx.Settings.MachinistOpener;
            MachinistPotion.Checked = ShinraEx.Settings.MachinistPotion;
            MachinistSyncWildfire.Checked = ShinraEx.Settings.MachinistSyncWildfire;
            MachinistSyncOverheat.Checked = ShinraEx.Settings.MachinistSyncOverheat;

            #endregion

            #endregion

            #region Monk

            #region Role

            MonkSecondWind.Checked = ShinraEx.Settings.MonkSecondWind;
            MonkInvigorate.Checked = ShinraEx.Settings.MonkInvigorate;
            MonkBloodbath.Checked = ShinraEx.Settings.MonkBloodbath;
            MonkGoad.Checked = ShinraEx.Settings.MonkGoad;
            MonkTrueNorth.Checked = ShinraEx.Settings.MonkTrueNorth;

            MonkSecondWindPct.Value = ShinraEx.Settings.MonkSecondWindPct;
            MonkInvigoratePct.Value = ShinraEx.Settings.MonkInvigoratePct;
            MonkBloodbathPct.Value = ShinraEx.Settings.MonkBloodbathPct;
            MonkGoadPct.Value = ShinraEx.Settings.MonkGoadPct;

            #endregion

            #region DoT

            MonkDemolish.Checked = ShinraEx.Settings.MonkDemolish;
            MonkDemolishHP.Value = ShinraEx.Settings.MonkDemolishHP;

            #endregion

            #region Cooldown

            MonkShoulderTackle.Checked = ShinraEx.Settings.MonkShoulderTackle;
            MonkSteelPeak.Checked = ShinraEx.Settings.MonkSteelPeak;
            MonkHowlingFist.Checked = ShinraEx.Settings.MonkHowlingFist;
            MonkForbiddenChakra.Checked = ShinraEx.Settings.MonkForbiddenChakra;
            MonkElixirField.Checked = ShinraEx.Settings.MonkElixirField;
            MonkFireTackle.Checked = ShinraEx.Settings.MonkFireTackle;

            #endregion

            #region Buff

            MonkInternalRelease.Checked = ShinraEx.Settings.MonkInternalRelease;
            MonkPerfectBalance.Checked = ShinraEx.Settings.MonkPerfectBalance;
            MonkFormShift.Checked = ShinraEx.Settings.MonkFormShift;
            MonkMeditation.Checked = ShinraEx.Settings.MonkMeditation;
            MonkRiddleOfFire.Checked = ShinraEx.Settings.MonkRiddleOfFire;
            MonkBrotherhood.Checked = ShinraEx.Settings.MonkBrotherhood;

            #endregion

            #region Fists

            MonkFist.Text = Convert.ToString(ShinraEx.Settings.MonkFist);

            #endregion

            #region Misc

            MonkOpener.Checked = ShinraEx.Settings.MonkOpener;
            MonkPotion.Checked = ShinraEx.Settings.MonkPotion;

            #endregion

            #endregion

            #region Ninja

            #region Role

            NinjaSecondWind.Checked = ShinraEx.Settings.NinjaSecondWind;
            NinjaInvigorate.Checked = ShinraEx.Settings.NinjaInvigorate;
            NinjaBloodbath.Checked = ShinraEx.Settings.NinjaBloodbath;
            NinjaGoad.Checked = ShinraEx.Settings.NinjaGoad;
            NinjaTrueNorth.Checked = ShinraEx.Settings.NinjaTrueNorth;

            NinjaSecondWindPct.Value = ShinraEx.Settings.NinjaSecondWindPct;
            NinjaInvigoratePct.Value = ShinraEx.Settings.NinjaInvigoratePct;
            NinjaBloodbathPct.Value = ShinraEx.Settings.NinjaBloodbathPct;
            NinjaGoadPct.Value = ShinraEx.Settings.NinjaGoadPct;

            #endregion

            #region DoT

            NinjaShadowFang.Checked = ShinraEx.Settings.NinjaShadowFang;
            NinjaShadowFangHP.Value = ShinraEx.Settings.NinjaShadowFangHP;

            #endregion

            #region Cooldown

            NinjaAssassinate.Checked = ShinraEx.Settings.NinjaAssassinate;
            NinjaMug.Checked = ShinraEx.Settings.NinjaMug;
            NinjaTrickAttack.Checked = ShinraEx.Settings.NinjaTrickAttack;
            NinjaJugulate.Checked = ShinraEx.Settings.NinjaJugulate;
            NinjaShukuchi.Checked = ShinraEx.Settings.NinjaShukuchi;
            NinjaDreamWithin.Checked = ShinraEx.Settings.NinjaDreamWithin;
            NinjaHellfrogMedium.Checked = ShinraEx.Settings.NinjaHellfrogMedium;
            NinjaBhavacakra.Checked = ShinraEx.Settings.NinjaBhavacakra;

            #endregion

            #region Buff

            NinjaShadeShift.Checked = ShinraEx.Settings.NinjaShadeShift;
            NinjaKassatsu.Checked = ShinraEx.Settings.NinjaKassatsu;
            NinjaDuality.Checked = ShinraEx.Settings.NinjaDuality;
            NinjaTenChiJin.Checked = ShinraEx.Settings.NinjaTenChiJin;

            NinjaShadeShiftPct.Value = ShinraEx.Settings.NinjaShadeShiftPct;

            #endregion

            #region Ninjutsu

            NinjaFuma.Checked = ShinraEx.Settings.NinjaFuma;
            NinjaKaton.Checked = ShinraEx.Settings.NinjaKaton;
            NinjaRaiton.Checked = ShinraEx.Settings.NinjaRaiton;
            NinjaHuton.Checked = ShinraEx.Settings.NinjaHuton;
            NinjaDoton.Checked = ShinraEx.Settings.NinjaDoton;
            NinjaSuiton.Checked = ShinraEx.Settings.NinjaSuiton;

            #endregion

            #region Misc

            NinjaOpener.Checked = ShinraEx.Settings.NinjaOpener;
            NinjaPotion.Checked = ShinraEx.Settings.NinjaPotion;

            #endregion

            #endregion

            #region Paladin

            #region Role

            PaladinRampart.Checked = ShinraEx.Settings.PaladinRampart;
            PaladinLowBlow.Checked = ShinraEx.Settings.PaladinLowBlow;
            PaladinProvoke.Checked = ShinraEx.Settings.PaladinProvoke;
            PaladinInterject.Checked = ShinraEx.Settings.PaladinInterject;
            PaladinReprisal.Checked = ShinraEx.Settings.PaladinReprisal;
            PaladinArmsLength.Checked = ShinraEx.Settings.PaladinArmsLength;
            PaladinRampartPct.Value = ShinraEx.Settings.PaladinRampartPct;

            #endregion

            #region AoE

            PaladinTotalEclipse.Checked = ShinraEx.Settings.PaladinTotalEclipse;
            PaladinProminence.Checked = ShinraEx.Settings.PaladinProminence;
            PaladinHolyCircle.Checked = ShinraEx.Settings.PaladinHolyCircle;

            #endregion

            #region Cooldown

            PaladinSpiritsWithin.Checked = ShinraEx.Settings.PaladinSpiritsWithin;
            PaladinCircleOfScorn.Checked = ShinraEx.Settings.PaladinCircleOfScorn;
            PaladinRequiescat.Checked = ShinraEx.Settings.PaladinRequiescat;

            #endregion

            #region Buff

            PaladinFightOrFlight.Checked = ShinraEx.Settings.PaladinFightOrFlight;
            PaladinSentinel.Checked = ShinraEx.Settings.PaladinSentinel;
            PaladinHallowedGround.Checked = ShinraEx.Settings.PaladinHallowedGround;
            PaladinSheltron.Checked = ShinraEx.Settings.PaladinSheltron;

            PaladinSentinelPct.Value = ShinraEx.Settings.PaladinSentinelPct;
            PaladinHallowedGroundPct.Value = ShinraEx.Settings.PaladinHallowedGroundPct;

            #endregion

            #region Heal

            PaladinClemency.Checked = ShinraEx.Settings.PaladinClemency;
            PaladinClemencyPct.Value = ShinraEx.Settings.PaladinClemencyPct;

            #endregion

            #region Misc

            PaladinOpener.Checked = ShinraEx.Settings.PaladinOpener;
            PaladinPotion.Checked = ShinraEx.Settings.PaladinPotion;

            #endregion

            #endregion

            #region Red Mage

            #region Role


            RedMageLucidDreaming.Checked = ShinraEx.Settings.RedMageLucidDreaming;
            RedMageSwiftcast.Checked = ShinraEx.Settings.RedMageSwiftcast;


            RedMageLucidDreamingPct.Value = ShinraEx.Settings.RedMageLucidDreamingPct;

            #endregion

            #region Cooldown

            RedMageCorpsACorps.Checked = ShinraEx.Settings.RedMageCorpsACorps;
            RedMageDisplacement.Checked = ShinraEx.Settings.RedMageDisplacement;

            #endregion

            #region Buff

            RedMageEmbolden.Checked = ShinraEx.Settings.RedMageEmbolden;
            RedMageManafication.Checked = ShinraEx.Settings.RedMageManafication;

            #endregion

            #region Heal

            RedMageVercure.Checked = ShinraEx.Settings.RedMageVercure;
            RedMageVerraise.Checked = ShinraEx.Settings.RedMageVerraise;

            RedMageVercurePct.Value = ShinraEx.Settings.RedMageVercurePct;

            #endregion

            #region Misc

            RedMageOpener.Checked = ShinraEx.Settings.RedMageOpener;
            RedMagePotion.Checked = ShinraEx.Settings.RedMagePotion;

            #endregion

            #endregion

            #region Samurai

            #region Role

            SamuraiSecondWind.Checked = ShinraEx.Settings.SamuraiSecondWind;
            SamuraiInvigorate.Checked = ShinraEx.Settings.SamuraiInvigorate;
            SamuraiBloodbath.Checked = ShinraEx.Settings.SamuraiBloodbath;
            SamuraiGoad.Checked = ShinraEx.Settings.SamuraiGoad;
            SamuraiTrueNorth.Checked = ShinraEx.Settings.SamuraiTrueNorth;

            SamuraiSecondWindPct.Value = ShinraEx.Settings.SamuraiSecondWindPct;
            SamuraiInvigoratePct.Value = ShinraEx.Settings.SamuraiInvigoratePct;
            SamuraiBloodbathPct.Value = ShinraEx.Settings.SamuraiBloodbathPct;
            SamuraiGoadPct.Value = ShinraEx.Settings.SamuraiGoadPct;

            #endregion

            #region Damage

            SamuraiMidare.Checked = ShinraEx.Settings.SamuraiMidare;
            SamuraiMidareHP.Value = ShinraEx.Settings.SamuraiMidareHP;

            #endregion

            #region DoT

            SamuraiHiganbana.Checked = ShinraEx.Settings.SamuraiHiganbana;
            SamuraiHiganbanaHP.Value = ShinraEx.Settings.SamuraiHiganbanaHP;

            #endregion

            #region Cooldown

            SamuraiGyoten.Checked = ShinraEx.Settings.SamuraiGyoten;
            SamuraiGuren.Checked = ShinraEx.Settings.SamuraiGuren;

            #endregion

            #region Buff

            SamuraiMeikyo.Checked = ShinraEx.Settings.SamuraiMeikyo;
            SamuraiHagakure.Checked = ShinraEx.Settings.SamuraiHagakure;

            #endregion

            #region Heal

            SamuraiMerciful.Checked = ShinraEx.Settings.SamuraiMerciful;
            SamuraiMercifulPct.Value = ShinraEx.Settings.SamuraiMercifulPct;

            #endregion

            #region Misc

            SamuraiOpener.Checked = ShinraEx.Settings.SamuraiOpener;
            SamuraiPotion.Checked = ShinraEx.Settings.SamuraiPotion;

            #endregion

            #endregion

            #region Scholar

            #region Role

            ScholarEsuna.Checked = ShinraEx.Settings.ScholarEsuna;
            ScholarLucidDreaming.Checked = ShinraEx.Settings.ScholarLucidDreaming;
            ScholarLucidDreamingPct.Value = ShinraEx.Settings.ScholarLucidDreamingPct;
            ScholarSwiftcast.Checked = ShinraEx.Settings.ScholarSwiftcast;

            #endregion

            #region Damage

            ScholarStopDamage.Checked = ShinraEx.Settings.ScholarStopDamage;
            ScholarStopDots.Checked = ShinraEx.Settings.ScholarStopDots;

            ScholarStopDamagePct.Value = ShinraEx.Settings.ScholarStopDamagePct;
            ScholarStopDotsPct.Value = ShinraEx.Settings.ScholarStopDotsPct;

            #endregion

            #region AoE

            ScholarBane.Checked = ShinraEx.Settings.ScholarBane;

            #endregion

            #region Cooldown

            ScholarEnergyDrain.Checked = ShinraEx.Settings.ScholarEnergyDrain;
            ScholarEnergyDrainPct.Value = ShinraEx.Settings.ScholarEnergyDrainPct;
            ScholarShadowFlare.Checked = ShinraEx.Settings.ScholarShadowFlare;
            ScholarChainStrategem.Checked = ShinraEx.Settings.ScholarChainStrategem;

            #endregion

            #region Buff

            ScholarRouse.Checked = ShinraEx.Settings.ScholarRouse;
            ScholarEmergencyTactics.Checked = ShinraEx.Settings.ScholarEmergencyTactics;

            #endregion

            #region Heal

            ScholarPartyHeal.Checked = ShinraEx.Settings.ScholarPartyHeal;
            ScholarInterruptDamage.Checked = ShinraEx.Settings.ScholarInterruptDamage;
            ScholarInterruptOverheal.Checked = ShinraEx.Settings.ScholarInterruptOverheal;
            ScholarPhysick.Checked = ShinraEx.Settings.ScholarPhysick;
            ScholarAdloquium.Checked = ShinraEx.Settings.ScholarAdloquium;
            ScholarAetherpact.Checked = ShinraEx.Settings.ScholarAetherpact;
            ScholarLustrate.Checked = ShinraEx.Settings.ScholarLustrate;
            ScholarExcogitation.Checked = ShinraEx.Settings.ScholarExcogitation;
            ScholarSuccor.Checked = ShinraEx.Settings.ScholarSuccor;
            ScholarIndomitability.Checked = ShinraEx.Settings.ScholarIndomitability;
            ScholarResurrection.Checked = ShinraEx.Settings.ScholarResurrection;

            ScholarPhysickPct.Value = ShinraEx.Settings.ScholarPhysickPct;
            ScholarAdloquiumPct.Value = ShinraEx.Settings.ScholarAdloquiumPct;
            ScholarAetherpactPct.Value = ShinraEx.Settings.ScholarAetherpactPct;
            ScholarLustratePct.Value = ShinraEx.Settings.ScholarLustratePct;
            ScholarExcogitationPct.Value = ShinraEx.Settings.ScholarExcogitationPct;
            ScholarSuccorPct.Value = ShinraEx.Settings.ScholarSuccorPct;
            ScholarIndomitabilityPct.Value = ShinraEx.Settings.ScholarIndomitabilityPct;

            #endregion

            #region Pet

            ScholarPet.Text = Convert.ToString(ShinraEx.Settings.ScholarPet);

            #endregion

            #endregion

            #region Summoner

            #region Role

            SummonerAddle.Checked = ShinraEx.Settings.SummonerAddle;
            SummonerDrain.Checked = ShinraEx.Settings.SummonerDrain;
            SummonerLucidDreaming.Checked = ShinraEx.Settings.SummonerLucidDreaming;
            SummonerSwiftcast.Checked = ShinraEx.Settings.SummonerSwiftcast;

            SummonerDrainPct.Value = ShinraEx.Settings.SummonerDrainPct;
            SummonerLucidDreamingPct.Value = ShinraEx.Settings.SummonerLucidDreamingPct;

            #endregion

            #region AoE

            SummonerBane.Checked = ShinraEx.Settings.SummonerBane;

            #endregion

            #region Cooldown

            SummonerShadowFlare.Checked = ShinraEx.Settings.SummonerShadowFlare;
            SummonerEnkindle.Checked = ShinraEx.Settings.SummonerEnkindle;
            SummonerTriDisaster.Checked = ShinraEx.Settings.SummonerTriDisaster;
            SummonerEnkindleBahamut.Checked = ShinraEx.Settings.SummonerEnkindleBahamut;

            #endregion

            #region Buff

            SummonerRouse.Checked = ShinraEx.Settings.SummonerRouse;
            SummonerDreadwyrmTrance.Checked = ShinraEx.Settings.SummonerDreadwyrmTrance;
            SummonerAetherpact.Checked = ShinraEx.Settings.SummonerAetherpact;
            SummonerSummonBahamut.Checked = ShinraEx.Settings.SummonerSummonBahamut;

            #endregion

            #region Heal

            SummonerPhysick.Checked = ShinraEx.Settings.SummonerPhysick;
            SummonerSustain.Checked = ShinraEx.Settings.SummonerSustain;
            SummonerResurrection.Checked = ShinraEx.Settings.SummonerResurrection;

            SummonerPhysickPct.Value = ShinraEx.Settings.SummonerPhysickPct;
            SummonerSustainPct.Value = ShinraEx.Settings.SummonerSustainPct;

            #endregion

            #region Pet

            SummonerPet.Text = Convert.ToString(ShinraEx.Settings.SummonerPet);

            #endregion

            #region Misc

            SummonerOpener.Checked = ShinraEx.Settings.SummonerOpener;
            SummonerPotion.Checked = ShinraEx.Settings.SummonerPotion;
            SummonerOpenerGaruda.Checked = ShinraEx.Settings.SummonerOpenerGaruda;

            #endregion

            #endregion

            #region Warrior

            #region Role

            WarriorRampart.Checked = ShinraEx.Settings.WarriorRampart;
            WarriorLowBlow.Checked = ShinraEx.Settings.WarriorLowBlow;
            WarriorProvoke.Checked = ShinraEx.Settings.WarriorProvoke;
            WarriorInterject.Checked = ShinraEx.Settings.WarriorInterject;
            WarriorReprisal.Checked = ShinraEx.Settings.WarriorReprisal;
            WarriorArmsLength.Checked = ShinraEx.Settings.WarriorArmsLength;
            WarriorRampartPct.Value = ShinraEx.Settings.WarriorRampartPct;

            #endregion

            #region Damage

            WarriorMaim.Checked = ShinraEx.Settings.WarriorMaim;
            WarriorStormsEye.Checked = ShinraEx.Settings.WarriorStormsEye;
            WarriorInnerBeast.Checked = ShinraEx.Settings.WarriorInnerBeast;
            WarriorFellCleave.Checked = ShinraEx.Settings.WarriorFellCleave;

            #endregion

            #region AoE

            WarriorOverpower.Checked = ShinraEx.Settings.WarriorOverpower;
            WarriorSteelCyclone.Checked = ShinraEx.Settings.WarriorSteelCyclone;
            WarriorDecimate.Checked = ShinraEx.Settings.WarriorDecimate;

            #endregion

            #region Cooldown

            WarriorOnslaught.Checked = ShinraEx.Settings.WarriorOnslaught;
            WarriorUpheaval.Checked = ShinraEx.Settings.WarriorUpheaval;

            #endregion

            #region Buff

            WarriorBerserk.Checked = ShinraEx.Settings.WarriorBerserk;
            WarriorThrillOfBattle.Checked = ShinraEx.Settings.WarriorThrillOfBattle;
            WarriorUnchained.Checked = ShinraEx.Settings.WarriorUnchained;
            WarriorVengeance.Checked = ShinraEx.Settings.WarriorVengeance;
            WarriorInfuriate.Checked = ShinraEx.Settings.WarriorInfuriate;
            WarriorEquilibriumTP.Checked = ShinraEx.Settings.WarriorEquilibriumTP;
            WarriorShakeItOff.Checked = ShinraEx.Settings.WarriorShakeItOff;
            WarriorInnerRelease.Checked = ShinraEx.Settings.WarriorInnerRelease;

            WarriorThrillOfBattlePct.Value = ShinraEx.Settings.WarriorThrillOfBattlePct;
            WarriorVengeancePct.Value = ShinraEx.Settings.WarriorVengeancePct;
            WarriorEquilibriumTPPct.Value = ShinraEx.Settings.WarriorEquilibriumTPPct;

            #endregion

            #region Heal

            WarriorEquilibrium.Checked = ShinraEx.Settings.WarriorEquilibrium;
            WarriorEquilibriumPct.Value = ShinraEx.Settings.WarriorEquilibriumPct;

            #endregion

            #region Stance

            WarriorStance.Text = Convert.ToString(ShinraEx.Settings.WarriorStance);

            #endregion

            #region Misc

            WarriorOpener.Checked = ShinraEx.Settings.WarriorOpener;
            WarriorPotion.Checked = ShinraEx.Settings.WarriorPotion;

            #endregion

            #endregion

            #region White Mage

            #region Role

            WhiteMageEsuna.Checked = ShinraEx.Settings.WhiteMageEsuna;
            WhiteMageLucidDreaming.Checked = ShinraEx.Settings.WhiteMageLucidDreaming;
            WhiteMageLucidDreamingPct.Value = ShinraEx.Settings.WhiteMageLucidDreamingPct;
            WhiteMageSwiftcast.Checked = ShinraEx.Settings.WhiteMageSwiftcast;

            #endregion

            #region Damage

            WhiteMageStopDamage.Checked = ShinraEx.Settings.WhiteMageStopDamage;
            WhiteMageStopDots.Checked = ShinraEx.Settings.WhiteMageStopDots;

            WhiteMageStopDamagePct.Value = ShinraEx.Settings.WhiteMageStopDamagePct;
            WhiteMageStopDotsPct.Value = ShinraEx.Settings.WhiteMageStopDotsPct;

            #endregion

            #region Buff

            WhiteMagePresenceOfMind.Checked = ShinraEx.Settings.WhiteMagePresenceOfMind;
            WhiteMagePresenceOfMindCount.Value = ShinraEx.Settings.WhiteMagePresenceOfMindCount;
            WhiteMagePresenceOfMindPct.Value = ShinraEx.Settings.WhiteMagePresenceOfMindPct;
            WhiteMageTemperance.Checked = ShinraEx.Settings.WhiteMageTemperance;
            WhiteMageTemperanceCount.Value = ShinraEx.Settings.WhiteMageTemperanceCount;
            WhiteMageTemperancePct.Value = ShinraEx.Settings.WhiteMageTemperancePct;
            WhiteMageThinAir.Checked = ShinraEx.Settings.WhiteMageThinAir;

            #endregion

            #region Heal

            WhiteMagePartyHeal.Checked = ShinraEx.Settings.WhiteMagePartyHeal;
            WhiteMageInterruptDamage.Checked = ShinraEx.Settings.WhiteMageInterruptDamage;
            WhiteMageInterruptOverheal.Checked = ShinraEx.Settings.WhiteMageInterruptOverheal;
            WhiteMageCure.Checked = ShinraEx.Settings.WhiteMageCure;
            WhiteMageCureII.Checked = ShinraEx.Settings.WhiteMageCureII;
            WhiteMageCureIII.Checked = ShinraEx.Settings.WhiteMageCureIII;
            WhiteMageTetragrammaton.Checked = ShinraEx.Settings.WhiteMageTetragrammaton;
            WhiteMageAfflatusSolace.Checked = ShinraEx.Settings.WhiteMageAfflatusSolace;
            WhiteMageBenediction.Checked = ShinraEx.Settings.WhiteMageBenediction;
            WhiteMageAfflatusRapture.Checked = ShinraEx.Settings.WhiteMageAfflatusRapture;
            WhiteMageRegen.Checked = ShinraEx.Settings.WhiteMageRegen;
            WhiteMageMedica.Checked = ShinraEx.Settings.WhiteMageMedica;
            WhiteMageMedicaII.Checked = ShinraEx.Settings.WhiteMageMedicaII;
            WhiteMageAssize.Checked = ShinraEx.Settings.WhiteMageAssize;
            WhiteMagePlenary.Checked = ShinraEx.Settings.WhiteMagePlenary;
            WhiteMageRaise.Checked = ShinraEx.Settings.WhiteMageRaise;
            WhiteMageCurePct.Value = ShinraEx.Settings.WhiteMageCurePct;
            WhiteMageCureIIPct.Value = ShinraEx.Settings.WhiteMageCureIIPct;
            WhiteMageCureIIIPct.Value = ShinraEx.Settings.WhiteMageCureIIIPct;
            WhiteMageTetragrammatonPct.Value = ShinraEx.Settings.WhiteMageTetragrammatonPct;
            WhiteMageAfflatusSolacePct.Value = ShinraEx.Settings.WhiteMageAfflatusSolacePct;
            WhiteMageBenedictionPct.Value = ShinraEx.Settings.WhiteMageBenedictionPct;
            WhiteMageAfflatusRapturePct.Value = ShinraEx.Settings.WhiteMageAfflatusRapturePct;
            WhiteMageRegenPct.Value = ShinraEx.Settings.WhiteMageRegenPct;
            WhiteMageMedicaPct.Value = ShinraEx.Settings.WhiteMageMedicaPct;
            WhiteMageMedicaIIPct.Value = ShinraEx.Settings.WhiteMageMedicaIIPct;
            WhiteMageAssizePct.Value = ShinraEx.Settings.WhiteMageAssizePct;
            WhiteMagePlenaryPct.Value = ShinraEx.Settings.WhiteMagePlenaryPct;

            #endregion

            #endregion

            #endregion
        }
        
        private void ShinraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShinraEx.RegisterHotkeys();
            ShinraEx.RegisterClassHotkeys();
            ShinraEx.Settings.WindowLocation = Location;
            ShinraEx.Settings.Save();
        }

        private void ShinraClose_Click(object sender, EventArgs e)
        {
            Close();
        }

      

        #region Main Settings

        #region Rotation

        private void RotationOverlay_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RotationOverlay = RotationOverlay.Checked;
            ShinraEx.Overlay.Visible = RotationOverlay.Checked;
        }

        private void RotationMessages_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RotationMessages = RotationMessages.Checked;
        }

        private void RotationMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (RotationMode.Text == @"Smart") ShinraEx.Settings.RotationMode = Modes.Smart;
            if (RotationMode.Text == @"Single") ShinraEx.Settings.RotationMode = Modes.Single;
            if (RotationMode.Text == @"Multi") ShinraEx.Settings.RotationMode = Modes.Multi;
            ShinraEx.Overlay.UpdateText();
        }

        private void RotationHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            ShinraEx.Settings.RotationHotkey = RotationHotkey.Hotkey;
        }

        private void CooldownMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CooldownMode.Text == @"Enabled") ShinraEx.Settings.CooldownMode = CooldownModes.Enabled;
            if (CooldownMode.Text == @"Disabled") ShinraEx.Settings.CooldownMode = CooldownModes.Disabled;
            ShinraEx.Overlay.UpdateText();
        }

        private void CooldownHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            ShinraEx.Settings.CooldownHotkey = CooldownHotkey.Hotkey;
        }

        private void TankMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (TankMode.Text == @"DPS") ShinraEx.Settings.TankMode = TankModes.DPS;
            if (TankMode.Text == @"Enmity") ShinraEx.Settings.TankMode = TankModes.Enmity;
            ShinraEx.Overlay.UpdateText();
        }

        private void TankHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            ShinraEx.Settings.TankHotkey = TankHotkey.Hotkey;
        }

        #endregion

        #region Chocobo

        private void ChocoboSummon_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonChocobo = ChocoboSummon.Checked;
        }

        private void ChocoboStanceDance_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ChocoboStanceDance = ChocoboStanceDance.Checked;
        }

        private void ChocoboStanceDancePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ChocoboStanceDancePct = Convert.ToInt32(ChocoboStanceDancePct.Value);
        }

        private void ChocoboStance_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ChocoboStance.Text == @"Free") ShinraEx.Settings.ChocoboStance = Stances.Free;
            if (ChocoboStance.Text == @"Attacker") ShinraEx.Settings.ChocoboStance = Stances.Attacker;
            if (ChocoboStance.Text == @"Healer") ShinraEx.Settings.ChocoboStance = Stances.Healer;
            if (ChocoboStance.Text == @"Defender") ShinraEx.Settings.ChocoboStance = Stances.Defender;
        }

        #endregion

        #region Rest

        private void RestHealth_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RestHealth = RestHealth.Checked;
        }

        private void RestEnergy_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RestEnergy = RestEnergy.Checked;
        }

        private void RestHealthPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RestHealthPct = Convert.ToInt32(RestHealthPct.Value);
        }

        private void RestEnergyPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RestEnergyPct = Convert.ToInt32(RestEnergyPct.Value);
        }

        #endregion

        #region Spell

        private void RandomCastLocations_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RandomCastLocations = RandomCastLocations.Checked;
        }

        private void CustomAoE_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.CustomAoE = CustomAoE.Checked;
        }

        private void CustomAoECount_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.CustomAoECount = Convert.ToInt32(CustomAoECount.Value);
        }

        private void QueueSpells_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.QueueSpells = QueueSpells.Checked;
        }

        #endregion

        #region Misc

        private void IgnoreSmart_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.IgnoreSmart = IgnoreSmart.Checked;
        }

        private void DisableDebug_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DisableDebug = DisableDebug.Checked;
        }

        private void DisablePause_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.CrPaused = ShinraPause.Checked;
        }


        #endregion

        #endregion

        #region Job Settings

        #region Astrologian

        #region Role

        private void AstrologianEsuna_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianEsuna = AstrologianEsuna.Checked;
        }

        private void AstrologianLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianLucidDreaming = AstrologianLucidDreaming.Checked;
        }

        private void AstrologianLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianLucidDreamingPct = Convert.ToInt32(AstrologianLucidDreamingPct.Value);
        }

        private void AstrologianSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianSwiftcast = AstrologianSwiftcast.Checked;
        }

        #endregion

        #region Damage

        private void AstrologianStopDamage_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianStopDamage = AstrologianStopDamage.Checked;
        }

        private void AstrologianStopDots_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianStopDots = AstrologianStopDots.Checked;
        }

        private void AstrologianStopDamagePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianStopDamagePct = Convert.ToInt32(AstrologianStopDamagePct.Value);
        }

        private void AstrologianStopDotsPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianStopDotsPct = Convert.ToInt32(AstrologianStopDotsPct.Value);
        }

        #endregion

        #region AoE

        private void AstrologianEarthlyStar_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianEarthlyStar = AstrologianEarthlyStar.Checked;
        }

        private void AstrologianStellarDetonation_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianStellarDetonation = AstrologianStellarDetonation.Checked;
        }

        #endregion

        #region Buff

        private void AstrologianLightspeed_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianLightspeed = AstrologianLightspeed.Checked;
        }

        private void AstrologianLightspeedCount_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianLightspeedCount = Convert.ToInt32(AstrologianLightspeedCount.Value);
        }

        private void AstrologianLightspeedPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianLightspeedPct = Convert.ToInt32(AstrologianLightspeedPct.Value);
        }

        private void AstrologianSynastry_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianSynastry = AstrologianSynastry.Checked;
        }

        private void AstrologianSynastryCount_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianSynastryCount = Convert.ToInt32(AstrologianSynastryCount.Value);
        }

        private void AstrologianSynastryPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianSynastryPct = Convert.ToInt32(AstrologianSynastryPct.Value);
        }

        private void AstrologianTimeDilation_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianTimeDilation = AstrologianTimeDilation.Checked;
        }

        private void AstrologianCelestialOpposition_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianCelestialOpposition = AstrologianCelestialOpposition.Checked;
        }

        #endregion

        #region Heal

        private void AstrologianPartyHeal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianPartyHeal = AstrologianPartyHeal.Checked;
        }

        private void AstrologianInterruptDamage_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianInterruptDamage = AstrologianInterruptDamage.Checked;
        }

        private void AstrologianInterruptOverheal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianInterruptOverheal = AstrologianInterruptOverheal.Checked;
        }

        private void AstrologianBenefic_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianBenefic = AstrologianBenefic.Checked;
        }

        private void AstrologianBeneficII_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianBeneficII = AstrologianBeneficII.Checked;
        }

        private void AstrologianEssDignity_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianEssDignity = AstrologianEssDignity.Checked;
        }

        private void AstrologianAspBenefic_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianAspBenefic = AstrologianAspBenefic.Checked;
        }

        private void AstrologianHelios_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianHelios = AstrologianHelios.Checked;
        }

        private void AstrologianAspHelios_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianAspHelios = AstrologianAspHelios.Checked;
        }

        private void AstrologianAscend_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianAscend = AstrologianAscend.Checked;
        }

        private void AstrologianBeneficPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianBeneficPct = Convert.ToInt32(AstrologianBeneficPct.Value);
        }

        private void AstrologianBeneficIIPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianBeneficIIPct = Convert.ToInt32(AstrologianBeneficIIPct.Value);
        }

        private void AstrologianEssDignityPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianEssDignityPct = Convert.ToInt32(AstrologianEssDignityPct.Value);
        }

        private void AstrologianAspBeneficPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianAspBeneficPct = Convert.ToInt32(AstrologianAspBeneficPct.Value);
        }

        private void AstrologianHeliosPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianHeliosPct = Convert.ToInt32(AstrologianHeliosPct.Value);
        }

        private void AstrologianAspHeliosPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianAspHeliosPct = Convert.ToInt32(AstrologianAspHeliosPct.Value);
        }

        #endregion

        #region Card

        private void AstrologianDraw_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianDraw = AstrologianDraw.Checked;
        }

        private void AstrologianSleeveDraw_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianSleeveDraw = AstrologianSleeveDraw.Checked;
        }

        private void AstrologianCardPreCombat_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianCardPreCombat = AstrologianCardPreCombat.Checked;
        }

        #endregion

        #region Sect

        private void AstrologianSect_SelectedValueChanged(object sender, EventArgs e)
        {
            if (AstrologianSect.Text == @"None") ShinraEx.Settings.AstrologianSect = AstrologianSects.None;
            if (AstrologianSect.Text == @"Diurnal") ShinraEx.Settings.AstrologianSect = AstrologianSects.Diurnal;
            if (AstrologianSect.Text == @"Nocturnal") ShinraEx.Settings.AstrologianSect = AstrologianSects.Nocturnal;
        }

        #endregion

        #region Misc

        private void AstrologianCardOnly_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.AstrologianCardOnly = AstrologianCardOnly.Checked;
        }

        #endregion

        #endregion

        #region Bard

        #region Role

        private void BardSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardSecondWind = BardSecondWind.Checked;
        }

        private void BardPeloton_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardPeloton = BardPeloton.Checked;
        }

        private void BardInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardInvigorate = BardInvigorate.Checked;
        }

        private void BardTactician_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardTactician = BardTactician.Checked;
        }

        private void BardRefresh_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardRefresh = BardRefresh.Checked;
        }

        private void BardPalisade_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardPalisade = BardPalisade.Checked;
        }

        private void BardSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardSecondWindPct = Convert.ToInt32(BardSecondWindPct.Value);
        }

        private void BardInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardInvigoratePct = Convert.ToInt32(BardInvigoratePct.Value);
        }

        private void BardTacticianPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardTacticianPct = Convert.ToInt32(BardTacticianPct.Value);
        }

        private void BardRefreshPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardRefreshPct = Convert.ToInt32(BardRefreshPct.Value);
        }

        private void BardPalisadePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardPalisadePct = Convert.ToInt32(BardPalisadePct.Value);
        }

        #endregion

        #region Damage

        private void BardPitchPerfect_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardPitchPerfect = BardPitchPerfect.Checked;
        }

        private void BardRepertoireCount_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardRepertoireCount = Convert.ToInt32(BardRepertoireCount.Value);
        }

        #endregion

        #region DoT

        private void BardUseDots_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardUseDots = BardUseDots.Checked;
        }

        private void BardUseDotsAoe_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardUseDotsAoe = BardUseDotsAoe.Checked;
        }

        private void BardDotSnapshot_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardDotSnapshot = BardDotSnapshot.Checked;
        }

        #endregion

        #region Cooldown

        private void BardSongs_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardSongs = BardSongs.Checked;
        }

        private void BardEmpyrealArrow_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardEmpyrealArrow = BardEmpyrealArrow.Checked;
        }

        private void BardSidewinder_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardSidewinder = BardSidewinder.Checked;
        }

        #endregion

        #region Buff

        private void BardRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardRagingStrikes = BardRagingStrikes.Checked;
        }

        private void BardFoeRequiem_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardFoeRequiem = BardFoeRequiem.Checked;
        }

        private void BardFoeRequiemPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardFoeRequiemPct = Convert.ToInt32(BardFoeRequiemPct.Value);
        }

        private void BardBarrage_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardBarrage = BardBarrage.Checked;
        }

        private void BardBattleVoice_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardBattleVoice = BardBattleVoice.Checked;
        }

        #endregion

        #region Misc

        private void BardOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardOpener = BardOpener.Checked;
        }

        private void BardPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BardPotion = BardPotion.Checked;
        }

        #endregion

        #endregion

        #region Black Mage

        #region Role

     
        private void BlackMageLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageLucidDreaming = BlackMageLucidDreaming.Checked;
        }

        private void BlackMageSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageSwiftcast = BlackMageSwiftcast.Checked;
        }

       

        private void BlackMageLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageLucidDreamingPct = Convert.ToInt32(BlackMageLucidDreamingPct.Value);
        }

        #endregion

        #region Damage

        private void BlackMageScathe_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageScathe = BlackMageScathe.Checked;
        }

        #endregion

        #region AoE

        private void BlackMageThunder_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageThunder = BlackMageThunder.Checked;
        }

        #endregion

        #region Buff

        private void BlackMageConvert_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageConvert = BlackMageConvert.Checked;
        }

        private void BlackMageLeyLines_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageLeyLines = BlackMageLeyLines.Checked;
        }

        private void BlackMageSharpcast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageSharpcast = BlackMageSharpcast.Checked;
        }

        private void BlackMageEnochian_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageEnochian = BlackMageEnochian.Checked;
        }

        private void BlackMageTriplecast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageTriplecast = BlackMageTriplecast.Checked;
        }

        #endregion

        #region Misc

        private void BlackMageOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageOpener = BlackMageOpener.Checked;
        }

        private void BlackMagePotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMagePotion = BlackMagePotion.Checked;
        }

        #endregion

        #endregion

        #region Dark Knight

        #region Role

        private void DarkKnightRampart_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightRampart = DarkKnightRampart.Checked;
        }

        private void DarkKnightLowBlow_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightLowBlow = DarkKnightLowBlow.Checked;
        }

        private void DarkKnightProvoke_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightProvoke = DarkKnightProvoke.Checked;
        }

        private void DarkKnightInterject_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightInterject = DarkKnightInterject.Checked;
        }

        private void DarkKnightReprisal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightReprisal = DarkKnightReprisal.Checked;
        }

        private void DarkKnightArmsLength_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightArmsLength = DarkKnightArmsLength.Checked;
        }

        private void DarkKnightRampartPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightRampartPct = Convert.ToInt32(DarkKnightRampartPct.Value);
        }

        #endregion

        #region Damage

        private void DarkKnightBloodspiller_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightBloodspiller = DarkKnightBloodspiller.Checked;
        }

        #endregion

        #region AoE

        private void DarkKnightQuietus_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightQuietus = DarkKnightQuietus.Checked;
        }

        #endregion

        #region Cooldown

        private void DarkKnightSaltedEarth_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightSaltedEarth = DarkKnightSaltedEarth.Checked;
        }

        private void DarkKnightPlunge_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightPlunge = DarkKnightPlunge.Checked;
        }

        private void DarkKnightCarveAndSpit_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightCarveAndSpit = DarkKnightCarveAndSpit.Checked;
        }

        #endregion

        #region Buff

        private void DarkKnightBloodWeapon_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightBloodWeapon = DarkKnightBloodWeapon.Checked;
        }

        private void DarkKnightBloodPrice_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightBloodPrice = DarkKnightBloodPrice.Checked;
        }

        private void DarkKnightShadowWall_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightShadowWall = DarkKnightShadowWall.Checked;
        }

        private void DarkKnightLivingDead_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightLivingDead = DarkKnightLivingDead.Checked;
        }

        private void DarkKnightDelirium_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightDelirium = DarkKnightDelirium.Checked;
        }

        private void DarkKnightBlackestNight_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightBlackestNight = DarkKnightBlackestNight.Checked;
        }

        private void DarkKnightBloodPricePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightBloodPricePct = Convert.ToInt32(DarkKnightBloodPricePct.Value);
        }

        private void DarkKnightShadowWallPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightShadowWallPct = Convert.ToInt32(DarkKnightShadowWallPct.Value);
        }

        private void DarkKnightLivingDeadPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightLivingDeadPct = Convert.ToInt32(DarkKnightLivingDeadPct.Value);
        }

        private void DarkKnightBlackestNightPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightBlackestNightPct = Convert.ToInt32(DarkKnightBlackestNightPct.Value);
        }

        #endregion

        #region Dark Arts

        private void DarkKnightSouleaterArts_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightSouleaterArts = DarkKnightSouleaterArts.Checked;
        }

        private void DarkKnightAbyssalArts_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightAbyssalArts = DarkKnightAbyssalArts.Checked;
        }

        private void DarkKnightCarveArts_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightCarveArts = DarkKnightCarveArts.Checked;
        }

        private void DarkKnightQuietusArts_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightQuietusArts = DarkKnightQuietusArts.Checked;
        }

        private void DarkKnightBloodspillerArts_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightBloodspillerArts = DarkKnightBloodspillerArts.Checked;
        }

        #endregion

        #region Aura

        private void DarkKnightGrit_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightGrit = DarkKnightGrit.Checked;
        }

        private void DarkKnightDarkside_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightDarkside = DarkKnightDarkside.Checked;
        }

        #endregion

        #region Misc

        private void DarkKnightOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightOpener = DarkKnightOpener.Checked;
        }

        private void DarkKnightPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightPotion = DarkKnightPotion.Checked;
        }

        private void DarkKnightOffTank_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DarkKnightOffTank = DarkKnightOffTank.Checked;
        }

        #endregion

        #endregion

        #region Dragoon

        #region Role

        private void DragoonSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonSecondWind = DragoonSecondWind.Checked;
        }

        private void DragoonInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonInvigorate = DragoonInvigorate.Checked;
        }

        private void DragoonBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonBloodbath = DragoonBloodbath.Checked;
        }

        private void DragoonGoad_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonGoad = DragoonGoad.Checked;
        }

        private void DragoonTrueNorth_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonTrueNorth = DragoonTrueNorth.Checked;
        }

        private void DragoonSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonSecondWindPct = Convert.ToInt32(DragoonSecondWindPct.Value);
        }

        private void DragoonInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonInvigoratePct = Convert.ToInt32(DragoonInvigoratePct.Value);
        }

        private void DragoonBloodbathPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonBloodbathPct = Convert.ToInt32(DragoonBloodbathPct.Value);
        }

        private void DragoonGoadPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonGoadPct = Convert.ToInt32(DragoonGoadPct.Value);
        }

        #endregion

        #region Cooldown

        private void DragoonJump_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonJump = DragoonJump.Checked;
        }

        private void DragoonSpineshatter_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonSpineshatter = DragoonSpineshatter.Checked;
        }

        private void DragoonDragonfire_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonDragonfire = DragoonDragonfire.Checked;
        }

        private void DragoonGeirskogul_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonGeirskogul = DragoonGeirskogul.Checked;
        }

        private void DragoonMirage_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonMirage = DragoonMirage.Checked;
        }

        #endregion

        #region Buff

        private void DragoonLifeSurge_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonLifeSurge = DragoonLifeSurge.Checked;
        }

        private void DragoonBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonBloodForBlood = DragoonBloodForBlood.Checked;
        }

        private void DragoonBattleLitany_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonBattleLitany = DragoonBattleLitany.Checked;
        }

        private void DragoonBloodOfTheDragon_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonBloodOfTheDragon = DragoonBloodOfTheDragon.Checked;
        }

        private void DragoonDragonSight_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonDragonSight = DragoonDragonSight.Checked;
        }

        #endregion

        #region Misc

        private void DragoonOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonOpener = DragoonOpener.Checked;
        }

        private void DragoonPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.DragoonPotion = DragoonPotion.Checked;
        }

        #endregion

        #endregion

        #region Machinist

        #region Role

        private void MachinistSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistSecondWind = MachinistSecondWind.Checked;
        }

        private void MachinistPeloton_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistPeloton = MachinistPeloton.Checked;
        }

        private void MachinistInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistInvigorate = MachinistInvigorate.Checked;
        }

        private void MachinistTactician_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistTactician = MachinistTactician.Checked;
        }

        private void MachinistRefresh_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistRefresh = MachinistRefresh.Checked;
        }

        private void MachinistPalisade_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistPalisade = MachinistPalisade.Checked;
        }

        private void MachinistSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistSecondWindPct = Convert.ToInt32(MachinistSecondWindPct.Value);
        }

        private void MachinistInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistInvigoratePct = Convert.ToInt32(MachinistInvigoratePct.Value);
        }

        private void MachinistTacticianPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistTacticianPct = Convert.ToInt32(MachinistTacticianPct.Value);
        }

        private void MachinistRefreshPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistRefreshPct = Convert.ToInt32(MachinistRefreshPct.Value);
        }

        private void MachinistPalisadePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistPalisadePct = Convert.ToInt32(MachinistPalisadePct.Value);
        }

        #endregion

        #region Cooldown

        private void MachinistWildfire_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistWildfire = MachinistWildfire.Checked;
        }

        private void MachinistRicochet_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistRicochet = MachinistRicochet.Checked;
        }

        private void MachinistCooldown_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistCooldown = MachinistCooldown.Checked;
        }

        private void MachinistFlamethrower_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistFlamethrower = MachinistFlamethrower.Checked;
        }

        private void MachinistWildfireHP_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistWildfireHP = Convert.ToInt32(MachinistWildfireHP.Value);
        }

        #endregion

        #region Buff

        private void MachinistReload_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistReload = MachinistReload.Checked;
        }

        private void MachinistReassemble_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistReassemble = MachinistReassemble.Checked;
        }

        private void MachinistRapidFire_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistRapidFire = MachinistRapidFire.Checked;
        }

        private void MachinistGaussBarrel_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistGaussBarrel = MachinistGaussBarrel.Checked;
        }

        private void MachinistHypercharge_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistHypercharge = MachinistHypercharge.Checked;
        }

        private void MachinistBarrelStabilizer_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistBarrelStabilizer = MachinistBarrelStabilizer.Checked;
        }

        private void MachinistRookOverdrive_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistRookOverdrive = MachinistRookOverdrive.Checked;
        }

        private void MachinistBishopOverdrive_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistBishopOverdrive = MachinistBishopOverdrive.Checked;
        }

        #endregion

        #region Turret

        private void MachinistTurret_SelectedValueChanged(object sender, EventArgs e)
        {
            if (MachinistTurret.Text == @"None") ShinraEx.Settings.MachinistTurret = MachinistTurrets.None;
            if (MachinistTurret.Text == @"Rook") ShinraEx.Settings.MachinistTurret = MachinistTurrets.Rook;
            if (MachinistTurret.Text == @"Bishop") ShinraEx.Settings.MachinistTurret = MachinistTurrets.Bishop;
        }

        private void MachinistTurretHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            ShinraEx.Settings.MachinistTurretHotkey = MachinistTurretHotkey.Hotkey;
        }

        private void MachinistTurretLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (MachinistTurretLocation.Text == @"Self") ShinraEx.Settings.MachinistTurretLocation = CastLocations.Self;
            if (MachinistTurretLocation.Text == @"Target") ShinraEx.Settings.MachinistTurretLocation = CastLocations.Target;
        }

        #endregion

        #region Misc

        private void MachinistOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistOpener = MachinistOpener.Checked;
        }

        private void MachinistPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistPotion = MachinistPotion.Checked;
        }

        private void MachinistSyncWildfire_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistSyncWildfire = MachinistSyncWildfire.Checked;
        }

        private void MachinistSyncOverheat_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MachinistSyncOverheat = MachinistSyncOverheat.Checked;
        }

        #endregion

        #endregion

        #region Monk

        #region Role

        private void MonkSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkSecondWind = MonkSecondWind.Checked;
        }

        private void MonkInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkInvigorate = MonkInvigorate.Checked;
        }

        private void MonkBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkBloodbath = MonkBloodbath.Checked;
        }

        private void MonkGoad_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkGoad = MonkGoad.Checked;
        }

        private void MonkTrueNorth_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkTrueNorth = MonkTrueNorth.Checked;
        }

        private void MonkSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkSecondWindPct = Convert.ToInt32(MonkSecondWindPct.Value);
        }

        private void MonkInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkInvigoratePct = Convert.ToInt32(MonkInvigoratePct.Value);
        }

        private void MonkBloodbathPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkBloodbathPct = Convert.ToInt32(MonkBloodbathPct.Value);
        }

        private void MonkGoadPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkGoadPct = Convert.ToInt32(MonkGoadPct.Value);
        }

        #endregion

        #region DoT

        private void MonkDemolish_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkDemolish = MonkDemolish.Checked;
        }

        private void MonkDemolishHP_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkDemolishHP = Convert.ToInt32(MonkDemolishHP.Value);
        }

        #endregion

        #region Cooldown

        private void MonkShoulderTackle_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkShoulderTackle = MonkShoulderTackle.Checked;
        }

        private void MonkSteelPeak_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkSteelPeak = MonkSteelPeak.Checked;
        }

        private void MonkHowlingFist_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkHowlingFist = MonkHowlingFist.Checked;
        }

        private void MonkForbiddenChakra_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkForbiddenChakra = MonkForbiddenChakra.Checked;
        }

        private void MonkElixirField_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkElixirField = MonkElixirField.Checked;
        }

        private void MonkFireTackle_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkFireTackle = MonkFireTackle.Checked;
        }

        #endregion

        #region Buff

        private void MonkInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkInternalRelease = MonkInternalRelease.Checked;
        }

        private void MonkPerfectBalance_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkPerfectBalance = MonkPerfectBalance.Checked;
        }

        private void MonkFormShift_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkFormShift = MonkFormShift.Checked;
        }

        private void MonkMeditation_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkMeditation = MonkMeditation.Checked;
        }

        private void MonkRiddleOfFire_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkRiddleOfFire = MonkRiddleOfFire.Checked;
        }

        private void MonkBrotherhood_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkBrotherhood = MonkBrotherhood.Checked;
        }

        #endregion

        #region Fists

        private void MonkFist_SelectedValueChanged(object sender, EventArgs e)
        {
            if (MonkFist.Text == @"None") ShinraEx.Settings.MonkFist = MonkFists.None;
            if (MonkFist.Text == @"Earth") ShinraEx.Settings.MonkFist = MonkFists.Earth;
            if (MonkFist.Text == @"Wind") ShinraEx.Settings.MonkFist = MonkFists.Wind;
            if (MonkFist.Text == @"Fire") ShinraEx.Settings.MonkFist = MonkFists.Fire;
        }

        #endregion

        #region Misc

        private void MonkOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkOpener = MonkOpener.Checked;
        }

        private void MonkPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.MonkPotion = MonkPotion.Checked;
        }

        #endregion

        #endregion

        #region Ninja

        #region Role

        private void NinjaSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaSecondWind = NinjaSecondWind.Checked;
        }

        private void NinjaInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaInvigorate = NinjaInvigorate.Checked;
        }

        private void NinjaBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaBloodbath = NinjaBloodbath.Checked;
        }

        private void NinjaGoad_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaGoad = NinjaGoad.Checked;
        }

        private void NinjaTrueNorth_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaTrueNorth = NinjaTrueNorth.Checked;
        }

        private void NinjaSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaSecondWindPct = Convert.ToInt32(NinjaSecondWindPct.Value);
        }

        private void NinjaInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaInvigoratePct = Convert.ToInt32(NinjaInvigoratePct.Value);
        }

        private void NinjaBloodbathPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaBloodbathPct = Convert.ToInt32(NinjaBloodbathPct.Value);
        }

        private void NinjaGoadPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaGoadPct = Convert.ToInt32(NinjaGoadPct.Value);
        }

        #endregion

        #region DoT

        private void NinjaShadowFang_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaShadowFang = NinjaShadowFang.Checked;
        }

        private void NinjaShadowFangHP_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaShadowFangHP = Convert.ToInt32(NinjaShadowFangHP.Value);
        }

        #endregion

        #region Cooldown

        private void NinjaAssassinate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaAssassinate = NinjaAssassinate.Checked;
        }

        private void NinjaMug_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaMug = NinjaMug.Checked;
        }

        private void NinjaTrickAttack_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaTrickAttack = NinjaTrickAttack.Checked;
        }

        private void NinjaJugulate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaJugulate = NinjaJugulate.Checked;
        }

        private void NinjaShukuchi_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaShukuchi = NinjaShukuchi.Checked;
        }

        private void NinjaDreamWithin_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaDreamWithin = NinjaDreamWithin.Checked;
        }

        private void NinjaHellfrogMedium_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaHellfrogMedium = NinjaHellfrogMedium.Checked;
        }

        private void NinjaBhavacakra_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaBhavacakra = NinjaBhavacakra.Checked;
        }

        #endregion

        #region Buff

        private void NinjaShadeShift_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaShadeShift = NinjaShadeShift.Checked;
        }

        private void NinjaKassatsu_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaKassatsu = NinjaKassatsu.Checked;
        }

        private void NinjaDuality_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaDuality = NinjaDuality.Checked;
        }

        private void NinjaTenChiJin_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaTenChiJin = NinjaTenChiJin.Checked;
        }

        private void NinjaShadeShiftPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaShadeShiftPct = Convert.ToInt32(NinjaShadeShiftPct.Value);
        }

        #endregion

        #region Ninjutsu

        private void NinjaFuma_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaFuma = NinjaFuma.Checked;
        }

        private void NinjaKaton_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaKaton = NinjaKaton.Checked;
        }

        private void NinjaRaiton_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaRaiton = NinjaRaiton.Checked;
        }

        private void NinjaHuton_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaHuton = NinjaHuton.Checked;
        }

        private void NinjaDoton_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaDoton = NinjaDoton.Checked;
        }

        private void NinjaSuiton_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaSuiton = NinjaSuiton.Checked;
        }

        #endregion

        #region Misc

        private void NinjaOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaOpener = NinjaOpener.Checked;
        }

        private void NinjaPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.NinjaPotion = NinjaPotion.Checked;
        }

        #endregion

        #endregion

        #region Paladin

        #region Role

        private void PaladinRampart_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinRampart = PaladinRampart.Checked;
        }

        private void PaladinLowBlow_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinLowBlow = PaladinLowBlow.Checked;
        }

        private void PaladinProvoke_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinProvoke = PaladinProvoke.Checked;
        }

        private void PaladinInterject_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinInterject = PaladinInterject.Checked;
        }

        private void PaladinReprisal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinReprisal = PaladinReprisal.Checked;
        }

        private void PaladinArmsLength_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinArmsLength = PaladinArmsLength.Checked;
        }

        private void PaladinRampartPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinRampartPct = Convert.ToInt32(PaladinRampartPct.Value);
        }

        #endregion

        #region AoE

        private void PaladinTotalEclipse_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinTotalEclipse = PaladinTotalEclipse.Checked;
        }

        private void PaladinProminence_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinProminence = PaladinProminence.Checked;
        }

        private void PaladinHolyCircle_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinHolyCircle = PaladinHolyCircle.Checked;
        }

        #endregion

        #region Cooldown

        private void PaladinSpiritsWithin_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinSpiritsWithin = PaladinSpiritsWithin.Checked;
        }

        private void PaladinCircleOfScorn_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinCircleOfScorn = PaladinCircleOfScorn.Checked;
        }

        private void PaladinRequiescat_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinRequiescat = PaladinRequiescat.Checked;
        }

        #endregion

        #region Buff

        private void PaladinFightOrFlight_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinFightOrFlight = PaladinFightOrFlight.Checked;
        }

        private void PaladinSentinel_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinSentinel = PaladinSentinel.Checked;
        }

        private void PaladinHallowedGround_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinHallowedGround = PaladinHallowedGround.Checked;
        }

        private void PaladinSheltron_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinSheltron = PaladinSheltron.Checked;
        }

        private void PaladinSentinelPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinSentinelPct = Convert.ToInt32(PaladinSentinelPct.Value);
        }

        private void PaladinHallowedGroundPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinHallowedGroundPct = Convert.ToInt32(PaladinHallowedGroundPct.Value);
        }

        #endregion

        #region Heal

        private void PaladinClemency_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinClemency = PaladinClemency.Checked;
        }

        private void PaladinClemencyPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinClemencyPct = Convert.ToInt32(PaladinClemencyPct.Value);
        }

        #endregion

        #region Misc

        private void PaladinOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinOpener = PaladinOpener.Checked;
        }

        private void PaladinPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.PaladinPotion = PaladinPotion.Checked;
        }

        #endregion

        #endregion

        #region Red Mage

        #region Role

        private void RedMageLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageLucidDreaming = RedMageLucidDreaming.Checked;
        }

        private void RedMageSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageSwiftcast = RedMageSwiftcast.Checked;
        }

        private void RedMageLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageLucidDreamingPct = Convert.ToInt32(RedMageLucidDreamingPct.Value);
        }

        #endregion

        #region Cooldown

        private void RedMageCorpsACorps_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageCorpsACorps = RedMageCorpsACorps.Checked;
        }

        private void RedMageDisplacement_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageDisplacement = RedMageDisplacement.Checked;
        }

        #endregion

        #region Buff

        private void RedMageEmbolden_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageEmbolden = RedMageEmbolden.Checked;
        }

        private void RedMageManafication_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageManafication = RedMageManafication.Checked;
        }

        #endregion

        #region Heal

        private void RedMageVercure_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageVercure = RedMageVercure.Checked;
        }

        private void RedMageVerraise_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageVerraise = RedMageVerraise.Checked;
        }

        private void RedMageVercurePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageVercurePct = Convert.ToInt32(RedMageVercurePct.Value);
        }

        #endregion

        #region Misc

        private void RedMageOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMageOpener = RedMageOpener.Checked;
        }

        private void RedMagePotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.RedMagePotion = RedMagePotion.Checked;
        }

        #endregion

        #endregion

        #region Samurai

        #region Role

        private void SamuraiSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiSecondWind = SamuraiSecondWind.Checked;
        }

        private void SamuraiInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiInvigorate = SamuraiInvigorate.Checked;
        }

        private void SamuraiBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiBloodbath = SamuraiBloodbath.Checked;
        }

        private void SamuraiGoad_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiGoad = SamuraiGoad.Checked;
        }

        private void SamuraiTrueNorth_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiTrueNorth = SamuraiTrueNorth.Checked;
        }

        private void SamuraiSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiSecondWindPct = Convert.ToInt32(SamuraiSecondWindPct.Value);
        }

        private void SamuraiInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiInvigoratePct = Convert.ToInt32(SamuraiInvigoratePct.Value);
        }

        private void SamuraiBloodbathPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiBloodbathPct = Convert.ToInt32(SamuraiBloodbathPct.Value);
        }

        private void SamuraiGoadPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiGoadPct = Convert.ToInt32(SamuraiGoadPct.Value);
        }

        #endregion

        #region Damage

        private void SamuraiMidare_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiMidare = SamuraiMidare.Checked;
        }

        private void SamuraiMidareHP_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiMidareHP = Convert.ToInt32(SamuraiMidareHP.Value);
        }

        #endregion

        #region DoT

        private void SamuraiHiganbana_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiHiganbana = SamuraiHiganbana.Checked;
        }

        private void SamuraiHiganbanaHP_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiHiganbanaHP = Convert.ToInt32(SamuraiHiganbanaHP.Value);
        }

        #endregion

        #region Cooldown

        private void SamuraiGyoten_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiGyoten = SamuraiGyoten.Checked;
        }

        private void SamuraiGuren_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiGuren = SamuraiGuren.Checked;
        }

        #endregion

        #region Buff

        private void SamuraiMeikyo_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiMeikyo = SamuraiMeikyo.Checked;
        }

        private void SamuraiHagakure_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiHagakure = SamuraiHagakure.Checked;
        }

        #endregion

        #region Heal

        private void SamuraiMerciful_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiMerciful = SamuraiMerciful.Checked;
        }

        private void SamuraiMercifulPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiMercifulPct = Convert.ToInt32(SamuraiMercifulPct.Value);
        }

        #endregion

        #region Misc

        private void SamuraiOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiOpener = SamuraiOpener.Checked;
        }

        private void SamuraiPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SamuraiPotion = SamuraiPotion.Checked;
        }

        #endregion

        #endregion

        #region Scholar

        #region Role

        private void ScholarEsuna_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarEsuna = ScholarEsuna.Checked;
        }

        private void ScholarLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarLucidDreaming = ScholarLucidDreaming.Checked;
        }

        private void ScholarLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarLucidDreamingPct = Convert.ToInt32(ScholarLucidDreamingPct.Value);
        }

        private void ScholarSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarSwiftcast = ScholarSwiftcast.Checked;
        }

        #endregion

        #region Damage

        private void ScholarStopDamage_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarStopDamage = ScholarStopDamage.Checked;
        }

        private void ScholarStopDots_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarStopDots = ScholarStopDots.Checked;
        }

        private void ScholarStopDamagePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarStopDamagePct = Convert.ToInt32(ScholarStopDamagePct.Value);
        }

        private void ScholarStopDotsPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarStopDotsPct = Convert.ToInt32(ScholarStopDotsPct.Value);
        }

        #endregion

        #region AoE

        private void ScholarBane_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarBane = ScholarBane.Checked;
        }

        #endregion

        #region Cooldown

        private void ScholarEnergyDrain_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarEnergyDrain = ScholarEnergyDrain.Checked;
        }

        private void ScholarEnergyDrainPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarEnergyDrainPct = Convert.ToInt32(ScholarEnergyDrainPct.Value);
        }

        private void ScholarShadowFlare_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarShadowFlare = ScholarShadowFlare.Checked;
        }

        private void ScholarChainStrategem_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarChainStrategem = ScholarChainStrategem.Checked;
        }

        #endregion

        #region Buff

        private void ScholarRouse_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarRouse = ScholarRouse.Checked;
        }

        private void ScholarEmergencyTactics_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarEmergencyTactics = ScholarEmergencyTactics.Checked;
        }

        #endregion

        #region Heal

        private void ScholarPartyHeal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarPartyHeal = ScholarPartyHeal.Checked;
        }

        private void ScholarInterruptDamage_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarInterruptDamage = ScholarInterruptDamage.Checked;
        }

        private void ScholarInterruptOverheal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarInterruptOverheal = ScholarInterruptOverheal.Checked;
        }

        private void ScholarPhysick_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarPhysick = ScholarPhysick.Checked;
        }

        private void ScholarAdloquium_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarAdloquium = ScholarAdloquium.Checked;
        }

        private void ScholarAetherpact_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarAetherpact = ScholarAetherpact.Checked;
        }

        private void ScholarLustrate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarLustrate = ScholarLustrate.Checked;
        }

        private void ScholarExcogitation_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarExcogitation = ScholarExcogitation.Checked;
        }

        private void ScholarSuccor_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarSuccor = ScholarSuccor.Checked;
        }

        private void ScholarIndomitability_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarIndomitability = ScholarIndomitability.Checked;
        }

        private void ScholarResurrection_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarResurrection = ScholarResurrection.Checked;
        }

        private void ScholarPhysickPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarPhysickPct = Convert.ToInt32(ScholarPhysickPct.Value);
        }

        private void ScholarAdloquiumPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarAdloquiumPct = Convert.ToInt32(ScholarAdloquiumPct.Value);
        }

        private void ScholarAetherpactPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarAetherpactPct = Convert.ToInt32(ScholarAetherpactPct.Value);
        }

        private void ScholarLustratePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarLustratePct = Convert.ToInt32(ScholarLustratePct.Value);
        }

        private void ScholarExcogitationPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarExcogitationPct = Convert.ToInt32(ScholarExcogitationPct.Value);
        }

        private void ScholarSuccorPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarSuccorPct = Convert.ToInt32(ScholarSuccorPct.Value);
        }

        private void ScholarIndomitabilityPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.ScholarIndomitabilityPct = Convert.ToInt32(ScholarIndomitabilityPct.Value);
        }

        #endregion

        #region Pet

        private void ScholarPet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ScholarPet.Text == @"None") ShinraEx.Settings.ScholarPet = ScholarPets.None;
            if (ScholarPet.Text == @"Eos") ShinraEx.Settings.ScholarPet = ScholarPets.Eos;
            if (ScholarPet.Text == @"Selene") ShinraEx.Settings.ScholarPet = ScholarPets.Selene;
        }

        #endregion

        #endregion

        #region Summoner

        #region Role

        private void SummonerAddle_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerAddle = SummonerAddle.Checked;
        }

        private void SummonerDrain_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerDrain = SummonerDrain.Checked;
        }

        private void SummonerLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerLucidDreaming = SummonerLucidDreaming.Checked;
        }

        private void SummonerSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerSwiftcast = SummonerSwiftcast.Checked;
        }

        private void SummonerDrainPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerDrainPct = Convert.ToInt32(SummonerDrainPct.Value);
        }

        private void SummonerLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerLucidDreamingPct = Convert.ToInt32(SummonerLucidDreamingPct.Value);
        }

        #endregion

        #region AoE

        private void SummonerBane_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerBane = SummonerBane.Checked;
        }

        #endregion

        #region Cooldown

        private void SummonerShadowFlare_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerShadowFlare = SummonerShadowFlare.Checked;
        }

        private void SummonerEnkindle_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerEnkindle = SummonerEnkindle.Checked;
        }

        private void SummonerTriDisaster_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerTriDisaster = SummonerTriDisaster.Checked;
        }

        private void SummonerEnkindleBahamut_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerEnkindleBahamut = SummonerEnkindleBahamut.Checked;
        }

        #endregion

        #region Buff

        private void SummonerRouse_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerRouse = SummonerRouse.Checked;
        }

        private void SummonerDreadwyrmTrance_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerDreadwyrmTrance = SummonerDreadwyrmTrance.Checked;
        }

        private void SummonerAetherpact_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerAetherpact = SummonerAetherpact.Checked;
        }

        private void SummonerSummonBahamut_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerSummonBahamut = SummonerSummonBahamut.Checked;
        }

        #endregion

        #region Heal

        private void SummonerPhysick_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerPhysick = SummonerPhysick.Checked;
        }

        private void SummonerSustain_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerSustain = SummonerSustain.Checked;
        }

        private void SummonerResurrection_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerResurrection = SummonerResurrection.Checked;
        }

        private void SummonerPhysickPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerPhysickPct = Convert.ToInt32(SummonerPhysickPct.Value);
        }

        private void SummonerSustainPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerSustainPct = Convert.ToInt32(SummonerSustainPct.Value);
        }

        #endregion

        #region Pet

        private void SummonerPet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SummonerPet.Text == @"None") ShinraEx.Settings.SummonerPet = SummonerPets.None;
            if (SummonerPet.Text == @"Garuda") ShinraEx.Settings.SummonerPet = SummonerPets.Garuda;
            if (SummonerPet.Text == @"Titan") ShinraEx.Settings.SummonerPet = SummonerPets.Titan;
            if (SummonerPet.Text == @"Ifrit") ShinraEx.Settings.SummonerPet = SummonerPets.Ifrit;
        }

        #endregion

        #region Misc

        private void SummonerOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerOpener = SummonerOpener.Checked;
        }

        private void SummonerPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerPotion = SummonerPotion.Checked;
        }

        private void SummonerOpenerGaruda_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.SummonerOpenerGaruda = SummonerOpenerGaruda.Checked;
        }

        #endregion

        #endregion

        #region Warrior

        #region Role

        private void WarriorRampart_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorRampart = WarriorRampart.Checked;
        }

        private void WarriorLowBlow_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorLowBlow = WarriorLowBlow.Checked;
        }

        private void WarriorProvoke_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorProvoke = WarriorProvoke.Checked;
        }

        private void WarriorInterject_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorInterject = WarriorInterject.Checked;
        }

        private void WarriorReprisal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorReprisal = WarriorReprisal.Checked;
        }

        private void WarriorArmsLength_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorArmsLength = WarriorArmsLength.Checked;
        }

        private void WarriorRampartPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorRampartPct = Convert.ToInt32(WarriorRampartPct.Value);
        }


        #endregion

        #region Damage

        private void WarriorMaim_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorMaim = WarriorMaim.Checked;
        }

        private void WarriorStormsEye_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorStormsEye = WarriorStormsEye.Checked;
        }

        private void WarriorInnerBeast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorInnerBeast = WarriorInnerBeast.Checked;
        }

        private void WarriorFellCleave_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorFellCleave = WarriorFellCleave.Checked;
        }

        #endregion

        #region AoE

        private void WarriorOverpower_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorOverpower = WarriorOverpower.Checked;
        }

        private void WarriorSteelCyclone_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorSteelCyclone = WarriorSteelCyclone.Checked;
        }

        private void WarriorDecimate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorDecimate = WarriorDecimate.Checked;
        }

        #endregion

        #region Cooldown

        private void WarriorOnslaught_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorOnslaught = WarriorOnslaught.Checked;
        }

        private void WarriorUpheaval_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorUpheaval = WarriorUpheaval.Checked;
        }

        #endregion

        #region Buff

        private void WarriorBerserk_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorBerserk = WarriorBerserk.Checked;
        }

        private void WarriorThrillOfBattle_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorThrillOfBattle = WarriorThrillOfBattle.Checked;
        }

        private void WarriorUnchained_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorUnchained = WarriorUnchained.Checked;
        }

        private void WarriorVengeance_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorVengeance = WarriorVengeance.Checked;
        }

        private void WarriorInfuriate_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorInfuriate = WarriorInfuriate.Checked;
        }

        private void WarriorEquilibriumTP_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorEquilibriumTP = WarriorEquilibriumTP.Checked;
        }

        private void WarriorShakeItOff_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorShakeItOff = WarriorShakeItOff.Checked;
        }

        private void WarriorInnerRelease_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorInnerRelease = WarriorInnerRelease.Checked;
        }

        private void WarriorThrillOfBattlePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorThrillOfBattlePct = Convert.ToInt32(WarriorThrillOfBattlePct.Value);
        }

        private void WarriorVengeancePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorVengeancePct = Convert.ToInt32(WarriorVengeancePct.Value);
        }

        private void WarriorEquilibriumTPPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorEquilibriumTPPct = Convert.ToInt32(WarriorEquilibriumTPPct.Value);
        }

        #endregion

        #region Heal

        private void WarriorEquilibrium_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorEquilibrium = WarriorEquilibrium.Checked;
        }

        private void WarriorEquilibriumPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorEquilibriumPct = Convert.ToInt32(WarriorEquilibriumPct.Value);
        }

        #endregion

        #region Stance

        private void WarriorStance_SelectedValueChanged(object sender, EventArgs e)
        {
            if (WarriorStance.Text == @"None") ShinraEx.Settings.WarriorStance = WarriorStances.None;
            if (WarriorStance.Text == @"Defiance") ShinraEx.Settings.WarriorStance = WarriorStances.Defiance;
            if (WarriorStance.Text == @"Deliverance") ShinraEx.Settings.WarriorStance = WarriorStances.Deliverance;
        }

        #endregion

        #region Misc

        private void WarriorOpener_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorOpener = WarriorOpener.Checked;
        }

        private void WarriorPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WarriorPotion = WarriorPotion.Checked;
        }

        #endregion

        #endregion

        #region White Mage

        #region Role

        private void WhiteMageEsuna_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageEsuna = WhiteMageEsuna.Checked;
        }

        private void WhiteMageLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageLucidDreaming = WhiteMageLucidDreaming.Checked;
        }

        private void WhiteMageLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageLucidDreamingPct = Convert.ToInt32(WhiteMageLucidDreamingPct.Value);
        }

        private void WhiteMageSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageSwiftcast = WhiteMageSwiftcast.Checked;
        }

        #endregion

        #region Damage

        private void WhiteMageStopDamage_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageStopDamage = WhiteMageStopDamage.Checked;
        }

        private void WhiteMageStopDots_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageStopDots = WhiteMageStopDots.Checked;
        }

        private void WhiteMageStopDamagePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageStopDamagePct = Convert.ToInt32(WhiteMageStopDamagePct.Value);
        }

        private void WhiteMageStopDotsPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageStopDotsPct = Convert.ToInt32(WhiteMageStopDotsPct.Value);
        }

        #endregion

        #region Buff

        private void WhiteMagePresenceOfMind_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMagePresenceOfMind = WhiteMagePresenceOfMind.Checked;
        }

        private void WhiteMagePresenceOfMindCount_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMagePresenceOfMindCount = Convert.ToInt32(WhiteMagePresenceOfMindCount.Value);
        }

        private void WhiteMagePresenceOfMindPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMagePresenceOfMindPct = Convert.ToInt32(WhiteMagePresenceOfMindPct.Value);
        }

        private void WhiteMageTemperance_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageTemperance = WhiteMageTemperance.Checked;
        }

        private void WhiteMageTemperanceCount_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageTemperanceCount = Convert.ToInt32(WhiteMageTemperanceCount.Value);
        }

        private void WhiteMageTemperancePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageTemperancePct = Convert.ToInt32(WhiteMageTemperancePct.Value);
        }
        
        private void WhiteMageThinAir_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageThinAir = WhiteMageThinAir.Checked;
        }

        #endregion

        #region Heal

        private void WhiteMagePartyHeal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMagePartyHeal = WhiteMagePartyHeal.Checked;
        }

        private void WhiteMageInterruptDamage_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageInterruptDamage = WhiteMageInterruptDamage.Checked;
        }

        private void WhiteMageInterruptOverheal_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageInterruptOverheal = WhiteMageInterruptOverheal.Checked;
        }

        private void WhiteMageCure_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageCure = WhiteMageCure.Checked;
        }

        private void WhiteMageCureII_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageCureII = WhiteMageCureII.Checked;
        }

        private void WhiteMageCureIII_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageCureIII = WhiteMageCureIII.Checked;
        }

        private void WhiteMageTetragrammaton_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageTetragrammaton = WhiteMageTetragrammaton.Checked;
        }

        private void WhiteMageAfflatusSolce_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageAfflatusSolace = WhiteMageAfflatusSolace.Checked;
        }

        private void WhiteMageBenediction_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageBenediction = WhiteMageBenediction.Checked;
        }

        private void WhiteMageAfflatusRapture_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageAfflatusRapture = WhiteMageAfflatusRapture.Checked;
        }

        private void WhiteMageRegen_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageRegen = WhiteMageRegen.Checked;
        }

        private void WhiteMageMedica_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageMedica = WhiteMageMedica.Checked;
        }

        private void WhiteMageMedicaII_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageMedicaII = WhiteMageMedicaII.Checked;
        }

        private void WhiteMageAssize_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageAssize = WhiteMageAssize.Checked;
        }

        private void WhiteMagePlenary_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMagePlenary = WhiteMagePlenary.Checked;
        }

        private void WhiteMageRaise_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageRaise = WhiteMageRaise.Checked;
        }

        private void WhiteMageCurePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageCurePct = Convert.ToInt32(WhiteMageCurePct.Value);
        }

        private void WhiteMageCureIIPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageCureIIPct = Convert.ToInt32(WhiteMageCureIIPct.Value);
        }

        private void WhiteMageCureIIIPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageCureIIIPct = Convert.ToInt32(WhiteMageCureIIIPct.Value);
        }

        private void WhiteMageTetragrammatonPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageTetragrammatonPct = Convert.ToInt32(WhiteMageTetragrammatonPct.Value);
        }

        private void WhiteMageAfflatusSolacePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageAfflatusSolacePct = Convert.ToInt32(WhiteMageAfflatusSolacePct.Value);
        }

        private void WhiteMageBenedictionPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageBenedictionPct = Convert.ToInt32(WhiteMageBenedictionPct.Value);
        }

        private void WhiteMageAfflatusRapturePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageAfflatusRapturePct = Convert.ToInt32(WhiteMageAfflatusRapturePct.Value);
        }

        private void WhiteMageRegenPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageRegenPct = Convert.ToInt32(WhiteMageRegenPct.Value);
        }

        private void WhiteMageMedicaPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageMedicaPct = Convert.ToInt32(WhiteMageMedicaPct.Value);
        }

        private void WhiteMageMedicaIIPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageMedicaIIPct = Convert.ToInt32(WhiteMageMedicaIIPct.Value);
        }

        private void WhiteMageAssizePct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMageAssizePct = Convert.ToInt32(WhiteMageAssizePct.Value);
        }

        private void WhiteMagePlenaryPct_ValueChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.WhiteMagePlenaryPct = Convert.ToInt32(WhiteMagePlenaryPct.Value);
        }


        #endregion

        #endregion

        #endregion

        private void pauseCheck_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.CrPaused =  pauseCheck.Checked;
            ShinraEx.Overlay.UpdateText();
        }

        private void UserHealthPotion_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.UseHealthPotion = userHealthPotion.Checked;
        }

        

        private void BlackMageBetweenTheLines_CheckedChanged(object sender, EventArgs e)
        {
            ShinraEx.Settings.BlackMageBetweenTheLines = BlackMageBetweenTheLines.Checked;
        }
    }
}