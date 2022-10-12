using CRUD_DDD.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DDD.Application.Interfaces.Persistence
{
    public interface IAppDbContext
    {
        DbSet<Book> Books { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
