using Siegy.FinancialData;
using Siegy.FinancialData.Years;
using Siegy.FinancialObjects;
using Siegy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.Factories
{
    internal class MonthlyStockQuotesFactory
    {
        public static IMonthlyStockQuotes Get(int p_year)
        {
            var lastAtLeastPartiallyKnownYear = 2017;

            switch (p_year)
            {
                case 2011:
                    {
                        return new MonthlyStockQuotes2011();
                    }
                case 2012:
                    {
                        return new MonthlyStockQuotes2012();
                    }
                case 2013:
                    {
                        return new MonthlyStockQuotes2013();
                    }
                case 2014:
                    {
                        return new MonthlyStockQuotes2014();
                    }
                case 2015:
                    {
                        return new MonthlyStockQuotes2015();
                    }
                case 2016:
                    {
                        return new MonthlyStockQuotes2016();
                    }
                case 2017:
                    {
                        return new MonthlyStockQuotes2017();
                    }
                default:
                    {
                        var lastKnownQuotes = Get(lastAtLeastPartiallyKnownYear);

                        var lastQuote = lastKnownQuotes.January;
                        lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent * (p_year - lastAtLeastPartiallyKnownYear));
                        return new MonthlyStockQuotesFuture(lastQuote);
                    }
            }
        }
    }
}