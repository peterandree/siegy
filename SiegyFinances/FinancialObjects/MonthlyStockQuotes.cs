using SiegyFinances.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiegyFinances.FinancialObjects
{
    public class MonthlyStockQuotes : IMonthlyStockQuotes
    {
        public decimal February { get;private set; }
        public decimal March { get; private set; }
        public decimal April { get; private set; }
        public decimal May { get; private set; }
        public decimal June { get; private set; }
        public decimal July { get; private set; }
        public decimal August { get; private set; }
        public decimal September { get; private set; }
        public decimal October { get; private set; }
        public decimal November { get; private set; }
        public decimal December { get; private set; }
        public decimal January { get; private set; }
        public decimal DividendDay { get;private set; }


        private MonthlyStockQuotes()
        {

        }

        public MonthlyStockQuotes(MonthContainer months)
        {
            February = months.February;
            March = months.March;
            April = months.April;
            May = months.May;
            June = months.June;
            July = months.July;
            August = months.August;
            September = months.September;
            October = months.October;
            November = months.November;
            December = months.December;
            January = months.January;
            DividendDay = months.DividendDay;

        }

        public MonthlyStockQuotes(decimal p_guess)
        {
            DividendDay = p_guess;
            February = p_guess;
            March = p_guess;
            April = p_guess;
            May = p_guess;
            June = p_guess;
            July = p_guess;
            August = p_guess;
            September = p_guess;
            October = p_guess;
            November = p_guess;
            December = p_guess;
            January = p_guess;
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