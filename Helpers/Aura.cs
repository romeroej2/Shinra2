using System.Linq;
using ff14bot;
using ff14bot.Objects;

namespace ShinraCo
{
    public static partial class Helpers
    {
        public static bool HasAura(this GameObject unit, string auraname, bool isMyAura = false, int msLeft = 0)
        {
            var unitasc = unit as Character;

            if (unit == null || unitasc == null) return false;

            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Name == auraname)
                : unitasc.CharacterAuras.Where(r => r.Name == auraname);

            return auras.Any(aura => aura.TimespanLeft.TotalMilliseconds >= msLeft);
        }

        public static bool HasAura(this GameObject unit, uint auraid, bool isMyAura = false, int msLeft = 0)
        {
            var unitasc = unit as Character;

            if (unit == null || unitasc == null) return false;

            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Id == auraid)
                : unitasc.CharacterAuras.Where(r => r.Id == auraid);

            return auras.Any(aura => aura.TimespanLeft.TotalMilliseconds >= msLeft);
        }

        public static bool HasDispellable(this GameObject unit)
        {
            var unitasc = unit as Character;

            if (unit == null || unitasc == null) return false;

            var auras = unitasc.CharacterAuras.Where(r => r.IsDebuff);

            return auras.Any(aura => aura.IsDispellable);
        }

        public static bool AuraExpiring(this GameObject unit, string auraname, bool isMyAura = false, int msLeft = 4000)
        {
            var unitasc = unit as Character;

            if (unit == null || unitasc == null) return false;

            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Name == auraname)
                : unitasc.CharacterAuras.Where(r => r.Name == auraname);

            return auras.Any(aura => aura.TimespanLeft.TotalMilliseconds <= msLeft);
        }

        public static bool AuraExpiring(this GameObject unit, uint auraid, bool isMyAura = false, int msLeft = 4000)
        {
            var unitasc = unit as Character;

            if (unit == null || unitasc == null) return false;

            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Id == auraid)
                : unitasc.CharacterAuras.Where(r => r.Id == auraid);

            return auras.Any(aura => aura.TimespanLeft.TotalMilliseconds <= msLeft);
        }
    }
}