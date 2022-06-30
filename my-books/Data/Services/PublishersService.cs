using my_books.Data.Models;
using my_books.Data.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            Publisher _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Add(_publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetAllPublishers() => _context.PUBLISHERS.ToList();

        public Publisher GetPublisherById(int publisherId) => _context.PUBLISHERS.FirstOrDefault(b => b.PublisherId == publisherId);

        public Publisher UpdatePublisher(int publisherId, PublisherVM publisher)
        {
            var _publisher = _context.PUBLISHERS.FirstOrDefault(b => b.PublisherId == publisherId);
            if (_publisher != null)
            {
                _publisher.Name = publisher.Name;
                _context.SaveChanges();
            }
            return _publisher;
        }

        public void DeletePublisherById(int publisherId)
        {
            var _publisher = _context.PUBLISHERS.FirstOrDefault(b => b.PublisherId == publisherId);
            if (_publisher != null)
            {
                _context.PUBLISHERS.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
