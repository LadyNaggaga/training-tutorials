using System;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {

            var originalBook = context.Books
                .Single(b => b.BookId = 1);

            Console.WriteLine(String.Format("Original Book - {0}: {1}", book.BookId, book.Title));

            var untrackedBook = new Book()
            {
                BookId = 1,
                Title = "Frankenstein: or, The Modern Prometheus",
                Genre = "Science Fiction",
                PublicationYear = 1818
            };

            context.Books.Update(book);
            context.SaveChanges();

            var updatedBook = context.Books
                .Single(b => b.BookId = 1);

            Console.WriteLine("{0}: {1}, {2} {3}", updatedBook.BookId, updatedBook.Title, updatedBook.Genre, updatedBook.PublicationYear);
        }
    }
}