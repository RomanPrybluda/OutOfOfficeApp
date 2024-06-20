using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class ApprovalRequestConfiguration : IEntityTypeConfiguration<ApprovalRequest>
    {
        public void Configure(EntityTypeBuilder<ApprovalRequest> builder)
        {

            builder
                .ToTable("ApprovalRequest");

            builder
                .HasKey(ar => ar.Id);

            builder
                .Property(ar => ar.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasOne(ar => ar.Approver)
                .WithMany(e => e.ApprovalRequests)
                .HasForeignKey(ar => ar.ApproverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ar => ar.LeaveRequest)
                .WithOne(lr => lr.CurrentApprovalRequest)
                .HasForeignKey<ApprovalRequest>(ar => ar.LeaveRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(ar => ar.RequestStatus)
                .WithMany(rs => rs.ApprovalRequests)
                .HasForeignKey(ar => ar.RequestStatusId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
