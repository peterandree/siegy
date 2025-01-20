using SiegyFinances.FinancialObjects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SiegyFinances.Helpers
{
    public static class FileHelpers
    {
        private static readonly string pathToFinancialData = Path.Combine(Directory.GetCurrentDirectory(), "FinancialData");
        private static readonly string pathToFinancialDataMonths = Path.Combine(pathToFinancialData, "Years");

        internal static Dictionary<int, decimal> GetDicOfIntDecimalFromJson(string filename)
        {
            string path = Path.Combine(pathToFinancialData, filename);
            using var r = new StreamReader(path);
            string json = r.ReadToEnd();
            var data = JsonSerializer.Deserialize<Dictionary<string, decimal>>(json);
            return data.ToDictionary(kvp => int.Parse(kvp.Key), kvp => kvp.Value);
        }

        // Cache for MonthlyStockQuotes
        private static Dictionary<int, MonthContainer> monthlyStockQuotesCache = [];

        internal static MonthContainer FillWithQuotes(int p_year)
        {
            if (monthlyStockQuotesCache.TryGetValue(p_year, out MonthContainer value))
            {
                // If the data is in the cache, return it
                return value;
            }

            string path = Path.Combine(pathToFinancialDataMonths, $"MonthlyStockQuotes{p_year}.json");
            if (!File.Exists(path))
            {
                return new MonthContainer(); //return an empty year, indicating there are no data
            }
            using var r = new StreamReader(path);
            string json = r.ReadToEnd();
            var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            var monthContainer = new MonthContainer
            {
                DividendDay = data["DividendDay"].GetDecimal(),
                February = data["February"].GetDecimal(),
                March = data["March"].GetDecimal(),
                April = data["April"].GetDecimal(),
                May = data["May"].GetDecimal(),
                June = data["June"].GetDecimal(),
                July = data["July"].GetDecimal(),
                August = data["August"].GetDecimal(),
                September = data["September"].GetDecimal(),
                October = data["October"].GetDecimal(),
                November = data["November"].GetDecimal(),
                December = data["December"].GetDecimal(),
                January = data["January"].GetDecimal()
            };

            // Add the data to the cache
            monthlyStockQuotesCache[p_year] = monthContainer;

            return monthContainer;
        }
    }
}
