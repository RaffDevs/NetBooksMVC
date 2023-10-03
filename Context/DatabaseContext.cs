using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetBooksMVC.Models;

namespace NetBooksMVC.Context
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCollection> BooksCollection { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookCollection>()
                .HasMany(bc => bc.Books)
                .WithOne()
                .IsRequired(false);

            base.OnModelCreating(builder);
        }
    }
}