using FCA.Business.Dtos.GroupDtos;
using FCA.Business.Services;
using FCA.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FCA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GroupController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;
        private readonly ICustomerService _customerService;

        public GroupController(IUserService userService, IGroupService groupService, ICustomerService customerService)
        {
            _groupService = groupService;
            _userService = userService;
            _customerService = customerService;
        }
        //DI

        public IActionResult List()
        {
            var groupDtos = _groupService.GetGroups();

            var viewModel = groupDtos.Select(x => new GroupListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UserId = x.UserId,
                UserName = x.UserName,
                CustomerCount = x.CustomerCount,
                Note = x.Note,
                StartDate = x.StartDate,
                
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New() 
        {
            ViewBag.Users = _userService.GetUsers();
            ViewBag.Customers = _customerService.GetCustomers();

            return View("Form", new GroupFormViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var editGroupDto = _groupService.GetGroupById(id);

            var viewModel = new GroupFormViewModel()
            {
                Id = editGroupDto.Id,
                Name = editGroupDto.Name,
                StartDate = editGroupDto.StartDate,
                EndDate = editGroupDto.EndDate,
                UserId = editGroupDto.UserId,
                Price = editGroupDto.Price,
                CustomerCount= editGroupDto.CustomerCount,
                Note = editGroupDto.Note,
            };

            ViewBag.Users = _userService.GetUsers();
            ViewBag.Customers = _customerService.GetCustomers();
            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Save(GroupFormViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                if(formData.UserId == 0)
                {
                    ViewBag.UserError = "Koç seçilmek zorunda.";
                }

                ViewBag.Users = _userService.GetUsers();
                ViewBag.Customers = _customerService.GetCustomers();
                return View("Form", formData);
            }

            if(formData.Id == 0)
            {
                var addGroupDto = new AddGroupDto()
                {
                    Name = formData.Name,
                    StartDate = formData.StartDate,
                    EndDate = formData.EndDate,
                    UserId = formData.UserId,
                    Note = formData.Note,
                    CustomerCount = formData.CustomerCount,
                    Price = formData.Price,
                };

                _groupService.AddGroup(addGroupDto);
                return RedirectToAction("List");
            }
            else //update
            {
                var editGroupDto = new EditGroupDto()
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    StartDate = formData.StartDate,
                    EndDate = formData.EndDate,
                    UserId = formData.UserId,
                    Note = formData.Note,
                    CustomerCount = formData.CustomerCount,
                    Price = formData.Price,
                };

                _groupService.EditGroup(editGroupDto);
                return RedirectToAction("List");
            }
        }

        public IActionResult Delete(int id)
        {
            _groupService.DeleteGroup(id);

            return RedirectToAction("List");
        }

    }
}
