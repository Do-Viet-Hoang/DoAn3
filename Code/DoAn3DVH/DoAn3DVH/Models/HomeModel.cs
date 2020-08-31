using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn3DVH.Models
{
    public class HomeModel
    {
        public List<SanPham> SanPhamMOi { get; set; }
        public List<SanPham> SanPhamHot { get; set; }
        public List<SanPham> DanhSachSP { get; set; }
        public List<SanPham> SPquangcao { get; set; }
    }
}