namespace SiegyFinances.FinancialData
{
    public static class SpeculativeData
    {
        public static decimal ExpectedDividendsRaiseInEuro { get; set; } = 0.10m; // == 10 Cent

        public static decimal ExpectedPayRaiseInPercent { get; set; } = 0.02m; // == 2%

        //Statistics says 6.8% for the last 15 years or so
        public static decimal ExpectedYearlyStockValueRaiseInPercent { get; set; } = 0.03m; // == 3%

    }
}