using FCA.Business.Dtos.CustomerDtos;
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
    public class CustomerManager : ICustomerService
    {
        private readonly IRepository<CustomerEntity> _customerRepository;
        public CustomerManager(IRepository<CustomerEntity> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool AddCustomer(AddCustomerDto addCustomerDto)
        {
            var hasCustomer = _customerRepository.GetAll(x => x.Phone.Trim() == addCustomerDto.Phone.Trim()).ToList();

            if (hasCustomer.Any())
            {
                return false;
            } //is not null

            var customerEntity = new CustomerEntity()
            {
                FirstName = addCustomerDto.FirstName,
                LastName = addCustomerDto.LastName,
                Phone = addCustomerDto.Phone,
                City = addCustomerDto.City,
                Email = addCustomerDto.Email,
                Interest = addCustomerDto.Interest,
                FindHow = addCustomerDto.FindHow,
                Note = addCustomerDto.Note
            };

            _customerRepository.Add(customerEntity);
            return true;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }

        public UpdateCustomerDto GetCustomer(int id)
        {
            var customerEntity = _customerRepository.GetById(id);

            var updateCustomerDto = new UpdateCustomerDto()
            {
                Id = customerEntity.Id,
                FirstName = customerEntity.FirstName,
                LastName = customerEntity.LastName,
                Phone = customerEntity.Phone,
                City = customerEntity.City,
                Email = customerEntity.Email,
                Interest = customerEntity.Interest,
                FindHow = customerEntity.FindHow,
                Note = customerEntity.Note
            };

            return updateCustomerDto;
        }

        public List<ListCustomerDto> GetCustomers()
        {
            var customerEntities = _customerRepository.GetAll().OrderBy(x => x.FirstName);

            var customerDtoList = customerEntities.Select(x => new ListCustomerDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone= x.Phone,
                City = x.City,
                Email = x.Email,
                FindHow= x.FindHow,
                Interest= x.Interest,
                Note = x.Note
            }).ToList();

            return customerDtoList;
        }

        public void UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var customerEntity = _customerRepository.GetById(updateCustomerDto.Id);

            customerEntity.FirstName = updateCustomerDto.FirstName;

            customerEntity.LastName = updateCustomerDto.LastName;

            customerEntity.Phone = updateCustomerDto.Phone;

            customerEntity.City = updateCustomerDto.City;

            customerEntity.Email = updateCustomerDto.Email;

            customerEntity.FindHow = updateCustomerDto.FindHow;

            customerEntity.Interest = updateCustomerDto.Interest;

            customerEntity.Note = updateCustomerDto.Note;
        }
    }
}
