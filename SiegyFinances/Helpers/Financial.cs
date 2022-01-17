using SiegyFinances.FinancialData;
using SiegyFinances.FinancialObjects;

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

        public static decimal GetYearlyRate(int p_year) => HistoricData.OneTimeRate.TryGetValue(p_year, out decimal div) ? div : FinancialConstants.DEFAULT_ONE_TIME_RATE;

        public static decimal GetDividend(int p_year)
        {
            //Dividend is payed out for the previous year, so we have to calculate with the dividend, saved for the year after the stock buying year
            return HistoricData.Dividend.TryGetValue(p_year + 1, out decimal dividend) ? dividend : GetDividendRaisedInPercent(p_year);
        }

        public static decimal GetDividendRaisedInPercent(int p_year)
        {
            var targetYear = p_year + 1; //Dividend is payed out for the previous year, so we have to calculate with the dividend, saved for the year after the stock buying year

            var back = 1;
            decimal dividend;
            while (!HistoricData.Dividend.TryGetValue(targetYear - back, out dividend))
            {
                back++;
            }

            //compund interest formula would also work
            var raise = SpeculativeData.ExpectedDividendsRaiseInPercent;
            while (back-- > 0)
            {
                dividend += dividend * raise;
            }
            return dividend;
        }

        public static decimal GetDividendAtYearsStart(int p_year, decimal p_numberOfStocks) => AdjustForTaxOnCapitalGains(p_numberOfStocks * GetDividend(p_year), p_year) / MonthlyStockQuoteCollection.Instance.GetMonthlyStockQuotes(p_year).DividendDay;

        public static decimal AdjustForTaxOnCapitalGains(decimal p_gross, int p_year) => p_gross - (p_gross * FinancialConstants.TAX_ADJUSTMENT(p_year));

        public static decimal ProfitSharingStocks(int p_year) => HistoricData.ProfitSharingStocksLookup.TryGetValue(p_year, out decimal div) ? div : 0m;
    }
}