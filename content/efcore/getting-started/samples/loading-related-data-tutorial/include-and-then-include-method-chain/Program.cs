using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books
                .Single(b => b.Title = "Call of the Wild")
                .Include(b => b.Editions)
                    .ThenInclude(e => e.Publisher)
                .Include(b => b.Author);
            Console.WriteLine(String.Format("{0} : {1} - {2}", book.Title, book.Editions, edition.Publisher));
        }
    }
}