using System.Collections.Generic;

namespace SiegyFinances.FinancialObjects
{
    internal static class AllPossibleYearsForMe
    {
        internal static IEnumerable<InvestmentYear> AllYears()
        {
            for (int i = 2011; i <= 2040; i++)
            {
                yield return new InvestmentYear(i);
            }
        }
    }
}