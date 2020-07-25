using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Models
{
    public class Paging
    {
        public int Page { get; set; }
        public int PageLimit { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public Paging(int page, int pageLimit, int totalPages, int totalItems)
        {
            Page = page;
            PageLimit = pageLimit;
            TotalPages = totalPages;
            TotalItems = totalItems;
        }
    }
}
