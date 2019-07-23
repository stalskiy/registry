using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registry.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Api.Infrastructure.Extentions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        /// <param name="hostingEnvironment">Hosting environment</param>
        /// <returns>Configured service provider</returns>
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services,
            IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            //add HttpContext accessor
            services.AddHttpContextAccessor();

            //add CORS
            services.AddCors();

            //add MVC
            services.AddMvc();

            //add dbcontext 
            var connectionString = configuration["ConnectionStrings:Registry"].ToString();
            services.AddDbContext<RegistryDbContext>(t => t.UseSqlServer(connectionString));

            //create engine
            var engine = EngineContext.Create();
            var serviceProvider = engine.ConfigureServices(services);

            var sqlProvider = new SqlServerDataProvider();
            sqlProvider.InitializeDatabase();

            return serviceProvider;
        }
    }
}
