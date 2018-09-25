using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekspedition.ViewModel.Admin
{
    public class AdminVMBranch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province_Id { get; set; }
        public string Regency_Id { get; set; }
        public string District_Id { get; set; }
        public string Village_Id { get; set; }
        public string Address { get; set; }
        public Nullable<int> Price{ get; set; }
        public AdminVMBranch()
        {

        }
        public AdminVMBranch(Branch data)
        {
            Id = data.Id;
            Name = data.Name;
            Address = data.Address;
            Price = data.Price;
        }
    }
}