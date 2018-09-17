//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ekspedition
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shipping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipping()
        {
            this.HistoryShippings = new HashSet<HistoryShipping>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> Assurances { get; set; }
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
        public int StatusShippings_Id { get; set; }
        public int Employee_Id { get; set; }
        public int Package_Id { get; set; }
        public int Destination_Branch_Id { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryShipping> HistoryShippings { get; set; }
        public virtual Package Package { get; set; }
        public virtual StatusShipping StatusShipping { get; set; }
        public virtual Village Village { get; set; }
        public virtual Village Village1 { get; set; }
    }
}
