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
                .Single(author => author.LastName == "Cather");

            var numBooks = context.Entry(author)
                .Collection(author => author.Books)
                .Query()
                .Count();
            Console.WriteLine("Count: {0}", author.Books.Count);
        }
    }
}