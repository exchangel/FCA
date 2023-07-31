using FCA.Business.Dtos;
using FCA.Business.Dtos.SessionDtos;
using FCA.Business.Services;
using FCA.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FCA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PersonalSessionController : Controller
    {
        private readonly ICustomerService _customerService;

        private readonly IUserService _userService;

        private readonly IPersonalSessionService _personalSessionService;

        public PersonalSessionController(IPersonalSessionService personalSessionService, ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
            _personalSessionService = personalSessionService;

        }
        //DI

        public ActionResult List() 
        {
            var sessionDtos = _personalSessionService.GetSessions();

            var viewModel = sessionDtos.Select(x => new SessionListViewModel
            {
                Id = x.Id,
                SessionName = x.SessionName,
                SessionDate = x.SessionDate,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                UserName = x.UserName,
                Note = x.Note,
                Price = x.Price,
                UserId = x.UserId,
                
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.Customers = _customerService.GetCustomers();
            ViewBag.Users = _userService.GetUsers();
            return View("Form", new SessionFormViewModel());
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editSessionDto = _personalSessionService.GetSessionById(id);

            var viewModel = new SessionFormViewModel()
            {
                Id = editSessionDto.Id,
                SessionName = editSessionDto.SessionName,
                SessionDate = editSessionDto.SessionDate,
                CustomerId = editSessionDto.CustomerId,
                Note = editSessionDto.Note,
                Price = editSessionDto.Price,
                UserId = editSessionDto.UserId,

            };

            ViewBag.Customers = _customerService.GetCustomers();
            ViewBag.Users = _userService.GetUsers();
            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Save(SessionFormViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                if(formData.CustomerId == 0)
                {
                    ViewBag.CustomerError = "Müşteri seçilmek zorunda.";
                }
                if(formData.UserId == 0)
                {
                    ViewBag.UserError = "Koç seçilmek zorunda.";
                }
                ViewBag.Customers = _customerService.GetCustomers();
                ViewBag.Users = _userService.GetUsers();
                return View("Form", formData);

            }

            if(formData.Id == 0)
            {
                var addSessionDto = new AddSessionDto()
                {
                    CustomerId = formData.CustomerId,
                    Note = formData.Note,
                    Price= formData.Price,
                    SessionDate = formData.SessionDate,
                    SessionName = formData.SessionName,
                    UserId = formData.UserId,
                };

                _personalSessionService.AddSession(addSessionDto);
                return RedirectToAction("List");
            }
            else
            {
                var editSessionDto = new EditSessionDto()
                {
                    Id = formData.Id,
                    CustomerId = formData.CustomerId,
                    Note = formData.Note,
                    Price = formData.Price,
                    SessionDate = formData.SessionDate,
                    SessionName = formData.SessionName,
                    UserId = formData.UserId,

                };

                _personalSessionService.EditSession(editSessionDto);
                return RedirectToAction("List");
            }
        }

        public IActionResult Delete(int id)
        {
            _personalSessionService.DeleteSession(id);

            return RedirectToAction("List");
        }
    }
}
