using System;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var author = new Author
            {
                FirstName = "Mary",
                LastName = "Shelley"
            };
            context.Authors.Add(author);
            context.SaveChanges();

            Console.WriteLine("{0}: {1} {2}", author.AuthorId, author.FirstName, author.LastName);
        }
    }
}