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
            var readers = context.Readers.First();
            Console.WriteLine("{0} {1}", reader.FirstName, reader.LastName);
            var address = context.Addresses.First();
            Console.WriteLine("{0} {1}", address.City, address.State);

            context.Readers.Remove(reader);
            context.SaveChanges();

            if (context.Addresses.Any(a => a.Id == 1)){
                Console.WriteLine("Address exists");
            }
            else{
                Console.WriteLine("Address has been deleted");
            }
        }
    }
}
