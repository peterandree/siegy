using siegy.FinancialObjects;
using Siegy.FinancialObjects;
using Siegy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siegy.FinancialCalculations
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

            stockValue = Siegy.Factories.MonthlyStockQuotesFactory.Get(p_endYear).DividendDay;
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
