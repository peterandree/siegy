using SiegyFinances.Helpers;
using System.Collections.Generic;

namespace SiegyFinances.FinancialData
{
    public static class HistoricData
    {
        //The year where the dividend is payed IN not FOR, that would be year minus 1
        // in Euro
        //Estimations for future years can be found in http://www.finanzen.net/dividende/Siemens
        internal static readonly Dictionary<int, decimal> Dividend = FileHelpers.GetDicOfIntDecimalFromJson("HistoricDividend.json");

        internal static readonly Dictionary<int, decimal> OneTimeRate = FileHelpers.GetDicOfIntDecimalFromJson("HistoricOneTimeRate.json");

        internal static readonly Dictionary<int, decimal> MonthlyRate = FileHelpers.GetDicOfIntDecimalFromJson("HistoricMonthlyRate.json");

        internal static readonly Dictionary<int, decimal> ProfitSharingStocksLookup = FileHelpers.GetDicOfIntDecimalFromJson("HistoricProfitSharingStocks.json");
    }
}