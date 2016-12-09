using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var author = context.Authors
                .Single(a => a.LastName == "Cather");

            var numBooks = context.Entry(author)
                .Collection(a => a.Books)
                .Query()
                .Count();
            Console.WriteLine(numBooks);
        }
    }
}