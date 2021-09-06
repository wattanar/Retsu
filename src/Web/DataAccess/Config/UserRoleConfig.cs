using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.DataAccess.Entities;

namespace Web.DataAccess.Config
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRoleTable>
    {
        public void Configure(EntityTypeBuilder<UserRoleTable> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}