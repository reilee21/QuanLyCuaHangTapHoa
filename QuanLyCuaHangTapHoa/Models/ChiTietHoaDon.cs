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
    
    public partial class ChiTietHoaDon
    {
        public string MaHD { get; set; }
        public string MaHH { get; set; }
        public short SoLuong { get; set; }
        public double GiaBan { get; set; }
        public decimal MucThue { get; set; }
        public double ThanhTien { get; set; }
    
        public virtual HangHoa HangHoa { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}
