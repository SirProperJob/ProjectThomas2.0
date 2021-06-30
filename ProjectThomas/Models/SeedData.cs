using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectThomas.Data;
using System;
using System.Linq;

namespace ProjectThomas.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (!context.Book.Any())
                {
                    context.Book.AddRange(
                     new Book
                     {
                         Series = "Mr Men",
                         Title = "Mr Tickle",
                         Type = "Mr Men",
                         Owned = true
                     },

                     new Book
                     {
                         Series = "Mr Men",
                         Title = "Mr Greedy",
                         Type = "Mr Men",
                         Owned = true
                     },

                     new Book
                     {
                         Series = "Mr Men",
                         Title = "Mr Happy",
                         Type = "Mr Men",
                         Owned = true
                     },

                     new Book
                     {
                         Series = "Mr Men",
                         Title = "Mr Nosey",
                         Type = "Mr Men",
                         Owned = true
                     }
                 );
                 
                    context.SaveChanges();

                }

                if (!context.CarouselImage.Any())
                {
                    context.CarouselImage.AddRange(
                     new CarouselImage
                     {
                         UrlString = "/images/MrMen/MrHappy.jpg",
                         altString = "MrHappy"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/MrMen/MrGreedy.jpg",
                         altString = "MrGreedy"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/MrMen/MrNosey.jpg",
                         altString = "MrNosey"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/MrMen/MrTickle.jpg",
                         altString = "MrTickle"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/BeastQuest/Arcta.jpg",
                         altString = "Arcta"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/BeastQuest/Epos.jpg",
                         altString = "Epos"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/BeastQuest/Ferno.jpg",
                         altString = "Ferno"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/BeastQuest/Nanook.jpg",
                         altString = "Nanook"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/BeastQuest/Sepron.jpg",
                         altString = "Sepron"
                     },
                     new CarouselImage
                     {
                         UrlString = "/images/BeastQuest/Tagus.jpg",
                         altString = "Tagus"
                     }
                 );

                    context.SaveChanges();

                }

            }
        }
    }
}
