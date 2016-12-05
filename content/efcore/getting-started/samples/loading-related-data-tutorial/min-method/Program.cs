using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new BookContext())
        {
            var year = context.Entry(book)
                .Collection(book => book.Editions)
                .Query()
                .Min(edition => edition.Year);
            Console.WriteLine("Minimum Year: {0}", book.Editions.Min);
        }
    }
}