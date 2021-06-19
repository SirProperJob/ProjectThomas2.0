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
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Mr Tickle",
                        Type = "Mr Men",
                        Owned = true
                    },

                    new Book
                    {
                        Title = "Mr Greedy",
                        Type = "Mr Men",
                        Owned = true
                    },

                    new Book
                    {
                        Title = "Mr Happy",
                        Type = "Mr Men",
                        Owned = true
                    },

                    new Book
                    {
                        Title = "Mr Nosey",
                        Type = "Mr Men",
                        Owned = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
