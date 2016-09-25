using System;
using System.Collections.Generic;
using System.Linq;
using InvSys.RuleOne.Core.Models.ThreeTools;
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
            var calculated = macdService.Calculate(prices, 12, 26, 9);

            // Assert
            #region Expected output
            var expected = new List<MACDData>
            {
                new MACDData{ Date = new DateTime(2013, 2, 19)},
                new MACDData{ Date = new DateTime(2013, 2, 20)},
                new MACDData{ Date = new DateTime(2013, 2, 21)},
                new MACDData{ Date = new DateTime(2013, 2, 22)},
                new MACDData{ Date = new DateTime(2013, 2, 25)},
                new MACDData{ Date = new DateTime(2013, 2, 26)},
                new MACDData{ Date = new DateTime(2013, 2, 27)},
                new MACDData{ Date = new DateTime(2013, 2, 28)},
                new MACDData{ Date = new DateTime(2013, 3, 1 )},
                new MACDData{ Date = new DateTime(2013, 3, 4 )},
                new MACDData{ Date = new DateTime(2013, 3, 5 )},
                new MACDData{ Date = new DateTime(2013, 3, 6 ), EMA12Day = 440.8975m   },
                new MACDData{ Date = new DateTime(2013, 3, 7 ), EMA12Day = 439.3101923m},
                new MACDData{ Date = new DateTime(2013, 3, 8 ), EMA12Day = 438.1424704m},
                new MACDData{ Date = new DateTime(2013, 3, 11), EMA12Day = 438.1005519m},
                new MACDData{ Date = new DateTime(2013, 3, 12), EMA12Day = 436.6127747m},
                new MACDData{ Date = new DateTime(2013, 3, 13), EMA12Day = 435.3415786m},
                new MACDData{ Date = new DateTime(2013, 3, 14), EMA12Day = 434.9044126m},
                new MACDData{ Date = new DateTime(2013, 3, 15), EMA12Day = 436.2514261m},
                new MACDData{ Date = new DateTime(2013, 3, 18), EMA12Day = 439.2465913m},
                new MACDData{ Date = new DateTime(2013, 3, 19), EMA12Day = 441.5917311m},
                new MACDData{ Date = new DateTime(2013, 3, 20), EMA12Day = 443.2053109m},
                new MACDData{ Date = new DateTime(2013, 3, 21), EMA12Day = 444.6706477m},
                new MACDData{ Date = new DateTime(2013, 3, 22), EMA12Day = 447.3228558m},
                new MACDData{ Date = new DateTime(2013, 3, 25), EMA12Day = 449.8239549m},
                new MACDData{ Date = new DateTime(2013, 3, 26), EMA12Day = 451.5648849m, EMA26Day = 443.2896154m, MACD = 8.275269504m},
                new MACDData{ Date = new DateTime(2013, 3, 27), EMA12Day = 451.6441334m, EMA26Day = 443.940755m , MACD = 7.703378381m},
                new MACDData{ Date = new DateTime(2013, 3, 28), EMA12Day = 450.261959m , EMA26Day = 443.8458842m, MACD = 6.416074757m},
                new MACDData{ Date = new DateTime(2013, 4, 1 ), EMA12Day = 446.9770422m, EMA26Day = 442.7395225m, MACD = 4.237519783m},
                new MACDData{ Date = new DateTime(2013, 4, 2 ), EMA12Day = 444.3328819m, EMA26Day = 441.7802986m, MACD = 2.552583325m},
                new MACDData{ Date = new DateTime(2013, 4, 3 ), EMA12Day = 442.433977m , EMA26Day = 441.0550913m, MACD = 1.37888572m },
                new MACDData{ Date = new DateTime(2013, 4, 4 ), EMA12Day = 440.1702882m, EMA26Day = 440.0673067m, MACD = 0.102981491m},
                new MACDData{ Date = new DateTime(2013, 4, 5 ), EMA12Day = 437.5594746m, EMA26Day = 438.8178766m, MACD = -1.25840195m},
                new MACDData{ Date = new DateTime(2013, 4, 8 ), EMA12Day = 435.8134016m, EMA26Day = 437.8839598m, MACD = -2.07055819m, Signal = 3.037525869m , Histogram = -5.108084059m},
                new MACDData{ Date = new DateTime(2013, 4, 9 ), EMA12Day = 434.4544168m, EMA26Day = 437.0762591m, MACD = -2.62184232m, Signal = 1.905652229m , Histogram = -4.527494558m},
                new MACDData{ Date = new DateTime(2013, 4, 10), EMA12Day = 434.6445065m, EMA26Day = 436.9735732m, MACD = -2.32906674m, Signal = 1.058708435m , Histogram = -3.387775176m},
                new MACDData{ Date = new DateTime(2013, 4, 11), EMA12Day = 434.5961209m, EMA26Day = 436.777753m , MACD = -2.18163211m, Signal = 0.410640325m , Histogram = -2.59227244m },
                new MACDData{ Date = new DateTime(2013, 4, 12), EMA12Day = 433.8582561m, EMA26Day = 436.2608824m, MACD = -2.40262627m, Signal = -0.152012994m, Histogram = -2.250613279m},
                new MACDData{ Date = new DateTime(2013, 4, 15), EMA12Day = 431.7031398m, EMA26Day = 435.0452615m, MACD = -3.34212168m, Signal = -0.790034732m, Histogram = -2.55208695m },
                new MACDData{ Date = new DateTime(2013, 4, 16), EMA12Day = 430.8626568m, EMA26Day = 434.3930199m, MACD = -3.53036313m, Signal = -1.338100413m, Histogram = -2.192262723m},
                new MACDData{ Date = new DateTime(2013, 4, 17), EMA12Day = 426.5453249m, EMA26Day = 432.0527962m, MACD = -5.50747124m, Signal = -2.17197458m , Histogram = -3.335496669m},
                new MACDData{ Date = new DateTime(2013, 4, 18), EMA12Day = 421.2383519m, EMA26Day = 429.0896261m, MACD = -7.85127422m, Signal = -3.30783451m , Histogram = -4.543439719m},
                new MACDData{ Date = new DateTime(2013, 4, 19), EMA12Day = 416.51399m  , EMA26Day = 426.2333575m, MACD = -9.71936745m, Signal = -4.590141099m, Histogram = -5.129226357m},
                new MACDData{ Date = new DateTime(2013, 4, 22), EMA12Day = 413.7687608m, EMA26Day = 424.1916273m, MACD = -10.4228665m, Signal = -5.756686181m, Histogram = -4.666180327m},
                new MACDData{ Date = new DateTime(2013, 4, 23), EMA12Day = 412.5935668m, EMA26Day = 422.853729m , MACD = -10.2601621m, Signal = -6.657381376m, Histogram = -3.602780783m},
                new MACDData{ Date = new DateTime(2013, 4, 24), EMA12Day = 411.496095m , EMA26Day = 421.5653046m, MACD = -10.0692096m, Signal = -7.339747023m, Histogram = -2.729462587m},
                new MACDData{ Date = new DateTime(2013, 4, 25), EMA12Day = 411.0166958m, EMA26Day = 420.5886154m, MACD = -9.57191961m, Signal = -7.786181541m, Histogram = -1.785738071m},
                new MACDData{ Date = new DateTime(2013, 4, 26), EMA12Day = 411.9679734m, EMA26Day = 420.3376068m, MACD = -8.36963349m, Signal = -7.902871931m, Histogram = -0.466761561m},
                new MACDData{ Date = new DateTime(2013, 4, 29), EMA12Day = 414.7605928m, EMA26Day = 421.0622286m, MACD = -6.30163572m, Signal = -7.58262469m , Histogram = 1.280988966m },
                new MACDData{ Date = new DateTime(2013, 4, 30), EMA12Day = 419.0712709m, EMA26Day = 422.6709524m, MACD = -3.59968150m, Signal = -6.786036054m, Histogram = 3.186354544m },
                new MACDData{ Date = new DateTime(2013, 5, 1 ), EMA12Day = 422.1818446m, EMA26Day = 423.9019929m, MACD = -1.72014836m, Signal = -5.772858515m, Histogram = 4.052710154m },
                new MACDData{ Date = new DateTime(2013, 5, 2 ), EMA12Day = 425.77233m  , EMA26Day = 425.5033268m, MACD = 0.269003232m, Signal = -4.564486166m, Histogram = 4.833489398m },
                new MACDData{ Date = new DateTime(2013, 5, 3 ), EMA12Day = 429.4965869m, EMA26Day = 427.3164137m, MACD = 2.180173247m, Signal = -3.215554283m, Histogram = 5.39572753m  },
                new MACDData{ Date = new DateTime(2013, 5, 6 ), EMA12Day = 434.2986505m, EMA26Day = 429.7900127m, MACD = 4.508637809m, Signal = -1.670715865m, Histogram = 6.179353673m },
                new MACDData{ Date = new DateTime(2013, 5, 7 ), EMA12Day = 438.0465504m, EMA26Day = 431.9285303m, MACD = 6.118020154m, Signal = -0.112968661m, Histogram = 6.230988815m },
                new MACDData{ Date = new DateTime(2013, 5, 8 ), EMA12Day = 442.0147734m, EMA26Day = 434.2923428m, MACD = 7.722430594m, Signal = 1.45411119m  , Histogram = 6.268319404m },
                new MACDData{ Date = new DateTime(2013, 5, 9 ), EMA12Day = 444.2848083m, EMA26Day = 435.9573545m, MACD = 8.327453809m, Signal = 2.828779714m , Histogram = 5.498674095m },
                new MACDData{ Date = new DateTime(2013, 5, 10), EMA12Day = 445.6209916m, EMA26Day = 437.2175504m, MACD = 8.403441185m, Signal = 3.943712008m , Histogram = 4.459729177m },
                new MACDData{ Date = new DateTime(2013, 5, 13), EMA12Day = 447.023916m , EMA26Day = 438.5155097m, MACD = 8.508406323m, Signal = 4.856650871m , Histogram = 3.651755452m },
                new MACDData{ Date = new DateTime(2013, 5, 14), EMA12Day = 446.5371597m, EMA26Day = 438.9113978m, MACD = 7.625761844m, Signal = 5.410473066m , Histogram = 2.215288778m },
                new MACDData{ Date = new DateTime(2013, 5, 15), EMA12Day = 443.8160582m, EMA26Day = 438.1661091m, MACD = 5.649949083m, Signal = 5.458368269m , Histogram = 0.191580814m },
                new MACDData{ Date = new DateTime(2013, 5, 16), EMA12Day = 442.3951262m, EMA26Day = 437.9004714m, MACD = 4.494654765m, Signal = 5.265625568m , Histogram = -0.770970803m},
                new MACDData{ Date = new DateTime(2013, 5, 17), EMA12Day = 440.9897221m, EMA26Day = 437.5567328m, MACD = 3.432989362m, Signal = 4.899098327m , Histogram = -1.466108965m},
                new MACDData{ Date = new DateTime(2013, 5, 20), EMA12Day = 441.2882264m, EMA26Day = 437.9547526m, MACD = 3.333473854m, Signal = 4.585973432m , Histogram = -1.252499579m},
                new MACDData{ Date = new DateTime(2013, 5, 21), EMA12Day = 441.0377301m, EMA26Day = 438.0810672m, MACD = 2.956662856m, Signal = 4.260111317m , Histogram = -1.303448461m},
                new MACDData{ Date = new DateTime(2013, 5, 22), EMA12Day = 441.0857716m, EMA26Day = 438.3232104m, MACD = 2.762561216m, Signal = 3.960601297m , Histogram = -1.198040081m}
            };

            #endregion
            var expectedLast = expected.Last();
            var calculatedLast = calculated.Last();
            Assert.Equal(expectedLast.EMA12Day, calculatedLast.EMA12Day);
            Assert.Equal(expectedLast.EMA26Day, calculatedLast.EMA26Day);
            Assert.Equal(expectedLast.MACD, calculatedLast.MACD);
            Assert.Equal(expectedLast.Signal, calculatedLast.Signal);
            Assert.Equal(expectedLast.Histogram, calculatedLast.Histogram);
        }
    }
}

