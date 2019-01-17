using SiegyFinances.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegyFinances.FinancialObjects
{
    public class MonthlyStockQuotes : IMonthlyStockQuotes
    {
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public decimal January { get; set; }
        public decimal DividendDay { get; set; }

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

        public void UpdateStockRatedListed(int monthNumber, decimal lastKnownQuote)
        {
            StockMonth mon = (StockMonth)Enum.ToObject(typeof(StockMonth), monthNumber);
            switch (mon)
            {
                case StockMonth.Feb:
                    February = lastKnownQuote;
                    break;

                case StockMonth.Mar:
                    March = lastKnownQuote;
                    break;

                case StockMonth.Apr:
                    April = lastKnownQuote;
                    break;

                case StockMonth.May:
                    May = lastKnownQuote;
                    break;

                case StockMonth.Jun:
                    June = lastKnownQuote;
                    break;

                case StockMonth.Jul:
                    July = lastKnownQuote;
                    break;

                case StockMonth.Sep:
                    September = lastKnownQuote;
                    break;

                case StockMonth.Oct:
                    October = lastKnownQuote;
                    break;

                case StockMonth.Nov:
                    November = lastKnownQuote;
                    break;

                case StockMonth.Dec:
                    December = lastKnownQuote;
                    break;

                case StockMonth.Jan:
                    January = lastKnownQuote;
                    break;
            }
        }

        //todo pk: move that elsewhere
        public enum StockMonth
        {
            Feb = 0,
            Mar = 1,
            Apr = 2,
            May = 3,
            Jun = 4,
            Jul = 5,
            Aug = 6,
            Sep = 7,
            Oct = 8,
            Nov = 9,
            Dec = 10,
            Jan = 11
        }
    }
}