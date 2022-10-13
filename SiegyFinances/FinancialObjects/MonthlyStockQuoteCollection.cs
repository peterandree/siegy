using SiegyFinances.Factories;
using SiegyFinances.Interfaces;
using System;
using System.Collections.Generic;

namespace SiegyFinances.FinancialObjects
{
    public sealed class MonthlyStockQuoteCollection
    {
        private static readonly Lazy<MonthlyStockQuoteCollection> lazy =
            new Lazy<MonthlyStockQuoteCollection>(() => new MonthlyStockQuoteCollection());

        public static MonthlyStockQuoteCollection Instance { get { return lazy.Value; } }

        private MonthlyStockQuoteCollection()
        {
            //initialize years
            years = new Dictionary<int, IMonthlyStockQuotes>();

            var factory = new MonthlyStockQuotesFactory(2011);

            for (int i = 2011; i <= 2040; i++)
            {
                years.Add(i, factory.Get(i));
            }
        }

        private readonly Dictionary<int, IMonthlyStockQuotes> years;

        public IMonthlyStockQuotes GetMonthlyStockQuotes(int p_year)
        {
            return years[p_year];
        }
    }
}