using FCA.Business.Dtos.GroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Services
{
    public interface IGroupService
    {
        void AddGroup(AddGroupDto addGroupDto);

        List<ListGroupDto> GetGroups();

        EditGroupDto GetGroupById(int id);

        void EditGroup(EditGroupDto editGroupDto);

        void DeleteGroup(int id);

        List<ListGroupDto>GetGroupsByUserId(int? userId);
    }
}
