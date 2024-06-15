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
                .Property(e => e.Subdivision)
                .IsRequired();

            builder
                .Property(e => e.Position)
                .IsRequired();

            builder
                .Property(e => e.EmployeeStatus)
                .IsRequired();

            builder
                .Property(e => e.PeoplePartner)
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
                .HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}