using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var db = new LibraryContext())
        {
            var author = new Author
            {
                FirstName = "Mary",
                LastName = "Shelley",
                Books = new List<Book> {
                    new Book
                    {
                        Title = "Frankenstein: or, The Modern Prometheus",
                        Genre = "Science Fiction",
                        PublicationYear = 1818
                    }
                }
            };
            db.Authors.Add(author);
            db.SaveChanges();

            var book = context.Books
                .Single(b => b.Title.Contains("Frankenstein"));

            Console.WriteLine("{0} - {1}, {2}", book.Title, book.Genre, book.PublicationYear);
        }
    }
}