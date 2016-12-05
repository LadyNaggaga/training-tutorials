using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new AuthorContext())
        {
            var author = context.Authors
                .Single(author => author.AuthorId == 2);

            context.Entry(author)
                .Collection(author => author.Books)
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