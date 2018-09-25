using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekspedition.ViewModel.Admin
{
    public class AdminVMCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AdminVMCategory()
        {

        }
        public AdminVMCategory(Category data)
        {
            Id = data.Id;
            Name = data.Name;
        }
    }
}