using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniSearch.Models
{
    public class SearchResultViewModel
    {
        public string EntityMatch { get; set; }
        public string HeaderFollowText { get; set; }
        public string Link { get; set; }
        public string LeadText { get; set; }
        public DateTime Stamp { get; set; }
    }
}
