﻿using System.Reflection;

using Common.Domain.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Common.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddCommonDomain(this IServiceCollection services, Assembly assembly)
            => services.AddFactories(assembly);

        private static IServiceCollection AddFactories(this IServiceCollection services, Assembly assembly)
            => services.Scan(scan => scan
                           .FromAssemblies(assembly)
                           .AddClasses(classes => classes
                               .AssignableTo(typeof(IFactory<>)))
                           .AsMatchingInterface()
                           .WithTransientLifetime());
    }
}
