using SiegyFinances.FinancialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegyFinances.FinancialData.Years
{
    internal class MonthlyStockQuotes2011 : MonthlyStockQuotes
    {
        public MonthlyStockQuotes2011()
        {
            this._DividendDay = 0.001m;  //egal, hauptsache nicht div by zero
            this._February = 91.66565m;
            this._March = 999m;
            this._April = 999m;
            this._May = 999m;
            this._June = 999m;
            this._July = 999m;
            this._August = 999m;
            this._September = 999m;
            this._October = 999m;
            this._November = 999m;
            this._December = 999m;
            this._January = 999m;
        }
    }
}