using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books.Include(b => b.Editions).First();
            context.Books.Remove(book);
            context.SaveChanges();

            Console.WriteLine(book.Title);
        }
    }
}