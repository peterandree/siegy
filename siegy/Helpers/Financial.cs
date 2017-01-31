using Siegy.Factories;
using Siegy.FinancialData;
using System.Collections.Generic;

namespace Siegy.Helpers
{
    internal static class Financial
    {
        public static decimal GetMonthlyRate(int year)
        {
            decimal rate;

            if (!HistoricData.MonthlyRate.TryGetValue(year, out rate))
            {
                rate = GetMonthlyRate(year - 1);
                rate += rate * SpeculativeData.ExpectedPayRaiseInPercent;
            }

            return rate;
        }

        public static decimal GetYearlyRate(int year)
        {
            return HistoricData.OneTimeRate(year);
        }

        public static decimal GetDividend(int p_year)
        {
            var dividend = HistoricData.Dividend(p_year);
            if (dividend >= 0)
            {
                return dividend;
            }

            int back = 0;
            do
            {
                back++;
                dividend = HistoricData.Dividend(p_year - back);
            } while (dividend < 0);

            return dividend + (back * SpeculativeData.ExpectedDividendsRaiseInEuro);
        }
    }
}