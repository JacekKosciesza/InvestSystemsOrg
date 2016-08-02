using System;
using System.ComponentModel.DataAnnotations;

namespace InvSys.Companies.Api.Model
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Culture { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Symbol { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(3000, MinimumLength = 20)]
        public string Description { get; set; }
    }
}
