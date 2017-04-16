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
			Console.WriteLine("Book: {0}", book.Title);
            Console.WriteLine("Author: {0} {1}", book.Author.FirstName, book.Author.LastName);

            foreach (CheckoutRecord checkoutRecord in book.CheckoutRecords)
			{
				Console.WriteLine("Due Date: {0}", checkoutRecord.DueDate.ToString("MMMM dd, yyyy"));
                Console.WriteLine("Checked out by Reader: {0} {1}", checkoutRecord.Reader.FirstName, checkoutRecord.Reader.LastName);
			}
        }
    }
}