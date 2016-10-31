# Querying Data

In this lesson, you'll learn how to use querying to fetch an item (or items) from your database based off a certain set of parameters.

EF Core uses LINQ to query data. If you need a refresher on LINQ, check out the [LINQ lesson] (https://www.microsoft.com/net/tutorials/csharp/getting-started/linq) in the C# Interactive Tutorial.

The basic format of a query is:

```c#
variableToStoreQueryResult = context.Model.QueryKeyword(m => m.Identifier == value)
```

## Loading All Data

To get all of the information in a table, you first create a disposable instance of the context. You then reference the DbSet within the context that you need, and the `ToList` function converts the DbSet to a List of the objects. In the example below, our `MusicContext` has a table named `Songs` that we would like a List of.

```c#
using (var context = new MusicContext())
{
    var songs = context.Songs.ToList();
}
```

## Loading a Single Entity

Fetching only one entity is very similar to loading all data. However, instead of converting the whole table to a List, we use the LINQ function `Single()` to get the Song with a SongId of 1.

```c#
using (var context = new MusicContext())
{
    //grabs the Song with a SongId of 1
    var song = context.Songs
        .Single(s => s.SongId == 1);
}
```

## Filtering

When fetching data, filtering can be done to find the objects you want based on parameters. In our example, we use the LINQ function `Where()` to fetch any Songs that have the word "You" in their Name. To filter on different parameters, you can simply change the attribute used in the `Where()` function, or change the criteria that it matches on. As in the first example, we then use the `ToList()` function to convert all of the objects returned to a List.

```c#
using (var context = new MusicContext())
{
    var songs = context.Songs
        .Where(s => s.Name.Contains("You"))
        .ToList();
}
```