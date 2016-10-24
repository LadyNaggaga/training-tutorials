# Querying Data

Sometimes you really need an item (or items) from your database based off a certain set of parameters. In case you've forgotten, this is what querying is.

Querying with EF Core uses LINQ statements (if you need some more pointers, check [this](https://www.microsoft.com/net/tutorials/csharp/getting-started/linq) out). For those who really like LINQ, [101 LINQ Samples](https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b) is a great resource.

The basic format of queries is:

```c#
variableToStoreQueryResult = context.Model.QueryKeyWord(m => m.Identifier == value)
```

## Loading All Data

Grabs the entirety of a table.

```c#
using (var context = new BlogsContext())
{
    var blogs = context.Blog.ToList();
}
```

## Loading a Single Entity

Just grab the one you want.

```c#
using (var context = new BlogsContext())
{
    var blog = context.Blog
        .Single(b => b.BlogId == 1); //grabs the Blog with a BlogId of 1
}
```

## Filtering

Make the program find the one you want based on parameters.

```c#
using (var context = new BlogsContext())
{
    var blogs = context.Blog
        .Where(b => b.Name.Contains("entity framework"))
        .ToList();
}
```