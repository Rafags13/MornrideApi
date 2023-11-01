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
        public List<Category> GetAll();
        public Category GetById(int id);
        public bool AddCategory(Category category);
    }
}
