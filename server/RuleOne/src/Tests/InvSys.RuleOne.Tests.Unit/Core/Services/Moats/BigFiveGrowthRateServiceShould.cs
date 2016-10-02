using InvSys.RuleOne.Core.Services.Moats;
using System.Collections.Generic;
using Xunit;
using InvSys.Financials.Api.Client.Proxy.Models;

namespace InvSys.RuleOne.Tests.Unit.Core.Services.Moats
{
    public class BigFiveGrowthRateServiceShould
    {
        #region Financial Data
        private List<FinancialData> _financialData = new List<FinancialData>
        {
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2015,
                Currency = "USD",
                Revenue = 2820.3,
                Eps = 2.39,
                Equity = 3345.1,
                Cash = 180.3,
                Roic = 0.1020
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2014,
                Currency = "USD",
                Revenue = 2870.7,
                Eps = 1.89,
                Equity = 3403.4,
                Cash = 702.8,
                Roic = 0.1220
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2013,
                Currency = "USD",
                Revenue = 2631.9,
                Eps = 3.13,
                Equity = 3659.7,
                Cash = 284.5,
                Roic = 0.1000
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2012,
                Currency = "USD",
                Revenue = 2715.7,
                Eps = 2.78,
                Equity = 3531.8,
                Cash = 527.5,
                Roic = 0.1110
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2011,
                Currency = "USD",
                Revenue = 2758.6,
                Eps = 2.68,
                Equity = 3256.6,
                Cash = 661.7,
                Roic = 0.1100
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2010,
                Currency = "USD",
                Revenue = 2689.9,
                Eps = 2.97,
                Equity = 3049.6,
                Cash = 550.7,
                Roic = 0.1350
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2009,
                Currency = "USD",
                Revenue = 2946.4,
                Eps = 3.51,
                Equity = 2836.4,
                Cash = 771.6,
                Roic = 0.1940
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2008,
                Currency = "USD",
                Revenue = 3497.1,
                Eps = 3.51,
                Equity = 2225.9,
                Cash = 518.7,
                Roic = 0.2350
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2007,
                Currency = "USD",
                Revenue = 3180.3,
                Eps = 3.95,
                Equity = 2350.6,
                Cash = 128.9,
                Roic = 0.2900
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2006,
                Currency = "USD",
                Revenue = 1774,
                Eps = 2.38,
                Equity = 1557.9,
                Cash = 125.2,
                Roic = 0.2550
            },
            new FinancialData
            {
                CompanySymbol = "GRMN",
                Year = 2005,
                Currency = "USD",
                Revenue = 1027.8,
                Eps = 1.44,
                Equity = 1157.3,
                Cash = 132.3,
                Roic = 0.2020
            }
        };
        #endregion

        [Fact]
        public void CalculateCorrectGrowthRate()
        {
            // Arrange
            const int future = 936;
            const int past = 136;
            const int years = 6;
            IBigFiveGrowthRateService bigFiveGrowthRateService = new BigFiveGrowthRateService();

            // Act
            var growthRate = bigFiveGrowthRateService.GrowthRate(future, past, years);

            // Assert
            Assert.NotNull(growthRate);
            Assert.Equal(0, growthRate); // TODO: change 0 to expected value and do correct double comparison
        }

        [Fact]
        public async void CalculateCorrectROIC()
        {
            // Arrange
            IBigFiveGrowthRateService bigFiveGrowthRateService = new BigFiveGrowthRateService();

            // Act
            var result = await bigFiveGrowthRateService.Calculate(_financialData, years: new int[] { 10, 5, 1 });

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

            // 10 years
            Assert.NotNull(result[0].ROIC);
            Assert.Equal(0, result[0].ROIC); // TODO: change 0 to expected value and do correct double comparison

            // 5 years
            Assert.NotNull(result[1].ROIC);
            Assert.Equal(0, result[1].ROIC); // TODO: change 0 to expected value and do correct double comparison

            // 1 year
            Assert.NotNull(result[2].ROIC);
            Assert.Equal(0, result[2].ROIC); // TODO: change 0 to expected value and do correct double comparison
        }
    }
}
