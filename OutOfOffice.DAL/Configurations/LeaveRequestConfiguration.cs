using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {

            builder
                .HasKey(lr => lr.Id);

            builder
                .Property(lr => lr.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(lr => lr.StartDate)
                .IsRequired();

            builder
                .Property(lr => lr.EndDate)
                .IsRequired();

            builder
                .HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId);

            builder
                .HasOne(lr => lr.AbsenceReason)
                .WithMany(ar => ar.LeaveRequests)
                .HasForeignKey(lr => lr.AbsenceReasonId);

            builder
                .HasOne(lr => lr.LeaveRequestStatus)
                .WithMany(lrs => lrs.LeaveRequests)
                .HasForeignKey(lr => lr.LeaveRequestStatusId);
        }
    }
}