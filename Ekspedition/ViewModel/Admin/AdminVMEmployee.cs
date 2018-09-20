using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekspedition.ViewModel.Admin
{
    public class AdminVMEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Branch_Id { get; set; }

        public AdminVMEmployee()
        {

        }

        public AdminVMEmployee (Employee data)
        {
            Id = data.Id;
            FirstName = data.FirstName;
            LastName = data.LastName;
            Position = data.Position;
            Username = data.Username;
            Password = data.Password;
        }
    }
}