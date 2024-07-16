using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepoLayer.Entity
{
    public class PaymentEntity
    {
        [Key]
        public string paymentId { get; set; }
        public string BookingId { get; set; }
        public long CarId { get; set; }

        public long UserId { get; set; }
        public String paymentType { get; set; }

        public DateTime paymmentDate { get; set; }

        public decimal Amount { get; set; }
    }
}
