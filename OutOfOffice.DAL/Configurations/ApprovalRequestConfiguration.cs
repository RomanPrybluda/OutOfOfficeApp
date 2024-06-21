using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL.Configurations
{
    public class ApprovalRequestConfiguration : IEntityTypeConfiguration<ApprovalRequest>
    {
        public void Configure(EntityTypeBuilder<ApprovalRequest> builder)
        {
            builder
                .ToTable("ApprovalRequests");

            builder
                .HasKey(ar => ar.Id);

            builder
                .Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasOne(ar => ar.LeaveRequest)
                .WithOne(lr => lr.ApprovalRequest)
                .HasForeignKey<ApprovalRequest>(ar => ar.LeaveRequestId)
                .OnDelete(DeleteBehavior.NoAction);


            builder
                .HasOne(ar => ar.Approver)
                .WithMany(e => e.ApprovalRequests)
                .HasForeignKey(ar => ar.ApproverId)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasOne(ar => ar.RequestStatus)
                .WithMany()
                .HasForeignKey(ar => ar.RequestStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(ar => ar.Comment)
                .HasMaxLength(255);
        }
    }
}
