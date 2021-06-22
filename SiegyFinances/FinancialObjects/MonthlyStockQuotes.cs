using SiegyFinances.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static SiegyFinances.Enums.MonthlyStockQuotes;

namespace SiegyFinances.FinancialObjects
{
    public class MonthlyStockQuotes : IMonthlyStockQuotes
    {
        public decimal February { get; private set; }
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
        public decimal DividendDay { get; private set; }

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

        public void UpdateStockRatedListed(int monthNumber, decimal lastKnownQuote)//todo: pk refactor this clunky code
        {
            UpdateStockRatedListed((BuyEvent)Enum.ToObject(typeof(BuyEvent), monthNumber), lastKnownQuote);
        }

        public void UpdateStockRatedListed(BuyEvent buyEvent, decimal lastKnownQuote) //todo: pk refactor this clunky code
        {
            switch (buyEvent)
            {
                case BuyEvent.Feb:
                    February = lastKnownQuote;
                    break;

                case BuyEvent.Mar:
                    March = lastKnownQuote;
                    break;

                case BuyEvent.Apr:
                    April = lastKnownQuote;
                    break;

                case BuyEvent.May:
                    May = lastKnownQuote;
                    break;

                case BuyEvent.Jun:
                    June = lastKnownQuote;
                    break;

                case BuyEvent.Jul:
                    July = lastKnownQuote;
                    break;

                case BuyEvent.Aug:
                    August = lastKnownQuote;
                    break;

                case BuyEvent.Sep:
                    September = lastKnownQuote;
                    break;

                case BuyEvent.Oct:
                    October = lastKnownQuote;
                    break;

                case BuyEvent.Nov:
                    November = lastKnownQuote;
                    break;

                case BuyEvent.Dec:
                    December = lastKnownQuote;
                    break;

                case BuyEvent.Jan:
                    January = lastKnownQuote;
                    break;

                case BuyEvent.DividendDay:
                    DividendDay = lastKnownQuote;
                    break;
            }
        }
    }
}