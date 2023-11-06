using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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
    public class BikeCategoryService : IBikeCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BikeCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateLinkForBike(CreateBikeCategoryDto createLinkBikeCategoryDto)
        {
            var newBikeCategory = new BikeCategory { BikeId = createLinkBikeCategoryDto.BikeId, CategoryId =  createLinkBikeCategoryDto.CategoryId };
            _unitOfWork.GetRepository<BikeCategory>().Insert(newBikeCategory);
            var sucessful = await _unitOfWork.SaveChangesAsync() > 0;

            return sucessful;
        }

        public async Task<IEnumerable<BikeCategory>> GetAll()
        {
            var allBikeCategories = await _unitOfWork.GetRepository<BikeCategory>().GetPagedListAsync(include: x => x.Include(p => p.Bike).Include(p => p.Category));

            return allBikeCategories.Items;
            
        }
    }
}
