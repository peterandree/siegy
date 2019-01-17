using System.Collections.Generic;

namespace SiegyFinances.Interfaces
{
    public interface IMonthlyStockQuotes
    {
        decimal February { get; set; }
        decimal March { get; set; }
        decimal April { get; set; }
        decimal May { get; set; }
        decimal June { get; set; }
        decimal July { get; set; }
        decimal August { get; set; }
        decimal September { get; set; }
        decimal October { get; set; }
        decimal November { get; set; }
        decimal December { get; set; }
        decimal January { get; set; } //of the next calendar year

        decimal DividendDay { get; set; }

        IEnumerable<decimal> StockRates();

        IList<decimal> StockRatesListed();
    }
}