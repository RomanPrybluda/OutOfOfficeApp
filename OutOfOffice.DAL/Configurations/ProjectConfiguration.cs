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
                .Property(p => p.ProjectStatus)
                .IsRequired();

            builder
                .HasOne(p => p.ProjectType)
                .WithMany(pt => pt.Projects)
                .HasForeignKey(p => p.ProjectTypeId);

            builder.HasOne(p => p.ProjectManager)
                   .WithMany(e => e.ManagedProjects)
                   .HasForeignKey(p => p.ProjectManagerId);

            builder.HasMany(p => p.Employees)
                   .WithMany(e => e.ParticipatedProjects)
                   .UsingEntity(j => j.ToTable("EmployeeProjects"));
        }
    }
}
