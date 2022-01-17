namespace SiegyFinances.FinancialData
{
    public static class SpeculativeData
    {
        /*
         * Information is that Siemens aims for a yearly raise in dividends of 4-5%.
         * Calculations are done with 2.1% which roughly matches in the outcome the old
         * cautious assumtion of a steady raise of 10 cent every year
         */
        public static decimal ExpectedDividendsRaiseInPercent { get; set; } = 0.021m; // == 2.1% percent

        public static decimal ExpectedPayRaiseInPercent { get; set; } = 0.02m; // == 2%

        //Statistics says yearly 6.8% for the last 15 years or so
        public static decimal ExpectedYearlyStockValueRaiseInPercent { get; set; } = 0.03m; // == 3%
    }
}