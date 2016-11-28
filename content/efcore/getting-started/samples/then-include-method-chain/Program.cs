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
                .Single(s => s.BookId == 3)
                .Include(author => author.Books)
                .ThenInclude(book => book.Edition)
                .ThenInclude(edition => edition.Publisher);
            Console.WriteLine(String.Format("{0} : {1} - {2}", book.Title, book.Edition, edition.Publisher));
        }
    }
}