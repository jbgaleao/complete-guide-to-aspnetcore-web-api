using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }

        public List<Book_Author> Books_Authors { get; set; }
    }
}
