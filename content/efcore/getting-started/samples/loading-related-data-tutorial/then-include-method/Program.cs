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
                .Single(book => book.BookId == 1)
                .Include(book => book.Editions)
                    .ThenInclude(edition => edition.Publisher);
            Console.WriteLine(String.Format("{0} - {1}", book.Editions, edition.Publisher));
        }
    }
}