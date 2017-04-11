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
                .Include(b => b.Author)
                .Single(b => b.Title.Contains("Orient Express"));
		   
			Console.WriteLine("Book: {0}\n Author: {1} {2}", book.Title, book.Author.FirstName, book.Author.LastName);
		
			foreach (CheckoutRecord checkoutRecord in book.CheckoutRecords)
			{
				Console.WriteLine("Due Date: {0}\n Checked out from Reader: {1} {2}", checkoutRecord.DueDate.ToString("MMMM dd, yyyy"), checkoutRecord.Reader.FirstName, checkoutRecord.Reader.LastName);
			}
        }
    }
}