using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectThomas.Data;
using ProjectThomas.Models;

namespace ProjectThomas.Pages.Legos
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ProjectThomas.Data.ApplicationDbContext _context;

        public EditModel(ProjectThomas.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegoExists(Lego.LegoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LegoExists(int id)
        {
            return _context.Lego.Any(e => e.LegoId == id);
        }
    }
}
