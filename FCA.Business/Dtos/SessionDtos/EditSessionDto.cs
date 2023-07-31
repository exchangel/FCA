using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Business.Dtos.SessionDtos
{
    public class EditSessionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public string SessionName { get; set; }
        public DateTime SessionDate { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
    }
}
