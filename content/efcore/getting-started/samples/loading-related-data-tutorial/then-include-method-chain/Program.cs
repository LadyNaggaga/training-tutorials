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
                .Single(a => a.LastName == "Douglass")
                .Include(a => a.Books)
                    .ThenInclude(b => b.Editions)
                        .ThenInclude(e => e.Publisher);
            Console.WriteLine(String.Format("{0} : {1} - {2}", book.Title, book.Editions, edition.Publisher));
        }
    }
}