using SiegyFinances.FinancialObjects;
using SiegyFinances.Helpers;

namespace SiegyFinances.FinancialCalculations
{
    public static class CalculateReturns
    {
        public static InvestmentReturns Calculate(int p_endYear)
        {
            //var averageReturnOnInvest = new List<decimal>(); todo pk: show capital gains for every investment year

            var amount = 0m;
            var investedCapital = 0m;
            foreach (InvestmentYear currentYear in AllPossibleYearsForMe.AllYears())
            {
                if (currentYear.Year <= p_endYear)
                {
                    amount += currentYear.AccumulatedStocks(p_endYear);
                    investedCapital += currentYear.InvestedCapital();
                }
            }

            var stockValue = MonthlyStockQuoteCollection.Instance.GetMonthlyStockQuotes(p_endYear).January;
            var divPerStock = Financial.GetDividend(p_endYear);

            return new InvestmentReturns
            {
                Endyear = p_endYear,
                amount = amount,
                DivPerStock = divPerStock,
                StockValue = stockValue,
                InvestedCapital = investedCapital
            };
        }
    }
}