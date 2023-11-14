using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Services
{
    public class UserService : IUserService
    {
        public HomeUserInformations GetHomeInformations()
        {
            return new HomeUserInformations();
        }
    }
}
