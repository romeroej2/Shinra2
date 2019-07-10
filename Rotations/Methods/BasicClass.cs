using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;

namespace ShinraCo.Rotations
{
    public sealed partial class BasicClass
    {
        private BasicClassSpells MySpells { get; } = new BasicClassSpells();

        #region Arcanist

        private async Task<bool> Ruin()
        {
            return await MySpells.Arcanist.Ruin.Cast();
        }

        private async Task<bool> Bio()
        {
            if (!ActionManager.HasSpell(MySpells.Arcanist.BioII.Name) &&
                !Core.Player.CurrentTarget.HasAura(MySpells.Arcanist.Bio.Name, true, 3000))
            {
                return await MySpells.Arcanist.Bio.Cast();
            }
            return false;
        }

        private async Task<bool> Summon()
        {
            if (ShinraEx.Settings.SummonerPet == SummonerPets.None || ShinraEx.Settings.SummonerPet == SummonerPets.Titan &&
                ActionManager.HasSpell(MySpells.Arcanist.SummonII.Name))
            {
                return false;
            }

            if (PetManager.ActivePetType != PetType.Emerald_Carbuncle)
            {
                if (ShinraEx.Settings.SummonerSwiftcast && ActionManager.CanCast(MySpells.Arcanist.Summon.Name, Core.Player))
                {
                    if (await MySpells.Arcanist.Role.Swiftcast.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Arcanist.Role.Swiftcast.Name));
                    }
                }
                return await MySpells.Arcanist.Summon.Cast();
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (ShinraEx.Settings.SummonerPhysick)
            {
                if (Core.Player.CurrentHealthPercent < ShinraEx.Settings.SummonerPhysickPct)
                {
                    return await MySpells.Arcanist.Physick.Cast();
                }
                if (PetExists && Core.Player.Pet.CurrentHealthPercent < ShinraEx.Settings.SummonerPhysickPct)
                {
                    return await MySpells.Arcanist.Physick.Cast(Core.Player.Pet);
                }
            }
            return false;
        }

        private async Task<bool> EnergyDrain()
        {
            return await MySpells.Arcanist.EnergyDrain.Cast();
        }

