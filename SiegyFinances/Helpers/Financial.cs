using SiegyFinances.Factories;
using SiegyFinances.FinancialData;

namespace SiegyFinances.Helpers
{
    public static class Financial
    {
        public static decimal GetMonthlyRate(int year)
        {
            if (!HistoricData.MonthlyRate.TryGetValue(year, out decimal rate))
            {
                rate = GetMonthlyRate(year - 1);
                rate += rate * SpeculativeData.ExpectedPayRaiseInPercent;
            }

            return rate;
        }

        public static decimal GetYearlyRate(int year) => HistoricData.OneTimeRate(year);

        public static decimal GetDividend(int p_year)
        {
            var dividend = HistoricData.Dividend(p_year);
            if (dividend >= 0)
            {
                return dividend;
            }

            var back = 0;
            do
            {
                back++;
                dividend = HistoricData.Dividend(p_year - back);

            } while (dividend < 0);

            return dividend + (back  * SpeculativeData.ExpectedDividendsRaiseInEuro);
        }

        public static decimal GetDividendAtYearsStart(int p_year, decimal p_ammount)
        {
            var grossDiv = p_ammount * Financial.GetDividend(p_year);

            return AdjustForTaxOnCapitalGains(grossDiv) / MonthlyStockQuotesFactory.Get(p_year).DividendDay;
        }

        public static decimal AdjustForTaxOnCapitalGains(decimal p_gross) => p_gross - (p_gross * 0.26375m);
    }
}