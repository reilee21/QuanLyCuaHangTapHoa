//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCuaHangTapHoa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietBangGia
    {
        public string MaHH { get; set; }
        public string MaBG { get; set; }
        public double GiaBan { get; set; }
    
        public virtual BangGia BangGia { get; set; }
        public virtual HangHoa HangHoa { get; set; }
    }
}
