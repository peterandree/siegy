using System.Collections.Generic;
using System.Linq;

namespace SiegyFinances.FinancialData
{
    public static class HistoricData
    {
        //The year where the dividend is payed IN not FOR, that youd be year minus 1
        // in Euro
        public static decimal Dividend(int p_year)
        {
            if (p_year > 2018) //Estimations according to http://www.finanzen.net/dividende/Siemens
            {
                switch (p_year)
                {
                    case 2019:
                        {
                            return 4.06m;
                        }
                    case 2020:
                        {
                            return 4.20m;
                        }
                    case 2021:
                        {
                            return 4.40m;
                        }
                    case 2022:
                        {
                            return 4.50m;
                        }
                }
            }


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
                        return 3.6m;
                    }
                case 2018:
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
                case 2014:
                case 2015:
                case 2016:
                case 2017:
                    {
                        return 720m;
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
            yield return new KeyValuePair<int, decimal>(2018, 232m);
        }

        public static decimal ProfitSharingStocks(int pYear)
        {
            switch (pYear)
            {
                case 9999:
                //case 2018:
                //case 2023:
                //case 2028:
                //case 2033:
                //case 2038:
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