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
                .Include(b => b.CheckoutRecords)
                    .ThenInclude(c => c.Reader)
                .Single(b => b.Id == 1);

            Console.WriteLine("Book: {0}", book.Title);			
            foreach (CheckoutRecord checkoutRecord in book.CheckoutRecords)
            {
                Console.WriteLine("Checkout Records for {0}", book.Title);
                Console.WriteLine("{0} - {1} {2}", checkoutRecord.DueDate.ToString("MMMM dd, yyyy"), checkoutRecord.Reader.FirstName, checkoutRecord.Reader.LastName);
            }
        }
    }
}