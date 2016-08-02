using InvSys.Companies.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvSys.Companies.State.EntityFramework.Seed
{
    public class CompaniesContextSeedData
    {
        private readonly CompaniesContext _dbContext;
        public CompaniesContextSeedData(CompaniesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EnsureSeedData()
        {
            if (!_dbContext.Companies.Any())
            {
                var company = new Company
                {
                    Id = Guid.NewGuid(),
                    Symbol = "MENT",
                    Name = "Mentor Graphics Corporation",
                    Translations = new List<CompanyTranslation>
                    {
                        new CompanyTranslation
                        {
                            Culture = "en-US",
                            Description = "Mentor Graphics Corporation provides electronic design automation software and hardware solutions to design, analyze, and test electro-mechanical systems, electronic hardware, and embedded systems software worldwide. It offers printed circuit boards; Mentor Graphics Scalable Verification tools; Questa platform to verify systems and integrated circuits (ICs); FastSPICE, Eldo, and ADVance MS analog/mixed signal simulation tools; and Veloce hardware emulation system. The company also provides Calibre DRC and Calibre LVS-H physical verification tools; Calibre xRC and xACT transistor-level extraction and device modeling tools; Calibre resolution enhancement technology tools; Calibre OPCverify tool to check and report the mask pattern corrections; Calibre RET tools; Calibre LFD for manufacturing (DFM) area; Calibre CMPAnalyzer tool; Calibre MPCpro for systematic errors; Calibre nmMPC; Calibre PERC to check electrical design of an IC; Tessent suite of integrated silicon test products; Olympus-SoC place and route product; Calibre InRoute design and verification platform; and Oasys-RTL tool. In addition, it offers PCB-FPGA Systems Design software; products for DFM and manufacturing execution systems; FloEFD three-dimensional computational fluid dynamics and heat transfer analysis tool; FloTHERM three-dimensional computational fluid dynamics software; Flowmaster one-dimensional computational fluid dynamics analysis software; and MicReD T3Ster temperature measurement system. Further, the company provides software, tools, and professional engineering services; and methodology development, enterprise integration, and deployment services. It sells and licenses its products through direct sales force, distributors, and sales representatives to the communications, computer, consumer electronics, semiconductor, networking, multimedia, military and aerospace, and transportation industries. Mentor Graphics Corporation was founded in 1981 and is headquartered in Wilsonville, Oregon."
                        }
                    }
                };
                _dbContext.Companies.Add(company);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
