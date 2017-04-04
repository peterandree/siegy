using System.Collections.Generic;

namespace SiegyFinances.Interfaces
{
    public interface IMonthlyStockQuotes
    {
        decimal February { get; }
        decimal March { get; }
        decimal April { get; }
        decimal May { get; }
        decimal June { get; }
        decimal July { get; }
        decimal August { get; }
        decimal September { get; }
        decimal October { get; }
        decimal November { get; }
        decimal December { get; }
        decimal January { get; } //of the next calendar year

        decimal DividendDay { get; }

        IEnumerable<decimal> StockRates();

        IList<decimal> StockRatesListed();
    }
}