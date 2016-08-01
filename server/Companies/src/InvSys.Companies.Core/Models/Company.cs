using System;

namespace InvSys.Companies.Core.Model
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
