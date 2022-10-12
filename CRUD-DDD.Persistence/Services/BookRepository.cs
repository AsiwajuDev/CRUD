using CRUD_DDD.Application.Interfaces.Persistence;
using CRUD_DDD.Application.Interfaces.Repositories;
using CRUD_DDD.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DDD.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IAppDbContext _context;
        public BookRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Book book, CancellationToken token)
        {
            await Task.Run(() => _context.Books.AddAsync(book));
            return await SaveAsync(token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            await Task.Run(() => _context.Books.Remove(book));
            return await SaveAsync(token);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.Run(() => _context.Books.ToListAsync());
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await Task.Run(() => _context.Books.Where(x => x.Id == id).FirstOrDefault());
        }

        public async Task<Book> GetbyTitle(string title)
        {
            return await Task.Run(() => _context.Books.Where(x => x.Title.ToLower() == title.ToLower()).FirstOrDefault());
        }

        public async Task<bool> UpdateAsync(Book book, CancellationToken token)
        {
            await Task.Run(() => _context.Books.Update(book));
            return await SaveAsync(token);
        }

        private async Task<bool> SaveAsync(CancellationToken token)
        {
            if (await _context.SaveChangesAsync(token) > 0)
                return true;
            else
                return false;
        }
    }
}
