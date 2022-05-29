using Microsoft.EntityFrameworkCore;
using UrlShortener.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UrlShortener.Infrastructure.Persistence.Configurations;

internal class UrlFluentConfiguration : IEntityTypeConfiguration<Url>
{
    public void Configure(EntityTypeBuilder<Url> builder)
    {
        builder.Property(p => p.OriginalUrl).IsRequired();
    }
}
