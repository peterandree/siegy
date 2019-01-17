using Newtonsoft.Json;
using SiegyFinances.FinancialObjects;
using System.Collections.Generic;
using System.IO;

namespace SiegyFinances.Helpers
{
    public static class FileHelpers
    {
        private static readonly string pathToFinancialData = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "FinancialData");
        private static readonly string pathToFinancialDataMonths = Path.Combine(pathToFinancialData, "Years");

        internal static Dictionary<int, decimal> GetDicOfIntDecimalFromJson(string filename)
        {
            string path = Path.Combine(pathToFinancialData, filename);
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Dictionary<int, decimal>>(json);
            }
        }

        internal static MonthlyStockQuotes FillWithQuotes(int p_year)
        {
            string path = Path.Combine(pathToFinancialDataMonths, $"MonthlyStockQuotes{p_year}.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<MonthlyStockQuotes>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}