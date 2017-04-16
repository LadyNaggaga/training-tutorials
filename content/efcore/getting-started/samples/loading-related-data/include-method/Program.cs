using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books
                .Include(b => b.Author)
                .Single(b => b.Id == 1);

            Console.WriteLine("Included author with book -");
            Console.WriteLine("Id: {0}", book.Id);
            Console.WriteLine("Title: {0}", book.Title);
            Console.WriteLine("Genre: {0}", book.Genre);
            Console.WriteLine("Publication Year: {0}", book.PublicationYear);
            Console.WriteLine("Author: {0} {1}", book.Author.FirstName, book.Author.LastName);
        }
    }
}