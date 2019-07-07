using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;

namespace ShinraCo
{
    public static partial class Helpers
    {
        public static int AoECount => ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;

        public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> dic, Func<TValue, bool> predicate)
        {
            var keys = dic.Keys.Where(k => predicate(dic[k])).ToList();
            foreach (var key in keys)
                dic.Remove(key);
        }

        private static readonly HashSet<ClassJobType> ManaJobs = new HashSet<ClassJobType>
        {
            ClassJobType.Arcanist,
            ClassJobType.Astrologian,
            ClassJobType.Conjurer,
            ClassJobType.RedMage,
            ClassJobType.Scholar,
            ClassJobType.Summoner,
            ClassJobType.BlackMage,
            ClassJobType.Thaumaturge,
            ClassJobType.WhiteMage
        };
        
        public static float CurrentEnergyPct => Core.Player.CurrentManaPercent;

        private static readonly string VersionPath = Path.Combine(Environment.CurrentDirectory, @"Routines\Shinra2\Properties\Version.txt");

        public static string GetLocalVersion()
        {
            if (!File.Exists(VersionPath)) { return null; }
            try
            {
                return File.ReadAllText(VersionPath);
            }
            catch { return null; }
        }

#if RB_CN
        public static readonly bool CNVersion = true;
#else
        public static readonly bool CNVersion = false;
#endif

        public static Keys GetHotkey(Keys number)
        {
            return (Keys)((int)number & 0x0000FFFF);
        }

        public static ModifierKeys GetModkey(Keys number)
        {
            var key = (Keys)((int)number & 0xFFFF0000);
            return (ModifierKeys)Enum.Parse(typeof(ModifierKeys), key.ToString());
        }

        public static void Debug(string msg)
        {
            if (ShinraEx.Settings.DisableDebug) return;
            Logging.Write(Colors.OrangeRed, $@"[ShinraEx] DEBUG - {msg}");
        }

        private static void DisplayToast(string msg, int duration = 1000)
        {
            if (ShinraEx.Settings.RotationMessages)
            {
                Core.OverlayManager.AddToast(() => msg, TimeSpan.FromMilliseconds(duration), Colors.GreenYellow, Color.FromRgb(0, 0, 0),
                    new FontFamily("Agency FB"));
            }
        }

        public static T Cycle<T>(this T src, string name, bool skip = false)
        {
            var arr = (T[])Enum.GetValues(src.GetType());
            var i = Array.IndexOf(arr, src) + 1;
            var next = arr.Length == i ? (skip ? arr[1] : arr[0]) : arr[i];

            DisplayToast($@"ShinraEx {name} >>> {next}");
            Logging.Write(Colors.Yellow, $@"[ShinraEx] {name} >>> {next}");
            return next;
        }
    }
}