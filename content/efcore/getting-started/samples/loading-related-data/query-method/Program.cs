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
                .Single(a => a.LastName == "Twain");

            Console.WriteLine("Eagerly loaded author: {0} {1}", author.FirstName, author.LastName);

            context.Entry(author)
                .Collection(a => a.Books)
                .Query()
                .Where(b => b.Title.Contains("Huck"))
                .Load();

            Console.WriteLine("Used a query to find the book ");
            foreach (var book in author.Books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}