using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SiegyFinances.Helpers
{
    public static class FileHelpers
    {
        private static readonly string pathToFinancialData = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "FinancialData");

        internal static Dictionary<int, decimal> GetDicOfIntDecimalFromJson(string filename)
        {
            string path = Path.Combine(pathToFinancialData, filename);
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                return JsonConvert.DeserializeObject<Dictionary<int, decimal>>(json);
            }
        }
    }
}