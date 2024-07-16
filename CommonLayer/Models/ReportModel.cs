using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class ReportModel
    {
        public int carId { get; set; }

        public string carBrand { get; set; }

        public string carName { get; set; }

        public DateTime fromDate { get; set; }

        public DateTime presentDate { get; set; }

        public DateTime endDate { get; set; }

        public int noOfBookings { get; set; }
    }
}
