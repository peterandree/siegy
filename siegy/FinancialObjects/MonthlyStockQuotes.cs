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

        public decimal February => _February;

        public decimal March => _March;

        public decimal April => _April;

        public decimal May => _May;

        public decimal June => _June;

        public decimal July => _July;

        public decimal August => _August;

        public decimal September => _September;

        public decimal October => _October;

        public decimal November => _November;

        public decimal December => _December;

        public decimal January => _January;

        public decimal DividendDay => _DividendDay;

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

        public IList<decimal> StockRatesListed() => StockRates().ToList();
    }
}