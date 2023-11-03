using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Interfaces
{
    public interface ImgService
    {
        public Task<bool> UploadImage(CreateImageDto image);
        public Task<List<Image>> GetImages();
    }
}
