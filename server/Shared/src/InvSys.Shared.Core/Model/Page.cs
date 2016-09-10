using System.Collections.Generic;

namespace InvSys.Shared.Core.Model
{
    public class Page<T> where T: class
    {
        public ICollection<T> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsCount { get; set; }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
