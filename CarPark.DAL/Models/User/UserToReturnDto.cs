using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class UserToReturnDto
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public UserToReturnDto(
            string userName, string firstName, 
            string lastname, string phoneNumber, 
            string email, string address, string role)
        {
            UserName = userName;
            FirstName = firstName;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Role = role;
        }
    }
}
