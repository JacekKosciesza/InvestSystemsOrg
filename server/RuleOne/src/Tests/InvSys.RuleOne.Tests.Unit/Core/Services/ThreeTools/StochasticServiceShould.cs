using System;
using System.Collections.Generic;
using InvSys.RuleOne.Core.Services;
using InvSys.RuleOne.Core.Services.ThreeTools;
using InvSys.StockQuotes.Api.Client.Proxy.Models;
using Xunit;

namespace InvSys.RuleOne.Tests.Unit.Core.Services.ThreeTools
{
    public class StochasticServiceShould
    {
        [Fact]
        public void CalculateCorrectStochasticData()
        {
            // Arrange
            #region Prices
            var prices = new List<HistoricalQuote>
            {
                new HistoricalQuote{ Date = new DateTime(2013, 4, 22), Open = 1555.25, High = 1565.55, Low = 1548.19, Close = 1562.5},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 23), Open = 1562.5,  High =1579.58, Low = 1562.5, Close =1578.78},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 24), Open = 1578.78, High = 1583, Low = 1575.8, Close = 1578.79},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 25), Open = 1578.93, High = 1592.64, Low = 1578.93, Close =1585.16},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 26), Open = 1585.16, High = 1585.78, Low = 1577.56, Close =1582.24},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 29), Open = 1582.34, High = 1596.65, Low = 1582.34, Close =1593.61},
                new HistoricalQuote{ Date = new DateTime(2013, 4, 30), Open = 1593.58, High = 1597.57, Low = 1586.5, Close =1597.57},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 1 ), Open = 1597.55, High = 1597.55, Low = 1581.28, Close =1582.7},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 2 ), Open = 1582.77, High = 1598.6, Low = 1582.77, Close =1597.59},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 3 ), Open = 1597.6,  High =1618.46, Low = 1597.6, Close =1614.42},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 6 ), Open = 1614.4,  High =1619.77, Low = 1614.21, Close =1617.5},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 7 ), Open = 1617.55, High = 1626.03, Low = 1616.64, Close =1625.96},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 8 ), Open = 1625.95, High = 1632.78, Low = 1622.7, Close =1632.69},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 9 ), Open = 1632.69, High = 1635.01, Low = 1623.09, Close =1626.67},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 10), Open = 1626.69, High = 1633.7, Low = 1623.71, Close =1633.7},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 13), Open = 1632.1,  High =1636, Low = 1626.74, Close =1633.77},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 14), Open = 1633.75, High = 1651.1, Low = 1633.75, Close =1650.34},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 15), Open = 1649.13, High = 1661.49,Low =  1646.68, Close =1658.78},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 16), Open = 1658.07, High = 1660.51,Low =  1648.6, Close =1650.47},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 17), Open = 1652.45, High = 1667.47,Low =  1652.45,Close = 1667.47},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 20), Open = 1665.71, High = 1672.84,Low =  1663.52,Close = 1666.29},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 21), Open = 1666.2,  High =1674.93, Low = 1662.67, Close =1669.16},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 22), Open = 1669.39, High = 1687.18,Low =  1648.86,Close = 1655.35},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 23), Open = 1651.62, High = 1655.5, Low = 1635.53, Close =1650.51},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 24), Open = 1646.67, High = 1649.78, Low = 1636.88,Close = 1649.6},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 28), Open = 1652.63, High = 1674.21, Low = 1652.63,Close = 1660.06},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 29), Open = 1656.57, High = 1656.57, Low = 1640.05,Close = 1648.36},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 30), Open = 1649.14, High = 1661.91, Low = 1648.61,Close = 1654.41},
                new HistoricalQuote{ Date = new DateTime(2013, 5, 31), Open = 1652.13, High = 1658.99, Low = 1630.74,Close = 1630.74},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 3 ), Open = 1631.71, High = 1640.42, Low = 1622.72,Close = 1640.42},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 4 ), Open = 1640.73, High = 1646.53, Low = 1623.62,Close = 1631.38},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 5 ), Open = 1629.05, High = 1629.31, Low = 1607.09,Close = 1608.9},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 6 ), Open = 1609.29, High = 1622.56, Low = 1598.23,Close = 1622.56},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 7 ), Open = 1625.27, High = 1644.4, Low = 1625.27, Close =1643.38},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 10), Open = 1644.67, High = 1648.69, Low = 1639.26,Close = 1642.81},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 11), Open = 1638.64, High = 1640.13, Low = 1622.92,Close = 1626.13},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 12), Open = 1629.94, High = 1637.71, Low = 1610.92,Close = 1612.52},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 13), Open = 1612.15, High = 1639.25, Low = 1608.07,Close = 1636.36},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 14), Open = 1635.52, High = 1640.8, Low = 1623.96, Close =1626.73},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 17), Open = 1630.64, High = 1646.5, Low = 1630.34, Close =1639.04},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 18), Open = 1639.77, High = 1654.19, Low = 1639.77,Close = 1651.81},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 19), Open = 1651.83, High = 1652.45, Low = 1628.91,Close = 1628.93},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 20), Open = 1624.62, High = 1624.62, Low = 1584.32,Close = 1588.19},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 21), Open = 1588.62, High = 1599.19, Low = 1577.7, Close =1592.43},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 24), Open = 1588.77, High = 1588.77, Low = 1560.33,Close = 1573.09},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 25), Open = 1577.52, High = 1593.79, Low = 1577.09,Close = 1588.03},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 26), Open = 1592.27, High = 1606.83, Low = 1592.27,Close = 1603.26},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 27), Open = 1606.44, High = 1620.07, Low = 1606.44,Close = 1613.2},
                new HistoricalQuote{ Date = new DateTime(2013, 6, 28), Open = 1611.12, High = 1615.94, Low = 1601.06,Close = 1606.28},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 1 ), Open = 1609.78, High = 1626.61, Low = 1609.78,Close = 1614.96},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 2 ), Open = 1614.29, High = 1624.26, Low = 1606.77,Close = 1614.08},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 3 ), Open = 1611.48, High = 1618.97, Low = 1604.57,Close = 1615.41},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 5 ), Open = 1618.65, High = 1632.07, Low = 1614.71,Close = 1631.89},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 8 ), Open = 1634.2,  High =1644.68, Low = 1634.2, Close =1640.46},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 9 ), Open = 1642.89, High = 1654.18, Low = 1642.89, Close =1652.32},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 10), Open = 1651.56, High = 1657.92, Low = 1647.66, Close =1652.62},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 11), Open = 1657.41, High = 1676.63, Low = 1657.41, Close =1675.02},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 12), Open = 1675.26, High = 1680.19, Low = 1672.33, Close =1680.19},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 15), Open = 1679.59, High = 1684.51, Low = 1677.89, Close =1682.5},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 16), Open = 1682.7,  High =1683.73, Low = 1671.84, Close =1676.26},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 17), Open = 1677.91, High = 1684.75, Low = 1677.91,Close = 1680.91},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 18), Open = 1681.05, High = 1693.12, Low = 1681.05,Close = 1689.37},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 19), Open = 1686.15, High = 1692.09, Low = 1684.08,Close = 1692.09},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 22), Open = 1694.41, High = 1697.61, Low = 1690.67,Close = 1695.53},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 23), Open = 1696.63, High = 1698.78, Low = 1691.13,Close = 1692.39},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 24), Open = 1696.06, High = 1698.38, Low = 1682.57,Close = 1685.94},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 25), Open = 1685.21, High = 1690.94, Low = 1680.07,Close = 1690.25},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 26), Open = 1687.31, High = 1691.85, Low = 1676.03,Close = 1691.65},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 29), Open = 1690.32, High = 1690.92, Low = 1681.86,Close = 1685.33},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 30), Open = 1687.92, High = 1693.19, Low = 1682.42,Close = 1685.96},
                new HistoricalQuote{ Date = new DateTime(2013, 7, 31), Open = 1687.76, High = 1698.43, Low = 1684.94,Close = 1685.73},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 1 ), Open = 1689.42, High = 1707.85, Low = 1689.42,Close = 1706.87},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 2 ), Open = 1706.1,  High =1709.67, Low = 1700.68, Close =1709.67},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 5 ), Open = 1708.01, High = 1709.24, Low = 1703.55,Close = 1707.14},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 6 ), Open = 1705.79, High = 1705.79, Low = 1693.29,Close = 1697.37},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 7 ), Open = 1695.3,  High =1695.3, Low = 1684.91, Close =1690.91},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 8 ), Open = 1693.35, High = 1700.18, Low = 1688.38,Close = 1697.48},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 9 ), Open = 1696.1,  High =1699.42, Low = 1686.02, Close =1691.42},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 12), Open = 1688.37, High = 1691.49, Low = 1683.35, Close =1689.47},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 13), Open = 1690.65, High = 1696.81, Low = 1682.62, Close =1694.16},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 14), Open = 1693.88, High = 1695.52, Low = 1684.83, Close =1685.39},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 15), Open = 1679.61, High = 1679.61, Low = 1658.59, Close =1661.32},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 16), Open = 1661.22, High = 1663.6, Low = 1652.61, Close =1655.83},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 19), Open = 1655.25, High = 1659.18, Low = 1645.84,Close = 1646.06},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 20), Open = 1646.81, High = 1658.92, Low = 1646.08,Close = 1652.35},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 21), Open = 1650.66, High = 1656.99, Low = 1639.43,Close = 1642.8},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 22), Open = 1645.03, High = 1659.55, Low = 1645.03,Close = 1656.96},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 23), Open = 1659.92, High = 1664.85, Low = 1654.81,Close = 1663.5},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 26), Open = 1664.29, High = 1669.51, Low = 1656.02,Close = 1656.78},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 27), Open = 1652.54, High = 1652.54, Low = 1629.05,Close = 1630.48},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 28), Open = 1630.25, High = 1641.18, Low = 1627.47,Close = 1634.96},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 29), Open = 1633.5,  High =1646.41, Low = 1630.88, Close =1638.17},
                new HistoricalQuote{ Date = new DateTime(2013, 8, 30), Open = 1638.89, High = 1640.08, Low = 1628.05,Close = 1632.97},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 3 ), Open = 1635.95, High = 1651.35, Low = 1633.41,Close = 1639.77},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 4 ), Open = 1640.72, High = 1655.72, Low = 1637.41,Close = 1653.08},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 5 ), Open = 1653.28, High = 1659.17, Low = 1653.07,Close = 1655.08},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 6 ), Open = 1657.44, High = 1664.83, Low = 1640.62,Close = 1655.17},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 9 ), Open = 1656.85, High = 1672.4, Low = 1656.85, Close =1671.71},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 10), Open = 1675.11, High = 1684.09, Low = 1675.11,Close = 1683.99},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 11), Open = 1681.04, High = 1689.13, Low = 1678.7, Close =1689.13},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 12), Open = 1689.21, High = 1689.97, Low = 1681.96,Close = 1683.42},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 13), Open = 1685.04, High = 1688.73, Low = 1682.22,Close = 1687.99},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 16), Open = 1691.7,  High =1704.95, Low = 1691.7, Close = 1697.6},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 17), Open = 1697.73, High = 1705.52, Low = 1697.73, Close =1704.76},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 18), Open = 1705.74, High = 1729.44, Low = 1700.35, Close =1725.52},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 19), Open = 1727.34, High = 1729.86, Low = 1720.2, Close =1722.34},
                new HistoricalQuote{ Date = new DateTime(2013, 9, 20), Open = 1722.44, High = 1725.23, Low = 1708.89, Close =1709.91}
            };
            #endregion
            IStochasticService stochasticService = new StochasticService();

            // Act
            var output = stochasticService.Calculate(prices, 14, 3); // 14, 3 not 14, 5 because test data is for 14, 3

            // Assert
        }
    }
}

