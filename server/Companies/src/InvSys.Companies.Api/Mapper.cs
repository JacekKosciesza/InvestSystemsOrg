using AutoMapper;
using InvSys.Companies.Api.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using InvSys.Shared.Core.Model;

namespace InvSys.Companies.Api
{
    public static class Mapper
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            // Company
            config.CreateMap<Company, Core.Models.Company>()
                .ForMember(d => d.Translations, opt => opt.MapFrom(s => new List<Core.Models.CompanyTranslation> { new Core.Models.CompanyTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Description = s.Description, Address = s.Address, Website = s.Website, Sector = s.Sector, Subsector = s.Subsector, Industry = s.Industry} }));
            config.CreateMap<Core.Models.Company, Company>()
                .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Culture))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Description))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Address))
                .ForMember(d => d.Website, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Website))
                .ForMember(d => d.Sector, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Sector))
                .ForMember(d => d.Subsector, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Subsector))
                .ForMember(d => d.Industry, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Industry));

            // Page of Company
            config.CreateMap<Page<Core.Models.Company>, Page<Company>>();

            // Generic configuration
            config.AllowNullCollections = true;
        }
    }
}
