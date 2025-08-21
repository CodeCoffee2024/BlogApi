using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogV3.Infrastructure.Data
{
    public class DatabaseSeeder
    {
        #region Public Methods

        public static async Task SeedAsync(AppDbContext context, ILogger logger, IPasswordHasherService passwordHasherService)
        {
            // Apply any pending migrations
            await context.Database.MigrateAsync();

            // Seed data if none exists
            if (!context.Users.Any())
            {
                var admin = User.Seed("admin", "admin@email.com", passwordHasherService.HashPassword("password"), "activ", "admin", "admin", "");
                context.Users.Add(admin);
                admin.FlagAsSystemGenerated();
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded default user.");

                // Create module
                Module[] modules = [
                    Module.Create("Modules", "/modules", admin.Id!.Value),
                    Module.Create("Posts", "/posts", admin.Id!.Value),
                    Module.Create("Categories", "/categories", admin.Id!.Value),
                    Module.Create("Users", "/users", admin.Id!.Value),
                    Module.Create("Dashboard", "/admin/dashboard", admin.Id!.Value)
                ];
                var module = modules[0];
                var post = modules[1];
                var category = modules[2];
                var user = modules[3];
                var dashboard = modules[4];
                dashboard.FlagAsSystemGenerated();
                // Add permissions module
                var viewPermissionModule = module.AddPermission("View");
                var editPermissionModule = module.AddPermission("Modify");
                module.FlagAsSystemGenerated();

                // Add permissions post
                var viewPermissionPost = post.AddPermission("View");
                var editPermissionPost = post.AddPermission("Modify");
                post.FlagAsSystemGenerated();

                // Add permissions category
                var viewPermissionCategory = category.AddPermission("View");
                var editPermissionCategory = category.AddPermission("Modify");
                category.FlagAsSystemGenerated();

                // Add permissions user
                var viewPermissionUser = user.AddPermission("View");
                var editPermissionUser = user.AddPermission("Modify");
                user.FlagAsSystemGenerated();

                // Create role
                var adminRole = Role.Create("Admin", admin.Id!.Value);
                adminRole.AddPermission(viewPermissionModule);
                adminRole.AddPermission(editPermissionModule);
                adminRole.AddPermission(viewPermissionPost);
                adminRole.AddPermission(editPermissionPost);
                adminRole.AddPermission(viewPermissionCategory);
                adminRole.AddPermission(editPermissionCategory);
                adminRole.AddPermission(viewPermissionUser);
                adminRole.AddPermission(editPermissionUser);
                admin.AssignRole(adminRole);

                // Add to DB
                await context.Modules.AddRangeAsync(modules);
                await context.Roles.AddAsync(adminRole);
                await context.SaveChangesAsync();
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