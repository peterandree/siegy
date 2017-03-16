using System;
using System.Globalization;
using System.Threading;

namespace Siegy.Helpers
{
    internal static class Display
    {
        private static NumberFormatInfo EuroFormat()
        {
            var de = new CultureInfo("de-DE");
            Thread.CurrentThread.CurrentCulture = de;
            var localFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            // Replaces the default currency symbol with the
            // local currency symbol.
            localFormat.CurrencySymbol = "Euro";
            return localFormat;
        }

        public static void ConWriteLineFinancial(string p_line, decimal p_value)
        {
            Console.WriteLine(string.Format(p_line, p_value.ToString("c", EuroFormat())));
        }

        public static void ConWriteLineFinancial(string p_line, int p_jahr, decimal p_value)
        {
            Console.WriteLine(string.Format(p_line, p_jahr.ToString(), p_value.ToString("c", EuroFormat())));
        }

        public static void ConWriteLineNumber(string p_line, int p_jahr, decimal p_value)
        {
            Console.WriteLine(string.Format(p_line, p_jahr.ToString(), Math.Round(p_value, 2).ToString()));
        }
    }
}