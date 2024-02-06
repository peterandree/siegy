namespace SiegyFinances.FinancialData
{
    internal static class FinancialConstants
    {
        internal const int THE_YEAR_THEY_STOPPED_THE_SOLI = 9999;
        
        internal const decimal DEFAULT_ONE_TIME_RATE = 720m;

        internal static decimal TAX_ADJUSTMENT(int p_year) => p_year <= THE_YEAR_THEY_STOPPED_THE_SOLI ? TAX_ADJUSTMENT_WITH_SOLI : TAX_ADJUSTMENT_WITHOUT_SOLI;

        internal const decimal TAX_ADJUSTMENT_WITH_SOLI = 0.26375m;
        internal const decimal TAX_ADJUSTMENT_WITHOUT_SOLI = 0.25m;
    }
}