using BlogV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogV3.Infrastructure.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        #region Public Methods

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(5);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Posts)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

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