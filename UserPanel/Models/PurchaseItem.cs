//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserPanel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseItem
    {
        public int id { get; set; }
        public string CustmorName { get; set; }
        public string CustmorEmail { get; set; }
        public string CustmorPhoneNumber { get; set; }
        public string CustmorDileveryAddress { get; set; }
        public string ItemName { get; set; }
        public string ItemQuantity { get; set; }
        public System.DateTime ItemPurchaseDate { get; set; }
        public string ItemPurchaseStaus { get; set; }
    }
}
