//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogDeneme.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Mesajlar
    {
        public int ID { get; set; }
        public string ADSOYAD { get; set; }
        public string MAIL { get; set; }
        public string KONU { get; set; }
        public string MESAJ { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public Nullable<bool> DURUM { get; set; }
    }
}