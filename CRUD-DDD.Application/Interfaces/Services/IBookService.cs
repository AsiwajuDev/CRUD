using CRUD_DDD.Application.Books.Dto;
using CRUD_DDD.Application.Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<ResponseDto<BookResponse>> CreateBook(CreateBookDto bookDto, CancellationToken cancellationToken);
        Task<ResponseDto<BookResponse>> UpdateBook(UpdateBookDto bookDto, CancellationToken cancellationToken);
        Task<ResponseDto<BookResponse>> DeleteBook(int id, CancellationToken cancellationToken);
        Task<IEnumerable<BookResponse>> GetAllBooks();
        Task<ResponseDto<BookResponse>> GetBookById(int id);
    }
}
