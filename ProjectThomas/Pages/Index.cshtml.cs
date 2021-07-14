using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectThomas.GlobalFunctions;
using ProjectThomas.Models;
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
        public IList<BookSummary> SeriesSummary { get; set; }
        public IList<LegoSummary> LegoSummary { get; set; }
        public CarouselImage img1 { get; set; }
        public CarouselImage img2 { get; set; }
        public CarouselImage img3 { get; set; }
        public CarouselImage img4 { get; set; }

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

            var sq = from b in _context.Book
                    group b by b.Series into g
                    select new BookSummary
                    {
                        Range = g.Key,
                        TotalCount = g.Count(),
                        OwnedCount = g.Where(o => o.Owned == true).Count(),
                        ReadCount = g.Where(o => o.ReadIt == true).Count(),
                    };

            SeriesSummary = sq.ToList();

            var lq = from l in _context.Lego
                     group l by l.Range into g
                     select new LegoSummary
                     {
                         Range = g.Key,
                         TotalCount = g.Count(),
                         OwnedCount = g.Where(o => o.Owned == true).Count()
                     };

            LegoSummary = lq.ToList();


            ImageFunctions imgFunc = new ImageFunctions();

            img1 = imgFunc.GetRandomImg(_context);
            img2 = imgFunc.GetRandomImg(_context, img1.CarouselImageId);
            img3 = imgFunc.GetRandomImg(_context, img1.CarouselImageId, img2.CarouselImageId);
            img4 = imgFunc.GetRandomImg(_context, img1.CarouselImageId, img2.CarouselImageId, img3.CarouselImageId);

        }
    }
}
