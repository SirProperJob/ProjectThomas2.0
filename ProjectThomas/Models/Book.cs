using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectThomas.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Range")]
        public string Type { get; set; }
        public bool Owned { get; set; }
        [Display(Name = "Read")]
        public bool ReadIt { get; set; }
    }
}
