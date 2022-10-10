using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Infrastructure.FluentConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CreateYourOwnAdventure.Infrastructure.Contexts;

public class AdventureContext : DbContext
{
	public AdventureContext() => DbPath = GetDatabasePath();

	public DbSet<BinaryTree<Question>> Adventures { get; set; }
	public DbSet<Game> MyAdventures { get; set; }

	public string DbPath { get; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AdventureConfiguration());
		modelBuilder.ApplyConfiguration(new GameConfiguration());
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite($"Data Source={DbPath}");
	}

	private string GetDatabasePath()
	{
        string path =
            Path.Combine(
                Path.GetDirectoryName(Assembly.Load("CreateYourOwnAdventure.Infrastructure").Location) ??
                string.Empty, "myadventures.db");

        return path;
    }
}