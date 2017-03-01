using Microsoft.EntityFrameworkCore;
using REPLHelper;

public class LibraryContext : DbContext
{
    public DbSet<CheckoutRecord> CheckoutRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckoutRecord>()
            .HasKey(cr => new { cr.ReaderId, cr.BookId, cr.CheckoutDate });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(DBHelper.GetMigrationDbConnectionString());
    }
}