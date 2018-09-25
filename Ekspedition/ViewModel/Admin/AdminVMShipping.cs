using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekspedition.ViewModel.Admin
{
    public class AdminVMShipping
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Assurances { get; set; }
        public int Weight { get; set; }
        public int Category_Id { get; set; }

        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderProvince_Id { get; set; }
        public string SenderRegency_Id { get; set; }
        public string SenderDistrict_Id { get; set; }
        public string SenderVillage_Id { get; set; }
        public string SenderAddress { get; set; }

        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverProvince_Id { get; set; }
        public string ReceiverRegency_Id { get; set; }
        public string ReceiverDistrict_Id { get; set; }
        public string ReceiverVillage_Id { get; set; }
        public string ReceiverAddress { get; set; }

        public int Price { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public int StatusShipping_Id { get; set; }
        public int Employee_Id { get; set; }
        public int Package_Id { get; set; }
        public int Destination_Branch_Id { get; set; }

        public AdminVMShipping()
        {

        }
        public AdminVMShipping(Shipping data)
        {
            Id = data.Id;
            Quantity = data.Quantity;
            Assurances = data.Assurances;
            Weight = data.Weight;
            Category_Id = data.Category_Id;

            SenderName = data.SenderName;
            SenderPhone = data.SenderPhone;
            SenderProvince_Id = data.SenderProvince_Id;
            SenderRegency_Id = data.SenderRegency_Id;
            SenderDistrict_Id = data.SenderDistrict_Id;
            SenderVillage_Id = data.SenderVillage_Id;
            SenderAddress = data.SenderAddress;

            ReceiverName = data.ReceiverName;
            ReceiverPhone = data.ReceiverPhone;
            ReceiverProvince_Id = ReceiverProvince_Id;
            ReceiverRegency_Id = data.ReceiverRegency_Id;
            ReceiverDistrict_Id = data.ReceiverDistrict_Id;
            ReceiverVillage_Id = data.ReceiverVillage_Id;
            ReceiverAddress = data.ReceiverAddress;

            Price = data.Price;
            TotalPrice = data.TotalPrice;

            StatusShipping_Id = data.StatusShipping_Id;
            Employee_Id = data.Employee_Id;
            Package_Id = data.Package_Id;
            Destination_Branch_Id = data.Destination_Branch_Id;

        }
    }
}