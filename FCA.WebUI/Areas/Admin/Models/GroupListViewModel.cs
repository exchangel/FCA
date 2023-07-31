using FCA.Data.Entities;

namespace FCA.WebUI.Areas.Admin.Models
{
    public class GroupListViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int CustomerCount { get; set; }
        public List<GroupsCustomersEntity> Customers { get; set; }
    }
}
