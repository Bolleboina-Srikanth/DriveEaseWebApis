using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepoLayer.Entity
{
    public class CarEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CarID { get; set; }
        public string CarBrand { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
        public string CarColor { get; set; }
        public string Seating { get; set; }
        public string CarStatus { get; set; }
        public decimal PriceperHour { get; set; }
        public decimal PriceperDay { get; set; }

        public string CarPhoto { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Place { get; set; }

    }
}
