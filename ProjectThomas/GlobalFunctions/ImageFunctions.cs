using ProjectThomas.Data;
using ProjectThomas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectThomas.GlobalFunctions
{
    public class ImageFunctions
    {
        public CarouselImage GetRandomImg(ApplicationDbContext _context, int img1 = -1, int img2 = -1, int img3 = -1)
        {
            CarouselImage ci;
            if (img1 == -1)
            {
                ci = _context.CarouselImage.OrderBy(x => Guid.NewGuid()).First();
                return ci;
            }
            else if (img2 == -1)
            {
                do
                {
                    ci = _context.CarouselImage.OrderBy(x => Guid.NewGuid()).First();
                } while (ci.CarouselImageId == img1);
                return ci;
            }
            else if (img3 == -1)
            {
                do
                {
                    ci = _context.CarouselImage.OrderBy(x => Guid.NewGuid()).First();
                } while (ci.CarouselImageId == img1 || ci.CarouselImageId == img2);
                return ci;
            }
            else
            {

                do
                {
                    ci = _context.CarouselImage.OrderBy(x => Guid.NewGuid()).First();
                } while (ci.CarouselImageId == img1 || ci.CarouselImageId == img2 || ci.CarouselImageId == img3);
                return ci;

            }
        }
    }
}
