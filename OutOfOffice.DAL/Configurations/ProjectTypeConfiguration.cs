using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class ProjectTypeConfiguration : IEntityTypeConfiguration<ProjectType>
    {
        public void Configure(EntityTypeBuilder<ProjectType> builder)
        {
            builder
                .HasKey(pt => pt.Id);

            builder
                .Property(pt => pt.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(pt => pt.ProjectTypeName)
                .IsRequired();
        }
    }
}