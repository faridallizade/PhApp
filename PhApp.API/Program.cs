using System;
using App.BUSINESS.DTOs.Brand;
using App.BUSINESS.DTOs.Category;
using App.BUSINESS.Services.Implementations;
using App.BUSINESS.Services.Interfaces;
using App.DAL.Context;
using App.DAL.Repositories.Implementations;
using App.DAL.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace PhApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddTransient<IValidator<CreateCategoryDto>, CategoryCreateDtoValidator>();
            builder.Services.AddTransient<IValidator<UpdateCategoryDto>, CategoryUpdateDtoValidator>();
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}