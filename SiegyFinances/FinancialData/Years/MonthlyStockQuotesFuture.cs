using SiegyFinances.FinancialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegyFinances.FinancialData.Years
{
    public class MonthlyStockQuotesFuture : MonthlyStockQuotes
    {
        private MonthlyStockQuotesFuture()
        {
        }

        public MonthlyStockQuotesFuture(decimal p_guess)
        {
            DividendDay = p_guess;
            February = p_guess;
            March = p_guess;
            April = p_guess;
            May = p_guess;
            June = p_guess;
            July = p_guess;
            August = p_guess;
            September = p_guess;
            October = p_guess;
            November = p_guess;
            December = p_guess;
            January = p_guess;
        }
    }
}