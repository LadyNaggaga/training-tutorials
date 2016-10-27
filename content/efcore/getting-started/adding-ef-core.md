#Adding Entity Framework Core to a Project

This section of the tutorial will help you set up EF Core on your computer. However, you do not need to complete these steps to continue with the tutorial. 

We will show you how to add EF Core to your project via command line. The command line method is cross-platform capable and you can use your favorite command shell. Alternatively, you can download the [.NET Core SDK for Windows](https://www.microsoft.com/net/core#windows), which has additional .NET Core functionality.

If you would prefer to configure EF Core using Visual Studio, follow along with [this tutorial](https://docs.efproject.net/en/latest/platforms/full-dotnet/new-db.html).

##Installing EF Core
If you haven't already, you will need to download .NET Core to your computer. For your ease, just go to [.NET Framework Downloads](https://www.microsoft.com/net/download), download the installer for your system, and follow the setup wizard (it takes about 10 seconds). 

To use EF Core in your project, you'll have to download the package for the database provider of choice. 

| **Database Provider** | **Package Name** |
| ----- | ------------- |
| Microsoft SQL Server | [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) |
| SQLite | [Microsoft.EntityFrameworkCore.SQLite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SQLite/) |
| Npgsql (PostgreSQL) | [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL) |
| MySQL (Official) | [MySql.Data.EntityFrameworkCore -Pre](https://www.nuget.org/packages/MySql.Data.EntityFrameworkCore) |
| Pomelo (MySQL) | [Pomelo.EntityFrameworkCore.MySQL](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySQL) |
| Microsoft SQL Server Compact Edition | [EntityFrameworkCore.SqlServerCompact40](https://www.nuget.org/packages/EntityFrameworkCore.SqlServerCompact40) 
OR 
[EntityFrameworkCore.SqlServerCompact35](https://www.nuget.org/packages/EntityFrameworkCore.SqlServerCompact35) |
| IBM Data Servers | [EntityFramework.IBMDataServer -Pre](https://www.nuget.org/packages/EntityFramework.IBMDataServer) |
| InMemory (for Testing) | [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/) |
| Devart (MySQL, Oracle, PostgreSQL, SQLite, DB2, SQL Server, and more) | N/A, for installation instructions, follow the [Devart dotConnect documentation](https://www.devart.com/dotconnect/). |

##Create an EF Core Project

To create a new .NET Core project using command line: 

1. Create a new directory for the project.  
    mkdir MyProject 
	
2. Navigate to this project directory. 
    cd MyProject 
	
3. Initialize a .NET Core project (this creates project.json and Startup.cs) 
    dotnet new 

4. Restore dependencies. 
    Dotnet restore 

5. Run the project 
    dotnet run

You can verify that Entity Framework Core is installed by running
    dotnet ef -help
	
##Using a Database
###Code-first vs. Database-first

Now that you have a working .NET Core project, we can connect the code project to a database. EF Core allows developers to generate a database from C# code, or to connect an existing database to the project. These methods are known as "code-first" and "database-first." Code-first projects create a database from models made in-code that represent database tables. Developers can populate tables, delete fields, and define keys all from the code without writing a single SQL script. While developers can still modify tables and data from code, database-first projects connect a EF Core project to an existing database. This works well for developers who already have a database in development. 

In this tutorial, we will demonstrate how to generate a database with a code-first project and how to connect a database for database-first. 

###Code-first: Generating a Database

For both code-first and database-first projects, we must set up the database context. Contexts "point" EF Core to the specified database (*.db) file. DbContext is an existing .NET Core class that can be extended to your context. In this example, we are generating a SQLite database from our code. 

If we had the classes "Blog" and "Post" in our project that we want to refer to database tables we would include them in the context (in the later section "Understanding Models" we will discuss these type of classes further).  With these classes, the context would look like: 

	public class BloggingContext : DbContext  
	{         
		public DbSet<Blog> Blogs { get; set; } 
		public DbSet<Post> Posts { get; set; } 
			
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
		{  
			optionsBuilder.UseSqlite("Filename=./blog.db");  
		} 
	} 

###Database-first: Connecting to a Database

If you are creating a .NET Core application around an existing database, you will probably need a connection string. 

Database providers often require the use of a connection string to connect to the database. Sometimes the information in the connection string needs to be protected (for example, if it contains a password). The connection string may also need to change as you move an application between development, testing, and production environments.  

In the example from the BloggingContext, we generated a database from our code. In database-first applications, you can add a connection string into your context. 

	public class BloggingContext : DbContext  
	{ 
		public DbSet<Blog> Blogs { get; set; } 
		public DbSet<Post> Posts { get; set; }
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
		{ 
			optionsBuilder.UseSqlServer("<database connection string");
		} 
	}

However, for security and ease, you will want to put your connection string in the App.config file, which you can read out using ConfigurationManager. Check out [this doc](https://docs.efproject.net/en/latest/miscellaneous/connection-strings.html) for how to add a connection string to your project.


