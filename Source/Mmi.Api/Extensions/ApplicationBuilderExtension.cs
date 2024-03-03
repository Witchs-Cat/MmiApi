using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mmi.Core.Repositories;
using Mmi.DataAccess;
using Mmi.DataAccess.Repositories;
using Mmi.Services.Authentication;
using System.Reflection;

namespace Mmi.Api.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IServiceCollection UseSqliteDb(this IServiceCollection services, string connectionString)
        {
            return services
                .AddTransient<IInsuredPersonRepository, InsuredPersonRepository>()
                .AddDbContext<MedicalInsuranceDb>(options =>
                {
                    options.UseSqlite(connectionString, dbOptions =>
                    {
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        string? assemblyName = assembly.GetName().Name;
                        dbOptions.MigrationsAssembly(assemblyName);
                    });
                });
        }

        public static IServiceCollection UseSimpleAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(nameof(SimpleAuthenticationHandler))
                .AddScheme<AuthenticationSchemeOptions, SimpleAuthenticationHandler>(
                    nameof(SimpleAuthenticationHandler), null);

            return services;
        }
    }
}
