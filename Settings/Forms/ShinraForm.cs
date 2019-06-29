using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using System.Diagnostics;

namespace ShinraCo.Settings.Forms
{
    public partial class ShinraForm : Form
    {
        private readonly Image _shinraBanner = Resources.ShinraBanner;
        private readonly Image _shinraDonate = Resources.ShinraDonate;

        public ShinraForm()
        {
            InitializeComponent();
        }

        #region Draggable

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        private void ShinraForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ReleaseCapture();
            SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
        }

        #endregion

        private void ShinraForm_Load(object sender, EventArgs e)
        {
            ShinraBanner.Image = _shinraBanner;
            ShinraDonate.Image = _shinraDonate;
            Shinra.UnregisterHotkeys();
            Location = Shinra.Settings.WindowLocation;
            var kc = new KeysConverter();

            #region Main Settings

            #region Rotation

            RotationOverlay.Checked = Shinra.Settings.RotationOverlay;
            RotationMessages.Checked = Shinra.Settings.RotationMessages;

            RotationMode.Text = Convert.ToString(Shinra.Settings.RotationMode);
            CooldownMode.Text = Convert.ToString(Shinra.Settings.CooldownMode);
            TankMode.Text = Convert.ToString(Shinra.Settings.TankMode);

            RotationHotkey.Text = kc.ConvertToString(Shinra.Settings.RotationHotkey);
            CooldownHotkey.Text = kc.ConvertToString(Shinra.Settings.CooldownHotkey);
            TankHotkey.Text = kc.ConvertToString(Shinra.Settings.TankHotkey);

            #endregion

            #region Chocobo

            ChocoboSummon.Checked = Shinra.Settings.SummonChocobo;
            ChocoboStanceDance.Checked = Shinra.Settings.ChocoboStanceDance;
            ChocoboStanceDancePct.Value = Shinra.Settings.ChocoboStanceDancePct;
            ChocoboStance.Text = Convert.ToString(Shinra.Settings.ChocoboStance);

            #endregion

            #region Rest

            RestHealth.Checked = Shinra.Settings.RestHealth;
            RestEnergy.Checked = Shinra.Settings.RestEnergy;

            RestHealthPct.Value = Shinra.Settings.RestHealthPct;
            RestEnergyPct.Value = Shinra.Settings.RestEnergyPct;

            #endregion

            #region Spell

            RandomCastLocations.Checked = Shinra.Settings.RandomCastLocations;
            CustomAoE.Checked = Shinra.Settings.CustomAoE;
            QueueSpells.Checked = Shinra.Settings.QueueSpells;

            CustomAoECount.Value = Shinra.Settings.CustomAoECount;

            #endregion

            #region Misc

            IgnoreSmart.Checked = Shinra.Settings.IgnoreSmart;
            DisableDebug.Checked = Shinra.Settings.DisableDebug;

            #endregion

            #endregion

            #region Job Settings

            #region Astrologian

            #region Role

            AstrologianClericStance.Checked = Shinra.Settings.AstrologianClericStance;
            AstrologianProtect.Checked = Shinra.Settings.AstrologianProtect;
            AstrologianEsuna.Checked = Shinra.Settings.AstrologianEsuna;
            AstrologianLucidDreaming.Checked = Shinra.Settings.AstrologianLucidDreaming;
            AstrologianLucidDreamingPct.Value = Shinra.Settings.AstrologianLucidDreamingPct;
            AstrologianSwiftcast.Checked = Shinra.Settings.AstrologianSwiftcast;
            AstrologianEyeForAnEye.Checked = Shinra.Settings.AstrologianEyeForAnEye;
            AstrologianEyeForAnEyePct.Value = Shinra.Settings.AstrologianEyeForAnEyePct;
            AstrologianLargesse.Checked = Shinra.Settings.AstrologianLargesse;
            AstrologianLargesseCount.Value = Shinra.Settings.AstrologianLargesseCount;
            AstrologianLargessePct.Value = Shinra.Settings.AstrologianLargessePct;

            #endregion

            #region Damage

            AstrologianStopDamage.Checked = Shinra.Settings.AstrologianStopDamage;
            AstrologianStopDots.Checked = Shinra.Settings.AstrologianStopDots;

            AstrologianStopDamagePct.Value = Shinra.Settings.AstrologianStopDamagePct;
            AstrologianStopDotsPct.Value = Shinra.Settings.AstrologianStopDotsPct;

            #endregion

            #region AoE

            AstrologianEarthlyStar.Checked = Shinra.Settings.AstrologianEarthlyStar;
            AstrologianStellarDetonation.Checked = Shinra.Settings.AstrologianStellarDetonation;

            #endregion

            #region Buff

            AstrologianLightspeed.Checked = Shinra.Settings.AstrologianLightspeed;
            AstrologianLightspeedCount.Value = Shinra.Settings.AstrologianLightspeedCount;
            AstrologianLightspeedPct.Value = Shinra.Settings.AstrologianLightspeedPct;
            AstrologianSynastry.Checked = Shinra.Settings.AstrologianSynastry;
            AstrologianSynastryCount.Value = Shinra.Settings.AstrologianSynastryCount;
            AstrologianSynastryPct.Value = Shinra.Settings.AstrologianSynastryPct;
            AstrologianTimeDilation.Checked = Shinra.Settings.AstrologianTimeDilation;
            AstrologianCelestialOpposition.Checked = Shinra.Settings.AstrologianCelestialOpposition;

            #endregion

            #region Heal

            AstrologianPartyHeal.Checked = Shinra.Settings.AstrologianPartyHeal;
            AstrologianInterruptDamage.Checked = Shinra.Settings.AstrologianInterruptDamage;
            AstrologianInterruptOverheal.Checked = Shinra.Settings.AstrologianInterruptOverheal;
            AstrologianBenefic.Checked = Shinra.Settings.AstrologianBenefic;
            AstrologianBeneficII.Checked = Shinra.Settings.AstrologianBeneficII;
            AstrologianEssDignity.Checked = Shinra.Settings.AstrologianEssDignity;
            AstrologianAspBenefic.Checked = Shinra.Settings.AstrologianAspBenefic;
            AstrologianHelios.Checked = Shinra.Settings.AstrologianHelios;
            AstrologianAspHelios.Checked = Shinra.Settings.AstrologianAspHelios;
            AstrologianAscend.Checked = Shinra.Settings.AstrologianAscend;

            AstrologianBeneficPct.Value = Shinra.Settings.AstrologianBeneficPct;
            AstrologianBeneficIIPct.Value = Shinra.Settings.AstrologianBeneficIIPct;
            AstrologianEssDignityPct.Value = Shinra.Settings.AstrologianEssDignityPct;
            AstrologianAspBeneficPct.Value = Shinra.Settings.AstrologianAspBeneficPct;
            AstrologianHeliosPct.Value = Shinra.Settings.AstrologianHeliosPct;
            AstrologianAspHeliosPct.Value = Shinra.Settings.AstrologianAspHeliosPct;

            #endregion

            #region Card

            AstrologianDraw.Checked = Shinra.Settings.AstrologianDraw;
            AstrologianSleeveDraw.Checked = Shinra.Settings.AstrologianSleeveDraw;
            AstrologianCardPreCombat.Checked = Shinra.Settings.AstrologianCardPreCombat;

            #endregion

            #region Sect

            AstrologianSect.Text = Convert.ToString(Shinra.Settings.AstrologianSect);

            #endregion

            #region Misc

            AstrologianCardOnly.Checked = Shinra.Settings.AstrologianCardOnly;

            #endregion

            #endregion

            #region Bard

            #region Role

            BardSecondWind.Checked = Shinra.Settings.BardSecondWind;
            BardPeloton.Checked = Shinra.Settings.BardPeloton;
            BardInvigorate.Checked = Shinra.Settings.BardInvigorate;
            BardTactician.Checked = Shinra.Settings.BardTactician;
            BardRefresh.Checked = Shinra.Settings.BardRefresh;
            BardPalisade.Checked = Shinra.Settings.BardPalisade;

            BardSecondWindPct.Value = Shinra.Settings.BardSecondWindPct;
            BardInvigoratePct.Value = Shinra.Settings.BardInvigoratePct;
            BardTacticianPct.Value = Shinra.Settings.BardTacticianPct;
            BardRefreshPct.Value = Shinra.Settings.BardRefreshPct;
            BardPalisadePct.Value = Shinra.Settings.BardPalisadePct;

            #endregion

            #region Damage

            BardPitchPerfect.Checked = Shinra.Settings.BardPitchPerfect;
            BardRepertoireCount.Value = Shinra.Settings.BardRepertoireCount;

            #endregion

            #region DoT

            BardUseDots.Checked = Shinra.Settings.BardUseDots;
            BardUseDotsAoe.Checked = Shinra.Settings.BardUseDotsAoe;
            BardDotSnapshot.Checked = Shinra.Settings.BardDotSnapshot;

            #endregion

            #region Cooldown

            BardSongs.Checked = Shinra.Settings.BardSongs;
            BardEmpyrealArrow.Checked = Shinra.Settings.BardEmpyrealArrow;
            BardSidewinder.Checked = Shinra.Settings.BardSidewinder;

            #endregion

            #region Buff

            BardRagingStrikes.Checked = Shinra.Settings.BardRagingStrikes;
            BardFoeRequiem.Checked = Shinra.Settings.BardFoeRequiem;
            BardFoeRequiemPct.Value = Shinra.Settings.BardFoeRequiemPct;
            BardBarrage.Checked = Shinra.Settings.BardBarrage;
            BardBattleVoice.Checked = Shinra.Settings.BardBattleVoice;

            #endregion

            #region Misc

            BardOpener.Checked = Shinra.Settings.BardOpener;
            BardPotion.Checked = Shinra.Settings.BardPotion;

            #endregion

            #endregion

            #region Black Mage

            #region Role

            BlackMageDrain.Checked = Shinra.Settings.BlackMageDrain;
            BlackMageLucidDreaming.Checked = Shinra.Settings.BlackMageLucidDreaming;
            BlackMageSwiftcast.Checked = Shinra.Settings.BlackMageSwiftcast;

            BlackMageDrainPct.Value = Shinra.Settings.BlackMageDrainPct;
            BlackMageLucidDreamingPct.Value = Shinra.Settings.BlackMageLucidDreamingPct;

            #endregion

            #region Damage

            BlackMageScathe.Checked = Shinra.Settings.BlackMageScathe;

            #endregion

            #region AoE

            BlackMageThunder.Checked = Shinra.Settings.BlackMageThunder;

            #endregion

            #region Buff

            BlackMageConvert.Checked = Shinra.Settings.BlackMageConvert;
            BlackMageLeyLines.Checked = Shinra.Settings.BlackMageLeyLines;
            BlackMageSharpcast.Checked = Shinra.Settings.BlackMageSharpcast;
            BlackMageEnochian.Checked = Shinra.Settings.BlackMageEnochian;
            BlackMageTriplecast.Checked = Shinra.Settings.BlackMageTriplecast;

            #endregion

            #region Misc

            BlackMageOpener.Checked = Shinra.Settings.BlackMageOpener;
            BlackMagePotion.Checked = Shinra.Settings.BlackMagePotion;

            #endregion

            #endregion

            #region Dark Knight

            #region Role

            DarkKnightRampart.Checked = Shinra.Settings.DarkKnightRampart;
            DarkKnightConvalescence.Checked = Shinra.Settings.DarkKnightConvalescence;
            DarkKnightAnticipation.Checked = Shinra.Settings.DarkKnightAnticipation;
            DarkKnightReprisal.Checked = Shinra.Settings.DarkKnightReprisal;
            DarkKnightAwareness.Checked = Shinra.Settings.DarkKnightAwareness;

            DarkKnightRampartPct.Value = Shinra.Settings.DarkKnightRampartPct;
            DarkKnightConvalescencePct.Value = Shinra.Settings.DarkKnightConvalescencePct;
            DarkKnightAnticipationPct.Value = Shinra.Settings.DarkKnightAnticipationPct;
            DarkKnightAwarenessPct.Value = Shinra.Settings.DarkKnightAwarenessPct;

            #endregion

            #region Damage

            DarkKnightBloodspiller.Checked = Shinra.Settings.DarkKnightBloodspiller;

            #endregion

            #region AoE

            DarkKnightQuietus.Checked = Shinra.Settings.DarkKnightQuietus;

            #endregion

            #region Cooldown

            DarkKnightSaltedEarth.Checked = Shinra.Settings.DarkKnightSaltedEarth;
            DarkKnightPlunge.Checked = Shinra.Settings.DarkKnightPlunge;
            DarkKnightCarveAndSpit.Checked = Shinra.Settings.DarkKnightCarveAndSpit;

            #endregion

            #region Buff

            DarkKnightBloodWeapon.Checked = Shinra.Settings.DarkKnightBloodWeapon;
            DarkKnightBloodPrice.Checked = Shinra.Settings.DarkKnightBloodPrice;
            DarkKnightShadowWall.Checked = Shinra.Settings.DarkKnightShadowWall;
            DarkKnightLivingDead.Checked = Shinra.Settings.DarkKnightLivingDead;
            DarkKnightDelirium.Checked = Shinra.Settings.DarkKnightDelirium;
            DarkKnightBlackestNight.Checked = Shinra.Settings.DarkKnightBlackestNight;

            DarkKnightBloodPricePct.Value = Shinra.Settings.DarkKnightBloodPricePct;
            DarkKnightShadowWallPct.Value = Shinra.Settings.DarkKnightShadowWallPct;
            DarkKnightLivingDeadPct.Value = Shinra.Settings.DarkKnightLivingDeadPct;
            DarkKnightBlackestNightPct.Value = Shinra.Settings.DarkKnightBlackestNightPct;

            #endregion

            #region Dark Arts

            DarkKnightSouleaterArts.Checked = Shinra.Settings.DarkKnightSouleaterArts;
            DarkKnightAbyssalArts.Checked = Shinra.Settings.DarkKnightAbyssalArts;
            DarkKnightCarveArts.Checked = Shinra.Settings.DarkKnightCarveArts;
            DarkKnightQuietusArts.Checked = Shinra.Settings.DarkKnightQuietusArts;
            DarkKnightBloodspillerArts.Checked = Shinra.Settings.DarkKnightBloodspillerArts;

            #endregion

            #region Aura

            DarkKnightGrit.Checked = Shinra.Settings.DarkKnightGrit;
            DarkKnightDarkside.Checked = Shinra.Settings.DarkKnightDarkside;

            #endregion

            #region Misc

            DarkKnightOpener.Checked = Shinra.Settings.DarkKnightOpener;
            DarkKnightPotion.Checked = Shinra.Settings.DarkKnightPotion;
            DarkKnightOffTank.Checked = Shinra.Settings.DarkKnightOffTank;

            #endregion

            #endregion

            #region Dragoon

            #region Role

            DragoonSecondWind.Checked = Shinra.Settings.DragoonSecondWind;
            DragoonInvigorate.Checked = Shinra.Settings.DragoonInvigorate;
            DragoonBloodbath.Checked = Shinra.Settings.DragoonBloodbath;
            DragoonGoad.Checked = Shinra.Settings.DragoonGoad;
            DragoonTrueNorth.Checked = Shinra.Settings.DragoonTrueNorth;

            DragoonSecondWindPct.Value = Shinra.Settings.DragoonSecondWindPct;
            DragoonInvigoratePct.Value = Shinra.Settings.DragoonInvigoratePct;
            DragoonBloodbathPct.Value = Shinra.Settings.DragoonBloodbathPct;
            DragoonGoadPct.Value = Shinra.Settings.DragoonGoadPct;

            #endregion

            #region Cooldown

            DragoonJump.Checked = Shinra.Settings.DragoonJump;
            DragoonSpineshatter.Checked = Shinra.Settings.DragoonSpineshatter;
            DragoonDragonfire.Checked = Shinra.Settings.DragoonDragonfire;
            DragoonGeirskogul.Checked = Shinra.Settings.DragoonGeirskogul;
            DragoonMirage.Checked = Shinra.Settings.DragoonMirage;

            #endregion

            #region Buff

            DragoonLifeSurge.Checked = Shinra.Settings.DragoonLifeSurge;
            DragoonBloodForBlood.Checked = Shinra.Settings.DragoonBloodForBlood;
            DragoonBattleLitany.Checked = Shinra.Settings.DragoonBattleLitany;
            DragoonBloodOfTheDragon.Checked = Shinra.Settings.DragoonBloodOfTheDragon;
            DragoonDragonSight.Checked = Shinra.Settings.DragoonDragonSight;

            #endregion

            #region Misc

            DragoonOpener.Checked = Shinra.Settings.DragoonOpener;
            DragoonPotion.Checked = Shinra.Settings.DragoonPotion;

            #endregion

            #endregion

            #region Machinist

            #region Role

            MachinistSecondWind.Checked = Shinra.Settings.MachinistSecondWind;
            MachinistPeloton.Checked = Shinra.Settings.MachinistPeloton;
            MachinistInvigorate.Checked = Shinra.Settings.MachinistInvigorate;
            MachinistTactician.Checked = Shinra.Settings.MachinistTactician;
            MachinistRefresh.Checked = Shinra.Settings.MachinistRefresh;
            MachinistPalisade.Checked = Shinra.Settings.MachinistPalisade;

            MachinistSecondWindPct.Value = Shinra.Settings.MachinistSecondWindPct;
            MachinistInvigoratePct.Value = Shinra.Settings.MachinistInvigoratePct;
            MachinistTacticianPct.Value = Shinra.Settings.MachinistTacticianPct;
            MachinistRefreshPct.Value = Shinra.Settings.MachinistRefreshPct;
            MachinistPalisadePct.Value = Shinra.Settings.MachinistPalisadePct;

            #endregion

            #region Cooldown

            MachinistWildfire.Checked = Shinra.Settings.MachinistWildfire;
            MachinistRicochet.Checked = Shinra.Settings.MachinistRicochet;
            MachinistCooldown.Checked = Shinra.Settings.MachinistCooldown;
            MachinistFlamethrower.Checked = Shinra.Settings.MachinistFlamethrower;

            MachinistWildfireHP.Value = Shinra.Settings.MachinistWildfireHP;

            #endregion

            #region Buff

            MachinistReload.Checked = Shinra.Settings.MachinistReload;
            MachinistReassemble.Checked = Shinra.Settings.MachinistReassemble;
            MachinistRapidFire.Checked = Shinra.Settings.MachinistRapidFire;
            MachinistGaussBarrel.Checked = Shinra.Settings.MachinistGaussBarrel;
            MachinistHypercharge.Checked = Shinra.Settings.MachinistHypercharge;
            MachinistBarrelStabilizer.Checked = Shinra.Settings.MachinistBarrelStabilizer;
            MachinistRookOverdrive.Checked = Shinra.Settings.MachinistRookOverdrive;
            MachinistBishopOverdrive.Checked = Shinra.Settings.MachinistBishopOverdrive;

            #endregion

            #region Turret

            MachinistTurret.Text = Convert.ToString(Shinra.Settings.MachinistTurret);
            MachinistTurretHotkey.Text = kc.ConvertToString(Shinra.Settings.MachinistTurretHotkey);
            MachinistTurretLocation.Text = Convert.ToString(Shinra.Settings.MachinistTurretLocation);

            #endregion

            #region Misc

            MachinistOpener.Checked = Shinra.Settings.MachinistOpener;
            MachinistPotion.Checked = Shinra.Settings.MachinistPotion;
            MachinistSyncWildfire.Checked = Shinra.Settings.MachinistSyncWildfire;
            MachinistSyncOverheat.Checked = Shinra.Settings.MachinistSyncOverheat;

            #endregion

            #endregion

            #region Monk

            #region Role

            MonkSecondWind.Checked = Shinra.Settings.MonkSecondWind;
            MonkInvigorate.Checked = Shinra.Settings.MonkInvigorate;
            MonkBloodbath.Checked = Shinra.Settings.MonkBloodbath;
            MonkGoad.Checked = Shinra.Settings.MonkGoad;
            MonkTrueNorth.Checked = Shinra.Settings.MonkTrueNorth;

            MonkSecondWindPct.Value = Shinra.Settings.MonkSecondWindPct;
            MonkInvigoratePct.Value = Shinra.Settings.MonkInvigoratePct;
            MonkBloodbathPct.Value = Shinra.Settings.MonkBloodbathPct;
            MonkGoadPct.Value = Shinra.Settings.MonkGoadPct;

            #endregion

            #region DoT

            MonkDemolish.Checked = Shinra.Settings.MonkDemolish;
            MonkDemolishHP.Value = Shinra.Settings.MonkDemolishHP;

            #endregion

            #region Cooldown

            MonkShoulderTackle.Checked = Shinra.Settings.MonkShoulderTackle;
            MonkSteelPeak.Checked = Shinra.Settings.MonkSteelPeak;
            MonkHowlingFist.Checked = Shinra.Settings.MonkHowlingFist;
            MonkForbiddenChakra.Checked = Shinra.Settings.MonkForbiddenChakra;
            MonkElixirField.Checked = Shinra.Settings.MonkElixirField;
            MonkFireTackle.Checked = Shinra.Settings.MonkFireTackle;

            #endregion

            #region Buff

            MonkInternalRelease.Checked = Shinra.Settings.MonkInternalRelease;
            MonkPerfectBalance.Checked = Shinra.Settings.MonkPerfectBalance;
            MonkFormShift.Checked = Shinra.Settings.MonkFormShift;
            MonkMeditation.Checked = Shinra.Settings.MonkMeditation;
            MonkRiddleOfFire.Checked = Shinra.Settings.MonkRiddleOfFire;
            MonkBrotherhood.Checked = Shinra.Settings.MonkBrotherhood;

            #endregion

            #region Fists

            MonkFist.Text = Convert.ToString(Shinra.Settings.MonkFist);

            #endregion

            #region Misc

            MonkOpener.Checked = Shinra.Settings.MonkOpener;
            MonkPotion.Checked = Shinra.Settings.MonkPotion;

            #endregion

            #endregion

            #region Ninja

            #region Role

            NinjaSecondWind.Checked = Shinra.Settings.NinjaSecondWind;
            NinjaInvigorate.Checked = Shinra.Settings.NinjaInvigorate;
            NinjaBloodbath.Checked = Shinra.Settings.NinjaBloodbath;
            NinjaGoad.Checked = Shinra.Settings.NinjaGoad;
            NinjaTrueNorth.Checked = Shinra.Settings.NinjaTrueNorth;

            NinjaSecondWindPct.Value = Shinra.Settings.NinjaSecondWindPct;
            NinjaInvigoratePct.Value = Shinra.Settings.NinjaInvigoratePct;
            NinjaBloodbathPct.Value = Shinra.Settings.NinjaBloodbathPct;
            NinjaGoadPct.Value = Shinra.Settings.NinjaGoadPct;

            #endregion

            #region DoT

            NinjaShadowFang.Checked = Shinra.Settings.NinjaShadowFang;
            NinjaShadowFangHP.Value = Shinra.Settings.NinjaShadowFangHP;

            #endregion

            #region Cooldown

            NinjaAssassinate.Checked = Shinra.Settings.NinjaAssassinate;
            NinjaMug.Checked = Shinra.Settings.NinjaMug;
            NinjaTrickAttack.Checked = Shinra.Settings.NinjaTrickAttack;
            NinjaJugulate.Checked = Shinra.Settings.NinjaJugulate;
            NinjaShukuchi.Checked = Shinra.Settings.NinjaShukuchi;
            NinjaDreamWithin.Checked = Shinra.Settings.NinjaDreamWithin;
            NinjaHellfrogMedium.Checked = Shinra.Settings.NinjaHellfrogMedium;
            NinjaBhavacakra.Checked = Shinra.Settings.NinjaBhavacakra;

            #endregion

            #region Buff

            NinjaShadeShift.Checked = Shinra.Settings.NinjaShadeShift;
            NinjaKassatsu.Checked = Shinra.Settings.NinjaKassatsu;
            NinjaDuality.Checked = Shinra.Settings.NinjaDuality;
            NinjaTenChiJin.Checked = Shinra.Settings.NinjaTenChiJin;

            NinjaShadeShiftPct.Value = Shinra.Settings.NinjaShadeShiftPct;

            #endregion

            #region Ninjutsu

            NinjaFuma.Checked = Shinra.Settings.NinjaFuma;
            NinjaKaton.Checked = Shinra.Settings.NinjaKaton;
            NinjaRaiton.Checked = Shinra.Settings.NinjaRaiton;
            NinjaHuton.Checked = Shinra.Settings.NinjaHuton;
            NinjaDoton.Checked = Shinra.Settings.NinjaDoton;
            NinjaSuiton.Checked = Shinra.Settings.NinjaSuiton;

            #endregion

            #region Misc

            NinjaOpener.Checked = Shinra.Settings.NinjaOpener;
            NinjaPotion.Checked = Shinra.Settings.NinjaPotion;

            #endregion

            #endregion

            #region Paladin

            #region Role

            PaladinRampart.Checked = Shinra.Settings.PaladinRampart;
            PaladinConvalescence.Checked = Shinra.Settings.PaladinConvalescence;
            PaladinAnticipation.Checked = Shinra.Settings.PaladinAnticipation;
            PaladinReprisal.Checked = Shinra.Settings.PaladinReprisal;
            PaladinAwareness.Checked = Shinra.Settings.PaladinAwareness;

            PaladinRampartPct.Value = Shinra.Settings.PaladinRampartPct;
            PaladinConvalescencePct.Value = Shinra.Settings.PaladinConvalescencePct;
            PaladinAnticipationPct.Value = Shinra.Settings.PaladinAnticipationPct;
            PaladinAwarenessPct.Value = Shinra.Settings.PaladinAwarenessPct;

            #endregion

            #region Damage

            PaladinGoringBlade.Checked = Shinra.Settings.PaladinGoringBlade;

            #endregion

            #region AoE

            PaladinFlash.Checked = Shinra.Settings.PaladinFlash;
            PaladinTotalEclipse.Checked = Shinra.Settings.PaladinTotalEclipse;

            #endregion

            #region Cooldown

            PaladinShieldSwipe.Checked = Shinra.Settings.PaladinShieldSwipe;
            PaladinSpiritsWithin.Checked = Shinra.Settings.PaladinSpiritsWithin;
            PaladinCircleOfScorn.Checked = Shinra.Settings.PaladinCircleOfScorn;
            PaladinRequiescat.Checked = Shinra.Settings.PaladinRequiescat;

            #endregion

            #region Buff

            PaladinFightOrFlight.Checked = Shinra.Settings.PaladinFightOrFlight;
            PaladinBulwark.Checked = Shinra.Settings.PaladinBulwark;
            PaladinSentinel.Checked = Shinra.Settings.PaladinSentinel;
            PaladinHallowedGround.Checked = Shinra.Settings.PaladinHallowedGround;
            PaladinSheltron.Checked = Shinra.Settings.PaladinSheltron;

            PaladinBulwarkPct.Value = Shinra.Settings.PaladinBulwarkPct;
            PaladinSentinelPct.Value = Shinra.Settings.PaladinSentinelPct;
            PaladinHallowedGroundPct.Value = Shinra.Settings.PaladinHallowedGroundPct;

            #endregion

            #region Heal

            PaladinClemency.Checked = Shinra.Settings.PaladinClemency;
            PaladinClemencyPct.Value = Shinra.Settings.PaladinClemencyPct;

            #endregion

            #region Oath

            PaladinOath.Text = Convert.ToString(Shinra.Settings.PaladinOath);

            #endregion

            #region Misc

            PaladinOpener.Checked = Shinra.Settings.PaladinOpener;
            PaladinPotion.Checked = Shinra.Settings.PaladinPotion;

            #endregion

            #endregion

            #region Red Mage

            #region Role

            RedMageDrain.Checked = Shinra.Settings.RedMageDrain;
            RedMageLucidDreaming.Checked = Shinra.Settings.RedMageLucidDreaming;
            RedMageSwiftcast.Checked = Shinra.Settings.RedMageSwiftcast;

            RedMageDrainPct.Value = Shinra.Settings.RedMageDrainPct;
            RedMageLucidDreamingPct.Value = Shinra.Settings.RedMageLucidDreamingPct;

            #endregion

            #region Cooldown

            RedMageCorpsACorps.Checked = Shinra.Settings.RedMageCorpsACorps;
            RedMageDisplacement.Checked = Shinra.Settings.RedMageDisplacement;

            #endregion

            #region Buff

            RedMageEmbolden.Checked = Shinra.Settings.RedMageEmbolden;
            RedMageManafication.Checked = Shinra.Settings.RedMageManafication;

            #endregion

            #region Heal

            RedMageVercure.Checked = Shinra.Settings.RedMageVercure;
            RedMageVerraise.Checked = Shinra.Settings.RedMageVerraise;

            RedMageVercurePct.Value = Shinra.Settings.RedMageVercurePct;

            #endregion

            #region Misc

            RedMageOpener.Checked = Shinra.Settings.RedMageOpener;
            RedMagePotion.Checked = Shinra.Settings.RedMagePotion;

            #endregion

            #endregion

            #region Samurai

            #region Role

            SamuraiSecondWind.Checked = Shinra.Settings.SamuraiSecondWind;
            SamuraiInvigorate.Checked = Shinra.Settings.SamuraiInvigorate;
            SamuraiBloodbath.Checked = Shinra.Settings.SamuraiBloodbath;
            SamuraiGoad.Checked = Shinra.Settings.SamuraiGoad;
            SamuraiTrueNorth.Checked = Shinra.Settings.SamuraiTrueNorth;

            SamuraiSecondWindPct.Value = Shinra.Settings.SamuraiSecondWindPct;
            SamuraiInvigoratePct.Value = Shinra.Settings.SamuraiInvigoratePct;
            SamuraiBloodbathPct.Value = Shinra.Settings.SamuraiBloodbathPct;
            SamuraiGoadPct.Value = Shinra.Settings.SamuraiGoadPct;

            #endregion

            #region Damage

            SamuraiMidare.Checked = Shinra.Settings.SamuraiMidare;
            SamuraiMidareHP.Value = Shinra.Settings.SamuraiMidareHP;

            #endregion

            #region DoT

            SamuraiHiganbana.Checked = Shinra.Settings.SamuraiHiganbana;
            SamuraiHiganbanaHP.Value = Shinra.Settings.SamuraiHiganbanaHP;

            #endregion

            #region Cooldown

            SamuraiGyoten.Checked = Shinra.Settings.SamuraiGyoten;
            SamuraiGuren.Checked = Shinra.Settings.SamuraiGuren;

            #endregion

            #region Buff

            SamuraiMeikyo.Checked = Shinra.Settings.SamuraiMeikyo;
            SamuraiHagakure.Checked = Shinra.Settings.SamuraiHagakure;

            #endregion

            #region Heal

            SamuraiMerciful.Checked = Shinra.Settings.SamuraiMerciful;
            SamuraiMercifulPct.Value = Shinra.Settings.SamuraiMercifulPct;

            #endregion

            #region Misc

            SamuraiOpener.Checked = Shinra.Settings.SamuraiOpener;
            SamuraiPotion.Checked = Shinra.Settings.SamuraiPotion;

            #endregion

            #endregion

            #region Scholar

            #region Role

            ScholarClericStance.Checked = Shinra.Settings.ScholarClericStance;
            ScholarProtect.Checked = Shinra.Settings.ScholarProtect;
            ScholarEsuna.Checked = Shinra.Settings.ScholarEsuna;
            ScholarLucidDreaming.Checked = Shinra.Settings.ScholarLucidDreaming;
            ScholarLucidDreamingPct.Value = Shinra.Settings.ScholarLucidDreamingPct;
            ScholarSwiftcast.Checked = Shinra.Settings.ScholarSwiftcast;
            ScholarEyeForAnEye.Checked = Shinra.Settings.ScholarEyeForAnEye;
            ScholarEyeForAnEyePct.Value = Shinra.Settings.ScholarEyeForAnEyePct;
            ScholarLargesse.Checked = Shinra.Settings.ScholarLargesse;
            ScholarLargesseCount.Value = Shinra.Settings.ScholarLargesseCount;
            ScholarLargessePct.Value = Shinra.Settings.ScholarLargessePct;

            #endregion

            #region Damage

            ScholarStopDamage.Checked = Shinra.Settings.ScholarStopDamage;
            ScholarStopDots.Checked = Shinra.Settings.ScholarStopDots;

            ScholarStopDamagePct.Value = Shinra.Settings.ScholarStopDamagePct;
            ScholarStopDotsPct.Value = Shinra.Settings.ScholarStopDotsPct;

            #endregion

            #region AoE

            ScholarBane.Checked = Shinra.Settings.ScholarBane;

            #endregion

            #region Cooldown

            ScholarEnergyDrain.Checked = Shinra.Settings.ScholarEnergyDrain;
            ScholarEnergyDrainPct.Value = Shinra.Settings.ScholarEnergyDrainPct;
            ScholarShadowFlare.Checked = Shinra.Settings.ScholarShadowFlare;
            ScholarChainStrategem.Checked = Shinra.Settings.ScholarChainStrategem;

            #endregion

            #region Buff

            ScholarRouse.Checked = Shinra.Settings.ScholarRouse;
            ScholarEmergencyTactics.Checked = Shinra.Settings.ScholarEmergencyTactics;

            #endregion

            #region Heal

            ScholarPartyHeal.Checked = Shinra.Settings.ScholarPartyHeal;
            ScholarInterruptDamage.Checked = Shinra.Settings.ScholarInterruptDamage;
            ScholarInterruptOverheal.Checked = Shinra.Settings.ScholarInterruptOverheal;
            ScholarPhysick.Checked = Shinra.Settings.ScholarPhysick;
            ScholarAdloquium.Checked = Shinra.Settings.ScholarAdloquium;
            ScholarAetherpact.Checked = Shinra.Settings.ScholarAetherpact;
            ScholarLustrate.Checked = Shinra.Settings.ScholarLustrate;
            ScholarExcogitation.Checked = Shinra.Settings.ScholarExcogitation;
            ScholarSuccor.Checked = Shinra.Settings.ScholarSuccor;
            ScholarIndomitability.Checked = Shinra.Settings.ScholarIndomitability;
            ScholarResurrection.Checked = Shinra.Settings.ScholarResurrection;

            ScholarPhysickPct.Value = Shinra.Settings.ScholarPhysickPct;
            ScholarAdloquiumPct.Value = Shinra.Settings.ScholarAdloquiumPct;
            ScholarAetherpactPct.Value = Shinra.Settings.ScholarAetherpactPct;
            ScholarLustratePct.Value = Shinra.Settings.ScholarLustratePct;
            ScholarExcogitationPct.Value = Shinra.Settings.ScholarExcogitationPct;
            ScholarSuccorPct.Value = Shinra.Settings.ScholarSuccorPct;
            ScholarIndomitabilityPct.Value = Shinra.Settings.ScholarIndomitabilityPct;

            #endregion

            #region Pet

            ScholarPet.Text = Convert.ToString(Shinra.Settings.ScholarPet);

            #endregion

            #endregion

            #region Summoner

            #region Role

            SummonerAddle.Checked = Shinra.Settings.SummonerAddle;
            SummonerDrain.Checked = Shinra.Settings.SummonerDrain;
            SummonerLucidDreaming.Checked = Shinra.Settings.SummonerLucidDreaming;
            SummonerSwiftcast.Checked = Shinra.Settings.SummonerSwiftcast;

            SummonerDrainPct.Value = Shinra.Settings.SummonerDrainPct;
            SummonerLucidDreamingPct.Value = Shinra.Settings.SummonerLucidDreamingPct;

            #endregion

            #region AoE

            SummonerBane.Checked = Shinra.Settings.SummonerBane;

            #endregion

            #region Cooldown

            SummonerShadowFlare.Checked = Shinra.Settings.SummonerShadowFlare;
            SummonerEnkindle.Checked = Shinra.Settings.SummonerEnkindle;
            SummonerTriDisaster.Checked = Shinra.Settings.SummonerTriDisaster;
            SummonerEnkindleBahamut.Checked = Shinra.Settings.SummonerEnkindleBahamut;

            #endregion

            #region Buff

            SummonerRouse.Checked = Shinra.Settings.SummonerRouse;
            SummonerDreadwyrmTrance.Checked = Shinra.Settings.SummonerDreadwyrmTrance;
            SummonerAetherpact.Checked = Shinra.Settings.SummonerAetherpact;
            SummonerSummonBahamut.Checked = Shinra.Settings.SummonerSummonBahamut;

            #endregion

            #region Heal

            SummonerPhysick.Checked = Shinra.Settings.SummonerPhysick;
            SummonerSustain.Checked = Shinra.Settings.SummonerSustain;
            SummonerResurrection.Checked = Shinra.Settings.SummonerResurrection;

            SummonerPhysickPct.Value = Shinra.Settings.SummonerPhysickPct;
            SummonerSustainPct.Value = Shinra.Settings.SummonerSustainPct;

            #endregion

            #region Pet

            SummonerPet.Text = Convert.ToString(Shinra.Settings.SummonerPet);

            #endregion

            #region Misc

            SummonerOpener.Checked = Shinra.Settings.SummonerOpener;
            SummonerPotion.Checked = Shinra.Settings.SummonerPotion;
            SummonerOpenerGaruda.Checked = Shinra.Settings.SummonerOpenerGaruda;

            #endregion

            #endregion

            #region Warrior

            #region Role

            WarriorRampart.Checked = Shinra.Settings.WarriorRampart;
            WarriorConvalescence.Checked = Shinra.Settings.WarriorConvalescence;
            WarriorAnticipation.Checked = Shinra.Settings.WarriorAnticipation;
            WarriorReprisal.Checked = Shinra.Settings.WarriorReprisal;
            WarriorAwareness.Checked = Shinra.Settings.WarriorAwareness;

            WarriorRampartPct.Value = Shinra.Settings.WarriorRampartPct;
            WarriorConvalescencePct.Value = Shinra.Settings.WarriorConvalescencePct;
            WarriorAnticipationPct.Value = Shinra.Settings.WarriorAnticipationPct;
            WarriorAwarenessPct.Value = Shinra.Settings.WarriorAwarenessPct;

            #endregion

            #region Damage

            WarriorMaim.Checked = Shinra.Settings.WarriorMaim;
            WarriorStormsEye.Checked = Shinra.Settings.WarriorStormsEye;
            WarriorInnerBeast.Checked = Shinra.Settings.WarriorInnerBeast;
            WarriorFellCleave.Checked = Shinra.Settings.WarriorFellCleave;

            #endregion

            #region AoE

            WarriorOverpower.Checked = Shinra.Settings.WarriorOverpower;
            WarriorSteelCyclone.Checked = Shinra.Settings.WarriorSteelCyclone;
            WarriorDecimate.Checked = Shinra.Settings.WarriorDecimate;

            #endregion

            #region Cooldown

            WarriorOnslaught.Checked = Shinra.Settings.WarriorOnslaught;
            WarriorUpheaval.Checked = Shinra.Settings.WarriorUpheaval;

            #endregion

            #region Buff

            WarriorBerserk.Checked = Shinra.Settings.WarriorBerserk;
            WarriorThrillOfBattle.Checked = Shinra.Settings.WarriorThrillOfBattle;
            WarriorUnchained.Checked = Shinra.Settings.WarriorUnchained;
            WarriorVengeance.Checked = Shinra.Settings.WarriorVengeance;
            WarriorInfuriate.Checked = Shinra.Settings.WarriorInfuriate;
            WarriorEquilibriumTP.Checked = Shinra.Settings.WarriorEquilibriumTP;
            WarriorShakeItOff.Checked = Shinra.Settings.WarriorShakeItOff;
            WarriorInnerRelease.Checked = Shinra.Settings.WarriorInnerRelease;

            WarriorThrillOfBattlePct.Value = Shinra.Settings.WarriorThrillOfBattlePct;
            WarriorVengeancePct.Value = Shinra.Settings.WarriorVengeancePct;
            WarriorEquilibriumTPPct.Value = Shinra.Settings.WarriorEquilibriumTPPct;

            #endregion

            #region Heal

            WarriorEquilibrium.Checked = Shinra.Settings.WarriorEquilibrium;
            WarriorEquilibriumPct.Value = Shinra.Settings.WarriorEquilibriumPct;

            #endregion

            #region Stance

            WarriorStance.Text = Convert.ToString(Shinra.Settings.WarriorStance);

            #endregion

            #region Misc

            WarriorOpener.Checked = Shinra.Settings.WarriorOpener;
            WarriorPotion.Checked = Shinra.Settings.WarriorPotion;

            #endregion

            #endregion

            #region White Mage

            #region Role

            WhiteMageClericStance.Checked = Shinra.Settings.WhiteMageClericStance;
            WhiteMageProtect.Checked = Shinra.Settings.WhiteMageProtect;
            WhiteMageEsuna.Checked = Shinra.Settings.WhiteMageEsuna;
            WhiteMageLucidDreaming.Checked = Shinra.Settings.WhiteMageLucidDreaming;
            WhiteMageLucidDreamingPct.Value = Shinra.Settings.WhiteMageLucidDreamingPct;
            WhiteMageSwiftcast.Checked = Shinra.Settings.WhiteMageSwiftcast;
            WhiteMageEyeForAnEye.Checked = Shinra.Settings.WhiteMageEyeForAnEye;
            WhiteMageEyeForAnEyePct.Value = Shinra.Settings.WhiteMageEyeForAnEyePct;
            WhiteMageLargesse.Checked = Shinra.Settings.WhiteMageLargesse;
            WhiteMageLargesseCount.Value = Shinra.Settings.WhiteMageLargesseCount;
            WhiteMageLargessePct.Value = Shinra.Settings.WhiteMageLargessePct;

            #endregion

            #region Damage

            WhiteMageStopDamage.Checked = Shinra.Settings.WhiteMageStopDamage;
            WhiteMageStopDots.Checked = Shinra.Settings.WhiteMageStopDots;

            WhiteMageStopDamagePct.Value = Shinra.Settings.WhiteMageStopDamagePct;
            WhiteMageStopDotsPct.Value = Shinra.Settings.WhiteMageStopDotsPct;

            #endregion

            #region Buff

            WhiteMagePresenceOfMind.Checked = Shinra.Settings.WhiteMagePresenceOfMind;
            WhiteMagePresenceOfMindCount.Value = Shinra.Settings.WhiteMagePresenceOfMindCount;
            WhiteMagePresenceOfMindPct.Value = Shinra.Settings.WhiteMagePresenceOfMindPct;
            WhiteMageThinAir.Checked = Shinra.Settings.WhiteMageThinAir;

            #endregion

            #region Heal

            WhiteMagePartyHeal.Checked = Shinra.Settings.WhiteMagePartyHeal;
            WhiteMageInterruptDamage.Checked = Shinra.Settings.WhiteMageInterruptDamage;
            WhiteMageInterruptOverheal.Checked = Shinra.Settings.WhiteMageInterruptOverheal;
            WhiteMageCure.Checked = Shinra.Settings.WhiteMageCure;
            WhiteMageCureII.Checked = Shinra.Settings.WhiteMageCureII;
            WhiteMageTetragrammaton.Checked = Shinra.Settings.WhiteMageTetragrammaton;
            WhiteMageBenediction.Checked = Shinra.Settings.WhiteMageBenediction;
            WhiteMageRegen.Checked = Shinra.Settings.WhiteMageRegen;
            WhiteMageMedica.Checked = Shinra.Settings.WhiteMageMedica;
            WhiteMageMedicaII.Checked = Shinra.Settings.WhiteMageMedicaII;
            WhiteMageAssize.Checked = Shinra.Settings.WhiteMageAssize;
            WhiteMagePlenary.Checked = Shinra.Settings.WhiteMagePlenary;
            WhiteMageRaise.Checked = Shinra.Settings.WhiteMageRaise;

            WhiteMageCurePct.Value = Shinra.Settings.WhiteMageCurePct;
            WhiteMageCureIIPct.Value = Shinra.Settings.WhiteMageCureIIPct;
            WhiteMageTetragrammatonPct.Value = Shinra.Settings.WhiteMageTetragrammatonPct;
            WhiteMageBenedictionPct.Value = Shinra.Settings.WhiteMageBenedictionPct;
            WhiteMageRegenPct.Value = Shinra.Settings.WhiteMageRegenPct;
            WhiteMageMedicaPct.Value = Shinra.Settings.WhiteMageMedicaPct;
            WhiteMageMedicaIIPct.Value = Shinra.Settings.WhiteMageMedicaIIPct;
            WhiteMageAssizePct.Value = Shinra.Settings.WhiteMageAssizePct;
            WhiteMagePlenaryPct.Value = Shinra.Settings.WhiteMagePlenaryPct;

            #endregion

            #endregion

            #endregion
        }

