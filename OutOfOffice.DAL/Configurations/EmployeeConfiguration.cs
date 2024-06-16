using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(e => e.FullName)
                .IsRequired();

            builder
                .Property(e => e.OutOfOfficeBalance)
                .IsRequired();

            builder
                .HasOne(e => e.Subdivision)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.SubdivisionId);

            builder
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId);

            builder
                .HasOne(e => e.EmployeeStatus)
                .WithMany()
                .HasForeignKey(e => e.EmployeeStatusId);

            builder
                .HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.ManagedProjects)
                   .WithOne(p => p.ProjectManager)
                   .HasForeignKey(p => p.ProjectManagerId);

            builder.HasMany(e => e.ParticipatedProjects)
                   .WithMany(p => p.Employees)
                   .UsingEntity(j => j.ToTable("EmployeeProjects"));

        }

    }
}