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

        public static decimal GetYearlyRate(int p_year)
        {
            return (HistoricData.OneTimeRate.TryGetValue(p_year, out decimal div)) ? div : FinancialConstants.DEFAULT_ONE_TIME_RATE;
        }

        public static decimal GetDividend(int p_year)
        {
            if (HistoricData.Dividend.TryGetValue(p_year, out decimal dividend))
            {
                return dividend;
            }
            else
            {
                var back = 1;
                while (!(HistoricData.Dividend.TryGetValue(p_year - back, out dividend)))
                {
                    back++;
                }
                return dividend + (back * SpeculativeData.ExpectedDividendsRaiseInEuro);
            }
        }

        public static decimal GetDividendAtYearsStart(int p_year, decimal p_ammount)
        {
            var grossDiv = p_ammount * Financial.GetDividend(p_year);

            return AdjustForTaxOnCapitalGains(grossDiv) / MonthlyStockQuotesFactory.Get(p_year).DividendDay;
        }

        public static decimal AdjustForTaxOnCapitalGains(decimal p_gross) => p_gross - (p_gross * FinancialConstants.TAX_ADJUSTMENT);

        public static decimal ProfitSharingStocks(int p_year)
        {
            return (HistoricData.ProfitSharingStocksLookup.TryGetValue(p_year, out decimal div)) ? div : 0m;
        }
    }
}