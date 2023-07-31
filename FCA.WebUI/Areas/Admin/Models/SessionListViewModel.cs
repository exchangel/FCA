namespace FCA.WebUI.Areas.Admin.Models
{
    public class SessionListViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SessionName { get; set; }
        public DateTime SessionDate { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
    }
}
