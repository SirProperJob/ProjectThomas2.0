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

namespace ProjectThomas.Pages.Books
{
    [Authorize(Roles = "Admin,Member")]
    public class IndexModel : PageModel
    {
        private readonly ProjectThomas.Data.ApplicationDbContext _context;
        public int OwnedCount { get; set; }
        public int ReadCount { get; set; }

        public IndexModel(ProjectThomas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }


        public async Task OnGetAsync()
        {

            var books = from b in _context.Book
                        select b;

            OwnedCount = books.Where(b => b.Owned == true).Count();
            ReadCount = books.Where(b => b.ReadIt == true).Count();
            Book = await books.ToListAsync();
        }
    }
}
