using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using InvSys.Companies.Core.State;
using System.Threading.Tasks;
using InvSys.Companies.Core.Models;

namespace InvSys.Companies.Core.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ISubsectorsRepository _subsectorsRepository;
        private readonly IIndustriesRepository _industriesRepository;
        private readonly ISectorsRepository _sectorsRepository;

        public CompaniesService(ICompaniesRepository companiesRepository, ISubsectorsRepository subsectorsRepository, IIndustriesRepository industriesRepository, ISectorsRepository sectorsRepository)
        {
            _companiesRepository = companiesRepository;
            _subsectorsRepository = subsectorsRepository;
            _industriesRepository = industriesRepository;
            _sectorsRepository = sectorsRepository;

        }

        public async Task<Company> AddCompany(Company company)
        {
            company.Sector = await CreateSectorIfDoesNotExist(company.Sector);
            company.Subsector = await CreateSubsectorIfDoesNotExist(company.Sector, company.Subsector);
            company.Industry = await CreateIndustryIfDoesNotExist(company.Subsector.Id, company.Industry);

            var addedCompany = _companiesRepository.Add(company);
            if (await _companiesRepository.SaveChangesAsync())
            {
                return addedCompany;
            } else
            {
                return null;
            }
        }

        public async Task<bool> DeleteCompany(Guid id)
        {
            _companiesRepository.Delete(id);
            return await _companiesRepository.SaveChangesAsync();
        }

        public async Task<ICollection<Company>> GetCompanies()
        {
            return await _companiesRepository.GetAll();
        }

        public async Task<Company> GetCompany(Guid id)
        {
            return await _companiesRepository.Get(id);
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _companiesRepository.Update(company);
            if (await _companiesRepository.SaveChangesAsync())
            {
                return company;
            }
            else
            {
                return null;
            }
        }

        private async Task<Sector> CreateSectorIfDoesNotExist(Sector companySector)
        {
            if (companySector == null)
            {
                companySector = new Sector
                {
                    Translations = new List<SectorTranslation>
                    {
                        new SectorTranslation
                        {
                            Culture = CultureInfo.CurrentCulture.Name,
                            Name = "Other"
                        }
                    }
                };
            }
            Sector sector = null;
            var sectorTranslation = companySector.Translations.FirstOrDefault();
            if (sectorTranslation != null)
            {
                sector = await _sectorsRepository.GetSectorByName(sectorTranslation.Culture, sectorTranslation.Name);
            }
            if (sector == null)
            {
                companySector.Id = Guid.NewGuid();
                _sectorsRepository.Add(companySector);
                await _sectorsRepository.SaveChangesAsync();
                return companySector;
            }
            else
            {
                return sector;
            }
        }

        private async Task<Subsector> CreateSubsectorIfDoesNotExist(Sector sector, Subsector companySubsector)
        {
            if (companySubsector == null)
            {
                companySubsector = new Subsector
                {
                    Translations = new List<SubsectorTranslation>
                    {
                        new SubsectorTranslation
                        {
                            Culture = sector.Translations.FirstOrDefault().Culture,
                            Name = sector.Translations.FirstOrDefault().Name,
                        }
                    }
                };
            }
            Subsector subsector = null;
            var sectorTranslation = companySubsector.Translations.FirstOrDefault();
            if (sectorTranslation != null)
            {
                subsector = await _subsectorsRepository.GetSubsectorByName(sectorTranslation.Culture, sectorTranslation.Name);
            }
            if (subsector == null)
            {
                companySubsector.Id = Guid.NewGuid();
                companySubsector.SectorId = sector.Id;
                _subsectorsRepository.Add(companySubsector);
                await _subsectorsRepository.SaveChangesAsync();
                return companySubsector;
            }
            else
            {
                return subsector;
            }
        }

        private async Task<Industry> CreateIndustryIfDoesNotExist(Guid subsectorId, Industry companyIndustry)
        {
            if (companyIndustry == null)
            {
                return null;
            }
            Industry industry = null;
            var industryTranslation = companyIndustry.Translations.FirstOrDefault();
            if (industryTranslation != null)
            {
                industry = await _industriesRepository.GetIndustryByName(industryTranslation.Culture, industryTranslation.Name);
            }
            if (industry == null)
            {
                companyIndustry.Id = Guid.NewGuid();
                companyIndustry.SubsectorId = subsectorId;
                _industriesRepository.Add(companyIndustry);
                await _industriesRepository.SaveChangesAsync();
                return companyIndustry;
            }
            else
            {
                return industry;
            }
        }
    }
}
