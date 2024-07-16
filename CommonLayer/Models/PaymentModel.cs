using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class PaymentModel
    {
        public string BookingId { get; set; }
        public long CarId { get; set; }

        public long UserId { get; set; }
        public String paymentType { get; set; }

        public DateTime paymmentDate { get; set; }

        public decimal Amount { get; set; }
    }
}
