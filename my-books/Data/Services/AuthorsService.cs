using my_books.Data.Models;
using my_books.Data.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.AUTHORS.Add(_author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthors() => _context.AUTHORS.ToList();

        public Author GetAuthorById(int authorId) => _context.AUTHORS.FirstOrDefault(b => b.AuthorId == authorId);

        public Author UpdateAuthor(int authorId, AuthorVM author)
        {
            var _author = _context.AUTHORS.FirstOrDefault(b => b.AuthorId == authorId);
            if (_author != null)
            {
                _author.FullName = author.FullName;
                _context.SaveChanges();
            }
            return _author;
        }

        public void DeleteAuthorById(int authorId)
        {
            var _author = _context.AUTHORS.FirstOrDefault(b => b.AuthorId == authorId);
            if (_author != null)
            {
                _context.AUTHORS.Remove(_author);
                _context.SaveChanges();
            }
        }
    }
}
