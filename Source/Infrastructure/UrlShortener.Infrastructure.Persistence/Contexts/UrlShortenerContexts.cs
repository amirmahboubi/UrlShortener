using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using UrlShortener.Core.Domain.Entities;

namespace UrlShortener.Infrastructure.Persistence.Contexts;

public class UrlShortenerContexts : DbContext
{
    public UrlShortenerContexts([NotNull] DbContextOptions options) : base(options) { }

    public DbSet<Url> Urls { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}
