using SiegyFinances.FinancialObjects;
using SiegyFinances.Helpers;
using System.Collections.Generic;

namespace SiegyFinances.FinancialCalculations
{
    public static class CalculateReturns
    {
        public static InvestmentReturns Calculate(int p_endYear)
        {
            decimal ammount;
            decimal divPerStock;
            decimal stockValue;
            decimal investedCapital;

            var averageReturnOnInvest = new List<decimal>();

            ammount = 0m;
            investedCapital = 0m;
            foreach (InvestmentYear currentYear in AllPossibleYearsForMe.AllYears())
            {
                if (currentYear.Year <= p_endYear)
                {
                    ammount += currentYear.AccumulatedStocks(p_endYear);
                    investedCapital += currentYear.InvestedCapital();
                }
            }

            stockValue = Factories.MonthlyStockQuotesFactory.Get(p_endYear).DividendDay;
            divPerStock = Financial.GetDividend(p_endYear);

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
