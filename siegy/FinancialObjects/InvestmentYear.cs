﻿using Siegy.Factories;
using Siegy.Helpers;
using Siegy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Siegy.FinancialObjects
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
                        ammount += Financial.GetDividendAtYearsStart(pTillYear, ammount);
                        ammount += StockBuysOverTwelveMonths / 3; //this used to happen in year 4, but changed to year 3 end of 2015 (email Fr 27.11.2015 16:56). Difference is ignored because of the low significance in this long term prediction
                        ammount += OneTimeBoughtStocks / 3;
                        return ammount;
                    }
                default:
                    {
                        ammount = AccumulatedStocks(pTillYear - 1);
                        ammount += Financial.GetDividendAtYearsStart(pTillYear, ammount);
                        return ammount;
                    }
            }
        }

        public decimal InvestedCapital() => (OneTimeInvest / 2) + MonthlyInvestRate * 12m;
    }
}