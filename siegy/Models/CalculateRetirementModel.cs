using siegy.Interfaces;
using Siegy.Factories;
using Siegy.FinancialObjects;
using Siegy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siegy.Models
{
    internal class CalculateRetirementModel : IModel
    {
        public decimal Ammount
        {
            get
            {
                return _ammount;
            }
        }

        public int Endyear
        {
            get
            {
                return _endYear;
            }
        }

        public decimal DivPerStock
        {
            get
            {
                return _divPerStock;
            }
        }

        public decimal StockValue
        {
            get
            {
                return _stockValue;
            }
        }

        public decimal InvestedCapital
        {
            get
            {
                return _investedCapital;
            }
        }

        //   public     List<decimal> averageReturnOnInvest { get;  }

        private int _endYear;
        private decimal _ammount;
        private decimal _divPerStock;
        private decimal _stockValue;
        private decimal _investedCapital;

        public void SetEndYear(int p_endyear)
        {
            _endYear = p_endyear;
            Calculate();
        }

        public void Calculate()
        {
            var averageReturnOnInvest = new List<decimal>();

            _ammount = 0m;
            _investedCapital = 0m;
            foreach (InvestmentYear currentYear in AllYears())
            {
                if (currentYear.Year <= _endYear)
                {
                    _ammount += currentYear.AccumulatedStocks(_endYear);
                    _investedCapital += currentYear.InvestedCapital();
                }
            }

            _stockValue = Siegy.Factories.MonthlyStockQuotesFactory.Get(_endYear).DividendDay;
            _divPerStock = Financial.GetDividend(_endYear);
        }

        private static IEnumerable<InvestmentYear> AllYears()
        {
            yield return new InvestmentYear(2011);
            yield return new InvestmentYear(2012);
            yield return new InvestmentYear(2014);
            yield return new InvestmentYear(2015);
            yield return new InvestmentYear(2016);
            yield return new InvestmentYear(2017);
            yield return new InvestmentYear(2018);
            yield return new InvestmentYear(2019);
            yield return new InvestmentYear(2020);
            yield return new InvestmentYear(2021);
            yield return new InvestmentYear(2022);
            yield return new InvestmentYear(2023);
            yield return new InvestmentYear(2023);
            yield return new InvestmentYear(2025);
            yield return new InvestmentYear(2026);
            yield return new InvestmentYear(2027);
            yield return new InvestmentYear(2028);
            yield return new InvestmentYear(2029);
            yield return new InvestmentYear(2030);
            yield return new InvestmentYear(2031);
            yield return new InvestmentYear(2032);
            yield return new InvestmentYear(2033);
            yield return new InvestmentYear(2033);
            yield return new InvestmentYear(2035);
            yield return new InvestmentYear(2036);
            yield return new InvestmentYear(2037);
            yield return new InvestmentYear(2038);
            yield return new InvestmentYear(2039);
            yield return new InvestmentYear(2040);
        }
    }
}