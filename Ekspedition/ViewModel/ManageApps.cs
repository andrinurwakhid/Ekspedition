using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekspedition.ViewModel
{
    public class ManageApps
    {
        public IEnumerable<Province> VMProvince { get; set; }
        public string ProvinceID { get; set; }
        public IEnumerable<Regency> VMRegency { get; set; }
        public string RegencyID { get; set; }
        public IEnumerable<District> VMDistrict { get; set; }
        public string DistrictID { get; set; }
        public IEnumerable<Village> VMVillage { get; set; }
        public string VillageID { get; set; }

        public IEnumerable<Category> VMCategory { get; set; }
        public IEnumerable<Package> VMPackage { get; set; }
        public IEnumerable<StatusShipping> VMStatusShipping { get; set; }

        public IEnumerable<Branch> VMBranch { get; set; }
        public IEnumerable<Warehouse> VMWarehouse { get; set; }

        public IEnumerable<Employee> VMEmployee { get; set; }

        public IEnumerable<Shipping> VMShipping { get; set; }
        public IEnumerable<HistoryShipping> VMHistoryShipping { get; set; }
    }
}