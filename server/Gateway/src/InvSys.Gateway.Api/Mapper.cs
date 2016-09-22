using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using InvSys.Companies.Api.Client.Proxy.Models;
using InvSys.Gateway.Core.Models;
using InvSys.Shared.Core.Model;

namespace InvSys.Gateway.Api
{
    public static class Mapper
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            // Company
            config.CreateMap<Company, DashboardCompany>(MemberList.Destination);

            // Page of Company
            config.CreateMap<PageCompany, Page<DashboardCompany>>();

            // Generic configuration
            config.AllowNullCollections = true;
        }
    }
}
