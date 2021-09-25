using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;

namespace Procuratio.Modules.Securities.DataAccess.EntitiesConfigurations.MicrosoftIdentity
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User), SecurityDbContext.SecuritySchemeName);

            builder.Property(x => x.BranchId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.UserName).IsRequired();

            builder.Property(x => x.NormalizedUserName).IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Surname).IsRequired();

            builder.Property(x => x.PasswordHash).HasColumnType("nvarchar(max)").IsRequired();

            builder.Ignore(x => x.Password);

            builder.HasIndex(x => new { x.UserName }).IsUnique();
        }
    }
}
