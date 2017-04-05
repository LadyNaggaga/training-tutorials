using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using REPLHelper;

public class LibraryContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<CheckoutRecord> CheckoutRecords { get; set; }
    public DbSet<Reader> Readers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
             .HasOne(a => a.Reader)
             .WithOne(r => r.Address)
             .OnDelete(DeleteBehavior.Restrict); // `SetNull`, `Restrict`, or `Cascade`
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(DBHelper.GetWriteableDbConnectionString());
    }
}