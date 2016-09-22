namespace InvSys.Gateway.Core.Models
{
    public class DashboardCompany
    {
        public string Symbol { get; set; }

        public string Name { get; set; }
        public string Logo { get; set; }
        public string Industry { get; set; }

        public bool? IsAwesome { get; set; }
    }
}
