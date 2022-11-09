using System;
using System.Collections.Generic;
using System.Text;

namespace MeasurementRetriever.Common.Pagination
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public ICollection<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }


     
    }
}
