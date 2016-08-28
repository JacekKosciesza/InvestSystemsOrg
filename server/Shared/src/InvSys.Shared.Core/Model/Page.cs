using System.Collections.Generic;

namespace InvSys.Shared.Core.Model
{
    public class Page<T> where T: class
    {
        public ICollection<T> Items { get; set; }
        public uint TotalPages { get; set; }
        public uint CurrentPage { get; set; }
        public uint ItemsPerPage { get; set; }
    }
}
