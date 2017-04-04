using SiegyFinances.FinancialObjects;

namespace SiegyConsole.Interfaces
{
    internal interface IModel:ISubject
    {
        InvestmentReturns investmentReturns { get; }

        void SetEndYear(int p_endyear);
    }
}