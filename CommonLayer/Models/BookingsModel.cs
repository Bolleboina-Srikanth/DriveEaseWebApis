using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class BookingsModel
    {
        public int carId { get; set; }

        public string CarBrand { get; set; }

        public string CarName { get; set; }
        public int customerId { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }

        public DateTime rentDate { get; set; }

        public DateTime returnDate { get; set; }

    }
}
