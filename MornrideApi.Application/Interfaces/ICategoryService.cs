using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAll();
        public Category? GetById(int id);
        public Task<bool> AddCategory(CreateCategoryDto category);
    }
}
