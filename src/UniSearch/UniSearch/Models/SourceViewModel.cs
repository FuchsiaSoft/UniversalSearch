using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniSearch.Models
{
    public class SourceViewModel
    {
        public string Name { get; set; }
        public string LeadText { get; set; }
        public string IconUrl { get; set; }
        public List<SearchResultViewModel> Results { get; set; } = new List<SearchResultViewModel>();
    }
}
