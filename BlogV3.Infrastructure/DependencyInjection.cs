using BlogV3.Application.Interfaces.Common;
using BlogV3.Application.Interfaces.Services;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Auth;
using BlogV3.Infrastructure.Data;
using BlogV3.Infrastructure.Repositories;
using BlogV3.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogV3.Infrastructure
{
    public static class DependencyInjection
    {
        #region Public Methods

        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            //services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<PasswordHasher<object>>();

            AddPersistence(services, configuration);

            return services;
        }

        #endregion Public Methods

        #region Private Methods

        private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(configuration), "Database connection string is missing!");
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString).UseLazyLoadingProxies());
        }

        #endregion Private Methods
    }
}