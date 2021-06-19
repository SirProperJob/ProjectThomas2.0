using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectThomas.ViewModel;

namespace ProjectThomas.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ProjectThomas.Data.ApplicationDbContext _context;
        public IndexModel(ProjectThomas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BookSummary> BookSummary { get; set; }

        public void OnGet()
        {
            var q = from b in _context.Book
                    group b by b.Type into g
                    select new BookSummary
                    {
                        Range = g.Key,
                        TotalCount = g.Count(),
                        OwnedCount = g.Where(o => o.Owned == true).Count(),
                        ReadCount = g.Where(o => o.ReadIt == true).Count(),
                    };

            BookSummary = q.ToList();
        }
    }
}
