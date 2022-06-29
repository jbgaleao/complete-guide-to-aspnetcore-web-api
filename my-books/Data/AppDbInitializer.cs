using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using my_books.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.BOOKS.Any())
                {
                    context.BOOKS.AddRange(new Book()
                    {
                        Title = "Titulo 1",
                        Description = "Descricao 1",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Genre1",
                        Author = "Author1",
                        CoverUrl = "https://url1......",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "Titulo 2",
                        Description = "Descricao 2",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-3),
                        Rate = 2,
                        Genre = "Genre 2",
                        Author = "Author 2",
                        CoverUrl = "https://url2......",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
