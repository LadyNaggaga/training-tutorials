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
                .Include(b => b.Author)
                .Single(b => b.Id == 1);

			Console.WriteLine("Included author and checkout record(s) with book - \nId: {0}\n Title: {1}\n Genre: {2}\n Publication Year: {3}\nAuthor: {4} {5}", book.Id, book.Title, book.Genre, book.PublicationYear, book.Author.FirstName, book.Author.LastName);
			
            foreach (CheckoutRecord checkoutRecord in book.CheckoutRecords)
            {
                Console.WriteLine("Due Date: {0}", checkoutRecord.DueDate.ToString("MMMM dd, yyyy"));
            }
        }
    }
}