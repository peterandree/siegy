namespace SiegyFinances.FinancialData
{
    internal static class FinancialConstants
    {
        internal const decimal DEFAULT_ONE_TIME_RATE = 720m;

        internal static decimal TAX_ADJUSTMENT(int p_year) => p_year <= 9999 ? TAX_ADJUSTMENT_WITH_SOLI : TAX_ADJUSTMENT_WITHOUT_SOLI;

        internal const decimal TAX_ADJUSTMENT_WITH_SOLI = 0.26375m;
        internal const decimal TAX_ADJUSTMENT_WITHOUT_SOLI = 0.25m;
    }
}