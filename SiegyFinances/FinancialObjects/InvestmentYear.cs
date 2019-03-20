using SiegyFinances.Factories;
using SiegyFinances.Helpers;
using SiegyFinances.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SiegyFinances.FinancialObjects
{
    public class InvestmentYear
    {
        public int Year { get; }

        private decimal MonthlyInvestRate { get; set; }

        private decimal StockBuysOverTwelveMonths { get; set; }

        private decimal OneTimeInvest { get; set; }

        private decimal OneTimeBoughtStocks { get; set; }

        private IMonthlyStockQuotes MonthlyStockprice { get; set; }

        public InvestmentYear(int pYear)
        {
            Year = pYear;
            MonthlyInvestRate = Financial.GetMonthlyRate(Year);
            OneTimeInvest = Financial.GetYearlyRate(Year);
            MonthlyStockprice = MonthlyStockQuotesFactory.Get(Year);
            OneTimeBoughtStocks = OneTimeInvest / MonthlyStockprice.February;

            foreach (var quote in MonthlyStockprice.StockRates())
            {
                StockBuysOverTwelveMonths += MonthlyInvestRate / quote;
            }
        }

        public decimal AccumulatedStocks(int pTillYear)
        {
            decimal numberOfStocks;

            switch (pTillYear - Year)
            {
                case 0:
                    {
                        numberOfStocks = OneTimeBoughtStocks;
                        numberOfStocks += StockBuysOverTwelveMonths;
                        numberOfStocks += Financial.ProfitSharingStocks(Year);
                        return numberOfStocks;
                    }
                case 3:
                    {
                        numberOfStocks = AccumulatedStocks(pTillYear - 1);
                        numberOfStocks += Financial.GetDividendAtYearsStart(pTillYear, numberOfStocks);
                        numberOfStocks += StockBuysOverTwelveMonths / 3; //this used to happen in year 4, but changed to year 3 end of 2015 (email Fr 27.11.2015 16:56). Difference is ignored because of the low significance in this long term prediction
                        numberOfStocks += OneTimeBoughtStocks / 3;
                        return numberOfStocks;
                    }
                default:
                    {
                        numberOfStocks = AccumulatedStocks(pTillYear - 1);
                        numberOfStocks += Financial.GetDividendAtYearsStart(pTillYear, numberOfStocks);
                        return numberOfStocks;
                    }
            }
        }

        public decimal InvestedCapital() => (OneTimeInvest / 2) + MonthlyInvestRate * 12m;
    }
}