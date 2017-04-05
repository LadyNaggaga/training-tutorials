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
            var addressId = reader.Address.Id;

            context.Readers.Remove(reader);
            context.SaveChanges();

            if (context.Addresses.Any(a => a.Id == addressId))
            {
                Console.WriteLine("Address exists");
            }
            else
            {
                Console.WriteLine("Address has been deleted");
            }
        }
    }
}