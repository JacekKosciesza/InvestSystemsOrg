using System;
using System.ComponentModel.DataAnnotations;

namespace InvSys.Email.Api.Models
{
    public class Template
    {
        public Guid Id { get; set; }
        public string Culture { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        [StringLength(3000, MinimumLength = 20)]
        public string Description { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
