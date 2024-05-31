using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smoke.Models;

namespace Smoke.Data.Configs;

public class GamesConfigs : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Title).HasMaxLength(100).IsRequired();
        builder.Property(g => g.Publisher).IsRequired();
        builder.Property(g => g.ImageUrl).IsRequired();
        builder.HasIndex(g => g.Title).IsUnique();
    }
}
