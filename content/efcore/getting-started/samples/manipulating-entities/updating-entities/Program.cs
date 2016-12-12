using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books.First();
            book.Title = "Frankenstein: or, The Modern Prometheus";
            context.SaveChanges();

            Console.WriteLine(book.Title);
        }
    }
}