using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectThomas.Models
{
    public class Lego
    {
        public int LegoId { get; set; }
        [Display(Name = "Theme")]
        public string Range { get; set; }
        public long Number { get; set; }
        public string Name { get; set; }
        [Display(Name = "Number of Pieces")]
        public long NumPieces { get; set; }
        public bool Owned { get; set; }
    }
}
