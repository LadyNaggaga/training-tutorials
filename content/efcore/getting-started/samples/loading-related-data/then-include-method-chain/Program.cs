using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var author = context.Authors 
                .Include(a => a.Books) 
			        .ThenInclude(b => b.CheckoutRecords) 
				        .ThenInclude(c => c.Reader)
                .Single(a => a.LastName == "Douglass");

            foreach (Book book in author.Books)
            {
                Console.WriteLine("Book: {0}", book.Title);		
				foreach (CheckoutRecord checkoutRecord in book.CheckoutRecords)
				{
					Console.WriteLine("Due Date: {0}", checkoutRecord.DueDate.ToString("MMMM dd, yyyy"));
                    Console.WriteLine("Checked out by Reader: {0} {1}", checkoutRecord.Reader.FirstName, checkoutRecord.Reader.LastName);
				}
			}
        }
    }
}