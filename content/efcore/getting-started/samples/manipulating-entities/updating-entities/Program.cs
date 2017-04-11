using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books
				.Single(b => b.Title == "Mrs Dalloway"); 

            Console.WriteLine("Original Book -\n Id: {0}\n Title: {1}\n Genre: {2}\n Publication Year: {3}", book.Id, book.Title, book.Genre, book.PublicationYear);
			
			book.Title = "To the Lighthouse";
			book.PublicationYear = 1927;
			context.SaveChanges(); 
			
			Console.WriteLine("\nUpdated Book -\n Id: {0}\n Title: {1}\n Genre: {2}\n Publication Year: {3}", book.Id, book.Title, book.Genre, book.PublicationYear);
        }
    }
}