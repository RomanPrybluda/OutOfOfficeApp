using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OutOfOffice.DAL
{
    public class SubdivisionConfiguration : IEntityTypeConfiguration<Subdivision>
    {
        public void Configure(EntityTypeBuilder<Subdivision> builder)
        {

            builder
                .HasKey(sd => sd.Id);

            builder
                .Property(sd => sd.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(s => s.SubdivisionName)
                .IsRequired();
        }
    }
}