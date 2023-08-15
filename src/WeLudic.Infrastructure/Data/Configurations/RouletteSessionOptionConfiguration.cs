using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeLudic.Domain.Entities;

namespace WeLudic.Infrastructure.Data.Configurations;

public class RouletteSessionOptionConfiguration : IEntityTypeConfiguration<RouletteSessionOption>
{
    public void Configure(EntityTypeBuilder<RouletteSessionOption> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedNever();
    }
}
