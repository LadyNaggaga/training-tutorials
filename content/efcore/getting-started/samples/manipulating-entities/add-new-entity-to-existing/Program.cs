using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var author = context.Authors
                .Include(a => a.Books)
                .Single(a => a.LastName == "Crane");

            var book = new Book
            {
                Title = "The Red Badge of Courage",
                Genre = "War Novel",
                PublicationYear = 1871
            };

            author.Books.Add(book);
            context.SaveChanges();

            Console.WriteLine("{0}: {1}, {2} {3}", book.BookId, book.Title, book.Author.FirstName, book.Author.LastName);
        }
    }
}