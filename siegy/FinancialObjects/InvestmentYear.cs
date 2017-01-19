using Siegy.Helpers;
using System.Collections.Generic;

namespace Siegy.FinancialObjects
{
    public class InvestmentYear
    {
        public int Year { get; }

        private decimal MonthlyInvestRate { get; set; }

        private decimal StockBuysOverTwelveMonths { get; set; }

        private decimal OneTimeInvest { get; set; }

        private decimal OneTimeBoughtStocks { get; set; }

        private IList<decimal> MonthlyStockprice { get; set; }

        public InvestmentYear(int pYear)
        {
            Year = pYear;
            MonthlyInvestRate = Financial.GetMonthlyRate(Year);
            OneTimeInvest = Financial.GetYearlyRate(Year);
            MonthlyStockprice = Financial.GetMonthlyStockQuotes(Year);
            OneTimeBoughtStocks = OneTimeInvest / MonthlyStockprice[0];

            for (int i = 0; i <= 11; i++)
            {
                StockBuysOverTwelveMonths += MonthlyInvestRate / MonthlyStockprice[i];
            }
        }

        public decimal AccumulatedStocks(int pTillYear)
        {
            decimal ammount;

            switch (pTillYear - Year)
            {
                case 0:
                    {
                        ammount = OneTimeBoughtStocks;
                        ammount += StockBuysOverTwelveMonths;
                        ammount += FinancialData.HistoricData.ProfitSharingStocks(Year);
                        return ammount;
                    }
                case 3:
                    {
                        ammount = AccumulatedStocks(pTillYear - 1);
                        ammount += GetDividendAtYearsStart(pTillYear, ammount);
                        ammount += StockBuysOverTwelveMonths / 3; //this used to happen in year 4, but changed to year 3 end of 2015 (email Fr 27.11.2015 16:56). Difference is ignored because of the low significance in this long term prediction
                        ammount += OneTimeBoughtStocks / 3;
                        return ammount;
                    }
                default:
                    {
                        ammount = AccumulatedStocks(pTillYear - 1);
                        ammount += GetDividendAtYearsStart(pTillYear, ammount);
                        return ammount;
                    }
            }
        }

        private static decimal GetDividendAtYearsStart(int p_year, decimal p_ammount)
        {
            var grossDiv = p_ammount * Financial.GetDividend(p_year);

            return (grossDiv - (grossDiv * 0.26375m)) / Financial.GetStockQuoteAtDividendDay(p_year);
        }

        public decimal InvestedCapital()
        {
            return OneTimeInvest + MonthlyInvestRate * 12m;
        }
    }
}