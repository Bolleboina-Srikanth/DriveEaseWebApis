using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepoLayer.Entity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }

        public string LicenseNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserPhoto { get; set; }


    }
}
