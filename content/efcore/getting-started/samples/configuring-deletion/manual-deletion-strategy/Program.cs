using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new LibraryContext())
        {
            var reader = context.Readers.Include(r => r.Address).First();
            context.Readers.Remove(reader);
            context.SaveChanges();

            var readers = context.Readers.Include(r => r.Address).ToList();
            foreach (Reader rd in readers)
            {
                Console.WriteLine("{0} {1} - {2}", rd.FirstName, rd.LastName, rd.Address.State);
            }
        }
    }
}