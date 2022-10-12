using AutoMapper;
using CRUD_DDD.Application.Books.Dto;
using CRUD_DDD.Domain.Books;

namespace CRUD_DDD.Api.Mapper
{
    public class CRUDProfile : Profile
    {
        public CRUDProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();            
        }
    }
}
