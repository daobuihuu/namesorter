using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace AcePointer.Assignment.NameSorter.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddComposite<TInterface, TConcrete>(this IServiceCollection services)
        where TInterface : class
        where TConcrete : class, TInterface
        {
            var wrappedDescriptors = services.Where(s => s.ServiceType == typeof(TInterface)).ToList();
            foreach (var descriptor in wrappedDescriptors)
                services.Remove(descriptor);

            var objectFactory = ActivatorUtilities.CreateFactory(
              typeof(TConcrete),
              new[] { typeof(IEnumerable<TInterface>) });

            services.Add(ServiceDescriptor.Describe(
              typeof(TInterface),
              s => (TInterface)objectFactory(s, new[] { wrappedDescriptors.Select(d => ActivatorUtilities.CreateInstance<TConcrete>(s, d)).Cast<TInterface>() }),
              wrappedDescriptors.Select(d => d.Lifetime).Max())
            );

            return services;
        }
    }
}
