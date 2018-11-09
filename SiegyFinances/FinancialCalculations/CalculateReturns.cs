using SiegyFinances.FinancialObjects;
using SiegyFinances.Helpers;

namespace SiegyFinances.FinancialCalculations
{
    public static class CalculateReturns
    {
        public static InvestmentReturns Calculate(int p_endYear)
        {
            //var averageReturnOnInvest = new List<decimal>(); todo pk: show capital gains for every investment year

            var ammount = 0m;
            var investedCapital = 0m;
            foreach (InvestmentYear currentYear in AllPossibleYearsForMe.AllYears())
            {
                if (currentYear.Year <= p_endYear)
                {
                    ammount += currentYear.AccumulatedStocks(p_endYear);
                    investedCapital += currentYear.InvestedCapital();
                }
            }

            var stockValue = Factories.MonthlyStockQuotesFactory.Get(p_endYear).DividendDay;
            var divPerStock = Financial.GetDividend(p_endYear);

            return new InvestmentReturns
            {
                Endyear = p_endYear,
                Ammount = ammount,
                DivPerStock = divPerStock,
                StockValue = stockValue,
                InvestedCapital = investedCapital
            };
        }
    }
}