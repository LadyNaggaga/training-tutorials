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
                .Single(author => author.LastName == "Twain");

            context.Entry(author)
                .Collection(author => author.Books)
                .Query()
                .Where(book => book.Title.Contains("Huck"))
                .Load();
            Console.WriteLine(book.Title);
        }
    }
}