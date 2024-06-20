using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder
                .ToTable("Employee");

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
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Subdivision)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.SubdivisionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.EmployeeStatus)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.EmployeeStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.AppUser)
                .WithOne(e => e.CurrentEmployee)
                .HasForeignKey<Employee>(e => e.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}