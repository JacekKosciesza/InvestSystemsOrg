using AutoMapper;
using InvSys.RuleOne.Api.Models;

namespace InvSys.RuleOne.Api
{
    public static class Mapper
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<Core.Models.ThreeTools.EMAData, EMAData>(MemberList.Destination);
            config.CreateMap<Core.Models.ThreeTools.MACDData, MACDData>(MemberList.Destination);
            config.CreateMap<Core.Models.ThreeTools.StochasticData, StochasticData>(MemberList.Destination);
        }
    }
}
