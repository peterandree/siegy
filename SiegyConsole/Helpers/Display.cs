using System;
using System.Globalization;

namespace SiegyConsole.Helpers
{
    //todo pk: changes to .net Core brought some regressions regarding specuial characters
    internal static class Display
    {
        private static NumberFormatInfo EuroFormat()
        {
            var cultureInfo = new CultureInfo("de-DE");
            cultureInfo.NumberFormat.CurrencySymbol = "Euro";

            return cultureInfo.NumberFormat;
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

        public static string ToCurrency(this decimal value, string cultureName)

        {
            CultureInfo currentCulture = new CultureInfo(cultureName);
            return string.Format(currentCulture, "{0:C}", value);
        }
    }
}