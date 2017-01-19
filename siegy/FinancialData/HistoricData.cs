using System;
using System.Collections.Generic;
using System.Linq;

namespace Siegy.FinancialData
{
    internal static class HistoricData
    {
        internal static decimal Dividend(int p_year)
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

        internal static IList<decimal> MonthlyStockRates(int p_year)
        {
            var rates = new List<decimal>();
            switch (p_year)
            {
                case 2011:
                    {
                        rates = StockRates2011().ToList();
                        if (rates.Count != 12)
                        {
                            throw new Exception("Ist nicht 12!!!");
                        }
                        return rates;
                    }
                case 2012:
                    {
                        rates = StockRates2012().ToList();
                        if (rates.Count != 12)
                        {
                            throw new Exception("Ist nicht 12!!!");
                        }
                        return rates;
                    }
                case 2013:
                    {
                        rates = StockRates2013().ToList();
                        if (rates.Count != 12)
                        {
                            throw new Exception("Ist nicht 12!!!");
                        }
                        return rates;
                    }
                case 2014:
                    {
                        rates = StockRates2014().ToList();
                        if (rates.Count != 12)
                        {
                            throw new Exception("Ist nicht 12!!!");
                        }
                        return rates;
                    }
                case 2015:
                     {
                        rates = StockRates2015().ToList();
                        if (rates.Count != 12)
                        {
                            throw new Exception("Ist nicht 12!!!");
                        }
                        return rates;
                    }
                case 2016:
                    {
                        rates = StockRates2016().ToList();
                        if (rates.Count != 12)
                        {
                            throw new Exception("Ist nicht 12!!!");
                        }
                        return rates;
                    }
                default:
                    {
                        return rates;
                    }
            }
        }

        internal static decimal OneTimeRate(int p_year)
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

        internal static decimal StockQuoteAtDividendDay(int p_year)
        {
            switch (p_year)
            {
                case 2010:
                case 2011:
                    {
                        return 0.001m;  //egal, hauptsache nicht div by zero
                    }
                case 2012:
                    {
                        return 71.2857m;
                    }
                case 2013:
                    {
                        return 77.89728m;
                    }
                case 2014:
                    {
                        return 95.4663m;
                    }
                case 2015:
                    {
                        return 94.8693m;
                    }
                case 2016:
                    {
                        return 87.9107m;
                    }
                default:
                    {
                        return -1m;
                    }
            }
        }

        internal static readonly Dictionary<int, decimal> MonthlyRate = InternalMonththlyRate().ToDictionary(x => x.Key, x => x.Value);

        private static IEnumerable<KeyValuePair<int, decimal>> InternalMonththlyRate()
        {
            yield return new KeyValuePair<int, decimal>(2011, 0m);
            yield return new KeyValuePair<int, decimal>(2012, 29m);
            yield return new KeyValuePair<int, decimal>(2013, 108m);
            yield return new KeyValuePair<int, decimal>(2014, 112m);
            yield return new KeyValuePair<int, decimal>(2015, 120m);
            yield return new KeyValuePair<int, decimal>(2016, 172m);
        }

        private static IEnumerable<decimal> StockRates2011()
        {
            yield return 91.66565m;
            yield return 999999;
            yield return 999999;
            yield return 999999;
            yield return 999999;
            yield return 999999;
            yield return 999999;
            yield return 999999;
            yield return 999999;
            yield return 999999;
            yield return 999999;
            yield return 999999;
        }

        private static IEnumerable<decimal> StockRates2012()
        {
            //February to January
            yield return 71.3952m;            //February
            yield return 73.75896m;            //March
            yield return 70.37251m;            //April
            yield return 64.20744m;            //May
            yield return 62.55763m;            //June
            yield return 65.63534m;            //July
            yield return 71.40485m;            //August
            yield return 76.7016m;            //September
            yield return 73.50811m;            //October
            yield return 75.2351m;            //November
            yield return 79.19078m;            //December
            yield return 80.29066m;            //January
        }

        private static IEnumerable<decimal> StockRates2013()
        {
            //February to January
            yield return 75.7561m;            //February
            yield return 80.99496m;            //March
            yield return 76.58582m;            //April
            yield return 78.22598m;            //May
            yield return 76.49899m;            //June
            yield return 79.55m;            //July
            yield return 84.38m;            //August
            yield return 86.94m;            //September
            yield return 91.24m;            //October
            yield return 96.98m;            //November
            yield return 93.29m;            //December
            yield return 101.35m;            //January
        }

        private static IEnumerable<decimal> StockRates2014()
        {
            //February to January
            yield return 95.06m;            //February
            yield return 90.62m;            //March
            yield return 96.35m;            //April
            yield return 96.44m;            //May
            yield return 98.8m;            //June
            yield return 93.59m;            //July
            yield return 91.63m;            //August
            yield return 97.09m;            //September
            yield return 82.34m;            //October
            yield return 88.5m;            //November
            yield return 91.38m;            //December
            yield return 94.65m;            //January
        }

        private static IEnumerable<decimal> StockRates2015()
        {
            //February to January
            yield return 95.96m;            //February
            yield return 103.4m;            //March
            yield return 101.45m;            //April
            yield return 95.88m;            //May
            yield return 94.21m;            //June
            yield return 93.91m;            //July
            yield return 95.46m;            //August
            yield return 85.06m;            //September
            yield return 83.71m;            //October
            yield return 92.86m;            //November
            yield return 86.25m;            //December
            yield return 81.7m;            //January
        }

        private static IEnumerable<decimal> StockRates2016()
        {
            //February to January
            yield return 80.65m;            //February
            yield return 91.17m;            //March
            yield return 93.04m;            //April
            yield return 93.6m;            //May
            yield return 90.17m;            //June
            yield return 94.08m;            //July
            yield return 107.45m;            //August
            yield return 102.45m;            //September
            yield return 104.45m;            //October
            yield return 109.05m;            //November
            yield return 116.10m;            //December !!!!!!!!!!!!!!!!!!!!!!!!!!!estimated
            yield return 116.10m;            //January !!!!!!!!!!!!!!!!!!!!!!!!!!!!!estimated
        }

        internal static decimal ProfitSharingStocks(int pYear)
        {
            switch (pYear)
            {
                case 2018:
                    {
                        return 10m;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!estimated
                    }
                default:
                    {
                        return 0m;
                    }
            }
        }
    }
}