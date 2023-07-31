using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Data.Entities
{
    public class SessionPaymentEntity : BaseEntity
    {
        public int PersonalSessionId { get; set; }
        public double Price { get; set; }
        public int Installments { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }
        public string Note { get; set; }
        //relational prop
        public PersonalSessionEntity PersonalSession { get; set; }
    }
}
