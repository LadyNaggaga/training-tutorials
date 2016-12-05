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
                .Single(author => author.LastName == "Douglass")
                .Include(author => author.Books)
                    .ThenInclude(book => book.Editions)
                        .ThenInclude(edition => edition.Publisher);
            Console.WriteLine(String.Format("{0} : {1} - {2}", book.Title, book.Editions, edition.Publisher));
        }
    }
}