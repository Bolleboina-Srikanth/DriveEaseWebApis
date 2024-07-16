using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepoLayer.Entity
{
    public class BookingEntity
    {
        [Key]
        public string BookingId { get; set; }

        public int CarId { get; set; }

        public string CarBrand { get; set; }

        public string CarName { get; set; }

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }


    }
}
