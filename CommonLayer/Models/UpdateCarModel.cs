using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class UpdateCarModel
    {
        public int carId { get; set; }
        public string carBrand { get; set; }
        public string carName { get; set; }
        public string carNumber { get; set; }
        public string transmission { get; set; }
        public string fuel { get; set; }
        public string carColor { get; set; }
        public string seating { get; set; }
        public string carStatus { get; set; }
        public decimal priceperHour { get; set; }
        public decimal priceperDay { get; set; }
        public IFormFile carPhoto { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public string place { get; set; }
    }
}
