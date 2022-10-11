using CRUD_DDD.Application.Books.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Application.Books.Validators
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookDto>
    {
        public DeleteBookValidator()
        {
             RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("{PropertyName} is required");            
        }
    }
}
