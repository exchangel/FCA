using FCA.Business.Dtos.GroupDtos;
using FCA.Business.Services;
using FCA.Data.Entities;
using FCA.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Managers
{
    public class GroupManager : IGroupService
    {
        private readonly IRepository<GroupEntity> _groupRepository;

        public GroupManager(IRepository<GroupEntity> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        //DI

        public void AddGroup(AddGroupDto addGroupDto)
        {
            var groupEntity = new GroupEntity()
            {
                Name = addGroupDto.Name,
                StartDate = addGroupDto.StartDate,
                EndDate = addGroupDto.EndDate,
                Price = addGroupDto.Price,
                UserId = addGroupDto.UserId,
                CustomerCount = addGroupDto.CustomerCount,
                Note = addGroupDto.Note,

            };

            _groupRepository.Add(groupEntity);
        }

        public void DeleteGroup(int id)
        {
            _groupRepository?.Delete(id);
        }

        public void EditGroup(EditGroupDto editGroupDto)
        {
            var groupEntity = _groupRepository.GetById(editGroupDto.Id);

            groupEntity.Name = editGroupDto.Name;
            groupEntity.StartDate = editGroupDto.StartDate;
            groupEntity.EndDate = editGroupDto.EndDate;
            groupEntity.Price = editGroupDto.Price;
            groupEntity.UserId = editGroupDto.UserId;
            groupEntity.CustomerCount = editGroupDto.CustomerCount;
            groupEntity.Note = editGroupDto.Note;

            _groupRepository.Update(groupEntity);
        }

        public EditGroupDto GetGroupById(int id)
        {
            var groupEntity = _groupRepository.GetById(id);

            var editGroupDto = new EditGroupDto()
            {
                Id = groupEntity.Id,
                Name = groupEntity.Name,
                StartDate = groupEntity.StartDate,
                EndDate = groupEntity.EndDate,
                Price = groupEntity.Price,
                UserId = groupEntity.UserId,
                CustomerCount = groupEntity.CustomerCount,
                Note = groupEntity.Note,

            };

            return editGroupDto;
        }

        public List<ListGroupDto> GetGroups()
        {
            var groupEntities = _groupRepository.GetAll().OrderBy(x => x.StartDate);

            var groupDtoList = groupEntities.Select(x => new ListGroupDto
            {
                Id = x.Id,
                Name = x.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price = x.Price,
                UserId = x.UserId,
                CustomerCount = x.CustomerCount,
                Note = x.Note,
            }).ToList();

            return groupDtoList;
        }

        public List<ListGroupDto> GetGroupsByUserId(int? userId)
        {
            if(userId.HasValue)
            {
                var groupEntities = _groupRepository.GetAll(x => x.UserId == userId).OrderBy(x => x.UserId);

                var groupDtos = groupEntities.Select(x => new ListGroupDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Price = x.Price,
                    UserId = x.UserId,
                    Note = x.Note,
                    CustomerCount = x.CustomerCount,
                    UserName = (x.User.FirstName + " " + x.User.LastName)
                }).ToList();

                return groupDtos;
            }
            else
            {
                return GetGroups();
            }
        }
    }
}
