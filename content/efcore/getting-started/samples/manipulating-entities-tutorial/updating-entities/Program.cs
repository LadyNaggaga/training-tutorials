using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var db = new LibraryContext())
        {
            var book = db.Books.First();
            book.Title = "Frankenstein: or, The Modern Prometheus";
            db.SaveChanges();

            Console.WriteLine(book.Title);
        }
    }
}