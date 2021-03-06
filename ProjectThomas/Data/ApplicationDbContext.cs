using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectThomas.Models;

namespace ProjectThomas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjectThomas.Models.Book> Book { get; set; }
        public DbSet<ProjectThomas.Models.CarouselImage> CarouselImage { get; set; }
        public DbSet<ProjectThomas.Models.Lego> Lego { get; set; }
    }
}
