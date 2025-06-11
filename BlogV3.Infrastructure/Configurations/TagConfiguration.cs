using BlogV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogV3.Infrastructure.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        #region Public Methods

        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.HasOne(t => t.Post)
                   .WithMany(p => p.Tags)
                   .HasForeignKey(t => t.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        #endregion Public Methods
    }
}