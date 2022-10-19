using CRUD_DDD.Application.Interfaces.Persistence;
using CRUD_DDD.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Persistence.Extensions
{
    public static class Extensions
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {           

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IAppDbContext, AppDbContext>();
        }
    }
}
