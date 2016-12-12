using System;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var book = new Book()
            {
                BookId = 1,
                Title = "Frankenstein: or, The Modern Prometheus",
                Genre = "Science Fiction",
                PublicationYear = 1818
            };
            context.Books.Update(book);
            context.SaveChanges();

            Console.WriteLine("{0}: {1}, {2} {3}", book.BookId, book.Title, book.Genre, book.PublicationYear);
        }
    }
}