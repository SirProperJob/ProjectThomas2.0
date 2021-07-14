using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectThomas.ViewModel
{
    public class LegoSummary
    {
        public string Range { get; set; }
        [Display(Name = "Total")]
        public int TotalCount { get; set; }
        [Display(Name = "Owned")]
        public int OwnedCount { get; set; }
    }
}
