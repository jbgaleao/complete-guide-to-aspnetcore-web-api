using my_books.Data.Models;
using my_books.Data.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            Book _book = new Book()
            {
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                DateRead = book.IsRead ? book.DateRead : null,
                Description = book.Description,
                Genre = book.Genre,
                IsRead = book.IsRead ? book.IsRead : false,
                Rate = book.Rate,
                Title = book.Title
            };
            _context.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks() => _context.BOOKS.ToList();

        public Book GetBookById(int bookId) => _context.BOOKS.FirstOrDefault(b => b.Id == bookId);
    }
}
