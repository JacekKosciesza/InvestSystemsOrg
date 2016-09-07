using InvSys.Companies.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace InvSys.Companies.Api.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Culture { get; set; }
        public string Exchange { get; set; }

        [Required]
        public string Symbol { get; set; }
        [Required]
        public string Name { get; set; }
        public Logo Logo { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

        public Sector Sector { get; set; }
        public Subsector Subsector { get; set; }
        public Industry Industry { get; set; }

        public DateTime? IPODate { get; set; }
        public string MarketValue { get; set; }
        public string Country { get; set; }
    }
}
