using ff14bot;
using ff14bot.Objects;

namespace ShinraCo
{
    public static class Constants
    {
        internal static LocalPlayer Me => Core.Me;
        internal static GameObject Target => Core.Player.CurrentTarget;
        internal static GameObject Pet => Core.Me.Pet;
    }
}