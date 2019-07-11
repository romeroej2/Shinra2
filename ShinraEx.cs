using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Navigation;
using ShinraCo.Rotations;
using ShinraCo.Settings;
using ShinraCo.Settings.Forms;
using ShinraCo.Spells;
using TreeSharp;

namespace ShinraCo
{
    public class ShinraEx : CombatRoutine
    {
        #region Overrides

        public sealed override string Name => "ShinraEx";
        public sealed override float PullRange => 25;
        public sealed override bool WantButton => true;
        public sealed override CapabilityFlags SupportedCapabilities => CapabilityFlags.All;

        private static DateTime runTime;

        public sealed override void Initialize()
        {
            Logging.Write(Colors.GreenYellow, $@"[ShinraEx] Loaded Version: {Helpers.GetLocalVersion()}");

            Settings.CrPaused = false;
            Overlay.Visible = Settings.RotationOverlay;
            Overlay.UpdateText();
            RegisterHotkeys();
        }

        public sealed override void Pulse()
        {
            if (DateTime.Now < runTime) return;
            runTime = DateTime.Now.AddSeconds(1);
            var _class = CurrentClass;
            Helpers.ResetOpener();
        }

        public sealed override void ShutDown()
        {
            Logging.Write(Colors.GreenYellow, @"[ShinraEx] Shutting down...");
            UnregisterHotkeys();
        }

        #endregion

        #region Settings

        private Form _configForm;

        public static ShinraSettings Settings = ShinraSettings.Instance;
        public static readonly ShinraOverlay Overlay = new ShinraOverlay();
     
        public sealed override void OnButtonPress()
        {
            if (_configForm == null || _configForm.IsDisposed || _configForm.Disposing)
                _configForm = new ShinraForm();

            _configForm.ShowDialog();
        }

        #endregion

        #region Hotkeys

        public static void RegisterHotkeys()
        {
            HotkeyManager.Register("ShinraEx Rotation", Helpers.GetHotkey(Settings.RotationHotkey),
                                   Helpers.GetModkey(Settings.RotationHotkey), hk =>
                                   {
                                       Settings.RotationMode = Settings.RotationMode.Cycle("Rotation", Settings.IgnoreSmart);
                                       Overlay.UpdateText();
                                   });
            HotkeyManager.Register("ShinraEx Cooldown", Helpers.GetHotkey(Settings.CooldownHotkey),
                                   Helpers.GetModkey(Settings.CooldownHotkey), hk =>
                                   {
                                       Settings.CooldownMode = Settings.CooldownMode.Cycle("Cooldown");
                                       Overlay.UpdateText();
                                   });
            HotkeyManager.Register("ShinraEx Tank", Helpers.GetHotkey(Settings.TankHotkey),
                                   Helpers.GetModkey(Settings.TankHotkey), hk =>
                                   {
                                       Settings.TankMode = Settings.TankMode.Cycle("Tank");
                                       Overlay.UpdateText();
                                   });
        }

        public static void RegisterClassHotkeys()
        {
            HotkeyManager.Unregister("ShinraEx Job");
            switch (Core.Player.CurrentJob)
            {
                case ClassJobType.Machinist:
                    HotkeyManager.Register("ShinraEx Job", Helpers.GetHotkey(Settings.MachinistTurretHotkey),
                                           Helpers.GetModkey(Settings.MachinistTurretHotkey),
                                           hk => Settings.MachinistTurret = Settings.MachinistTurret.Cycle("Turret", true));
                    break;
            }
        }

        public static void UnregisterHotkeys()
        {
            HotkeyManager.Unregister("ShinraEx Rotation");
            HotkeyManager.Unregister("ShinraEx Cooldown");
            HotkeyManager.Unregister("ShinraEx Tank");
            HotkeyManager.Unregister("ShinraEx Job");
        }

        #endregion

        #region CurrentClass

        private IRotation _myRotation;
        private IRotation MyRotation => _myRotation ?? (_myRotation = GetRotation(CurrentClass));

