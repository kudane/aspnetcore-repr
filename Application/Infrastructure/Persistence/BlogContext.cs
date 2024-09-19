using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Persistence;

// PM:
// Add-Migration InitialCreate -OutputDir "Infrastructure/Persistence/Migrations"
// Remove Migration
// Update-Database
public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Directory.GetCurrentDirectory();
        DbPath = System.IO.Path.Join(folder, "\\Infrastructure\\Persistence\\blogging.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Blog
{
    public int BlogId { get; set; }
    public required string Url { get; set; }
    public List<Post> Posts { get; } = [];
}

public class Post
{
    public int PostId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}
