using Siegy.FinancialObjects;
using Siegy.Interfaces;
using System;
using System.Collections.Generic;

namespace Siegy
{
    public static class CalculateRetirement
    {
        public static void Main()
        {
            Calculate();
        }

        public static void Calculate()
        {
            decimal ammount;
            const int endyear = 2040;
            decimal divperstock;
            decimal stockValue;
            decimal investedCapital;

            ammount = 0m;
            investedCapital = 0m;
            foreach (InvestmentYear currentYear in AllYears())
            {
                ammount += currentYear.AccumulatedStocks(endyear);
                investedCapital += currentYear.InvestedCapital();
            }

            stockValue = Factories.MonthlyStockQuotesFactory.Get(endyear).DividendDay;
            divperstock = Helpers.Financial.GetDividend(endyear);

            Console.ForegroundColor = ConsoleColor.White;

            Helpers.Display.ConWriteLineFinancial("Gesamtinvestment: {0}", investedCapital);

            Helpers.Display.ConWriteLineNumber("Anzahl der Aktien im Jahr {0}: {1}", endyear, ammount);

            Helpers.Display.ConWriteLineFinancial("Wert einer Aktie im Jahr {0}: {1}", endyear, stockValue);
            Helpers.Display.ConWriteLineFinancial("Gesamtwert der Aktien im Jahr {0}: {1}", endyear, ammount * stockValue);

            Helpers.Display.ConWriteLineFinancial("Geschätze Dividende pro Aktie im Jahr {0}: {1}", endyear, divperstock);

            Helpers.Display.ConWriteLineFinancial("Geschätze Dividendenzahlungen im Jahr {0}: {1}", endyear, ammount * divperstock);

            Console.WriteLine("Press a key to continue...");
            Console.ReadKey(true);
            // True stops it from showing the pressed key
        }

        private static IEnumerable<InvestmentYear> AllYears()
        {
            yield return new InvestmentYear(2011);
            yield return new InvestmentYear(2012);
            yield return new InvestmentYear(2014);
            yield return new InvestmentYear(2015);
            yield return new InvestmentYear(2016);
            yield return new InvestmentYear(2017);
            yield return new InvestmentYear(2018);
            yield return new InvestmentYear(2019);
            yield return new InvestmentYear(2020);
            yield return new InvestmentYear(2021);
            yield return new InvestmentYear(2022);
            yield return new InvestmentYear(2023);
            yield return new InvestmentYear(2023);
            yield return new InvestmentYear(2025);
            yield return new InvestmentYear(2026);
            yield return new InvestmentYear(2027);
            yield return new InvestmentYear(2028);
            yield return new InvestmentYear(2029);
            yield return new InvestmentYear(2030);
            yield return new InvestmentYear(2031);
            yield return new InvestmentYear(2032);
            yield return new InvestmentYear(2033);
            yield return new InvestmentYear(2033);
            yield return new InvestmentYear(2035);
            yield return new InvestmentYear(2036);
            yield return new InvestmentYear(2037);
            yield return new InvestmentYear(2038);
            yield return new InvestmentYear(2039);
            yield return new InvestmentYear(2040);
        }
    }
}