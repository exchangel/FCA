using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Data.Entities
{
    public class GroupsCustomersEntity : BaseEntity
    {
        public int GroupId { get; set; }
        public int CustomerId { get; set; }
        //relational prop
        public GroupEntity Group { get; set; }
        public CustomerEntity Customer { get; set; }
    }
}
