namespace InvSys.Shared.Core.Model
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public class Sorter
    {
        public string SortBy { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}
