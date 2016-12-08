using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        using (var db = new LibraryContext())
        {
            var author = new Author
            {
                FirstName = "Mary",
                LastName = "Shelley"
            };
            db.Authors.Add(author);
            db.SaveChanges();

            Console.WriteLine("{0}: {1} {2}", author.AuthorId, author.FirstName, author.LastName);
        }
    }
}