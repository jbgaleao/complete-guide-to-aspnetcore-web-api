using Microsoft.EntityFrameworkCore;

using my_books.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Books_Authors)
                .HasForeignKey(bi => bi.BookId);
            
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Books_Authors)
                .HasForeignKey(bi => bi.AuthorId);
        }
        public DbSet<Book> BOOKS { get; set; }
        public DbSet<Author> AUTHORS { get; set; }
        public DbSet<Publisher> PUBLISHERS { get; set; }
        public DbSet<Book_Author> BOOKS_AUTHORS { get; set; }
    }
}
