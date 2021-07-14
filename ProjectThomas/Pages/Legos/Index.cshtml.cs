using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectThomas.Data;
using ProjectThomas.Models;

namespace ProjectThomas.Pages.Legos
{
    [Authorize(Roles = "Admin,Member")]
    public class IndexModel : PageModel
    {
        private readonly ProjectThomas.Data.ApplicationDbContext _context;
        public int OwnedCount { get; set; }

        public IndexModel(ProjectThomas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Lego> Lego { get;set; }

        public async Task OnGetAsync()
        {
            var legos = from l in _context.Lego
                        select l;

            OwnedCount = legos.Where(l => l.Owned == true).Count();
            Lego = await legos.ToListAsync();
        }
    }
}
