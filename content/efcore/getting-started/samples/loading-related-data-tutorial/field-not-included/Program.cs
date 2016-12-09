using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books
                .Single(b => b.BookId == 1);

            Console.WriteLine("{0} - {1} {2}", book.Title, book.Author.FirstName, book.Author.LastName);
        }
    }
}