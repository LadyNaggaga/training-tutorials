using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var author = context.Authors
                .Single(a => a.AuthorId == 2);

            context.Entry(author)
                .Collection(a => a.Books)
                .Query()
                .Where(b => b.Title.Contains("Huck"))
                .Load();
            foreach (var book in author.Books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}