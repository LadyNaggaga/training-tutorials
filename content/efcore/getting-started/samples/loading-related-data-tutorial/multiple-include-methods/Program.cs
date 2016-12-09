using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books
                .Single(b => b.BookId == 1)
                .Include(b => b.Editions)
                .Include(b => b.Author);
            Console.WriteLine(String.Format("{0} - {1}", book.Author, book.Edition));
        }
    }
}