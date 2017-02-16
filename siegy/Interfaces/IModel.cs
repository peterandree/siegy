using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siegy.Interfaces
{
    internal interface IModel
    {
        decimal Ammount { get; }
        int Endyear { get; }
        decimal DivPerStock { get; }
        decimal StockValue { get; }
        decimal InvestedCapital { get; }
        //   public     List<decimal> averageReturnOnInvest { get;  }

        void SetEndYear(int p_endyear);
    }
}