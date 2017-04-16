using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using REPLHelper;

public class LibraryContext : DbContext  
{  
    public DbSet<Address> Addresses { get; set; } 
    public DbSet<Reader> Readers { get; set; }  
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)  
    {  
        modelBuilder.Entity<Reader>()  
            .HasOne(r => r.Address) 
            .WithOne(a => a.Reader)  
            .HasForeignKey<Address>(a => a.ReaderId);

        modelBuilder.Entity<Address>()
            .HasOne(r => r.Reader)
            .WithOne(a => a.Address)
            .HasForeignKey<Reader>(a => a.AddressId);
    }  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(DBHelper.GetMigrationDbConnectionString());
    }
} 