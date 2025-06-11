using BlogV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogV3.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        #region Public Methods

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(30);
            builder.Property(c => c.Status)
                   .IsRequired()
                   .HasMaxLength(5);
            builder.HasMany(c => c.Posts)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.CreatedBy)
                   .WithMany()
                   .HasForeignKey(p => p.CreatedById)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.UpdatedBy)
                   .WithMany()
                   .HasForeignKey(p => p.UpdatedById)
                   .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion Public Methods
    }
}