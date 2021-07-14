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
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ProjectThomas.Data.ApplicationDbContext _context;

        public DeleteModel(ProjectThomas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lego Lego { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lego = await _context.Lego.FirstOrDefaultAsync(m => m.LegoId == id);

            if (Lego == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lego = await _context.Lego.FindAsync(id);

            if (Lego != null)
            {
                _context.Lego.Remove(Lego);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
