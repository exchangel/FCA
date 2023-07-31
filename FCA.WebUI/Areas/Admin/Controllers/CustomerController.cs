using FCA.Business.Dtos;
using FCA.Business.Dtos.CustomerDtos;
using FCA.Business.Services;
using FCA.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace FCA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        //DI

        public IActionResult List()
        {
            var listCustomerDtos = _customerService.GetCustomers();

            var viewModel = listCustomerDtos.Select(
                x => new CustomerListViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Interest = x.Interest,
                    City = x.City,
                    Phone = x.Phone
                }
                ).ToList();

            return View(viewModel);
        }

        [HttpGet]// URL
        public IActionResult New()
        {
            return View("Form", new CustomerFormViewModel()); //boş model
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var updateCustomerDto = _customerService.GetCustomer(id);

            var viewModel = new CustomerFormViewModel()
            {
                FirstName = updateCustomerDto.FirstName,

                LastName = updateCustomerDto.LastName,
                Phone = updateCustomerDto.Phone,

                Email = updateCustomerDto.Email,

                City = updateCustomerDto.City,

                FindHow = updateCustomerDto.FindHow,

                Interest = updateCustomerDto.Interest,

                Note = updateCustomerDto.Note


            };
            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Save(CustomerFormViewModel formData)
        {
            if (ModelState.IsValid)
            {
                if (formData.Id == 0)
                {
                    var addCustomerDto = new AddCustomerDto()
                    {
                        FirstName = formData.FirstName,
                        LastName = formData.LastName,
                        Phone = formData.Phone,
                        Note = formData.Note,
                        City = formData.City,
                        Interest = formData.Interest,
                        Email = formData.Email,
                        FindHow = formData.FindHow,
                    };

                    var result = _customerService.AddCustomer(addCustomerDto);

                    if (result)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Bu numaralı bir müşteri zaten mevcut.";
                        return View("form", formData);
                    }
                }
                else //update
                {
                    var updateCustomerDto = new UpdateCustomerDto()
                    {
                        Id = formData.Id,
                        FirstName = formData.FirstName,
                        LastName = formData.LastName,
                        Phone = formData.Phone,
                        Interest = formData.Interest,
                        City = formData.City,
                        Note = formData.Note,
                        Email = formData.Email,
                        FindHow = formData.FindHow,

                    };

                    _customerService.UpdateCustomer(updateCustomerDto);

                    return RedirectToAction("List");
                }
            }

            return View("form", formData);
        }

        public IActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);

            return RedirectToAction("List");
        }
    }


}
