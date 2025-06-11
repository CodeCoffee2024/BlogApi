using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlogV3.Application
{
    public static class DependencyInjection
    {
        #region Public Methods

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly()
                );
            });
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

            services.AddAutoMapper(typeof(AutomapperProfile));
            return services;
        }

        #endregion Public Methods
    }
}