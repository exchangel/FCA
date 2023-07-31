using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Dtos.CustomerDtos
{
    public class AddCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Interest { get; set; }
        public string FindHow { get; set; }
        public string Note { get; set; }
    }
}
