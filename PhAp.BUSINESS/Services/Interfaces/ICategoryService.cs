using App.BUSINESS.DTOs.Brand;
using App.BUSINESS.DTOs.Category;
using App.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<Category> GetById(int id);
        Task Create(CreateCategoryDto createCategoryDto);
        Task Delete(int id);
        Task Update(UpdateCategoryDto updateCategoryDto);

    }
}
