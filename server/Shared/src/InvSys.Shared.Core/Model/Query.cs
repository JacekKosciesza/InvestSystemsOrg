namespace InvSys.Shared.Core.Model
{
    public class Query
    {
        public Query()
        {
            Filter = new Filter();
            Sorter = new Sorter();
        }

        public Filter Filter { get; set; }
        public Sorter Sorter { get; set; }
        public Searcher Searcher { get; set; }
    }
}
