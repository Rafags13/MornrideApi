using Arch.EntityFrameworkCore.UnitOfWork;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddCategory(CreateCategoryDto category)
        {
            var newCategory = new Category { Name = category.Name, Description = category.Description};
            _unitOfWork.GetRepository<Category>().Insert(newCategory);
            var sucess = await _unitOfWork.SaveChangesAsync() > 0;
            return sucess;
        }

        public async Task<List<Category>> GetAll()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetPagedListAsync();
            return categories.Items.ToList();
        }

        public Category? GetById(int id)
        {
            var category = _unitOfWork.GetRepository<Category>().GetFirstOrDefault(predicate: x => x.Id == id);
            return category;
        }
    }
}
