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

            var addedBook = context.Books
                .Include(b => b.Author)
                .Single(b => b.Title.Contains("Badge"));
			
			Console.WriteLine("We added a book to the author {0} {1} -", author.FirstName, author.LastName);

			Console.WriteLine("\nTitle: {0}\n Genre: {1}\n Publication Year: {2}", addedBook.Title, addedBook.Genre, addedBook.PublicationYear); 
        }
    }
}