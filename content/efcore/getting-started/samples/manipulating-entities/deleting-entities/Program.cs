using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books.First();
            context.Books.Remove(book);
            context.SaveChanges();

            Console.WriteLine(book.Title);
        }
    }
}