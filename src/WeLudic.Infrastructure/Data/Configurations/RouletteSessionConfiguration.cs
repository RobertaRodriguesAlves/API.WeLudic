using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeLudic.Domain.Entities;

namespace WeLudic.Infrastructure.Data.Configurations;
public class RouletteSessionConfiguration : IEntityTypeConfiguration<RouletteSession>
{
    public void Configure(EntityTypeBuilder<RouletteSession> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
