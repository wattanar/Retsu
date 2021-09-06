using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.DataAccess.Entities;

namespace Web.DataAccess.Config
{
    public class RoleConfig : IEntityTypeConfiguration<RoleTable>
    {
        public void Configure(EntityTypeBuilder<RoleTable> builder)
        {
        }
    }
}