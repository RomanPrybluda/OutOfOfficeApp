using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class AbsenceReasonConfiguration : IEntityTypeConfiguration<AbsenceReason>
    {
        public void Configure(EntityTypeBuilder<AbsenceReason> builder)
        {

            builder
                .ToTable("AbsenceReason");

            builder
                .HasKey(ar => ar.Id);

            builder
                .Property(ar => ar.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(ar => ar.AbsenceReasonName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
