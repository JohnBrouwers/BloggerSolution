using BloggerDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggerDataAccess
{
    public class BloggerDbContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>(blog => { 
                blog.Property(b => b.Title).IsRequired().HasMaxLength(150);
                blog.Property(b => b.Content).HasMaxLength(500);
            });
        }
    }
}
