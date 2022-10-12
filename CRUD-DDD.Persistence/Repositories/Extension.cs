using CRUD_DDD.Application.Interfaces.Repositories;
using CRUD_DDD.Application.Interfaces.Services;
using CRUD_DDD.Application.Repositories;
using CRUD_DDD.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Persistence.Repositories
{
    public static class Extension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookServices>();
        }
    }
}
