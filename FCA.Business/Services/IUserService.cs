using FCA.Business.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Services
{
    public interface IUserService
    {
        UserInfoDto LoginUser(LoginDto loginDto);

        List<ListUserDto> GetUsers();
    }
}
