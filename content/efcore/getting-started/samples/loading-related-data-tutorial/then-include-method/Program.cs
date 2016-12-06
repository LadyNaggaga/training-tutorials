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
                .Single(b => b.BookId == 1)
                .Include(b => b.Editions)
                    .ThenInclude(e => e.Publisher);
            Console.WriteLine(String.Format("{0} - {1}", book.Editions, edition.Publisher));
        }
    }
}