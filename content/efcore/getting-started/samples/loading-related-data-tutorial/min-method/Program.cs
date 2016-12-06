using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var year = context.Entry(book)
                .Collection(b => b.Editions)
                .Query()
                .Min(e => e.Year);
            Console.WriteLine("Minimum Year: {0}", book.Editions.Min);
        }
    }
}