namespace InvSys.Companies.Core.Models
{
    public class Officer
    {
        public int Id { get; set; }
        public OfficerType Type { get; set; }
        public string Name { get; set; }
    }

    public enum OfficerType
    {
        ChiefExecutiveOfficer,
        ChiefFinancialOfficer
    }
}
