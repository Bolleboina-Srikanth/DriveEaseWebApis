using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class UpdateUserModel
    {
        public int userId { get; set; }
        public string name { get; set; }

        public string phoneNumber { get; set; }

        public string state { get; set; }

        public string city { get; set; }

        public string address { get; set; }

        public string role { get; set; }

        public string status { get; set; }

        public string licenseNumber { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}
