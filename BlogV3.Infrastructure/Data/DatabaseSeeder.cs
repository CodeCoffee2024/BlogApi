using BlogV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogV3.Infrastructure.Data
{
    public class DatabaseSeeder
    {
        #region Public Methods

        public static async Task SeedAsync(AppDbContext context, ILogger logger)
        {
            // Apply any pending migrations
            await context.Database.MigrateAsync();

            // Seed data if none exists
            if (!context.Users.Any())
            {
                var admin = User.Seed("admin", "admin@email.com", "password", "activ", "admin", "admin", "");
                context.Users.Add(admin);
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded default user.");
            }
            if (!context.Categories.Any())
            {
                var admin = context.Users.Where(it => it.Email == "admin@email.com").FirstOrDefaultAsync();
                context.Categories.AddRange(
                    Category.Create("Test Category", "activ", DateTime.Now, admin.Result!.Id!.Value),
                    Category.Create("Test Category 2", "activ", DateTime.Now, admin.Result.Id!.Value)
                );
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded default categories.");
            }
            if (!context.Posts.Any())
            {
                var admin = await context.Users.Where(it => it.Email == "admin@email.com").FirstOrDefaultAsync();

                var category = await context.Categories.Where(it => it.Name == "Test Category").FirstOrDefaultAsync();

                if (admin != null && category != null)
                {
                    context.Posts.AddRange(
                        Post.Create(category.Id!.Value, "activ", "Test Title 1", "Test Description 1", DateTime.Now, admin!.Id!.Value),
                        Post.Create(category.Id!.Value, "activ", "Test Title 2", "Test Description 2", DateTime.Now, admin!.Id!.Value)
                    );
                    await context.SaveChangesAsync();

                    var post = await context.Posts
                        .Where(it => it.Title == "Test Title 1")
                        .FirstOrDefaultAsync();

                    if (post != null)
                    {
                        context.Tags.AddRange(
                            Tag.Create(post.Id!.Value, "Tag 1"),
                            Tag.Create(post.Id!.Value, "Tag 2")
                        );
                        await context.SaveChangesAsync();
                        logger.LogInformation("Seeded default posts.");
                    }
                }
            }

            // Add more seeds here...
        }

        #endregion Public Methods
    }
}