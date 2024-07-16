using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepoLayer.Entity
{
    public class ReportEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }
        public int CarId { get; set; }

        public string CarBrand { get; set; }

        public string CarName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime PresentDate { get; set; }

        public DateTime EndDate { get; set; }

        public int NoOfBookings { get; set; }

    }
}
