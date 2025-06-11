using BlogV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogV3.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        #region Public Methods

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(ut => ut.Id);
            builder.Property(ut => ut.Id)
                .ValueGeneratedOnAdd();
            builder.Property(ut => ut.UserName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(ut => ut.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(ut => ut.Password)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(ut => ut.Status)
                .IsRequired()
                .HasMaxLength(5);
            builder.Property(ut => ut.FirstName)
                .IsRequired()
                .HasMaxLength(5);
            builder.Property(ut => ut.MiddleName)
                .IsRequired()
                .HasMaxLength(5);
            builder.Property(ut => ut.LastName)
                .IsRequired()
                .HasMaxLength(5);
            builder.HasOne(u => u.CreatedBy)
                .WithMany()
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedBy)
                .WithMany()
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion Public Methods
    }
}