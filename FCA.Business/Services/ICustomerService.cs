using FCA.Business.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Services
{
    public interface ICustomerService
    {
        bool AddCustomer(AddCustomerDto addCustomerDto);

        List<ListCustomerDto> GetCustomers();
        UpdateCustomerDto GetCustomer(int id);

        void UpdateCustomer(UpdateCustomerDto updateCustomerDto);

        void DeleteCustomer(int id);
    }
}
