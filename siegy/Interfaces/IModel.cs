using siegy.FinancialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.Interfaces
{
    internal interface IModel:ISubject
    {
        InvestmentReturns investmentReturns { get; }

        void SetEndYear(int p_endyear);
    }
}