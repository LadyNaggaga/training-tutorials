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
                .Single(s => s.BookId == 10)
                .Include(book => book.Edition)
                .ThenInclude(edition => edition.Publisher);
            Console.WriteLine(String.Format("{0} - {1}", book.Edition, edition.Publisher));
        }
    }
}