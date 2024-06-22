using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder
                .ToTable("Role");

            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}