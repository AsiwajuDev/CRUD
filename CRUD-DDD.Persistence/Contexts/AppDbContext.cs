using CRUD_DDD.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using CRUD_DDD.Domain.Books;
using CRUD_DDD.Domain.Common;

namespace CRUD_DDD.Persistence.Contexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
        {
                
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public static AppDbContext Create()
        {
             return new AppDbContext();
        }

        public DbSet<Book> Books { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity> entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdated = DateTime.Now;
                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //         .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
        //         .AddJsonFile("appsettings.json", optional: true)
        //         .AddJsonFile($"appsettings.{envName}.json", optional: true)
        //         .Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //}
    }
}
