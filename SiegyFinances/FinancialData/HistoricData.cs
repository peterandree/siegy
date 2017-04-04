using System;
using System.Collections.Generic;
using System.Linq;

namespace SiegyFinances.FinancialData
{
    public static class HistoricData
    {
        public static decimal Dividend(int p_year)
        {
            // in Euro
            switch (p_year)
            {
                case 2010:
                    {
                        return 0m;
                    }
                case 2011:
                case 2012:
                case 2013:
                case 2014:
                    {
                        return 3m;
                    }
                case 2015:
                    {
                        return 3.3m;
                    }
                case 2016:
                    {
                        return 3.5m;
                    }
                case 2017:
                    {
                        return 3.7m;
                    }
                default:
                    {
                        return -1m;
                    }
            }
        }

        public static decimal OneTimeRate(int p_year)
        {
            switch (p_year)
            {
                case 2011:
                case 2012:
                case 2013:
                    {
                        return 695m;
                    }
                default:
                    {
                        return 720m;
                    }
            }
        }

        public static readonly Dictionary<int, decimal> MonthlyRate = InternalMonththlyRate().ToDictionary(x => x.Key, x => x.Value);

        private static IEnumerable<KeyValuePair<int, decimal>> InternalMonththlyRate()
        {
            yield return new KeyValuePair<int, decimal>(2011, 0m);
            yield return new KeyValuePair<int, decimal>(2012, 29m);
            yield return new KeyValuePair<int, decimal>(2013, 108m);
            yield return new KeyValuePair<int, decimal>(2014, 112m);
            yield return new KeyValuePair<int, decimal>(2015, 120m);
            yield return new KeyValuePair<int, decimal>(2016, 172m);
            yield return new KeyValuePair<int, decimal>(2017, 179m);
        }

        public static decimal ProfitSharingStocks(int pYear)
        {
            switch (pYear)
            {
                //case 2018:
                //    {
                //        return 10m;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!estimated
                //    }
                default:
                    {
                        return 0m;
                    }
            }
        }
    }
}