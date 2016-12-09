using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var db = new LibraryContext())
        {
            var book = db.Books.Include(b => b.Editions).First();
            db.Books.Remove(book);
            db.SaveChanges();

            Console.WriteLine(book.Title);
        }
    }
}