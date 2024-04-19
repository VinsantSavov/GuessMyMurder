using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Common.Infrastructure.Services;
using Common.Infrastructure.Extensions;
using Common.Infrastructure.Persistence;

namespace Common.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddCommonInfrastructure<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContext
            => services.AddDbContext<TDbContext>(configuration)
                       .AddHostedServices();

        public static IServiceCollection AddHostedServices(this IServiceCollection services)
            => services.AddHostedService<MessagesBackgroundService>();

        private static IServiceCollection AddDbContext<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContext
            => services.AddDbContext<MessagesDbContext>(opt => opt.UseSqlServer(configuration.GetDefaultConnectionString()));
    }
}
