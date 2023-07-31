using FCA.Business.Dtos.UserDtos;
using FCA.Business.Services;
using FCA.Data.Entities;
using FCA.Data.Repositories;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;

        private readonly IDataProtector _dataProtector;
        public UserManager(IRepository<UserEntity> userRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userRepository = userRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        public List<ListUserDto> GetUsers()
        {
            var userEntities = _userRepository.GetAll().OrderBy(x => x.FirstName);

            var userDtoList = userEntities.Select(x => new ListUserDto { 
                FirstName = x.FirstName, 
                LastName = x.LastName,
                Email = x.Email,
                Id = x.Id
                
            }).ToList();

            return userDtoList;
        }

        public UserInfoDto LoginUser(LoginDto loginDto)
        {
            var userEntity = _userRepository.Get(x => x.Email == loginDto.Email);

            if (userEntity is null)
            {
                return null;
            }

            var rawPassword = /*_dataProtector.Unprotect(userEntity.Password);*/ userEntity.Password;

            if (loginDto.Password == rawPassword)
            {
                return new UserInfoDto()
                {
                    Id = userEntity.Id,
                    Email = userEntity.Email,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    UserType = userEntity.UserType
                };
            }
            else
            {
                return null;
            }
        }
    }
}
