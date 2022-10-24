using AutoMapper;
using CRUD_DDD.Application.Books.Dto;
using CRUD_DDD.Application.Books.Models;
using CRUD_DDD.Application.Interfaces.Repositories;
using CRUD_DDD.Application.Interfaces.Services;
using CRUD_DDD.Domain.Books;
using Microsoft.AspNetCore.Http;

namespace CRUD_DDD.Application.Services
{
    public class BookServices : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookServices(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<ResponseDto<BookResponse>> CreateBook(CreateBookDto bookDto, CancellationToken cancellationToken)
        {
            ResponseDto<BookResponse> response = new ResponseDto<BookResponse>();
            try
            {
                var isExist = await _bookRepository.GetbyTitle(bookDto.Title);
                if (isExist != null)
                {
                    response.ResponseMessage = "Book Already Exist";
                    response.ResponseCode = StatusCodes.Status409Conflict;
                    return response;
                }

                var bookObj = _mapper.Map<Book>(bookDto);
                var result = await _bookRepository.AddAsync(bookObj, cancellationToken);

                if (result)
                {
                    var resp = await _bookRepository.GetByIdAsync(bookObj.Id);
                    var data = _mapper.Map<BookResponse>(resp);
                    response.Data = data;
                    response.ResponseMessage = "Book Created successfully";
                    response.ResponseCode = StatusCodes.Status201Created;
                }
                else
                {
                    response.ResponseMessage = "Failed";
                    response.ResponseCode = StatusCodes.Status503ServiceUnavailable;
                }
               

                return response;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                response.ResponseCode = StatusCodes.Status500InternalServerError;
                response.ResponseMessage = "An Error Occurred";
                return response;
            }
        }

        public async Task<ResponseDto<BookResponse>> DeleteBook(int id, CancellationToken cancellationToken)
        {
            ResponseDto<BookResponse> response = new ResponseDto<BookResponse>();
            try
            {
                var delete = await _bookRepository.DeleteAsync(id, cancellationToken);
                if (delete)
                {
                    response.ResponseMessage = "Book Deleted successfully";
                    response.ResponseCode = StatusCodes.Status204NoContent;
                }
                else
                {
                    response.ResponseMessage = "Failed";
                    response.ResponseCode = StatusCodes.Status503ServiceUnavailable;
                }
                return response;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                response.ResponseCode = StatusCodes.Status500InternalServerError;
                response.ResponseMessage = "An Error Occurred";
                return response;
            }
        }

        public async Task<IEnumerable<BookResponse>> GetAllBooks()
        {
            var bookList = new List<BookResponse>();
            var books = await _bookRepository.GetAllAsync();
            foreach (var item in books)
            {
                bookList.Add(_mapper.Map<BookResponse>(item));
            }
            return bookList;
        }

        public async Task<ResponseDto<BookResponse>> GetBookById(int id)
        {
            ResponseDto<BookResponse> response = new ResponseDto<BookResponse>();
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if(book != null)
                {
                    response.ResponseMessage = "Book successfully loaded";
                    response.ResponseCode = StatusCodes.Status200OK;
                    response.Data = _mapper.Map<BookResponse>(book);
                }
                else
                {
                    response.ResponseMessage = "Book not found";
                    response.ResponseCode = StatusCodes.Status404NotFound;
                }
                return response;
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
                response.ResponseCode = StatusCodes.Status500InternalServerError;
                response.ResponseMessage = "An Error Occurred";
                return response;
            }
        }

        public async Task<ResponseDto<BookResponse>> UpdateBook(UpdateBookDto bookDto, CancellationToken cancellationToken)
        {
            ResponseDto<BookResponse> response = new ResponseDto<BookResponse>();
            try
            {
                var book = await _bookRepository.GetByIdAsync(bookDto.Id);
                if (book == null)
                {
                    response.ResponseMessage = "Book Not Found";
                    response.ResponseCode = StatusCodes.Status404NotFound;
                    //response.Data = _mapper.Map<BookResponse>(book);
                }

                //var updateObj = _mapper.Map<Book>(bookDto);
                book.Title = bookDto.Title;
                book.Author = bookDto.Author;
                book.Description = bookDto.Description;
                book.Category = bookDto.Category;
                book.ISBN = bookDto.ISBN;
                book.Language = bookDto.Language;
                var result = await _bookRepository.UpdateAsync(book, cancellationToken);
                if (result)
                {
                    response.ResponseCode = StatusCodes.Status204NoContent;
                    response.ResponseMessage = "Book Updated Successfully";
                }
                
                return response;
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
                response.ResponseCode = StatusCodes.Status500InternalServerError;
                response.ResponseMessage = "An Error Occurred";
                return response;
            }
        }
    }
}
