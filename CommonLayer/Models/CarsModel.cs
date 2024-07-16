using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class CarsModel
    {
        [Required]
        public string carBrand { get; set; }

        [Required]
        public string carName { get; set; }

        [Required]
        public string carNumber { get; set; }

        [Required]
        public string transmission { get; set; }

        [Required]
        public string fuel { get; set; }

        [Required]
        public string carColor { get; set; }

        [Required]
        public string seating { get; set; }

        [Required]
        public string carStatus { get; set; }

        [Required]
        public decimal priceperHour { get; set; }

        [Required]
        public decimal priceperDay { get; set; }

        [Required]
        public IFormFile carPhoto { get; set; }

        public string state { get; set; }
        public string dictrict { get; set; }
        public string place { get; set; }
    }
}
