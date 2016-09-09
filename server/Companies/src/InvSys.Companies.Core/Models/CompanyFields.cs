using System;

namespace InvSys.Companies.Core.Models
{
    [Flags]
    public enum CompanyFields
    {
        Name = 1,
        Symbol = 2,
        Description = 4
    }
}
