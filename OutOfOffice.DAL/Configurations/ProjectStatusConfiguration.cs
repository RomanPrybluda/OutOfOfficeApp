using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class ProjectStatusConfiguration : IEntityTypeConfiguration<ProjectStatus>
    {
        public void Configure(EntityTypeBuilder<ProjectStatus> builder)
        {
            builder
                .HasKey(pt => pt.Id);

            builder
                .Property(pt => pt.Id)
                .HasDefaultValueSql("NEWID()");


            builder
                .Property(ps => ps.ProjectStatusName)
                .IsRequired();
        }
    }
}
