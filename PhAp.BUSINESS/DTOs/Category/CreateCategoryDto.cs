using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.DTOs.Category
{
    public record CreateCategoryDto
    {
        public string? Name { get; set; }
        public IFormFile? LogoImg { get; set; }

    }

    public class CategoryCreateDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Required")
                .MinimumLength(3).WithMessage("Name must contains at least 3 characters")
                .MaximumLength(100).WithMessage("Name must be shorter than 55 chracters.");
        }
    }
}
