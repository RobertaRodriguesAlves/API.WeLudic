using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeLudic.Domain.Entities;

namespace WeLudic.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(p => p.Email)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(p => p.HashedPassword)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(p => p.ConfirmAndAgree)
           .IsRequired();

        builder.Property(p => p.AccessToken)
            .IsRequired(false)
            .IsUnicode(false);

        builder.Property(p => p.RefreshToken)
            .IsRequired(false)
            .IsUnicode(false);

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
