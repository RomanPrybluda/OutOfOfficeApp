using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class RequestStatusConfiguration : IEntityTypeConfiguration<RequestStatus>
    {
        public void Configure(EntityTypeBuilder<RequestStatus> builder)
        {

            builder
                .ToTable("RequestStatus");

            builder
                .HasKey(pt => pt.Id);

            builder
                .Property(pt => pt.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(rs => rs.RequestStatusName)
                .IsRequired();
        }
    }
}