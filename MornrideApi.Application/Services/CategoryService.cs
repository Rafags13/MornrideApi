using Arch.EntityFrameworkCore.UnitOfWork;
using MornrideApi.Application.Interfaces;
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

        public bool AddCategory(Category category)
        {
            return true;
        }

        public List<Category> GetAll()
        {
            return new List<Category>();
        }

        public Category GetById(int id)
        {
            return new Category();
        }
    }
}
