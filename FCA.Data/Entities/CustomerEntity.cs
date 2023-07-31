using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Data.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Interest { get; set; }
        public string? FindHow { get; set; }
        public string? Note { get; set; }

        //relational prop
        public List<PersonalSessionEntity> PersonalSessions { get; set; }
        public List<GroupsCustomersEntity> Groups { get; set; }
    }
}
