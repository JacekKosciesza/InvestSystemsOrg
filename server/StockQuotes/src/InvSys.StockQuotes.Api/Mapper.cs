using AutoMapper;
using InvSys.StockQuotes.Core.Models;
using YahooFinance.NET;

namespace InvSys.StockQuotes.Api
{
    public static class Mapper
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<YahooHistoricalPriceData, HistoricalQuote>(MemberList.Source);

            // Generic configuration
            config.AllowNullCollections = true;
        }
    }
}
