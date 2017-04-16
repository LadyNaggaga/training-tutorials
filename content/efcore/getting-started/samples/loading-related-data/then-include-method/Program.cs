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
                Console.WriteLine("Due Date: {0}", checkoutRecord.DueDate.ToString("MMMM dd, yyyy"));
                Console.WriteLine("Checked out from Reader: {0} {1}", checkoutRecord.Reader.FirstName, checkoutRecord.Reader.LastName);
            }
        }
    }
}