        private async Task<bool> Miasma()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Arcanist.Miasma.Name, true, 4000))
            {
                return await MySpells.Arcanist.Miasma.Cast();
            }
            return false;
        }

        private async Task<bool> SummonII()
        {
            if (ShinraEx.Settings.SummonerPet == SummonerPets.Titan && PetManager.ActivePetType != PetType.Topaz_Carbuncle)
            {
                if (ShinraEx.Settings.SummonerSwiftcast && ActionManager.CanCast(MySpells.Arcanist.SummonII.Name, Core.Player))
                {
                    if (await MySpells.Arcanist.Role.Swiftcast.Cast(null, false))
                    {
                        await Coroutine.Wait(3000, () => ActionManager.CanCast(MySpells.Arcanist.SummonII.Name, Core.Player));
                    }
                }
                return await MySpells.Arcanist.SummonII.Cast();
            }
            return false;
        }

        private async Task<bool> BioII()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Arcanist.BioII.Name, true, 3000))
            {
                return await MySpells.Arcanist.BioII.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> HeavyShot()
        {
            return await MySpells.Archer.HeavyShot.Cast();
        }

        private async Task<bool> StraightShot()
        {
            if (!Core.Player.HasAura(MySpells.Archer.StraightShot.Name, true, 4000) || Core.Player.HasAura("Straighter Shot"))
            {
                return await MySpells.Archer.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> RagingStrikes()
        {
            if (ShinraEx.Settings.BardRagingStrikes)
            {
                return await MySpells.Archer.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> VenomousBite()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Archer.VenomousBite.Name, true, 4000))
            {
                return await MySpells.Archer.VenomousBite.Cast();
            }
            return false;
        }

        private async Task<bool> MiserysEnd()
        {
            return await MySpells.Archer.MiserysEnd.Cast();
        }

        private async Task<bool> Bloodletter()
        {
            return await MySpells.Archer.Bloodletter.Cast();
        }

        #endregion

        #region Conjurer

        private async Task<bool> Stone()
        {
            if (!ActionManager.HasSpell(MySpells.Conjurer.StoneII.Name))
            {
                return await MySpells.Conjurer.Stone.Cast();
            }
            return false;
        }

        private async Task<bool> StoneII()
        {
            return await MySpells.Conjurer.StoneII.Cast();
        }

        private async Task<bool> Aero()
        {
            if (!ActionManager.HasSpell(MySpells.Conjurer.AeroII.Name) &&
                !Core.Player.CurrentTarget.HasAura(MySpells.Conjurer.Aero.Name, true, 3000))
            {
                return await MySpells.Conjurer.Aero.Cast();
            }
            return false;
        }

        private async Task<bool> AeroII()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Conjurer.AeroII.Name, true, 3000))
            {
                return await MySpells.Conjurer.AeroII.Cast();
            }
            return false;
        }

        private async Task<bool> Cure()
        {
            if (Core.Player.CurrentHealthPercent < 50)
            {
                return await MySpells.Conjurer.Cure.Cast(Core.Player);
            }
            return false;
        }

        private async Task<bool> CureII()
        {
            if (Core.Player.CurrentHealthPercent < 40)
            {
                return await MySpells.Conjurer.CureII.Cast(Core.Player);
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> FastBlade()
        {
            return await MySpells.Gladiator.FastBlade.Cast();
        }

        private async Task<bool> FightOrFlight()
        {
            if (ShinraEx.Settings.PaladinFightOrFlight)
            {
                if (Core.Player.TargetDistance(5, false))
                {
                    return await MySpells.Gladiator.FightOrFlight.Cast();
                }
            }
            return false;
        }

        private async Task<bool> RiotBlade()
        {
            if (ActionManager.LastSpell.Name == MySpells.Gladiator.FastBlade.Name && Core.Player.CurrentManaPercent < 40)
            {
                return await MySpells.Gladiator.RiotBlade.Cast();
            }
            return false;
        }


        #endregion

        #region Lancer

        private async Task<bool> TrueThrust()
        {
            return await MySpells.Lancer.TrueThrust.Cast();
        }

        private async Task<bool> VorpalThrust()
        {
            if (ActionManager.LastSpell.Name == MySpells.Lancer.TrueThrust.Name)
            {
                return await MySpells.Lancer.VorpalThrust.Cast();
            }
            return false;
        }

        private async Task<bool> HeavyThrust()
        {
            if (ActionManager.LastSpell.Name != MySpells.Lancer.TrueThrust.Name &&
                !Core.Player.HasAura(MySpells.Lancer.HeavyThrust.Name, true, 5000))
            {
                return await MySpells.Lancer.HeavyThrust.Cast();
            }
            return false;
        }

        private async Task<bool> LifeSurge()
        {
            if (ActionManager.LastSpell.Name == MySpells.Lancer.VorpalThrust.Name)
            {
                return await MySpells.Lancer.LifeSurge.Cast();
            }
            return false;
        }

        private async Task<bool> FullThrust()
        {
            if (ActionManager.LastSpell.Name == MySpells.Lancer.VorpalThrust.Name)
            {
                return await MySpells.Lancer.FullThrust.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            return await MySpells.Lancer.BloodForBlood.Cast();
        }

        #endregion

        #region Marauder

        private async Task<bool> HeavySwing()
        {
            return await MySpells.Marauder.HeavySwing.Cast();
        }

        private async Task<bool> SkullSunder()
        {
            if (ActionManager.LastSpell.Name == MySpells.Marauder.HeavySwing.Name)
            {
                return await MySpells.Marauder.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Berserk()
        {
            return await MySpells.Marauder.Berserk.Cast();
        }

        private async Task<bool> Overpower()
        {
            if (ShinraEx.Settings.RotationMode != Modes.Single && Core.Player.CurrentTPPercent > 30)
            {
                return await MySpells.Marauder.Overpower.Cast();
            }
            return false;
        }

        private async Task<bool> Maim()
        {
            if (ActionManager.LastSpell.Name == MySpells.Marauder.HeavySwing.Name && !Core.Player.CurrentTarget.HasAura(819))
            {
                return await MySpells.Marauder.Maim.Cast();
            }
            return false;
        }

        private async Task<bool> ButchersBlock()
        {
            if (ActionManager.LastSpell.Name == MySpells.Marauder.SkullSunder.Name)
            {
                return await MySpells.Marauder.ButchersBlock.Cast();
            }
            return false;
        }

        private async Task<bool> StormsPath()
        {
            if (ActionManager.LastSpell.Name == MySpells.Marauder.Maim.Name)
            {
                return await MySpells.Marauder.StormsPath.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Bootshine()
        {
            return await MySpells.Pugilist.Bootshine.Cast();
        }

        private async Task<bool> TrueStrike()
        {
            if (Core.Player.HasAura(108))
            {
                return await MySpells.Pugilist.TrueStrike.Cast();
            }
            return false;
        }

        private async Task<bool> SnapPunch()
        {
            if (Core.Player.HasAura(109))
            {
                return await MySpells.Pugilist.SnapPunch.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            return await MySpells.Pugilist.InternalRelease.Cast();
        }

        private async Task<bool> FistsOfEarth()
        {
            if (!Core.Player.HasAura(MySpells.Pugilist.FistsOfEarth.Name))
            {
                return await MySpells.Pugilist.FistsOfEarth.Cast();
            }
            return false;
        }

        private async Task<bool> TwinSnakes()
        {
            if (Core.Player.HasAura(108) && !Core.Player.HasAura(MySpells.Pugilist.TwinSnakes.Name, true, 3000))
            {
                return await MySpells.Pugilist.TwinSnakes.Cast();
            }
            return false;
        }

        #endregion

        #region Rogue

        private async Task<bool> SpinningEdge()
        {
            return await MySpells.Rogue.SpinningEdge.Cast();
        }

        private async Task<bool> ShadeShift()
        {
            if (Core.Player.CurrentHealthPercent < 50)
            {
                return await MySpells.Rogue.ShadeShift.Cast();
            }
            return false;
        }

        private async Task<bool> GustSlash()
        {
            if (ActionManager.LastSpell.Name == MySpells.Rogue.SpinningEdge.Name)
            {
                return await MySpells.Rogue.GustSlash.Cast();
            }
            return false;
        }

        private async Task<bool> Assassinate()
        {
            return await MySpells.Rogue.Assassinate.Cast();
        }

        private async Task<bool> Mug()
        {
            return await MySpells.Rogue.Mug.Cast();
        }

        private async Task<bool> AeolianEdge()
        {
            if (ActionManager.LastSpell.Name == MySpells.Rogue.GustSlash.Name)
            {
                return await MySpells.Rogue.AeolianEdge.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private bool AstralFire => ActionResourceManager.BlackMage.AstralStacks > 0 &&
                                   ShinraEx.LastSpell.Name != MySpells.Thaumaturge.Transpose.Name;

        private async Task<bool> Blizzard()
        {
            return await MySpells.Thaumaturge.Blizzard.Cast();
        }

        private async Task<bool> Fire()
        {
            if (AstralFire || Core.Player.CurrentManaPercent > 80)
            {
                return await MySpells.Thaumaturge.Fire.Cast();
            }
            return false;
        }

        private async Task<bool> Transpose()
        {
            if (AstralFire && Core.Player.CurrentManaPercent < 20)
            {
                return await MySpells.Thaumaturge.Transpose.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Scathe()
        {
            if (MovementManager.IsMoving && Core.Player.CurrentManaPercent > 20)
            {
                return await MySpells.Thaumaturge.Scathe.Cast();
            }
            return false;
        }

        private async Task<bool> FireIII()
        {
            if (!AstralFire && Core.Player.CurrentManaPercent > 80 || AstralFire && Core.Player.HasAura(165))
            {
                return await MySpells.Thaumaturge.FireIII.Cast();
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (Core.Player.CurrentHealthPercent < 50)
            {
                return await MySpells.Lancer.Role.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Drain()
        {
            if (Core.Player.CurrentHealthPercent < 50 || Core.Player.CurrentHealthPercent < ShinraEx.Settings.BlackMageDrainPct)
            {
                return await MySpells.Thaumaturge.Role.Drain.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static bool PetExists => Core.Player.Pet != null;

        #endregion
    }
}