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
                .ForMember(d => d.Translations, opt => opt.MapFrom(s => new List<Core.Models.CompanyTranslation> { new Core.Models.CompanyTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Description = s.Description, Address = s.Address, Website = s.Website } }));
            config.CreateMap<Core.Models.Company, Company>()
                .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Culture))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Description))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Address))
                .ForMember(d => d.Website, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Website));

            // Page of Company
            config.CreateMap<Page<Core.Models.Company>, Page<Company>>();

            // Sector
            config.CreateMap<Sector, Core.Models.Sector>()
                .ForMember(d => d.Translations, opt => opt.MapFrom(s => new List<Core.Models.SectorTranslation> { new Core.Models.SectorTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Name = s.Name, Description = s.Description } }));
            config.CreateMap<Core.Models.Sector, Sector>()
                .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Culture))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Description));

            // Subsector
            config.CreateMap<Subsector, Core.Models.Subsector>()
                .ForMember(d => d.Translations, opt => opt.MapFrom(s => new List<Core.Models.SubsectorTranslation> { new Core.Models.SubsectorTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Name = s.Name, Description = s.Description } }));
            config.CreateMap<Core.Models.Subsector, Subsector>()
                .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Culture))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Description));

            // Industry
            config.CreateMap<Industry, Core.Models.Industry>()
                .ForMember(d => d.Translations, opt => opt.MapFrom(s => new List<Core.Models.IndustryTranslation> { new Core.Models.IndustryTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Name = s.Name, Description = s.Description } }));
            config.CreateMap<Core.Models.Industry, Industry>()
                .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Culture))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Description));

            // Generic configuration
            config.AllowNullCollections = true;
        }
    }
}
