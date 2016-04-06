using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContosoBooks.Models
{
    public class SampleData
    {
        public static void Initialize (IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("SampleData");
            var context = serviceProvider.GetService<ApplicationDbContext>();
            
            logger.LogInformation("Context.Database.Type = {0}", context);
            //TODO: how to check if its using SQL or InMemory 
            //context.Database.Migrate();
            
            if (!context.Book.Any())
            {
                var starWars = context.Movie.Add(new Movie { Title="Star Wars", ReleaseDate = DateTime.Now, Genre = "Fiction", Price = 1}).Entity;
                
                var austen = context.Author.Add(new Author { LastName = "Austen", FirstName = "Jane" }).Entity;
                var dickens = context.Author.Add(new Author { LastName = "Dickens", FirstName = "Charles" }).Entity;
                var cervantes = context.Author.Add(new Author { LastName = "Cervantes", FirstName = "Miguel" }).Entity;

                context.Book.AddRange(
                    new Book()
                    {
                        Title = "Pride and Prejudice",
                        Year = 1813,
                        Author = austen,
                        Price = 9.99M,
                        Genre = "Comedy of manners"
                    },
                    new Book()
                    {
                        Title = "Northanger Abbey",
                        Year = 1817,
                        Author = austen,
                        Price = 12.95M,
                        Genre = "Gothic Parody"
                    },
                    new Book()
                    {
                        Title = "David Copperfield",
                        Year = 1850,
                        Author = dickens,
                        Price = 15,
                        Genre = "Bildungsroman"
                    },
                    new Book()
                    {
                        Title = "Don Quixote",
                        Year = 1617,
                        Author = cervantes,
                        Price = 8.95M,
                        Genre = "Picaresque"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
