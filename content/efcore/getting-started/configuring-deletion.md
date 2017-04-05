# Configuring Deletion 
 
When a record is deleted from a database, its dependent records are also affected. In this lesson, we will learn the various behaviors a relational database can use to handle dependent records when a principal record is deleted, as well as how to configure each behavior in EF Core. 
 
## Deletion Strategies 
 
There are three behaviors that a database can use to handle a dependent of a deleted record: 
 
  * Delete it. This is known as **cascade deletion** because the deletion of the principal record is cascaded to its dependents. 
  * Change its foreign key value from the primary key of the deleted record to `null`. 
  * Leave it unchanged. 
 
## Configuring Deletion Strategies 
 
By convention, EF Core uses **cascade deletion**, so if you run the following example where we delete a `Reader`, you will see that its related `Address` is deleted as well. 
 
```{.snippet} 
 
public class Program {
    public static void Main() {  
        using (var context = new LibraryContext()){    
                var reader = context.Reader.Include(b => b.Address).First();  
                context.Reader.Remove(reader);  
                context.SaveChanges();  
        }    
    }  
}  
 
``` 
:::repl{data-name=default-deletion-strategy}
::: 
 
To use one of the other deletion behaviors, we use Fluent API's `OnDelete` method with the `DeleteBehavior` enum as an argument. The possible values of the `DeleteBehavior` enum are `Cascade`, `SetNull`, and `Restrict` (leave the dependent entity alone).  
 
Let's try setting the delete behavior for `Reader` to `SetNull`. When a `Reader` is deleted, the `ReaderId` property of its dependent `Address` will be set to `null`.  
 
```{.snippet} 
 
public class LibraryContext : DbContext  
{  
    public DbSet<Address> Addresses { get; set; } 
    public DbSet<Author> Authors { get; set; } 
    public DbSet<Book> Books { get; set; } 
    public DbSet<CheckoutRecord> CheckoutRecords { get; set; } 
    public DbSet<Reader> Readers { get; set; } 
 
     protected override void OnModelCreating(ModelBuilder modelBuilder) {  
        modelBuilder.Entity<Reader>()  
            .OnDelete(DeleteBehavior.SetNull); // `SetNull`, `Restrict`, or `Cascade` 
    }  
}  
``` 
:::repl{data-name=deletion-configuration}
::: 
 
If you change the delete behavior to `Restrict` and run the example again, you will see that the dependent `Address` will be unaffected.  
 
It should be noted that dependent entities must be tracked by the context for them to be affected by the configured EF Core delete behavior (see the [Tracking vs. No-Tracking](https://docs.microsoft.com/en-us/ef/core/querying/tracking) page in the docs for more information on tracked entities). Untracked entities will have whatever delete behavior is configured in the database itself. If you generated the database from your data model, EF Core will have configured the database to use the delete behavior specified in your data model.