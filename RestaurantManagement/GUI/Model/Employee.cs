using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CMND { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<Order> Orders { get; set; }

    }
}