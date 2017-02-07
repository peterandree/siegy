using Siegy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.FinancialObjects
{
    public abstract class MonthlyStockQuotes : IMonthlyStockQuotes

    {
        protected decimal _February;
        protected decimal _March;
        protected decimal _April;
        protected decimal _May;
        protected decimal _June;
        protected decimal _July;
        protected decimal _August;
        protected decimal _September;
        protected decimal _October;
        protected decimal _November;
        protected decimal _December;
        protected decimal _January;
        protected decimal _DividendDay;

        public decimal February
        {
            get
            {
                return _February;
            }
        }

        public decimal March
        {
            get
            {
                return _March;
            }
        }

        public decimal April
        {
            get
            {
                return _April;
            }
        }

        public decimal May
        {
            get
            {
                return _May;
            }
        }

        public decimal June
        {
            get
            {
                return _June;
            }
        }

        public decimal July
        {
            get
            {
                return _July;
            }
        }

        public decimal August
        {
            get
            {
                return _August;
            }
        }

        public decimal September
        {
            get
            {
                return _September;
            }
        }

        public decimal October
        {
            get
            {
                return _October;
            }
        }

        public decimal November
        {
            get
            {
                return _November;
            }
        }

        public decimal December
        {
            get
            {
                return _December;
            }
        }

        public decimal January
        {
            get
            {
                return _January;
            }
        }

        public decimal DividendDay
        {
            get
            {
                return _DividendDay;
            }
        }

        public IEnumerable<decimal> StockRates()
        {
            //February to January
            yield return February;
            yield return March;
            yield return April;
            yield return May;
            yield return June;
            yield return July;
            yield return August;
            yield return September;
            yield return October;
            yield return November;
            yield return December;
            yield return January;
        }

        public IList<decimal> StockRatesListed()
        {
            return StockRates().ToList();
        }
    }
}