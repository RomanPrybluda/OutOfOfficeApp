using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class LeaveRequestStatusConfiguration : IEntityTypeConfiguration<LeaveRequestStatus>
    {
        public void Configure(EntityTypeBuilder<LeaveRequestStatus> builder)
        {
            builder
                .HasKey(pt => pt.Id);

            builder
                .Property(pt => pt.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(rs => rs.LeaveRequestStatusName)
                .IsRequired();
        }
    }
}