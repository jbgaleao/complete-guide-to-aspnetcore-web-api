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

        public Book UpdateBook(int bookId, BookVM book)
        {
            var _book = _context.BOOKS.FirstOrDefault(b => b.Id == bookId);
            if (_book != null)
            {
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
                _book.DateRead = book.IsRead ? book.DateRead : null;
                _book.Description = book.Description;
                _book.Genre = book.Genre;
                _book.IsRead = book.IsRead ? book.IsRead : false;
                _book.Rate = book.Rate;
                _book.Title = book.Title;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.BOOKS.FirstOrDefault(b => b.Id == bookId);
            if (_book != null)
            {
                _context.BOOKS.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
