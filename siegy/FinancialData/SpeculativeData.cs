namespace Siegy.FinancialData
{
    internal static class SpeculativeData
    {
        public static decimal ExpectedDividendsRaiseInEuro { get; set; } = 0.1m; // == 5 Cent

        public static decimal ExpectedPayRaiseInPercent { get; set; } = 0.02m; // == 2%

        public static decimal ExpectedYearlyStockValueRaiseInPercent { get; set; } = 0.03m; // == 3%
    }
}