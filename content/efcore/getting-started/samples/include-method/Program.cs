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
                .Include(books => books.Authors);
            Console.WriteLine(String.Format("{0} - {1}", book.Title, book.Author));
        }
    }
}