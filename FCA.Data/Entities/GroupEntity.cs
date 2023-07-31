using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Data.Entities
{
    public class GroupEntity : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
        public int CustomerCount { get; set; }

        //relational prop
        public UserEntity User { get; set; }
        public List<GroupsCustomersEntity> Customers { get; set; }
    }
}