        private ClassJobType _currentClass;
        private ClassJobType CurrentClass
        {
            get
            {
                if (_currentClass == Core.Player.CurrentJob)
                {
                    return _currentClass;
                }
                _currentClass = Core.Player.CurrentJob;
                _myRotation = GetRotation(_currentClass);
                Logging.Write(Colors.Yellow, $@"[ShinraEx] Loading {_currentClass}...");
                RegisterClassHotkeys();
                return _currentClass;
            }
        }

        public sealed override ClassJobType[] Class => new[] { Core.Player.CurrentJob };

        private static IRotation GetRotation(ClassJobType classJob)
        {
            switch (classJob)
            {
                case ClassJobType.Arcanist:
                case ClassJobType.Archer:
                case ClassJobType.Conjurer:
                case ClassJobType.Gladiator:
                case ClassJobType.Lancer:
                case ClassJobType.Marauder:
                case ClassJobType.Pugilist:
                case ClassJobType.Rogue:
                case ClassJobType.Thaumaturge:
                    return new BasicClass();
                case ClassJobType.Astrologian:
                    return new Astrologian();
                case ClassJobType.Bard:
                    return new Bard();
                case ClassJobType.BlackMage:
                    return new BlackMage();
                case ClassJobType.Dancer:
                    return new Dancer();
                case ClassJobType.DarkKnight:
                    return new DarkKnight();
                case ClassJobType.Dragoon:
                    return new Dragoon();
                case ClassJobType.Gunbreaker:
                    return new Gunbreaker();
                case ClassJobType.Machinist:
                    return new Machinist();
                case ClassJobType.Monk:
                    return new Monk();
                case ClassJobType.Ninja:
                    return new Ninja();
                case ClassJobType.Paladin:
                    return new Paladin();
                case ClassJobType.RedMage:
                    return new RedMage();
                case ClassJobType.Samurai:
                    return new Samurai();
                case ClassJobType.Scholar:
                    return new Scholar();
                case ClassJobType.Summoner:
                    return new Summoner();
                case ClassJobType.Warrior:
                    return new Warrior();
                case ClassJobType.WhiteMage:
                    return new WhiteMage();
                default:
                    Logging.Write(Colors.OrangeRed, $@"[ShinraEx] {classJob} is not supported.");
                    return new Default();
            }
        }

        #endregion

        #region Behaviors

        public override Composite CombatBehavior
        {
            get
            {
                return new Decorator(r => Core.Player.HasTarget,
                                     new PrioritySelector(new Decorator(r => WorldManager.InPvP, new ActionRunCoroutine(ctx => MyRotation.CombatPVP())),
                                                          new Decorator(r => !WorldManager.InPvP, new ActionRunCoroutine(ctx => MyRotation.Combat()))));
            }
        }

        public override Composite CombatBuffBehavior
        {
            get { return new Decorator(r => Core.Player.HasTarget && !WorldManager.InPvP, new ActionRunCoroutine(ctx => MyRotation.CombatBuff())); }
        }

        public override Composite PullBehavior
        {
            get
            {
                return new Decorator(r => Core.Player.HasTarget,
                                     new PrioritySelector(new Decorator(r => WorldManager.InPvP, new ActionRunCoroutine(ctx => MyRotation.CombatPVP())),
                                                          new Decorator(r => !WorldManager.InPvP, new ActionRunCoroutine(ctx => MyRotation.Pull()))));
            }
        }

