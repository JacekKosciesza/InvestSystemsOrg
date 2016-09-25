using System;
using System.Collections.Generic;
using InvSys.RuleOne.Core.Services;
using InvSys.RuleOne.Core.Services.ThreeTools;
using InvSys.StockQuotes.Api.Client.Proxy.Models;
using Xunit;

namespace InvSys.RuleOne.Tests.Unit.Core.Services.ThreeTools
{
    public class MACDServiceShould
    {
        [Fact]
        public void CalculateCorrectMACDData()
        {
            // Arrange
            #region Prices
            var prices = new List<HistoricalQuote>
            {
                new HistoricalQuote{ Date = new DateTime(2013, 2, 19), Close = 459.99},
                new HistoricalQuote{ Date = new DateTime(2013, 2, 20), Close = 448.85},
                new HistoricalQuote{ Date = new DateTime(2013, 2, 21), Close = 446.06},
                new HistoricalQuote{ Date = new DateTime(2013, 2, 22), Close = 450.81},
                new HistoricalQuote{ Date = new DateTime(2013, 2, 25), Close = 442.8},
                new HistoricalQuote{ Date = new DateTime(2013, 2, 26), Close = 448.97},
                new HistoricalQuote{ Date = new DateTime(2013, 2, 27), Close = 444.57},
                new HistoricalQuote{ Date = new DateTime(2013, 2, 28), Close = 441.4},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 1 ), Close = 430.47},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 4 ), Close = 420.05},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 5 ), Close = 431.14},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 6 ), Close = 425.66},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 7 ), Close = 430.58},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 8 ), Close = 431.72},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 11), Close = 437.87},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 12), Close = 428.43},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 13), Close = 428.35},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 14), Close = 432.5},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 15), Close = 443.66},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 18), Close = 455.72},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 19), Close = 454.49},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 20), Close = 452.08},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 21), Close = 452.73},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 22), Close = 461.91},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 25), Close = 463.58},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 26), Close = 461.14},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 27), Close = 452.08},
                new HistoricalQuote{ Date = new DateTime(2013, 3, 28), Close = 442.66},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 1 ), Close = 428.91},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 2 ), Close = 429.79},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 3 ), Close = 431.99},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 4 ), Close = 427.72},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 5 ), Close = 423.2},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 8 ), Close = 426.21},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 9 ), Close = 426.98},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 10), Close = 435.69},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 11), Close = 434.33},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 12), Close = 429.8},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 15), Close = 419.85},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 16), Close = 426.24},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 17), Close = 402.8},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 18), Close = 392.05},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 19), Close = 390.53},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 22), Close = 398.67},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 23), Close = 406.13},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 24), Close = 405.46},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 25), Close = 408.38},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 26), Close = 417.2},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 29), Close = 430.12},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 30), Close = 442.78},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 1 ), Close = 439.29},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 2 ), Close = 445.52},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 3 ), Close = 449.98},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 6 ), Close = 460.71},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 7 ), Close = 458.66},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 8 ), Close = 463.84},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 9 ), Close = 456.77},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 10), Close = 452.97},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 13), Close = 454.74},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 14), Close = 443.86},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 15), Close = 428.85},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 16), Close = 434.58},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 17), Close = 433.26},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 20), Close = 442.93},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 21), Close = 439.66},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 22), Close = 441.35},
            };
            #endregion
            IMACDService macdService = new MACDService();

            // Act
            var output = macdService.Calculate(prices, 12, 26, 9);

            // Assert
        }
    }
}

