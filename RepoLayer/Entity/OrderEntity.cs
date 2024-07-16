using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepoLayer.Entity
{
    public class OrderEntity
    {
        [Key]
        public long OrderID { get; set; }
        [ForeignKey(nameof(OrderEntity))]
        public long UserID { get; set; }
        public  UserEntity usertable { get; set; }

        [ForeignKey(nameof(OrderEntity))]
        public string BookingId { get; set; }
        public BookingEntity BookingTable { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CarPhoto { get; set; }
        public string CarBrand { get; set; }
        public string CarName { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
        public string CarColor { get; set; }
        public string Seating { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public long BookingTime { get; set; }
        public Decimal Amount { get; set; }
    }
}
