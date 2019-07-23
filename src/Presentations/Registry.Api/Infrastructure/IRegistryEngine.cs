using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Api.Infrastructure
{
    /// <summary>
    /// Classes implementing this interface can serve as a portal for the various services composing the engine. 
    /// Edit functionality, modules and implementations access most functionality through this interface.
    /// </summary>
    public interface IRegistryEngine
    {
        /// <summary>
        /// Get service service provider
        /// </summary>
        /// <returns>Service provider</returns>
        IServiceProvider GetServiceProvider();

        /// <summary>
        /// Add and configure services
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>Service provider</returns>
        IServiceProvider ConfigureServices(IServiceCollection services);

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">Type of resolved service</typeparam>
        /// <returns>Resolved service</returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <param name="type">Type of resolved service</param>
        /// <returns>Resolved service</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">Type of resolved services</typeparam>
        /// <returns>Collection of resolved services</returns>
        IEnumerable<T> ResolveAll<T>();
    }
}
