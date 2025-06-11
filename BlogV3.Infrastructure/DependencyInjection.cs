using BlogV3.Application.Interfaces.Common;
using BlogV3.Application.Interfaces.Services;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using BlogV3.Infrastructure.Repositories;
using BlogV3.Infrastructure.Services;
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
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

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