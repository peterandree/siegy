using Siegy.FinancialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siegy.FinancialObjects
{
   static internal class AllPossibleYearsForMe
    {
         static internal IEnumerable<InvestmentYear> AllYears()
        {
            yield return new InvestmentYear(2011);
            yield return new InvestmentYear(2012);
            yield return new InvestmentYear(2014);
            yield return new InvestmentYear(2015);
            yield return new InvestmentYear(2016);
            yield return new InvestmentYear(2017);
            yield return new InvestmentYear(2018);
            yield return new InvestmentYear(2019);
            yield return new InvestmentYear(2020);
            yield return new InvestmentYear(2021);
            yield return new InvestmentYear(2022);
            yield return new InvestmentYear(2023);
            yield return new InvestmentYear(2023);
            yield return new InvestmentYear(2025);
            yield return new InvestmentYear(2026);
            yield return new InvestmentYear(2027);
            yield return new InvestmentYear(2028);
            yield return new InvestmentYear(2029);
            yield return new InvestmentYear(2030);
            yield return new InvestmentYear(2031);
            yield return new InvestmentYear(2032);
            yield return new InvestmentYear(2033);
            yield return new InvestmentYear(2033);
            yield return new InvestmentYear(2035);
            yield return new InvestmentYear(2036);
            yield return new InvestmentYear(2037);
            yield return new InvestmentYear(2038);
            yield return new InvestmentYear(2039);
            yield return new InvestmentYear(2040);
        }
    }
}