        private void ShinraDonate_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ECDZMK27NSFWA");
        }

        private void ShinraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shinra.RegisterHotkeys();
            Shinra.RegisterClassHotkeys();
            Shinra.Settings.WindowLocation = Location;
            Shinra.Settings.Save();
        }

        private void ShinraClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Main Settings

        #region Rotation

        private void RotationOverlay_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RotationOverlay = RotationOverlay.Checked;
            Shinra.Overlay.Visible = RotationOverlay.Checked;
        }

        private void RotationMessages_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RotationMessages = RotationMessages.Checked;
        }

        private void RotationMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (RotationMode.Text == @"Smart") Shinra.Settings.RotationMode = Modes.Smart;
            if (RotationMode.Text == @"Single") Shinra.Settings.RotationMode = Modes.Single;
            if (RotationMode.Text == @"Multi") Shinra.Settings.RotationMode = Modes.Multi;
            Shinra.Overlay.UpdateText();
        }

        private void RotationHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Shinra.Settings.RotationHotkey = RotationHotkey.Hotkey;
        }

        private void CooldownMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CooldownMode.Text == @"Enabled") Shinra.Settings.CooldownMode = CooldownModes.Enabled;
            if (CooldownMode.Text == @"Disabled") Shinra.Settings.CooldownMode = CooldownModes.Disabled;
            Shinra.Overlay.UpdateText();
        }

        private void CooldownHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Shinra.Settings.CooldownHotkey = CooldownHotkey.Hotkey;
        }

        private void TankMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (TankMode.Text == @"DPS") Shinra.Settings.TankMode = TankModes.DPS;
            if (TankMode.Text == @"Enmity") Shinra.Settings.TankMode = TankModes.Enmity;
            Shinra.Overlay.UpdateText();
        }

        private void TankHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Shinra.Settings.TankHotkey = TankHotkey.Hotkey;
        }

        #endregion

        #region Chocobo

        private void ChocoboSummon_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonChocobo = ChocoboSummon.Checked;
        }

        private void ChocoboStanceDance_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ChocoboStanceDance = ChocoboStanceDance.Checked;
        }

        private void ChocoboStanceDancePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ChocoboStanceDancePct = Convert.ToInt32(ChocoboStanceDancePct.Value);
        }

        private void ChocoboStance_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ChocoboStance.Text == @"Free") Shinra.Settings.ChocoboStance = Stances.Free;
            if (ChocoboStance.Text == @"Attacker") Shinra.Settings.ChocoboStance = Stances.Attacker;
            if (ChocoboStance.Text == @"Healer") Shinra.Settings.ChocoboStance = Stances.Healer;
            if (ChocoboStance.Text == @"Defender") Shinra.Settings.ChocoboStance = Stances.Defender;
        }

        #endregion

        #region Rest

        private void RestHealth_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RestHealth = RestHealth.Checked;
        }

        private void RestEnergy_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RestEnergy = RestEnergy.Checked;
        }

        private void RestHealthPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RestHealthPct = Convert.ToInt32(RestHealthPct.Value);
        }

        private void RestEnergyPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RestEnergyPct = Convert.ToInt32(RestEnergyPct.Value);
        }

        #endregion

        #region Spell

        private void RandomCastLocations_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RandomCastLocations = RandomCastLocations.Checked;
        }

        private void CustomAoE_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.CustomAoE = CustomAoE.Checked;
        }

        private void CustomAoECount_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.CustomAoECount = Convert.ToInt32(CustomAoECount.Value);
        }

        private void QueueSpells_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.QueueSpells = QueueSpells.Checked;
        }

        #endregion

        #region Misc

        private void IgnoreSmart_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.IgnoreSmart = IgnoreSmart.Checked;
        }

        private void DisableDebug_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DisableDebug = DisableDebug.Checked;
        }

        #endregion

        #endregion

        #region Job Settings

        #region Astrologian

        #region Role

        private void AstrologianClericStance_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianClericStance = AstrologianClericStance.Checked;
        }

        private void AstrologianProtect_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianProtect = AstrologianProtect.Checked;
        }

        private void AstrologianEsuna_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianEsuna = AstrologianEsuna.Checked;
        }

        private void AstrologianLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianLucidDreaming = AstrologianLucidDreaming.Checked;
        }

        private void AstrologianLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianLucidDreamingPct = Convert.ToInt32(AstrologianLucidDreamingPct.Value);
        }

        private void AstrologianSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianSwiftcast = AstrologianSwiftcast.Checked;
        }

        private void AstrologianEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianEyeForAnEye = AstrologianEyeForAnEye.Checked;
        }

        private void AstrologianEyeForAnEyePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianEyeForAnEyePct = Convert.ToInt32(AstrologianEyeForAnEyePct.Value);
        }

        private void AstrologianLargesse_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianLargesse = AstrologianLargesse.Checked;
        }

        private void AstrologianLargesseCount_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianLargesseCount = Convert.ToInt32(AstrologianLargesseCount.Value);
        }

        private void AstrologianLargessePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianLargessePct = Convert.ToInt32(AstrologianLargessePct.Value);
        }

        #endregion

        #region Damage

        private void AstrologianStopDamage_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianStopDamage = AstrologianStopDamage.Checked;
        }

        private void AstrologianStopDots_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianStopDots = AstrologianStopDots.Checked;
        }

        private void AstrologianStopDamagePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianStopDamagePct = Convert.ToInt32(AstrologianStopDamagePct.Value);
        }

        private void AstrologianStopDotsPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianStopDotsPct = Convert.ToInt32(AstrologianStopDotsPct.Value);
        }

        #endregion

        #region AoE

        private void AstrologianEarthlyStar_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianEarthlyStar = AstrologianEarthlyStar.Checked;
        }

        private void AstrologianStellarDetonation_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianStellarDetonation = AstrologianStellarDetonation.Checked;
        }

        #endregion

        #region Buff

        private void AstrologianLightspeed_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianLightspeed = AstrologianLightspeed.Checked;
        }

        private void AstrologianLightspeedCount_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianLightspeedCount = Convert.ToInt32(AstrologianLightspeedCount.Value);
        }

        private void AstrologianLightspeedPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianLightspeedPct = Convert.ToInt32(AstrologianLightspeedPct.Value);
        }

        private void AstrologianSynastry_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianSynastry = AstrologianSynastry.Checked;
        }

        private void AstrologianSynastryCount_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianSynastryCount = Convert.ToInt32(AstrologianSynastryCount.Value);
        }

        private void AstrologianSynastryPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianSynastryPct = Convert.ToInt32(AstrologianSynastryPct.Value);
        }

        private void AstrologianTimeDilation_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianTimeDilation = AstrologianTimeDilation.Checked;
        }

        private void AstrologianCelestialOpposition_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianCelestialOpposition = AstrologianCelestialOpposition.Checked;
        }

        #endregion

        #region Heal

        private void AstrologianPartyHeal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianPartyHeal = AstrologianPartyHeal.Checked;
        }

        private void AstrologianInterruptDamage_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianInterruptDamage = AstrologianInterruptDamage.Checked;
        }

        private void AstrologianInterruptOverheal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianInterruptOverheal = AstrologianInterruptOverheal.Checked;
        }

        private void AstrologianBenefic_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianBenefic = AstrologianBenefic.Checked;
        }

        private void AstrologianBeneficII_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianBeneficII = AstrologianBeneficII.Checked;
        }

        private void AstrologianEssDignity_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianEssDignity = AstrologianEssDignity.Checked;
        }

        private void AstrologianAspBenefic_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianAspBenefic = AstrologianAspBenefic.Checked;
        }

        private void AstrologianHelios_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianHelios = AstrologianHelios.Checked;
        }

        private void AstrologianAspHelios_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianAspHelios = AstrologianAspHelios.Checked;
        }

        private void AstrologianAscend_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianAscend = AstrologianAscend.Checked;
        }

        private void AstrologianBeneficPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianBeneficPct = Convert.ToInt32(AstrologianBeneficPct.Value);
        }

        private void AstrologianBeneficIIPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianBeneficIIPct = Convert.ToInt32(AstrologianBeneficIIPct.Value);
        }

        private void AstrologianEssDignityPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianEssDignityPct = Convert.ToInt32(AstrologianEssDignityPct.Value);
        }

        private void AstrologianAspBeneficPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianAspBeneficPct = Convert.ToInt32(AstrologianAspBeneficPct.Value);
        }

        private void AstrologianHeliosPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianHeliosPct = Convert.ToInt32(AstrologianHeliosPct.Value);
        }

        private void AstrologianAspHeliosPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianAspHeliosPct = Convert.ToInt32(AstrologianAspHeliosPct.Value);
        }

        #endregion

        #region Card

        private void AstrologianDraw_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianDraw = AstrologianDraw.Checked;
        }

        private void AstrologianSleeveDraw_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianSleeveDraw = AstrologianSleeveDraw.Checked;
        }

        private void AstrologianCardPreCombat_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianCardPreCombat = AstrologianCardPreCombat.Checked;
        }

        #endregion

        #region Sect

        private void AstrologianSect_SelectedValueChanged(object sender, EventArgs e)
        {
            if (AstrologianSect.Text == @"None") Shinra.Settings.AstrologianSect = AstrologianSects.None;
            if (AstrologianSect.Text == @"Diurnal") Shinra.Settings.AstrologianSect = AstrologianSects.Diurnal;
            if (AstrologianSect.Text == @"Nocturnal") Shinra.Settings.AstrologianSect = AstrologianSects.Nocturnal;
        }

        #endregion

        #region Misc

        private void AstrologianCardOnly_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.AstrologianCardOnly = AstrologianCardOnly.Checked;
        }

        #endregion

        #endregion

        #region Bard

        #region Role

        private void BardSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardSecondWind = BardSecondWind.Checked;
        }

        private void BardPeloton_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardPeloton = BardPeloton.Checked;
        }

        private void BardInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardInvigorate = BardInvigorate.Checked;
        }

        private void BardTactician_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardTactician = BardTactician.Checked;
        }

        private void BardRefresh_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardRefresh = BardRefresh.Checked;
        }

        private void BardPalisade_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardPalisade = BardPalisade.Checked;
        }

        private void BardSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardSecondWindPct = Convert.ToInt32(BardSecondWindPct.Value);
        }

        private void BardInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardInvigoratePct = Convert.ToInt32(BardInvigoratePct.Value);
        }

        private void BardTacticianPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardTacticianPct = Convert.ToInt32(BardTacticianPct.Value);
        }

        private void BardRefreshPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardRefreshPct = Convert.ToInt32(BardRefreshPct.Value);
        }

        private void BardPalisadePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardPalisadePct = Convert.ToInt32(BardPalisadePct.Value);
        }

        #endregion

        #region Damage

        private void BardPitchPerfect_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardPitchPerfect = BardPitchPerfect.Checked;
        }

        private void BardRepertoireCount_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardRepertoireCount = Convert.ToInt32(BardRepertoireCount.Value);
        }

        #endregion

        #region DoT

        private void BardUseDots_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardUseDots = BardUseDots.Checked;
        }

        private void BardUseDotsAoe_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardUseDotsAoe = BardUseDotsAoe.Checked;
        }

        private void BardDotSnapshot_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardDotSnapshot = BardDotSnapshot.Checked;
        }

        #endregion

        #region Cooldown

        private void BardSongs_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardSongs = BardSongs.Checked;
        }

        private void BardEmpyrealArrow_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardEmpyrealArrow = BardEmpyrealArrow.Checked;
        }

        private void BardSidewinder_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardSidewinder = BardSidewinder.Checked;
        }

        #endregion

        #region Buff

        private void BardRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardRagingStrikes = BardRagingStrikes.Checked;
        }

        private void BardFoeRequiem_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardFoeRequiem = BardFoeRequiem.Checked;
        }

        private void BardFoeRequiemPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardFoeRequiemPct = Convert.ToInt32(BardFoeRequiemPct.Value);
        }

        private void BardBarrage_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardBarrage = BardBarrage.Checked;
        }

        private void BardBattleVoice_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardBattleVoice = BardBattleVoice.Checked;
        }

        #endregion

        #region Misc

        private void BardOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardOpener = BardOpener.Checked;
        }

        private void BardPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BardPotion = BardPotion.Checked;
        }

        #endregion

        #endregion

        #region Black Mage

        #region Role

        private void BlackMageDrain_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageDrain = BlackMageDrain.Checked;
        }

        private void BlackMageLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageLucidDreaming = BlackMageLucidDreaming.Checked;
        }

        private void BlackMageSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageSwiftcast = BlackMageSwiftcast.Checked;
        }

        private void BlackMageDrainPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageDrainPct = Convert.ToInt32(BlackMageDrainPct.Value);
        }

        private void BlackMageLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageLucidDreamingPct = Convert.ToInt32(BlackMageLucidDreamingPct.Value);
        }

        #endregion

        #region Damage

        private void BlackMageScathe_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageScathe = BlackMageScathe.Checked;
        }

        #endregion

        #region AoE

        private void BlackMageThunder_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageThunder = BlackMageThunder.Checked;
        }

        #endregion

        #region Buff

        private void BlackMageConvert_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageConvert = BlackMageConvert.Checked;
        }

        private void BlackMageLeyLines_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageLeyLines = BlackMageLeyLines.Checked;
        }

        private void BlackMageSharpcast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageSharpcast = BlackMageSharpcast.Checked;
        }

        private void BlackMageEnochian_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageEnochian = BlackMageEnochian.Checked;
        }

        private void BlackMageTriplecast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageTriplecast = BlackMageTriplecast.Checked;
        }

        #endregion

        #region Misc

        private void BlackMageOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMageOpener = BlackMageOpener.Checked;
        }

        private void BlackMagePotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.BlackMagePotion = BlackMagePotion.Checked;
        }

        #endregion

        #endregion

        #region Dark Knight

        #region Role

        private void DarkKnightRampart_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightRampart = DarkKnightRampart.Checked;
        }

        private void DarkKnightConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightConvalescence = DarkKnightConvalescence.Checked;
        }

        private void DarkKnightAnticipation_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightAnticipation = DarkKnightAnticipation.Checked;
        }

        private void DarkKnightReprisal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightReprisal = DarkKnightReprisal.Checked;
        }

        private void DarkKnightAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightAwareness = DarkKnightAwareness.Checked;
        }

        private void DarkKnightRampartPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightRampartPct = Convert.ToInt32(DarkKnightRampartPct.Value);
        }

        private void DarkKnightConvalescencePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightConvalescencePct = Convert.ToInt32(DarkKnightConvalescencePct.Value);
        }

        private void DarkKnightAnticipationPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightAnticipationPct = Convert.ToInt32(DarkKnightAnticipationPct.Value);
        }

        private void DarkKnightAwarenessPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightAwarenessPct = Convert.ToInt32(DarkKnightAwarenessPct.Value);
        }

        #endregion

        #region Damage

        private void DarkKnightBloodspiller_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightBloodspiller = DarkKnightBloodspiller.Checked;
        }

        #endregion

        #region AoE

        private void DarkKnightQuietus_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightQuietus = DarkKnightQuietus.Checked;
        }

        #endregion

        #region Cooldown

        private void DarkKnightSaltedEarth_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightSaltedEarth = DarkKnightSaltedEarth.Checked;
        }

        private void DarkKnightPlunge_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightPlunge = DarkKnightPlunge.Checked;
        }

        private void DarkKnightCarveAndSpit_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightCarveAndSpit = DarkKnightCarveAndSpit.Checked;
        }

        #endregion

        #region Buff

        private void DarkKnightBloodWeapon_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightBloodWeapon = DarkKnightBloodWeapon.Checked;
        }

        private void DarkKnightBloodPrice_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightBloodPrice = DarkKnightBloodPrice.Checked;
        }

        private void DarkKnightShadowWall_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightShadowWall = DarkKnightShadowWall.Checked;
        }

        private void DarkKnightLivingDead_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightLivingDead = DarkKnightLivingDead.Checked;
        }

        private void DarkKnightDelirium_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightDelirium = DarkKnightDelirium.Checked;
        }

        private void DarkKnightBlackestNight_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightBlackestNight = DarkKnightBlackestNight.Checked;
        }

        private void DarkKnightBloodPricePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightBloodPricePct = Convert.ToInt32(DarkKnightBloodPricePct.Value);
        }

        private void DarkKnightShadowWallPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightShadowWallPct = Convert.ToInt32(DarkKnightShadowWallPct.Value);
        }

        private void DarkKnightLivingDeadPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightLivingDeadPct = Convert.ToInt32(DarkKnightLivingDeadPct.Value);
        }

        private void DarkKnightBlackestNightPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightBlackestNightPct = Convert.ToInt32(DarkKnightBlackestNightPct.Value);
        }

        #endregion

        #region Dark Arts

        private void DarkKnightSouleaterArts_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightSouleaterArts = DarkKnightSouleaterArts.Checked;
        }

        private void DarkKnightAbyssalArts_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightAbyssalArts = DarkKnightAbyssalArts.Checked;
        }

        private void DarkKnightCarveArts_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightCarveArts = DarkKnightCarveArts.Checked;
        }

        private void DarkKnightQuietusArts_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightQuietusArts = DarkKnightQuietusArts.Checked;
        }

        private void DarkKnightBloodspillerArts_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightBloodspillerArts = DarkKnightBloodspillerArts.Checked;
        }

        #endregion

        #region Aura

        private void DarkKnightGrit_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightGrit = DarkKnightGrit.Checked;
        }

        private void DarkKnightDarkside_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightDarkside = DarkKnightDarkside.Checked;
        }

        #endregion

        #region Misc

        private void DarkKnightOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightOpener = DarkKnightOpener.Checked;
        }

        private void DarkKnightPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightPotion = DarkKnightPotion.Checked;
        }

        private void DarkKnightOffTank_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DarkKnightOffTank = DarkKnightOffTank.Checked;
        }

        #endregion

        #endregion

        #region Dragoon

        #region Role

        private void DragoonSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonSecondWind = DragoonSecondWind.Checked;
        }

        private void DragoonInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonInvigorate = DragoonInvigorate.Checked;
        }

        private void DragoonBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonBloodbath = DragoonBloodbath.Checked;
        }

        private void DragoonGoad_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonGoad = DragoonGoad.Checked;
        }

        private void DragoonTrueNorth_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonTrueNorth = DragoonTrueNorth.Checked;
        }

        private void DragoonSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonSecondWindPct = Convert.ToInt32(DragoonSecondWindPct.Value);
        }

        private void DragoonInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonInvigoratePct = Convert.ToInt32(DragoonInvigoratePct.Value);
        }

        private void DragoonBloodbathPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonBloodbathPct = Convert.ToInt32(DragoonBloodbathPct.Value);
        }

        private void DragoonGoadPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonGoadPct = Convert.ToInt32(DragoonGoadPct.Value);
        }

        #endregion

        #region Cooldown

        private void DragoonJump_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonJump = DragoonJump.Checked;
        }

        private void DragoonSpineshatter_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonSpineshatter = DragoonSpineshatter.Checked;
        }

        private void DragoonDragonfire_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonDragonfire = DragoonDragonfire.Checked;
        }

        private void DragoonGeirskogul_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonGeirskogul = DragoonGeirskogul.Checked;
        }

        private void DragoonMirage_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonMirage = DragoonMirage.Checked;
        }

        #endregion

        #region Buff

        private void DragoonLifeSurge_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonLifeSurge = DragoonLifeSurge.Checked;
        }

        private void DragoonBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonBloodForBlood = DragoonBloodForBlood.Checked;
        }

        private void DragoonBattleLitany_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonBattleLitany = DragoonBattleLitany.Checked;
        }

        private void DragoonBloodOfTheDragon_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonBloodOfTheDragon = DragoonBloodOfTheDragon.Checked;
        }

        private void DragoonDragonSight_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonDragonSight = DragoonDragonSight.Checked;
        }

        #endregion

        #region Misc

        private void DragoonOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonOpener = DragoonOpener.Checked;
        }

        private void DragoonPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.DragoonPotion = DragoonPotion.Checked;
        }

        #endregion

        #endregion

        #region Machinist

        #region Role

        private void MachinistSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistSecondWind = MachinistSecondWind.Checked;
        }

        private void MachinistPeloton_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistPeloton = MachinistPeloton.Checked;
        }

        private void MachinistInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistInvigorate = MachinistInvigorate.Checked;
        }

        private void MachinistTactician_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistTactician = MachinistTactician.Checked;
        }

        private void MachinistRefresh_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistRefresh = MachinistRefresh.Checked;
        }

        private void MachinistPalisade_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistPalisade = MachinistPalisade.Checked;
        }

        private void MachinistSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistSecondWindPct = Convert.ToInt32(MachinistSecondWindPct.Value);
        }

        private void MachinistInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistInvigoratePct = Convert.ToInt32(MachinistInvigoratePct.Value);
        }

        private void MachinistTacticianPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistTacticianPct = Convert.ToInt32(MachinistTacticianPct.Value);
        }

        private void MachinistRefreshPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistRefreshPct = Convert.ToInt32(MachinistRefreshPct.Value);
        }

        private void MachinistPalisadePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistPalisadePct = Convert.ToInt32(MachinistPalisadePct.Value);
        }

        #endregion

        #region Cooldown

        private void MachinistWildfire_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistWildfire = MachinistWildfire.Checked;
        }

        private void MachinistRicochet_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistRicochet = MachinistRicochet.Checked;
        }

        private void MachinistCooldown_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistCooldown = MachinistCooldown.Checked;
        }

        private void MachinistFlamethrower_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistFlamethrower = MachinistFlamethrower.Checked;
        }

        private void MachinistWildfireHP_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistWildfireHP = Convert.ToInt32(MachinistWildfireHP.Value);
        }

        #endregion

        #region Buff

        private void MachinistReload_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistReload = MachinistReload.Checked;
        }

        private void MachinistReassemble_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistReassemble = MachinistReassemble.Checked;
        }

        private void MachinistRapidFire_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistRapidFire = MachinistRapidFire.Checked;
        }

        private void MachinistGaussBarrel_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistGaussBarrel = MachinistGaussBarrel.Checked;
        }

        private void MachinistHypercharge_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistHypercharge = MachinistHypercharge.Checked;
        }

        private void MachinistBarrelStabilizer_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistBarrelStabilizer = MachinistBarrelStabilizer.Checked;
        }

        private void MachinistRookOverdrive_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistRookOverdrive = MachinistRookOverdrive.Checked;
        }

        private void MachinistBishopOverdrive_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistBishopOverdrive = MachinistBishopOverdrive.Checked;
        }

        #endregion

        #region Turret

        private void MachinistTurret_SelectedValueChanged(object sender, EventArgs e)
        {
            if (MachinistTurret.Text == @"None") Shinra.Settings.MachinistTurret = MachinistTurrets.None;
            if (MachinistTurret.Text == @"Rook") Shinra.Settings.MachinistTurret = MachinistTurrets.Rook;
            if (MachinistTurret.Text == @"Bishop") Shinra.Settings.MachinistTurret = MachinistTurrets.Bishop;
        }

        private void MachinistTurretHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Shinra.Settings.MachinistTurretHotkey = MachinistTurretHotkey.Hotkey;
        }

        private void MachinistTurretLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (MachinistTurretLocation.Text == @"Self") Shinra.Settings.MachinistTurretLocation = CastLocations.Self;
            if (MachinistTurretLocation.Text == @"Target") Shinra.Settings.MachinistTurretLocation = CastLocations.Target;
        }

        #endregion

        #region Misc

        private void MachinistOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistOpener = MachinistOpener.Checked;
        }

        private void MachinistPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistPotion = MachinistPotion.Checked;
        }

        private void MachinistSyncWildfire_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistSyncWildfire = MachinistSyncWildfire.Checked;
        }

        private void MachinistSyncOverheat_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MachinistSyncOverheat = MachinistSyncOverheat.Checked;
        }

        #endregion

        #endregion

        #region Monk

        #region Role

        private void MonkSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkSecondWind = MonkSecondWind.Checked;
        }

        private void MonkInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkInvigorate = MonkInvigorate.Checked;
        }

        private void MonkBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkBloodbath = MonkBloodbath.Checked;
        }

        private void MonkGoad_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkGoad = MonkGoad.Checked;
        }

        private void MonkTrueNorth_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkTrueNorth = MonkTrueNorth.Checked;
        }

        private void MonkSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkSecondWindPct = Convert.ToInt32(MonkSecondWindPct.Value);
        }

        private void MonkInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkInvigoratePct = Convert.ToInt32(MonkInvigoratePct.Value);
        }

        private void MonkBloodbathPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkBloodbathPct = Convert.ToInt32(MonkBloodbathPct.Value);
        }

        private void MonkGoadPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkGoadPct = Convert.ToInt32(MonkGoadPct.Value);
        }

        #endregion

        #region DoT

        private void MonkDemolish_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkDemolish = MonkDemolish.Checked;
        }

        private void MonkDemolishHP_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkDemolishHP = Convert.ToInt32(MonkDemolishHP.Value);
        }

        #endregion

        #region Cooldown

        private void MonkShoulderTackle_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkShoulderTackle = MonkShoulderTackle.Checked;
        }

        private void MonkSteelPeak_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkSteelPeak = MonkSteelPeak.Checked;
        }

        private void MonkHowlingFist_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkHowlingFist = MonkHowlingFist.Checked;
        }

        private void MonkForbiddenChakra_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkForbiddenChakra = MonkForbiddenChakra.Checked;
        }

        private void MonkElixirField_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkElixirField = MonkElixirField.Checked;
        }

        private void MonkFireTackle_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkFireTackle = MonkFireTackle.Checked;
        }

        #endregion

        #region Buff

        private void MonkInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkInternalRelease = MonkInternalRelease.Checked;
        }

        private void MonkPerfectBalance_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkPerfectBalance = MonkPerfectBalance.Checked;
        }

        private void MonkFormShift_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkFormShift = MonkFormShift.Checked;
        }

        private void MonkMeditation_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkMeditation = MonkMeditation.Checked;
        }

        private void MonkRiddleOfFire_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkRiddleOfFire = MonkRiddleOfFire.Checked;
        }

        private void MonkBrotherhood_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkBrotherhood = MonkBrotherhood.Checked;
        }

        #endregion

        #region Fists

        private void MonkFist_SelectedValueChanged(object sender, EventArgs e)
        {
            if (MonkFist.Text == @"None") Shinra.Settings.MonkFist = MonkFists.None;
            if (MonkFist.Text == @"Earth") Shinra.Settings.MonkFist = MonkFists.Earth;
            if (MonkFist.Text == @"Wind") Shinra.Settings.MonkFist = MonkFists.Wind;
            if (MonkFist.Text == @"Fire") Shinra.Settings.MonkFist = MonkFists.Fire;
        }

        #endregion

        #region Misc

        private void MonkOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkOpener = MonkOpener.Checked;
        }

        private void MonkPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.MonkPotion = MonkPotion.Checked;
        }

        #endregion

        #endregion

        #region Ninja

        #region Role

        private void NinjaSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaSecondWind = NinjaSecondWind.Checked;
        }

        private void NinjaInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaInvigorate = NinjaInvigorate.Checked;
        }

        private void NinjaBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaBloodbath = NinjaBloodbath.Checked;
        }

        private void NinjaGoad_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaGoad = NinjaGoad.Checked;
        }

        private void NinjaTrueNorth_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaTrueNorth = NinjaTrueNorth.Checked;
        }

        private void NinjaSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaSecondWindPct = Convert.ToInt32(NinjaSecondWindPct.Value);
        }

        private void NinjaInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaInvigoratePct = Convert.ToInt32(NinjaInvigoratePct.Value);
        }

        private void NinjaBloodbathPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaBloodbathPct = Convert.ToInt32(NinjaBloodbathPct.Value);
        }

        private void NinjaGoadPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaGoadPct = Convert.ToInt32(NinjaGoadPct.Value);
        }

        #endregion

        #region DoT

        private void NinjaShadowFang_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaShadowFang = NinjaShadowFang.Checked;
        }

        private void NinjaShadowFangHP_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaShadowFangHP = Convert.ToInt32(NinjaShadowFangHP.Value);
        }

        #endregion

        #region Cooldown

        private void NinjaAssassinate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaAssassinate = NinjaAssassinate.Checked;
        }

        private void NinjaMug_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaMug = NinjaMug.Checked;
        }

        private void NinjaTrickAttack_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaTrickAttack = NinjaTrickAttack.Checked;
        }

        private void NinjaJugulate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaJugulate = NinjaJugulate.Checked;
        }

        private void NinjaShukuchi_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaShukuchi = NinjaShukuchi.Checked;
        }

        private void NinjaDreamWithin_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaDreamWithin = NinjaDreamWithin.Checked;
        }

        private void NinjaHellfrogMedium_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaHellfrogMedium = NinjaHellfrogMedium.Checked;
        }

        private void NinjaBhavacakra_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaBhavacakra = NinjaBhavacakra.Checked;
        }

        #endregion

        #region Buff

        private void NinjaShadeShift_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaShadeShift = NinjaShadeShift.Checked;
        }

        private void NinjaKassatsu_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaKassatsu = NinjaKassatsu.Checked;
        }

        private void NinjaDuality_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaDuality = NinjaDuality.Checked;
        }

        private void NinjaTenChiJin_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaTenChiJin = NinjaTenChiJin.Checked;
        }

        private void NinjaShadeShiftPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaShadeShiftPct = Convert.ToInt32(NinjaShadeShiftPct.Value);
        }

        #endregion

        #region Ninjutsu

        private void NinjaFuma_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaFuma = NinjaFuma.Checked;
        }

        private void NinjaKaton_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaKaton = NinjaKaton.Checked;
        }

        private void NinjaRaiton_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaRaiton = NinjaRaiton.Checked;
        }

        private void NinjaHuton_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaHuton = NinjaHuton.Checked;
        }

        private void NinjaDoton_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaDoton = NinjaDoton.Checked;
        }

        private void NinjaSuiton_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaSuiton = NinjaSuiton.Checked;
        }

        #endregion

        #region Misc

        private void NinjaOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaOpener = NinjaOpener.Checked;
        }

        private void NinjaPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.NinjaPotion = NinjaPotion.Checked;
        }

        #endregion

        #endregion

        #region Paladin

        #region Role

        private void PaladinRampart_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinRampart = PaladinRampart.Checked;
        }

        private void PaladinConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinConvalescence = PaladinConvalescence.Checked;
        }

        private void PaladinAnticipation_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinAnticipation = PaladinAnticipation.Checked;
        }

        private void PaladinReprisal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinReprisal = PaladinReprisal.Checked;
        }

        private void PaladinAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinAwareness = PaladinAwareness.Checked;
        }

        private void PaladinRampartPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinRampartPct = Convert.ToInt32(PaladinRampartPct.Value);
        }

        private void PaladinConvalescencePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinConvalescencePct = Convert.ToInt32(PaladinConvalescencePct.Value);
        }

        private void PaladinAnticipationPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinAnticipationPct = Convert.ToInt32(PaladinAnticipationPct.Value);
        }

        private void PaladinAwarenessPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinAwarenessPct = Convert.ToInt32(PaladinAwarenessPct.Value);
        }

        #endregion

        #region Damage

        private void PaladinGoringBlade_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinGoringBlade = PaladinGoringBlade.Checked;
        }

        #endregion

        #region AoE

        private void PaladinFlash_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinFlash = PaladinFlash.Checked;
        }

        private void PaladinTotalEclipse_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinTotalEclipse = PaladinTotalEclipse.Checked;
        }

        #endregion

        #region Cooldown

        private void PaladinShieldSwipe_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinShieldSwipe = PaladinShieldSwipe.Checked;
        }

        private void PaladinSpiritsWithin_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinSpiritsWithin = PaladinSpiritsWithin.Checked;
        }

        private void PaladinCircleOfScorn_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinCircleOfScorn = PaladinCircleOfScorn.Checked;
        }

        private void PaladinRequiescat_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinRequiescat = PaladinRequiescat.Checked;
        }

        #endregion

        #region Buff

        private void PaladinFightOrFlight_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinFightOrFlight = PaladinFightOrFlight.Checked;
        }

        private void PaladinBulwark_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinBulwark = PaladinBulwark.Checked;
        }

        private void PaladinSentinel_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinSentinel = PaladinSentinel.Checked;
        }

        private void PaladinHallowedGround_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinHallowedGround = PaladinHallowedGround.Checked;
        }

        private void PaladinSheltron_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinSheltron = PaladinSheltron.Checked;
        }

        private void PaladinBulwarkPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinBulwarkPct = Convert.ToInt32(PaladinBulwarkPct.Value);
        }

        private void PaladinSentinelPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinSentinelPct = Convert.ToInt32(PaladinSentinelPct.Value);
        }

        private void PaladinHallowedGroundPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinHallowedGroundPct = Convert.ToInt32(PaladinHallowedGroundPct.Value);
        }

        #endregion

        #region Heal

        private void PaladinClemency_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinClemency = PaladinClemency.Checked;
        }

        private void PaladinClemencyPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinClemencyPct = Convert.ToInt32(PaladinClemencyPct.Value);
        }

        #endregion

        #region Oath

        private void PaladinOath_SelectedValueChanged(object sender, EventArgs e)
        {
            if (PaladinOath.Text == @"None") Shinra.Settings.PaladinOath = PaladinOaths.None;
            if (PaladinOath.Text == @"Shield") Shinra.Settings.PaladinOath = PaladinOaths.Shield;
            if (PaladinOath.Text == @"Sword") Shinra.Settings.PaladinOath = PaladinOaths.Sword;
        }

        #endregion

        #region Misc

        private void PaladinOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinOpener = PaladinOpener.Checked;
        }

        private void PaladinPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.PaladinPotion = PaladinPotion.Checked;
        }

        #endregion

        #endregion

        #region Red Mage

        #region Role

        private void RedMageDrain_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageDrain = RedMageDrain.Checked;
        }

        private void RedMageLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageLucidDreaming = RedMageLucidDreaming.Checked;
        }

        private void RedMageSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageSwiftcast = RedMageSwiftcast.Checked;
        }

        private void RedMageDrainPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageDrainPct = Convert.ToInt32(RedMageDrainPct.Value);
        }

        private void RedMageLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageLucidDreamingPct = Convert.ToInt32(RedMageLucidDreamingPct.Value);
        }

        #endregion

        #region Cooldown

        private void RedMageCorpsACorps_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageCorpsACorps = RedMageCorpsACorps.Checked;
        }

        private void RedMageDisplacement_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageDisplacement = RedMageDisplacement.Checked;
        }

        #endregion

        #region Buff

        private void RedMageEmbolden_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageEmbolden = RedMageEmbolden.Checked;
        }

        private void RedMageManafication_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageManafication = RedMageManafication.Checked;
        }

        #endregion

        #region Heal

        private void RedMageVercure_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageVercure = RedMageVercure.Checked;
        }

        private void RedMageVerraise_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageVerraise = RedMageVerraise.Checked;
        }

        private void RedMageVercurePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageVercurePct = Convert.ToInt32(RedMageVercurePct.Value);
        }

        #endregion

        #region Misc

        private void RedMageOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMageOpener = RedMageOpener.Checked;
        }

        private void RedMagePotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.RedMagePotion = RedMagePotion.Checked;
        }

        #endregion

        #endregion

        #region Samurai

        #region Role

        private void SamuraiSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiSecondWind = SamuraiSecondWind.Checked;
        }

        private void SamuraiInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiInvigorate = SamuraiInvigorate.Checked;
        }

        private void SamuraiBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiBloodbath = SamuraiBloodbath.Checked;
        }

        private void SamuraiGoad_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiGoad = SamuraiGoad.Checked;
        }

        private void SamuraiTrueNorth_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiTrueNorth = SamuraiTrueNorth.Checked;
        }

        private void SamuraiSecondWindPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiSecondWindPct = Convert.ToInt32(SamuraiSecondWindPct.Value);
        }

        private void SamuraiInvigoratePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiInvigoratePct = Convert.ToInt32(SamuraiInvigoratePct.Value);
        }

        private void SamuraiBloodbathPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiBloodbathPct = Convert.ToInt32(SamuraiBloodbathPct.Value);
        }

        private void SamuraiGoadPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiGoadPct = Convert.ToInt32(SamuraiGoadPct.Value);
        }

        #endregion

        #region Damage

        private void SamuraiMidare_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiMidare = SamuraiMidare.Checked;
        }

        private void SamuraiMidareHP_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiMidareHP = Convert.ToInt32(SamuraiMidareHP.Value);
        }

        #endregion

        #region DoT

        private void SamuraiHiganbana_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiHiganbana = SamuraiHiganbana.Checked;
        }

        private void SamuraiHiganbanaHP_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiHiganbanaHP = Convert.ToInt32(SamuraiHiganbanaHP.Value);
        }

        #endregion

        #region Cooldown

        private void SamuraiGyoten_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiGyoten = SamuraiGyoten.Checked;
        }

        private void SamuraiGuren_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiGuren = SamuraiGuren.Checked;
        }

        #endregion

        #region Buff

        private void SamuraiMeikyo_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiMeikyo = SamuraiMeikyo.Checked;
        }

        private void SamuraiHagakure_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiHagakure = SamuraiHagakure.Checked;
        }

        #endregion

        #region Heal

        private void SamuraiMerciful_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiMerciful = SamuraiMerciful.Checked;
        }

        private void SamuraiMercifulPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiMercifulPct = Convert.ToInt32(SamuraiMercifulPct.Value);
        }

        #endregion

        #region Misc

        private void SamuraiOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiOpener = SamuraiOpener.Checked;
        }

        private void SamuraiPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SamuraiPotion = SamuraiPotion.Checked;
        }

        #endregion

        #endregion

        #region Scholar

        #region Role

        private void ScholarClericStance_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarClericStance = ScholarClericStance.Checked;
        }

        private void ScholarProtect_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarProtect = ScholarProtect.Checked;
        }

        private void ScholarEsuna_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarEsuna = ScholarEsuna.Checked;
        }

        private void ScholarLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarLucidDreaming = ScholarLucidDreaming.Checked;
        }

        private void ScholarLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarLucidDreamingPct = Convert.ToInt32(ScholarLucidDreamingPct.Value);
        }

        private void ScholarSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarSwiftcast = ScholarSwiftcast.Checked;
        }

        private void ScholarEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarEyeForAnEye = ScholarEyeForAnEye.Checked;
        }

        private void ScholarEyeForAnEyePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarEyeForAnEyePct = Convert.ToInt32(ScholarEyeForAnEyePct.Value);
        }

        private void ScholarLargesse_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarLargesse = ScholarLargesse.Checked;
        }

        private void ScholarLargesseCount_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarLargesseCount = Convert.ToInt32(ScholarLargesseCount.Value);
        }

        private void ScholarLargessePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarLargessePct = Convert.ToInt32(ScholarLargessePct.Value);
        }

        #endregion

        #region Damage

        private void ScholarStopDamage_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarStopDamage = ScholarStopDamage.Checked;
        }

        private void ScholarStopDots_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarStopDots = ScholarStopDots.Checked;
        }

        private void ScholarStopDamagePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarStopDamagePct = Convert.ToInt32(ScholarStopDamagePct.Value);
        }

        private void ScholarStopDotsPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarStopDotsPct = Convert.ToInt32(ScholarStopDotsPct.Value);
        }

        #endregion

        #region AoE

        private void ScholarBane_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarBane = ScholarBane.Checked;
        }

        #endregion

        #region Cooldown

        private void ScholarEnergyDrain_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarEnergyDrain = ScholarEnergyDrain.Checked;
        }

        private void ScholarEnergyDrainPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarEnergyDrainPct = Convert.ToInt32(ScholarEnergyDrainPct.Value);
        }

        private void ScholarShadowFlare_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarShadowFlare = ScholarShadowFlare.Checked;
        }

        private void ScholarChainStrategem_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarChainStrategem = ScholarChainStrategem.Checked;
        }

        #endregion

        #region Buff

        private void ScholarRouse_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarRouse = ScholarRouse.Checked;
        }

        private void ScholarEmergencyTactics_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarEmergencyTactics = ScholarEmergencyTactics.Checked;
        }

        #endregion

        #region Heal

        private void ScholarPartyHeal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarPartyHeal = ScholarPartyHeal.Checked;
        }

        private void ScholarInterruptDamage_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarInterruptDamage = ScholarInterruptDamage.Checked;
        }

        private void ScholarInterruptOverheal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarInterruptOverheal = ScholarInterruptOverheal.Checked;
        }

        private void ScholarPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarPhysick = ScholarPhysick.Checked;
        }

        private void ScholarAdloquium_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarAdloquium = ScholarAdloquium.Checked;
        }

        private void ScholarAetherpact_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarAetherpact = ScholarAetherpact.Checked;
        }

        private void ScholarLustrate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarLustrate = ScholarLustrate.Checked;
        }

        private void ScholarExcogitation_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarExcogitation = ScholarExcogitation.Checked;
        }

        private void ScholarSuccor_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarSuccor = ScholarSuccor.Checked;
        }

        private void ScholarIndomitability_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarIndomitability = ScholarIndomitability.Checked;
        }

        private void ScholarResurrection_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarResurrection = ScholarResurrection.Checked;
        }

        private void ScholarPhysickPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarPhysickPct = Convert.ToInt32(ScholarPhysickPct.Value);
        }

        private void ScholarAdloquiumPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarAdloquiumPct = Convert.ToInt32(ScholarAdloquiumPct.Value);
        }

        private void ScholarAetherpactPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarAetherpactPct = Convert.ToInt32(ScholarAetherpactPct.Value);
        }

        private void ScholarLustratePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarLustratePct = Convert.ToInt32(ScholarLustratePct.Value);
        }

        private void ScholarExcogitationPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarExcogitationPct = Convert.ToInt32(ScholarExcogitationPct.Value);
        }

        private void ScholarSuccorPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarSuccorPct = Convert.ToInt32(ScholarSuccorPct.Value);
        }

        private void ScholarIndomitabilityPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.ScholarIndomitabilityPct = Convert.ToInt32(ScholarIndomitabilityPct.Value);
        }

        #endregion

        #region Pet

        private void ScholarPet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ScholarPet.Text == @"None") Shinra.Settings.ScholarPet = ScholarPets.None;
            if (ScholarPet.Text == @"Eos") Shinra.Settings.ScholarPet = ScholarPets.Eos;
            if (ScholarPet.Text == @"Selene") Shinra.Settings.ScholarPet = ScholarPets.Selene;
        }

        #endregion

        #endregion

        #region Summoner

        #region Role

        private void SummonerAddle_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerAddle = SummonerAddle.Checked;
        }

        private void SummonerDrain_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerDrain = SummonerDrain.Checked;
        }

        private void SummonerLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerLucidDreaming = SummonerLucidDreaming.Checked;
        }

        private void SummonerSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerSwiftcast = SummonerSwiftcast.Checked;
        }

        private void SummonerDrainPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerDrainPct = Convert.ToInt32(SummonerDrainPct.Value);
        }

        private void SummonerLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerLucidDreamingPct = Convert.ToInt32(SummonerLucidDreamingPct.Value);
        }

        #endregion

        #region AoE

        private void SummonerBane_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerBane = SummonerBane.Checked;
        }

        #endregion

        #region Cooldown

        private void SummonerShadowFlare_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerShadowFlare = SummonerShadowFlare.Checked;
        }

        private void SummonerEnkindle_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerEnkindle = SummonerEnkindle.Checked;
        }

        private void SummonerTriDisaster_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerTriDisaster = SummonerTriDisaster.Checked;
        }

        private void SummonerEnkindleBahamut_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerEnkindleBahamut = SummonerEnkindleBahamut.Checked;
        }

        #endregion

        #region Buff

        private void SummonerRouse_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerRouse = SummonerRouse.Checked;
        }

        private void SummonerDreadwyrmTrance_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerDreadwyrmTrance = SummonerDreadwyrmTrance.Checked;
        }

        private void SummonerAetherpact_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerAetherpact = SummonerAetherpact.Checked;
        }

        private void SummonerSummonBahamut_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerSummonBahamut = SummonerSummonBahamut.Checked;
        }

        #endregion

        #region Heal

        private void SummonerPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerPhysick = SummonerPhysick.Checked;
        }

        private void SummonerSustain_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerSustain = SummonerSustain.Checked;
        }

        private void SummonerResurrection_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerResurrection = SummonerResurrection.Checked;
        }

        private void SummonerPhysickPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerPhysickPct = Convert.ToInt32(SummonerPhysickPct.Value);
        }

        private void SummonerSustainPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerSustainPct = Convert.ToInt32(SummonerSustainPct.Value);
        }

        #endregion

        #region Pet

        private void SummonerPet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SummonerPet.Text == @"None") Shinra.Settings.SummonerPet = SummonerPets.None;
            if (SummonerPet.Text == @"Garuda") Shinra.Settings.SummonerPet = SummonerPets.Garuda;
            if (SummonerPet.Text == @"Titan") Shinra.Settings.SummonerPet = SummonerPets.Titan;
            if (SummonerPet.Text == @"Ifrit") Shinra.Settings.SummonerPet = SummonerPets.Ifrit;
        }

        #endregion

        #region Misc

        private void SummonerOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerOpener = SummonerOpener.Checked;
        }

        private void SummonerPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerPotion = SummonerPotion.Checked;
        }

        private void SummonerOpenerGaruda_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.SummonerOpenerGaruda = SummonerOpenerGaruda.Checked;
        }

        #endregion

        #endregion

        #region Warrior

        #region Role

        private void WarriorRampart_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorRampart = WarriorRampart.Checked;
        }

        private void WarriorConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorConvalescence = WarriorConvalescence.Checked;
        }

        private void WarriorAnticipation_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorAnticipation = WarriorAnticipation.Checked;
        }

        private void WarriorReprisal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorReprisal = WarriorReprisal.Checked;
        }

        private void WarriorAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorAwareness = WarriorAwareness.Checked;
        }

        private void WarriorRampartPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorRampartPct = Convert.ToInt32(WarriorRampartPct.Value);
        }

        private void WarriorConvalescencePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorConvalescencePct = Convert.ToInt32(WarriorConvalescencePct.Value);
        }

        private void WarriorAnticipationPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorAnticipationPct = Convert.ToInt32(WarriorAnticipationPct.Value);
        }

        private void WarriorAwarenessPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorAwarenessPct = Convert.ToInt32(WarriorAwarenessPct.Value);
        }

        #endregion

        #region Damage

        private void WarriorMaim_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorMaim = WarriorMaim.Checked;
        }

        private void WarriorStormsEye_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorStormsEye = WarriorStormsEye.Checked;
        }

        private void WarriorInnerBeast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorInnerBeast = WarriorInnerBeast.Checked;
        }

        private void WarriorFellCleave_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorFellCleave = WarriorFellCleave.Checked;
        }

        #endregion

        #region AoE

        private void WarriorOverpower_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorOverpower = WarriorOverpower.Checked;
        }

        private void WarriorSteelCyclone_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorSteelCyclone = WarriorSteelCyclone.Checked;
        }

        private void WarriorDecimate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorDecimate = WarriorDecimate.Checked;
        }

        #endregion

        #region Cooldown

        private void WarriorOnslaught_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorOnslaught = WarriorOnslaught.Checked;
        }

        private void WarriorUpheaval_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorUpheaval = WarriorUpheaval.Checked;
        }

        #endregion

        #region Buff

        private void WarriorBerserk_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorBerserk = WarriorBerserk.Checked;
        }

        private void WarriorThrillOfBattle_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorThrillOfBattle = WarriorThrillOfBattle.Checked;
        }

        private void WarriorUnchained_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorUnchained = WarriorUnchained.Checked;
        }

        private void WarriorVengeance_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorVengeance = WarriorVengeance.Checked;
        }

        private void WarriorInfuriate_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorInfuriate = WarriorInfuriate.Checked;
        }

        private void WarriorEquilibriumTP_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorEquilibriumTP = WarriorEquilibriumTP.Checked;
        }

        private void WarriorShakeItOff_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorShakeItOff = WarriorShakeItOff.Checked;
        }

        private void WarriorInnerRelease_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorInnerRelease = WarriorInnerRelease.Checked;
        }

        private void WarriorThrillOfBattlePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorThrillOfBattlePct = Convert.ToInt32(WarriorThrillOfBattlePct.Value);
        }

        private void WarriorVengeancePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorVengeancePct = Convert.ToInt32(WarriorVengeancePct.Value);
        }

        private void WarriorEquilibriumTPPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorEquilibriumTPPct = Convert.ToInt32(WarriorEquilibriumTPPct.Value);
        }

        #endregion

        #region Heal

        private void WarriorEquilibrium_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorEquilibrium = WarriorEquilibrium.Checked;
        }

        private void WarriorEquilibriumPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorEquilibriumPct = Convert.ToInt32(WarriorEquilibriumPct.Value);
        }

        #endregion

        #region Stance

        private void WarriorStance_SelectedValueChanged(object sender, EventArgs e)
        {
            if (WarriorStance.Text == @"None") Shinra.Settings.WarriorStance = WarriorStances.None;
            if (WarriorStance.Text == @"Defiance") Shinra.Settings.WarriorStance = WarriorStances.Defiance;
            if (WarriorStance.Text == @"Deliverance") Shinra.Settings.WarriorStance = WarriorStances.Deliverance;
        }

        #endregion

        #region Misc

        private void WarriorOpener_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorOpener = WarriorOpener.Checked;
        }

        private void WarriorPotion_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WarriorPotion = WarriorPotion.Checked;
        }

        #endregion

        #endregion

        #region White Mage

        #region Role

        private void WhiteMageClericStance_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageClericStance = WhiteMageClericStance.Checked;
        }

        private void WhiteMageProtect_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageProtect = WhiteMageProtect.Checked;
        }

        private void WhiteMageEsuna_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageEsuna = WhiteMageEsuna.Checked;
        }

        private void WhiteMageLucidDreaming_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageLucidDreaming = WhiteMageLucidDreaming.Checked;
        }

        private void WhiteMageLucidDreamingPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageLucidDreamingPct = Convert.ToInt32(WhiteMageLucidDreamingPct.Value);
        }

        private void WhiteMageSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageSwiftcast = WhiteMageSwiftcast.Checked;
        }

        private void WhiteMageEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageEyeForAnEye = WhiteMageEyeForAnEye.Checked;
        }

        private void WhiteMageEyeForAnEyePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageEyeForAnEyePct = Convert.ToInt32(WhiteMageEyeForAnEyePct.Value);
        }

        private void WhiteMageLargesse_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageLargesse = WhiteMageLargesse.Checked;
        }

        private void WhiteMageLargesseCount_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageLargesseCount = Convert.ToInt32(WhiteMageLargesseCount.Value);
        }

        private void WhiteMageLargessePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageLargessePct = Convert.ToInt32(WhiteMageLargessePct.Value);
        }

        #endregion

        #region Damage

        private void WhiteMageStopDamage_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageStopDamage = WhiteMageStopDamage.Checked;
        }

        private void WhiteMageStopDots_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageStopDots = WhiteMageStopDots.Checked;
        }

        private void WhiteMageStopDamagePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageStopDamagePct = Convert.ToInt32(WhiteMageStopDamagePct.Value);
        }

        private void WhiteMageStopDotsPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageStopDotsPct = Convert.ToInt32(WhiteMageStopDotsPct.Value);
        }

        #endregion

        #region Buff

        private void WhiteMagePresenceOfMind_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMagePresenceOfMind = WhiteMagePresenceOfMind.Checked;
        }

        private void WhiteMagePresenceOfMindCount_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMagePresenceOfMindCount = Convert.ToInt32(WhiteMagePresenceOfMindCount.Value);
        }

        private void WhiteMagePresenceOfMindPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMagePresenceOfMindPct = Convert.ToInt32(WhiteMagePresenceOfMindPct.Value);
        }

        private void WhiteMageThinAir_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageThinAir = WhiteMageThinAir.Checked;
        }

        #endregion

        #region Heal

        private void WhiteMagePartyHeal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMagePartyHeal = WhiteMagePartyHeal.Checked;
        }

        private void WhiteMageInterruptDamage_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageInterruptDamage = WhiteMageInterruptDamage.Checked;
        }

        private void WhiteMageInterruptOverheal_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageInterruptOverheal = WhiteMageInterruptOverheal.Checked;
        }

        private void WhiteMageCure_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageCure = WhiteMageCure.Checked;
        }

        private void WhiteMageCureII_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageCureII = WhiteMageCureII.Checked;
        }

        private void WhiteMageTetragrammaton_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageTetragrammaton = WhiteMageTetragrammaton.Checked;
        }

        private void WhiteMageBenediction_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageBenediction = WhiteMageBenediction.Checked;
        }

        private void WhiteMageRegen_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageRegen = WhiteMageRegen.Checked;
        }

        private void WhiteMageMedica_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageMedica = WhiteMageMedica.Checked;
        }

        private void WhiteMageMedicaII_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageMedicaII = WhiteMageMedicaII.Checked;
        }

        private void WhiteMageAssize_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageAssize = WhiteMageAssize.Checked;
        }

        private void WhiteMagePlenary_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMagePlenary = WhiteMagePlenary.Checked;
        }

        private void WhiteMageRaise_CheckedChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageRaise = WhiteMageRaise.Checked;
        }

        private void WhiteMageCurePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageCurePct = Convert.ToInt32(WhiteMageCurePct.Value);
        }

        private void WhiteMageCureIIPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageCureIIPct = Convert.ToInt32(WhiteMageCureIIPct.Value);
        }

        private void WhiteMageTetragrammatonPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageTetragrammatonPct = Convert.ToInt32(WhiteMageTetragrammatonPct.Value);
        }

        private void WhiteMageBenedictionPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageBenedictionPct = Convert.ToInt32(WhiteMageBenedictionPct.Value);
        }

        private void WhiteMageRegenPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageRegenPct = Convert.ToInt32(WhiteMageRegenPct.Value);
        }

        private void WhiteMageMedicaPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageMedicaPct = Convert.ToInt32(WhiteMageMedicaPct.Value);
        }

        private void WhiteMageMedicaIIPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageMedicaIIPct = Convert.ToInt32(WhiteMageMedicaIIPct.Value);
        }

        private void WhiteMageAssizePct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMageAssizePct = Convert.ToInt32(WhiteMageAssizePct.Value);
        }

        private void WhiteMagePlenaryPct_ValueChanged(object sender, EventArgs e)
        {
            Shinra.Settings.WhiteMagePlenaryPct = Convert.ToInt32(WhiteMagePlenaryPct.Value);
        }


        #endregion

        #endregion

        #endregion
    }
}