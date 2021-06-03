using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;

namespace Procuratio.Modules.Securities.DataAccess.EntitiesConfigurations.MicrosoftIdentity
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User).ToString(), SecuritiesDbContext.SecuritesSchemaName);

            builder.Property(x => x.UserName).IsRequired();

            builder.Property(x => x.NormalizedUserName).IsRequired();

            builder.Property(x => x.UserSurname).IsRequired();

            builder.Property(x => x.NormalizedUserSurname).IsRequired();

            builder.Ignore(x => x.Password);

            builder.HasIndex(x => new { x.RestaurantID, x.UserName, x.PasswordHash }).IsUnique(true);
            builder.HasIndex(x => new { x.RestaurantID, x.UserName, x.UserSurname }).IsUnique(true);
        }
    }
}
