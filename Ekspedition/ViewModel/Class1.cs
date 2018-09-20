using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekspedition.ViewModel
{
    public class Class1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Branch_Id { get; set; }

        public Class1()
        {

        }

        public Class1(Employee data)
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