        public override Composite HealBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.Heal()); } }
        public override Composite PreCombatBuffBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.PreCombatBuff()); } }
        public override Composite RestBehavior { get { return new ActionRunCoroutine(ctx => Rest()); } }

        #endregion

        #region Rest

        private async Task<bool> Rest()
        {
            if (Settings.CrPaused == true)
            {
                Logging.Write(Colors.Yellow, @"[ShinraEx] Paused...");
                return true;
            }

            if (!BotManager.Current.IsAutonomous || WorldManager.InSanctuary || Core.Player.HasAura("Sprint") ||
                (!Settings.RestHealth || Core.Player.CurrentHealthPercent > Settings.RestHealthPct) &&
                (!Settings.RestEnergy || Helpers.CurrentEnergyPct > Settings.RestEnergyPct))
            {
                return false;
            }
            
            if (MovementManager.IsMoving) Navigator.PlayerMover.MoveStop();
            Logging.Write(Colors.Yellow, @"[ShinraEx] Resting...");
            return true;
        }

        #endregion

        #region Chocobo

        #region Summon

        public static async Task<bool> SummonChocobo()
        {
            if (Settings.CrPaused)
            {
                if (MovementManager.IsMoving)
                {
                    Navigator.PlayerMover.MoveStop();
                }

                Logging.Write(Colors.Yellow, @"[ShinraEx] Paused...");
                await Coroutine.Wait(10000, () => false);
                return false;
            }

            if (!Settings.SummonChocobo ||
                !BotManager.Current.IsAutonomous || 
                !ChocoboManager.CanSummon || 
                MovementManager.IsMoving ||
                ChocoboManager.Summoned)
            {
                return false;
            }
            ChocoboManager.Summon();
            await Coroutine.Wait(2000, () => ChocoboManager.Summoned);
            Logging.Write(Colors.Yellow, @"[ShinraEx] Summoning Chocobo...");

            if (!ChocoboManager.Summoned) return await SummonChocobo();
            return true;
        }

        #endregion

        #region Stance

        public static async Task<bool> ChocoboStance()
        {
            if (!Settings.SummonChocobo || !ChocoboManager.Summoned || Core.Player.IsMounted || ChocoboManager.Object == null)
                return false;

            if (Settings.ChocoboStanceDance)
            {
                if (ChocoboManager.Stance == CompanionStance.Healer &&
                    Core.Player.CurrentHealthPercent < Math.Min(100, Settings.ChocoboStanceDancePct + 10))
                {
                    return false;
                }

                if (Core.Player.CurrentHealthPercent < Settings.ChocoboStanceDancePct)
                {
                    ChocoboManager.HealerStance();
                    await Coroutine.Wait(1000, () => ChocoboManager.Stance == CompanionStance.Healer);
                    Logging.Write(Colors.Yellow, @"[ShinraEx] Chocobo Stance >>> Healer");
                    return true;
                }
            }

            switch (Settings.ChocoboStance)
            {
                case Stances.Free:
                    if (ChocoboManager.Stance == CompanionStance.Free) break;
                    ChocoboManager.FreeStance();
                    await Coroutine.Wait(1000, () => ChocoboManager.Stance == CompanionStance.Free);
                    Logging.Write(Colors.Yellow, @"[ShinraEx] Chocobo Stance >>> Free");
                    return true;
                case Stances.Attacker:
                    if (ChocoboManager.Stance == CompanionStance.Attacker) break;
                    ChocoboManager.AttackerStance();
                    await Coroutine.Wait(1000, () => ChocoboManager.Stance == CompanionStance.Attacker);
                    Logging.Write(Colors.Yellow, @"[ShinraEx] Chocobo Stance >>> Attacker");
                    return true;
                case Stances.Healer:
                    if (ChocoboManager.Stance == CompanionStance.Healer) break;
                    ChocoboManager.HealerStance();
                    await Coroutine.Wait(1000, () => ChocoboManager.Stance == CompanionStance.Healer);
                    Logging.Write(Colors.Yellow, @"[ShinraEx] Chocobo Stance >>> Healer");
                    return true;
                case Stances.Defender:
                    if (ChocoboManager.Stance == CompanionStance.Defender) break;
                    ChocoboManager.DefenderStance();
                    await Coroutine.Wait(1000, () => ChocoboManager.Stance == CompanionStance.Defender);
                    Logging.Write(Colors.Yellow, @"[ShinraEx] Chocobo Stance >>> Defender");
                    return true;
            }
            return false;
        }

        #endregion

        #endregion

        #region LastSpell

        private static Spell _lastSpell;
        public static Spell LastSpell {
            get => _lastSpell ?? (_lastSpell = new Spell());
            set => _lastSpell = value;
        }

        #endregion
    }
}