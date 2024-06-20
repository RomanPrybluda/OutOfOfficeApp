using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class EmployeeStatusConfiguration : IEntityTypeConfiguration<EmployeeStatus>
    {
        public void Configure(EntityTypeBuilder<EmployeeStatus> builder)
        {

            builder
                .ToTable("EmployeeStatus");

            builder
                .HasKey(es => es.Id);

            builder
                .Property(es => es.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(es => es.EmployeeStatusName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}