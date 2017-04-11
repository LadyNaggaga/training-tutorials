using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
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
            context.Authors.Add(author);
            context.SaveChanges();

            var addedAuthor = context.Authors
                .Include(a => a.Books)
                .Single(a => a.LastName.Contains("Shelley"));
				
			Console.WriteLine("We added the author {0} {1} with their book(s) -", addedAuthor.FirstName, addedAuthor.LastName);

            foreach (Book book in addedAuthor.Books) {
                Console.WriteLine("\nTitle: {0}\n Genre: {1}\n Publication Year: {2}", book.Title, book.Genre, book.PublicationYear);
            }
        }
    }
}