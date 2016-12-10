# Manipulating Entities 
 
Four operations that we often perform on a record in a database are create, read, update, and delete (commonly referred to as "CRUD" operations). We walked through how to read records from a database in the [Querying Data](querying-data.md) tutorial. Now let's learn how to perform the other CRUD operations which allow us to manipulate records in the database. 
 
## Adding Entities to a Database 
 
Let's first look at how to create a new record in the database. In the following example, we create a new author and add it to the database: 
  
```{.snippet} 
using (var context = new LibraryContext()) 
{ 
var author = new Author 
{  
FirstName = "Mary",  
LastName = "Shelley", 
Books = new List<Book>() 
}; 
context.Authors.Add(author); 
context.SaveChanges(); 
} 
``` 
:::repl{data-name=CODE_EXAMPLE_NAME} 
::: 
 
As you can see, it is easy to add new entities to the database with EF Core. First, we add the entity to the database using the `Add` method of the `DbSet`, much like we would when adding items to a `List`. Next, we call the context's `SaveChanges` method. This step is essential because rather than write changes to the database right away, EF Core keeps track of all the pending changes and waits to write them until `SaveChanges` is called. 
 
Notice that we do not specify the author's `ID` property before adding it to the database. This is because `ID` is a generated property, meaning EF Core will automatically generate a value for it. 
 
## Adding Related Data 
 
In the previous example, we added an author without any books to the database. Now we want to add an author and their books to the database. How do we add related entities like this to the database, while maintaining their relationships? We accomplish this with EF Core by adding the parent entity (in our example, the author would be the parent entity and its books would be the ones dependent on it). It will then automatically add the related entities to the database. In the following example, we add an author and their books to the database by simply adding the author: 
 
``` 
using (var context = new LibraryContext()) 
{ 
var author = new Author 
{  
FirstName = "Mary",  
LastName = "Shelley", 
Books = new List<Book> { 
new Book 
{ 
Title = "Frankenstein: or, The Modern Prometheus", 
Genre = "Science Fiction", 
PublicationYear = 1818 
 
} 
} 
}; 
context.Authors.Add(author); 
context.SaveChanges(); 
} 
``` 
:::repl{data-name=CODE_EXAMPLE_NAME} 
::: 
 
## Updating Entities in a Database 
 
Next, let's look at how to update records that are already in the database. In the following example, we update the title of the first book in the database: 
 
```{.snippet} 
using (var context = new LibraryContext()) 
{ 
var book = context.Books.First(); 
book.Title = "Frankenstein: or, The Modern Prometheus"; 
context.SaveChanges(); 
} 
``` 
:::repl{data-name=CODE_EXAMPLE_NAME} 
::: 
 
Notice that we do not need to tell EF Core about the change. This is because the book we retrieved from the database is a Tracked Entity, meaning EF Core will keep track of any changes made to it. EF Core will continue to track changes made to the entity until the context is disposed, which occurs automatically when leaving the `using` block. To learn more about tracked entities, check out the ["Tracking vs. No-Tracking"](https://docs.microsoft.com/en-us/ef/core/querying/tracking) page in the docs. 
 
Suppose you want to update an untracked entity. As long as the untracked entity has the same primary key as the record in the database, you can accomplish this using the `DbSet`'s `Update` method. In the following example, we update the book with a primary key of `1`: 
 
```{.snippet} 
Using (var context = new LibraryContext()) 
{ 
var book = new Book() 
{ 
BookId = 1, 
Title = "Frankenstein: or, The Modern Prometheus", 
Genre = "Science Fiction", 
PublicationYear = 1818 
} 
context.Books.Update(book); 
context.SaveChanges(); 
} 
``` 
:::repl{data-name=CODE_EXAMPLE_NAME} 
::: 
 
## Deleting Entities 
 
Finally, let's look at how to delete records from the database. This can be accomplished using the `DbSet`'s `Remove` method. The following example demonstrates removing a book from the database:  
 
```{.snippet}  
using (var context = new LibraryContext()) 
{ 
var book = context.Books.First(); 
context.Books.Remove(book); 
context.SaveChanges(); 
} 
``` 
:::repl{data-name=CODE_EXAMPLE_NAME} 
::: 
 
## Deleting Related Data 
 
In the previous example, we were able to successfully delete a book, but what happened to that book's editions and publishers? The short answer is it depends. The way that EF Core handles deletion of an entity with related data depends on several factors including whether the related data is tracked, how EF Core is configured, and how the database is configured. To learn more about the available behaviors and how to configure a certain behavior, check out the Cascade Delete (COMING SOON) lesson.  
 
> Note {.note} 
> The Cascade Delete lesson has not been added yet. For now, please refer to [this](https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete). 