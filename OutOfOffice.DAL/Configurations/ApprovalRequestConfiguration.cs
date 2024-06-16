using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class ApprovalRequestConfiguration : IEntityTypeConfiguration<ApprovalRequest>
    {
        public void Configure(EntityTypeBuilder<ApprovalRequest> builder)
        {
            builder
                .HasKey(ar => ar.Id);

            builder
                .Property(ar => ar.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(ar => ar.LeaveRequestStatus)
                .IsRequired();

            builder
                .HasOne(ar => ar.Approver)
                .WithMany(e => e.ApprovalRequests)
                .HasForeignKey(ar => ar.ApproverId);

            builder
                .HasOne(ar => ar.LeaveRequest)
                .WithMany(lr => lr.ApprovalRequests)
                .HasForeignKey(ar => ar.LeaveRequestId);

        }
    }
}
