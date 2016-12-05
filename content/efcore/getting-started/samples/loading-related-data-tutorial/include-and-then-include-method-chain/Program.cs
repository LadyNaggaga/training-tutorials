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
                .Single(book => book.Title = "Call of the Wild")
                .Include(book => book.Editions)
                    .ThenInclude(edition => edition.Publisher)
                .Include(book => book.Author);
            Console.WriteLine(String.Format("{0} : {1} - {2}", book.Title, book.Editions, edition.Publisher));
        }
    }
}