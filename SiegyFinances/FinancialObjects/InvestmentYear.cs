using SiegyFinances.Factories;
using SiegyFinances.Helpers;
using SiegyFinances.Interfaces;

namespace SiegyFinances.FinancialObjects
{
    public class InvestmentYear
    {
        public int Year { get; }

        private decimal MonthlyInvestRate { get; }

        private decimal StockBuysOverTwelveMonths { get; }

        private decimal OneTimeInvest { get; }

        private decimal OneTimeBoughtStocks { get; }

        private IMonthlyStockQuotes MonthlyStockprice { get; }

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

        public decimal AccumulatedStocks(int p_tillYear)
        {
            decimal numberOfStocks;

            switch (p_tillYear - Year)
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
                        numberOfStocks = AccumulatedStocks(p_tillYear - 1);
                        numberOfStocks += Financial.GetDividendAtYearsStart(p_tillYear, numberOfStocks);
                        numberOfStocks += StockBuysOverTwelveMonths / 3; //this used to happen in year 4, but changed to year 3 end of 2015 (email Fr 27.11.2015 16:56). Difference is ignored because of the low significance in this long term prediction
                        numberOfStocks += OneTimeBoughtStocks / 3;
                        return numberOfStocks;
                    }
                default:
                    {
                        numberOfStocks = AccumulatedStocks(p_tillYear - 1);
                        numberOfStocks += Financial.GetDividendAtYearsStart(p_tillYear, numberOfStocks);
                        return numberOfStocks;
                    }
            }
        }

        public decimal InvestedCapital() => (OneTimeInvest / 2) + (MonthlyInvestRate * 12m);
    }
}