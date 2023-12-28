using App.BUSINESS.DTOs.Category;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.DTOs.Brand
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? LogoImg { get; set; }

    }
    public class CategoryUpdateDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Required")
                .MinimumLength(3).WithMessage("Name must contains at least 3 characters")
                .MaximumLength(100).WithMessage("Name must be shorter than 55 chracters.");
        }
    }
}
