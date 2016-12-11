using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = context.Books
                .Single(b => b.BookId == 1);
            
            // If the next line is uncommented, an error will be thrown because there is no Author
            // Console.WriteLine("{0} - {1} {2}", book.Title, book.Author.FirstName, book.Author.LastName);
        }
    }
}