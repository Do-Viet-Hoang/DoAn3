using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class SanPham
    {
        public string maSp { get; set; }
        public string maLoaiDt { get; set; }
        public string tenSp { get; set; }
        public string hangSp { get; set; }
        public int gia { get; set; }
        public string manHinh { get; set; }
        public string heDieuhanh { get; set; }
        public string CPU { get; set; }
        public string cameraTruoc { get; set; }
        public string cameraSau { get; set; }
        public string RAM { get; set; }
        public string boNho { get; set; }
        public string Sim { get; set; }
        public string Pin { get; set; }
        public string trangThai { get; set; }
        public string hinhAnh { get; set; }
        public int soLuong {
            get {
                return 10;
            }
        }
    }
}