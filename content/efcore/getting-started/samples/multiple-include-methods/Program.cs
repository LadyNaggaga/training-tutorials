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
                .Single(s => s.BookId == 1)
                .Include(book => book.Edition)
                .Include(book => book.Author);
            Console.WriteLine(String.Format("{0} - {1} {2}", book.Title, book.Author, book.Edition));
        }
    }
}