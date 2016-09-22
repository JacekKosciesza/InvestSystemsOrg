namespace InvSys.Gateway.Core.Models
{
    public class DashboardCompany
    {
        // Summary
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Industry { get; set; }

        // Rule #1 rating
        public bool? IsWonderful { get; set; }
    }
}
