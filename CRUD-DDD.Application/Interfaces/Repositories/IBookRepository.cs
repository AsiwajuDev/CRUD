using CRUD_DDD.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Application.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<bool> AddAsync(Book book, CancellationToken token);
        Task<bool> UpdateAsync(Book book, CancellationToken token);
        Task<bool> DeleteAsync(int id, CancellationToken token);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> GetbyTitle(string title);
    }
}
