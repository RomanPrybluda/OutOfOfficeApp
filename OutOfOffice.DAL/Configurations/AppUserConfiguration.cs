using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfOffice.DAL.Models;

namespace OutOfOffice.DAL
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasKey(ap => ap.Id);

            builder
                .Property(ap => ap.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(ap => ap.Name)
                .IsRequired();

            builder
                .Property(ap => ap.Surname)
                .IsRequired();

            builder
                .Property(ap => ap.Email)
                .IsRequired();

            builder
                .Property(ap => ap.Password)
                .IsRequired();

            builder
                .Property(ap => ap.FullName);

            builder
                .HasOne(ap => ap.Employee)
                .WithOne(e => e.AppUser)
                .HasForeignKey<Employee>(e => e.Id);
        }
    }
}