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
                .ToTable("AppUser");

            builder
                .HasKey(au => au.Id);

            builder
                .Property(au => au.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(au => au.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(au => au.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(au => au.Email)
                .IsRequired();

            builder
                .Ignore(au => au.FullName);

            builder
                .Property(au => au.Password)
                .IsRequired();

            builder.HasOne(au => au.CurrentEmployee)
                   .WithOne(e => e.AppUser)
                   .HasForeignKey<Employee>(e => e.AppUserId)
                   .OnDelete(DeleteBehavior.NoAction);


        }
    }
}