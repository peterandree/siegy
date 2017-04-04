using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegyFinances.FinancialObjects
{
  public  class InvestmentReturns
    {
        public decimal Ammount { get; set; }
        public int Endyear { get; set; }
        public decimal DivPerStock { get; set; }
        public decimal StockValue { get; set; }
        public decimal InvestedCapital { get; set; }
    }
}
