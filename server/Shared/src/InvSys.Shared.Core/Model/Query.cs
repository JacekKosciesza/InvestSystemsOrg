namespace InvSys.Shared.Core.Model
{
    public class Query
    {
        public int Page { get; set; } = 1;
        public int? Display { get; set; }
        public string OrderBy { get; set; }
        public string Q { get; set; } // search query
    }
}
