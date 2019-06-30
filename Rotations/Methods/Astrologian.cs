using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Astrologian;

namespace ShinraCo.Rotations
{
    public sealed partial class Astrologian
    {
        private AstrologianSpells MySpells { get; } = new AstrologianSpells();

        #region Damage

        private async Task<bool> Malefic()
        {
            if (!ActionManager.HasSpell(MySpells.MaleficII.Name) && !StopDamage)
            {
                return await MySpells.Malefic.Cast();
            }
            return false;
        }

        private async Task<bool> MaleficII()
        {
            if (!ActionManager.HasSpell(MySpells.MaleficIII.Name) && !StopDamage)
            {
                return await MySpells.MaleficII.Cast();
            }
            return false;
        }

        private async Task<bool> MaleficIII()
        {
            if (!StopDamage)
            {
                return await MySpells.MaleficIII.Cast();
            }
            return false;
        }

        #endregion

        #region DoT

        private async Task<bool> Combust()
        {
            if (!ActionManager.HasSpell(MySpells.CombustII.Name) && !StopDots &&
                !Core.Player.CurrentTarget.HasAura(MySpells.Combust.Name, true, 4000))
            {
                return await MySpells.Combust.Cast();
            }
            return false;
        }

        private async Task<bool> CombustII()
        {
            if (!StopDots && !Core.Player.CurrentTarget.HasAura(MySpells.CombustII.Name, true, 4000))
            {
                return await MySpells.CombustII.Cast();
            }
            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> Gravity()
        {
            if (!StopDamage)
            {
                return await MySpells.Gravity.Cast();
            }
            return false;
        }

        private async Task<bool> EarthlyStar()
        {
            if (ShinraEx.Settings.AstrologianEarthlyStar)
            {
                var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;

                if (ShinraEx.Settings.RotationMode == Modes.Multi || Helpers.EnemiesNearTarget(8) >= count)
                {
                    return await MySpells.EarthlyStar.Cast();
                }
            }
            return false;
        }

        private async Task<bool> StellarDetonation()
        {
            if (ShinraEx.Settings.AstrologianStellarDetonation)
            {
                return await MySpells.StellarDetonation.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> Lightspeed()
        {
            if (ShinraEx.Settings.AstrologianLightspeed && ShinraEx.Settings.AstrologianPartyHeal)
            {
                if (Helpers.HealManager.Count(hm => hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianLightspeedPct) >=
                    ShinraEx.Settings.AstrologianLightspeedCount)
                {
                    return await MySpells.Lightspeed.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> Synastry()
        {
            if (ShinraEx.Settings.AstrologianPartyHeal && ShinraEx.Settings.AstrologianSynastry)
            {
                if (Helpers.HealManager.Count(hm => hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianSynastryPct) >=
                    ShinraEx.Settings.AstrologianSynastryCount)
                {
                    var target = Helpers.HealManager.FirstOrDefault(hm => hm.IsTank());

                    if (target != null)
                    {
                        return await MySpells.Synastry.Cast(target, false);
                    }
                }
            }
            return false;
        }

        private async Task<bool> TimeDilation()
        {
            if (ShinraEx.Settings.AstrologianPartyHeal && ShinraEx.Settings.AstrologianTimeDilation)
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.IsDPS() && IsBuffed(hm) || hm.IsTank() && hm.HasAura("The Bole"));

                if (target != null)
                {
                    return await MySpells.TimeDilation.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> CelestialOpposition()
        {
            if (ShinraEx.Settings.AstrologianCelestialOpposition && Core.Player.HasAura(MySpells.Role.LucidDreaming.Name))
            {
                return await MySpells.CelestialOpposition.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Heal

        private async Task<bool> UpdateHealing()
        {
            if (ShinraEx.Settings.AstrologianPartyHeal || ShinraEx.Settings.AstrologianDraw)
            {
                if (!await Helpers.UpdateHealManager())
                {
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> StopCasting()
        {
            if (ShinraEx.Settings.AstrologianInterruptOverheal && Core.Player.IsCasting)
            {
                var target = GameObjectManager.GetObjectByObjectId(Core.Player.SpellCastInfo.TargetId);
                var spellName = Core.Player.SpellCastInfo.Name;

                if (target != null)
                {
                    if (spellName == MySpells.Benefic.Name && target.CurrentHealthPercent >= ShinraEx.Settings.AstrologianBeneficPct + 10 ||
                        spellName == MySpells.BeneficII.Name && target.CurrentHealthPercent >= ShinraEx.Settings.AstrologianBeneficIIPct + 10)
                    {
                        var debugSetting = spellName == MySpells.Benefic.Name ? ShinraEx.Settings.AstrologianBeneficPct
                            : ShinraEx.Settings.AstrologianBeneficIIPct;
                        Helpers.Debug($@"Target HP: {target.CurrentHealthPercent}, Setting: {debugSetting}, Adjusted: {debugSetting + 10}");

                        Logging.Write(Colors.Yellow, $@"[ShinraEx] Interrupting >>> {spellName}");
                        ActionManager.StopCasting();
                        await Coroutine.Wait(500, () => !Core.Player.IsCasting);
                    }
                }
            }
            return false;
        }

        private async Task<bool> Benefic()
        {
            if (ShinraEx.Settings.AstrologianBenefic)
            {
                var target = ShinraEx.Settings.AstrologianPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianBeneficPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.AstrologianBeneficPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Benefic.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> BeneficII()
        {
            if (ShinraEx.Settings.AstrologianBeneficII)
            {
                var target = ShinraEx.Settings.AstrologianPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianBeneficIIPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.AstrologianBeneficIIPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.BeneficII.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> EssentialDignity()
        {
            if (ShinraEx.Settings.AstrologianEssDignity)
            {
                var target = ShinraEx.Settings.AstrologianPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianEssDignityPct)
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.AstrologianEssDignityPct ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.EssentialDignity.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> AspectedBenefic()
        {
            if (ShinraEx.Settings.AstrologianAspBenefic && SectActive)
            {
                var target = ShinraEx.Settings.AstrologianPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianAspBeneficPct &&
                                                               !hm.HasAura(MySpells.AspectedBenefic.Name, true))
                    : Core.Player.CurrentHealthPercent < ShinraEx.Settings.AstrologianAspBeneficPct &&
                      !Core.Player.HasAura(MySpells.AspectedBenefic.Name, true) ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.AspectedBenefic.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Helios()
        {
            if (ShinraEx.Settings.AstrologianHelios && ShinraEx.Settings.AstrologianPartyHeal && UseAoEHeals)
            {
                var count = Helpers.FriendsNearPlayer(ShinraEx.Settings.AstrologianHeliosPct);

                if (count > 2)
                {
                    return await MySpells.Helios.Cast();
                }
            }
            return false;
        }

        private async Task<bool> AspectedHelios()
        {
            if (ShinraEx.Settings.AstrologianAspHelios && ShinraEx.Settings.AstrologianPartyHeal && SectActive && UseAoEHeals &&
                !Core.Player.HasAura(MySpells.AspectedHelios.Name, true))
            {
                var count = Helpers.FriendsNearPlayer(ShinraEx.Settings.AstrologianAspHeliosPct);

                if (count > 2)
                {
                    return await MySpells.AspectedHelios.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Ascend()
        {
            if (ShinraEx.Settings.AstrologianAscend &&
                (ShinraEx.Settings.AstrologianSwiftcast && ActionManager.CanCast(MySpells.Role.Swiftcast.Name, Core.Player) ||
                 !Helpers.HealManager.Any(hm => hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianBeneficPct)))
            {
                var target = Helpers.RessManager.FirstOrDefault(pm => !pm.HasAura("Raise"));

                if (target != null)
                {
                    if (ShinraEx.Settings.AstrologianSwiftcast && ActionManager.CanCast(MySpells.Ascend.Name, target))
                    {
                        if (await MySpells.Role.Swiftcast.Cast(null, false))
                        {
                            await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Role.Swiftcast.Name));
                        }
                    }
                    return await MySpells.Ascend.Cast(target);
                }
            }
            return false;
        }

        #endregion

        #region Card

        private async Task<bool> DrawTargetted()
        {
            if (!HasCard || BuffShared && Helpers.HealManager.Any(IsBuffed))
            {
                return false;
            }

            var target = Core.Player as BattleCharacter;

            if (CardOffensive)
            {
                target = Helpers.HealManager.FirstOrDefault(hm => hm.IsDPS() && !IsBuffed(hm)) ?? Core.Player;
            }
            if (CardBole && !BuffShared)
            {
                target = Helpers.HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.HasAura("The Bole"));
            }
            if (CardSpire && !BuffShared)
            {
                target = Helpers.GoadManager.FirstOrDefault(gm => !gm.HasAura("The Spire"));
            }

            if (target != null)
            {
                return await MySpells.Draw.Cast(target);
            }
            return false;
        }

        private async Task<bool> SpreadTargetted()
        {
            if (SpreadOffensive && BuffShared && !Helpers.HealManager.Any(IsBuffed))
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.IsDPS()) ?? Core.Player;

                if (target != null)
                {
                    return await MySpells.Spread.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Draw()
        {
            if (!HasCard && (!BuffShared || !SpreadOffensive || Core.Player.InCombat))
            {
                return await MySpells.Draw.Cast();
            }
            return false;
        }

        private async Task<bool> Spread()
        {
            if (!HasSpread && CardOffensive && (!BuffShared || !Core.Player.InCombat))
            {
                return await MySpells.Spread.Cast();
            }
            return false;
        }

        private async Task<bool> RoyalRoad()
        {
            if (!BuffShared && CardSupport)
            {
                return await MySpells.RoyalRoad.Cast();
            }
            return false;
        }

        private async Task<bool> Redraw()
        {
            if (!CardOffensive && (BuffShared || !CardSupport))
            {
                return await MySpells.Redraw.Cast();
            }
            return false;
        }

        private async Task<bool> MinorArcana()
        {
            if (!HasArcana && !CardOffensive && (BuffShared || CardEwer))
            {
                return await MySpells.MinorArcana.Cast();
            }
            return false;
        }

        private async Task<bool> Undraw()
        {
            if (HasArcana || !ActionManager.HasSpell(MySpells.MinorArcana.Name))
            {
                if (!CardOffensive && (BuffShared || CardEwer))
                {
                    return await MySpells.Undraw.Cast();
                }
            }
            return false;
        }

        private async Task<bool> UndrawSpread()
        {
            if (HasSpread && !SpreadOffensive)
            {
                return await MySpells.UndrawSpread.Cast();
            }
            return false;
        }

        private async Task<bool> LadyOfCrowns()
        {
            if (ShinraEx.Settings.AstrologianDraw && CardLady)
            {
                var target = ShinraEx.Settings.AstrologianPartyHeal ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < 80)
                    : Core.Player.CurrentHealthPercent < 80 ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.LadyOfCrowns.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> LordOfCrowns()
        {
            if (CardLord)
            {
                return await MySpells.LordOfCrowns.Cast();
            }
            return false;
        }

        private async Task<bool> SleeveDraw()
        {
            if (ShinraEx.Settings.AstrologianSleeveDraw && !HasCard && (!HasSpread || !BuffShared))
            {
                return await MySpells.SleeveDraw.Cast();
            }
            return false;
        }

        #endregion

        #region Sect

        private async Task<bool> DiurnalSect()
        {
            if (ShinraEx.Settings.AstrologianSect == AstrologianSects.Diurnal ||
                ShinraEx.Settings.AstrologianSect == AstrologianSects.Nocturnal && !ActionManager.HasSpell(MySpells.NocturnalSect.Name))
            {
                if (!Core.Player.HasAura(MySpells.DiurnalSect.Name))
                {
                    return await MySpells.DiurnalSect.Cast();
                }
            }
            return false;
        }

        private async Task<bool> NocturnalSect()
        {
            if (ShinraEx.Settings.AstrologianSect == AstrologianSects.Nocturnal && !Core.Player.HasAura(MySpells.NocturnalSect.Name))
            {
                return await MySpells.NocturnalSect.Cast();
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> ClericStance()
        {
            if (ShinraEx.Settings.AstrologianClericStance)
            {
                return await MySpells.Role.ClericStance.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (ShinraEx.Settings.AstrologianProtect)
            {
                var target = ShinraEx.Settings.AstrologianPartyHeal
                    ? Helpers.HealManager.FirstOrDefault(hm => !hm.HasAura(MySpells.Role.Protect.Name) && hm.Type == GameObjectType.Pc)
                    : !Core.Player.HasAura(MySpells.Role.Protect.Name) ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Role.Protect.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> Esuna()
        {
            if (ShinraEx.Settings.AstrologianEsuna)
            {
                var target = ShinraEx.Settings.AstrologianPartyHeal ? Helpers.HealManager.FirstOrDefault(hm => hm.HasDispellable())
                    : Core.Player.HasDispellable() ? Core.Player : null;

                if (target != null)
                {
                    return await MySpells.Role.Esuna.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> LucidDreaming()
        {
            if (ShinraEx.Settings.AstrologianLucidDreaming && Core.Player.CurrentManaPercent < ShinraEx.Settings.AstrologianLucidDreamingPct)
            {
                return await MySpells.Role.LucidDreaming.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (ShinraEx.Settings.AstrologianPartyHeal && ShinraEx.Settings.AstrologianEyeForAnEye)
            {
                var target = Helpers.HealManager.FirstOrDefault(hm => hm.IsTank() &&
                                                                      hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianEyeForAnEyePct &&
                                                                      !hm.HasAura("Eye for an Eye"));

                if (target != null)
                {
                    return await MySpells.Role.EyeForAnEye.Cast(target, false);
                }
            }
            return false;
        }

        private async Task<bool> Largesse()
        {
            if (ShinraEx.Settings.AstrologianPartyHeal && ShinraEx.Settings.AstrologianLargesse)
            {
                if (Helpers.HealManager.Count(hm => hm.CurrentHealthPercent < ShinraEx.Settings.AstrologianLargessePct) >=
                    ShinraEx.Settings.AstrologianLargesseCount)
                {
                    return await MySpells.Role.Largesse.Cast(null, false);
                }
            }
            return false;
        }

        #endregion

        #region Custom

        private static bool IsBuffed(GameObject unit)
        {
            return unit.HasAura("The Balance") || unit.HasAura("The Arrow") || unit.HasAura("The Spear");
        }

        private static bool StopDamage => ShinraEx.Settings.AstrologianStopDamage && Core.Player.CurrentManaPercent <= ShinraEx.Settings.AstrologianStopDamagePct;
        private static bool StopDots => ShinraEx.Settings.AstrologianStopDots && Core.Player.CurrentManaPercent <= ShinraEx.Settings.AstrologianStopDotsPct;

        private static bool HasCard => Resource.Cards[0] != Resource.AstrologianCard.None;
        private static bool HasSpread => Resource.Cards[1] != Resource.AstrologianCard.None;
        private static bool HasArcana => Resource.Arcana != Resource.AstrologianCard.None;

        private static bool BuffShared => Resource.Buff == Resource.AstrologianCardBuff.Shared;

        private static bool CardLord => Resource.Arcana == Resource.AstrologianCard.LordofCrowns;
        private static bool CardLady => Resource.Arcana == Resource.AstrologianCard.LadyofCrowns;
        private static bool CardBole => Resource.Cards[0] == Resource.AstrologianCard.Bole;
        private static bool CardEwer => Resource.Cards[0] == Resource.AstrologianCard.Ewer;
        private static bool CardSpire => Resource.Cards[0] == Resource.AstrologianCard.Spire;
        private static bool CardSupport => Resource.Cards[0] == Resource.AstrologianCard.Ewer || Resource.Cards[0] == Resource.AstrologianCard.Spire;
        private static bool CardOffensive => Resource.Cards[0] == Resource.AstrologianCard.Balance || Resource.Cards[0] == Resource.AstrologianCard.Arrow ||
                                             Resource.Cards[0] == Resource.AstrologianCard.Spear;

        private static bool SpreadOffensive => Resource.Cards[1] == Resource.AstrologianCard.Balance || Resource.Cards[1] == Resource.AstrologianCard.Arrow ||
                                             Resource.Cards[1] == Resource.AstrologianCard.Spear;

        private bool UseAoEHeals => ShinraEx.LastSpell.Name != MySpells.Helios.Name && ShinraEx.LastSpell.Name != MySpells.AspectedHelios.Name;
        private bool SectActive => Core.Player.HasAura(MySpells.DiurnalSect.Name) || Core.Player.HasAura(MySpells.NocturnalSect.Name);

        #endregion
    }
}