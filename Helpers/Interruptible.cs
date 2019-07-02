using System.Collections.Generic;
using ff14bot.Objects;

namespace ShinraCo
{
    public static partial class Helpers
    {
        public static bool IsInterruptible(this GameObject unit)
        {
            return InterruptibleMobsIds.Contains(unit.NpcId);
        }

        public static bool IsInterruptibleSpell(this GameObject unit)
        {
            var unitAsCharacter = unit as Character;
            if (unitAsCharacter == null) return false;
            return unitAsCharacter.IsCasting && InterruptibleSpellIds.Contains(unitAsCharacter.CastingSpellId);
        }

        private static readonly HashSet<uint> InterruptibleSpellIds = new HashSet<uint>
        {
            308, 311, 313, 317, 331, 346, 399, 405, 426, 430, 476, 495, 497, 498, 499, 507, 516, 518, 520, 545, 547,
            553, 566, 579, 604, 917, 966, 968, 970, 971, 978, 1006, 1007, 1784, 4452, 4453, 4456, 4482, 4484, 4490,
            4498, 4507, 4531, 4532, 4657, 4700, 4701, 4706, 4708, 4939, 5150, 5166, 5167, 5168, 5195, 5197, 5302, 5303,
            5372, 5434, 5517, 5537, 5539, 5545, 5547,5549, 5551, 5552, 5556, 5557, 5561, 5615, 5619, 5630, 5788, 5794,
            5815, 5888, 5889, 5891, 5892
        };

        private static readonly HashSet<uint> InterruptibleMobsIds = new HashSet<uint>
        {
            113, 116, 117, 270, 275, 304, 305, 345, 353, 411, 560, 858, 865, 894, 1313, 1608, 1673, 1674, 1831, 2316,
            2317, 2318, 2319, 2320, 2518, 2681, 2715, 2749, 3376, 3477, 3488, 3494, 3533, 3568, 3571, 3601, 3602, 3603,
            3605, 3606, 3746, 4362, 4519, 4607, 4608, 4610, 4612, 4614, 4616, 4617, 4619, 4620, 4622, 4634, 4690, 4699,
            4700, 4701, 4713, 4720, 4724, 4797, 4798, 4800, 4802, 4803, 4804, 4805, 4808, 4810, 4811, 4812, 4813
        };
    }
}