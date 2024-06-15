using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class EmployeeStatusConfiguration : IEntityTypeConfiguration<EmployeeStatus>
    {
        public void Configure(EntityTypeBuilder<EmployeeStatus> builder)
        {
            builder
                .HasKey(pt => pt.Id);

            builder
                .Property(pt => pt.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(es => es.EmployeeStatusName)
                .IsRequired();
        }
    }
}