using Autofac;
using Microsoft.EntityFrameworkCore;
using Registry.Core.Configuration;
using Registry.Core.Data;
using Registry.Core.Infrastructure;
using Registry.Core.Infrastructure.DependencyManagement;
using Registry.Data;
using Registry.Services.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Api.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, Config config)
        {
        }

        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        public void Register(ContainerBuilder builder)
        {
            //file provider
            builder.RegisterType<EngineFileProvider>().As<IEngineFileProvider>().InstancePerLifetimeScope();

            //repositories
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //services
            builder.RegisterType<AreaService>().As<IAreaService>().InstancePerLifetimeScope();

            //dbcontexts
            builder.Register(context => new RegistryDbContext(context.Resolve<DbContextOptions<RegistryDbContext>>()))
                .As<IDbContext>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 2; }
        }

    }
}
