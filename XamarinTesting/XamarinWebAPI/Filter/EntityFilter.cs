using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinWebAPI.Filter
{
    public class EntityFilter
    {
        public string EntityID { get; set; }
        public string SearchQuery { get; set; }
        public string SortByParam { get; set; }
        public string SortByMethod { get; set; }
    }
}
