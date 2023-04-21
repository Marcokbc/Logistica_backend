using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Domain.Pagination
{
    public class PaginatedResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}
