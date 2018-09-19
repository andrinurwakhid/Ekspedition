using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekspedition.ViewModel
{
    public class DashboardAdmin
    {
        public int HistID { get; set; }
        public int ShipID { get; set; }
        public int EmplID { get; set; }
        public int StatID { get; set; }

        public DashboardAdmin(HistoryShipping data)
        {
            HistID = data.Id;
            ShipID = data.Shipping_Id;
            EmplID = data.Employee_Id;
            StatID = data.StatusShipping_Id;
        }
    }
}