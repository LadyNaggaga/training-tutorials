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
                .Single(s => s.BookId == 8);
            Console.WriteLine("{0} - {1}", book.Title, book.Author);
        }
    }
}