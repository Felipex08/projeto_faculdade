using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFaculdade.API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFaculdade.API
{
    public static class Initializer
    {
        public static void Configure(IServiceCollection services, IConfiguration config)
        {
            //ClientConfig.SetConfiguration(ref config);
            //var connectionString = config.GetConnectionString("ColaboradorConnection");
            //services.AddDbContext<ColaboradorContext>(x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //services.AddScoped(typeof(IHobbyService), typeof(HobbyService));
            services.AddScoped(typeof(ApplicationDBContext), typeof(ApplicationDBContext));
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
