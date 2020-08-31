using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class DatHangModel
    {
        Connection db = new Connection();
        public void createDonHang(KhachHang x)
        {
            string sql = "INSERT INTO KhachHang VALUES('" + x.tenTk + "','" + x.matKhau + "','" + x.tenKh + "','" + x.diaChi + "','" + x.sdt + "')";
            db.WriteData(sql);
        }
    }
}