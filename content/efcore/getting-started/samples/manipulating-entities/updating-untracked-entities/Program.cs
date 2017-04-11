using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var untrackedBook = new Book() 
			{ 
				Id = 1, 
				Title = "To the Lighthouse",
				Genre = "Literary",
				PublicationYear = 1927 
			};
			
			context.Books.Update(untrackedBook); 
			context.SaveChanges();

            var updatedBook = context.Books
                .Single(b => b.Id == 1);

            Console.WriteLine("Updated Book -\n Id: {0}\n Title: {1}\n Genre: {2}\n Publication Year: {3}", updatedBook.Id, updatedBook.Title, updatedBook.Genre, updatedBook.PublicationYear);
        }
    }
}