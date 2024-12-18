using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Common
{
    public class PagedData<T> where T : class
    {
        public int TotalRows { get; set; }
        public IEnumerable<T>? Rows { get; set; }
    }
}
