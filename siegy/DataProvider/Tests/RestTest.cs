using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace ConsoleProgram
{

    public static class RestTest
    {
     private class DataObject
    {
        public string Name { get; set; }
    }
       //private static string URL;//= "http://www.google.com/finance/option_chain";
        //private static string urlParameters; //= "?q=FRA:SIE&output=json";
        //http://finance.google.com/finance/info?client=ig&q=FRA:SIE

        //next goal: scrape this page http://www.finanzen.net/Kursziele/Siemens

        private static void Main()
        {
            //const string tickers = "AAPL,GOOG,GOOGL,YHOO,TSLA,INTC,AMZN,BIDU,ORCL,MSFT,ORCL,ATVI,NVDA,GME,LNKD,NFLX";
            const string tickers = "SIE";
            const string market = "ETR";

            string json;

            using (var web = new WebClient())
            {
                //var url = $"http://finance.google.com/finance/info?client=ig&amp;amp;q=NASDAQ%3A{tickers}";
                var url = $"http://finance.google.com/finance/info?client=ig&q={market}:{tickers}";
                json = web.DownloadString(url);
            }

            //Google adds a comment before the json for some unknown reason, so we need to remove it
            json = json.Replace("//", "");

            foreach (JToken i in JArray.Parse(json))
            {
                var ticker = i.SelectToken("t");
                var price = (decimal)i.SelectToken("l");

                Console.WriteLine($"{ticker} : {price}");
            }

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}