using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {

            builder
                .ToTable("LeaveRequest");

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
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(lr => lr.AbsenceReason)
                .WithMany(ar => ar.LeaveRequests)
                .HasForeignKey(lr => lr.AbsenceReasonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasOne(lr => lr.RequestStatus)
                 .WithMany(ar => ar.LeaveRequests)
                 .HasForeignKey(lr => lr.RequestStatusId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasOne(lr => lr.CurrentApprovalRequest)
                 .WithOne(ar => ar.LeaveRequest)
                 .HasForeignKey<ApprovalRequest>(ar => ar.LeaveRequestId)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}