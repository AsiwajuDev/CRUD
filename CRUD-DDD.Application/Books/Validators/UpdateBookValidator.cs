using CRUD_DDD.Application.Books.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Application.Books.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidator()
        {
            {
                RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
                RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
                RuleFor(x => x.Author).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
                RuleFor(x => x.ISBN).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
                RuleFor(x => x.Publisher).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
                RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
                RuleFor(x => x.Language).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
                RuleFor(x => x.Category).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
            }
        }
    }
}
