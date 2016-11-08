using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new LibraryContext())
        {
            //grabs the Title with a BookId of 1
            var book = context.Books
                .Single(s => s.BookId == 1);
            Console.WriteLine(book.Title);
        }
    }
}