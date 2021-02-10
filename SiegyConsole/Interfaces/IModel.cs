using SiegyFinances.FinancialObjects;

namespace SiegyConsole.Interfaces
{
    internal interface IModel : ISubject
    {
        InvestmentReturns InvestmentReturns { get; }

        void SetEndYear(int p_endyear);
    }
}