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
                .Single(b => b.Title.Contains("Orient Express")); 
 
            var earliestCheckout = context.Entry(book) 
                .Collection(b => b.CheckoutRecords) 
                .Query() 
                .Min(c => c.CheckoutDate); 

            Console.WriteLine("Earliest Checkout: {0}", earliestCheckout.ToString("MMMM dd, yyyy"));
        }
    }
}