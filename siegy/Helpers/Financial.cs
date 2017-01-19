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

        public static IList<decimal> GetMonthlyStockQuotes(int p_year)
        {
            var quotes = HistoricData.MonthlyStockRates(p_year);
            if (quotes != null && quotes.Count > 0)
            {
                return quotes;
            }

            int back = 0;
            do
            {
                back++;
                quotes = HistoricData.MonthlyStockRates(p_year - back);
            } while (quotes == null || quotes.Count == 0);

            var lastQuote = quotes[11];
            lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent * back);

            quotes = new List<decimal>();
            for (var i = 0; i <= 11; i++)
            {
                quotes.Add(lastQuote);
            }
            return quotes;
        }

        public static decimal GetStockQuoteAtDividendDay(int p_year)
        {
            var stockpriceAtDividendPayout = HistoricData.StockQuoteAtDividendDay(p_year);
            if (stockpriceAtDividendPayout < 0)
            {
                stockpriceAtDividendPayout = GetMonthlyStockQuotes(p_year)[11];
            }
            return stockpriceAtDividendPayout;
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