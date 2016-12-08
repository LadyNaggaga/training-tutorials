using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var db = new LibraryContext())
        {
            using (var db = new LibraryContext())
            {
                var book = db.Books.First();
                db.Books.Remove(book);
                db.SaveChanges();

                Console.WriteLine(book.Title);
            }
        }
    }
}