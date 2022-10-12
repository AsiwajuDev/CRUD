using CRUD_DDD.Application.Interfaces.Persistence;
using CRUD_DDD.Application.Interfaces.Repositories;
using CRUD_DDD.Application.Interfaces.Services;
using CRUD_DDD.Application.Services;
using CRUD_DDD.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_DDD.Persistence.Repositories
{
    public static class Extension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IAppDbContext, AppDbContext>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookServices>();
        }
    }
}
