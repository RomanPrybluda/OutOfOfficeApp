using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder
                .HasKey(pr => pr.Id);

            builder
                .Property(pr => pr.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(p => p.ProjectName)
                .IsRequired();

            builder
                .Property(p => p.StartDate)
                .IsRequired();

            builder
                .Property(p => p.EndDate)
                .IsRequired();

            builder
                .HasOne(p => p.ProjectType)
                .WithMany(pt => pt.Projects)
                .HasForeignKey(p => p.ProjectTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.ProjectManager)
                .WithOne()
                .HasForeignKey<Project>(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.ProjectStatus)
                .WithMany(ps => ps.Projects)
                .HasForeignKey(p => p.ProjectStatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
