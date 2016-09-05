using System;
using System.Collections.Generic;
using System.Linq;
using InvSys.Companies.Core.State;
using System.Threading.Tasks;
using InvSys.Companies.Core.Models;

namespace InvSys.Companies.Core.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IIndustriesRepository _industriesRepository;
        private readonly ISectorsRepository _sectorsRepository;
        private readonly ISubsectorsRepository _subsectorsRepository;

        public CompaniesService(ICompaniesRepository companiesRepository, IIndustriesRepository industriesRepository, ISectorsRepository sectorsRepository, ISubsectorsRepository subsectorsRepository)
        {
            _companiesRepository = companiesRepository;
            _industriesRepository = industriesRepository;
            _sectorsRepository = sectorsRepository;
            _subsectorsRepository = subsectorsRepository;
        }

        public async Task<Company> AddCompany(Company company)
        {
            company.Industry = await CreateIndustryIfDoesNotExist(company.Industry);
            company.Sector = await CreateSectorIfDoesNotExist(company.Industry.Id, company.Sector);
            company.Subsector = await CreateSubsectorIfDoesNotExist(company.Sector.Id, company.Subsector);

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

        private async Task<Industry> CreateIndustryIfDoesNotExist(Industry companyIndustry)
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
                _industriesRepository.Add(companyIndustry);
                await _industriesRepository.SaveChangesAsync();
                return companyIndustry;
            }
            else
            {
                return industry;
            }
        }

        private async Task<Sector> CreateSectorIfDoesNotExist(Guid industryId, Sector companySector)
        {
            if (companySector == null)
            {
                return null;
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
                companySector.IndustryId = industryId;
                _sectorsRepository.Add(companySector);
                await _sectorsRepository.SaveChangesAsync();
                return companySector;
            }
            else
            {
                return sector;
            }
        }

        private async Task<Subsector> CreateSubsectorIfDoesNotExist(Guid sectorId, Subsector companySubsector)
        {
            if (companySubsector == null)
            {
                return null;
            }
            Subsector sector = null;
            var subsectorTranslation = companySubsector.Translations.FirstOrDefault();
            if (subsectorTranslation != null)
            {
                sector = await _subsectorsRepository.GetSubsectorByName(subsectorTranslation.Culture, subsectorTranslation.Name);
            }
            if (sector == null)
            {
                companySubsector.Id = Guid.NewGuid();
                companySubsector.SectorId = sectorId;
                _subsectorsRepository.Add(companySubsector);
                await _subsectorsRepository.SaveChangesAsync();
                return companySubsector;
            }
            else
            {
                return sector;
            }
        }
    }
}
