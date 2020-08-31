using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class CTHoaDonBanModel
    {
        Connection db = new Connection();

        public List<ChiTietHoaDonBan> GetAllCTHDN()
        {
            DataTable dt = db.GetData("SELECT * FROM chiTietHoaDonBan");
            List<ChiTietHoaDonBan> li = new List<ChiTietHoaDonBan>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietHoaDonBan l = new ChiTietHoaDonBan();
                l.maHoaDonBan = int.Parse(dr[0].ToString());
                l.maSp = dr[1].ToString();
                l.soLuong = int.Parse(dr[2].ToString());
                l.giaBan = int.Parse(dr[3].ToString());
                li.Add(l);
            }
            return li;
        }
        public ChiTietHoaDonBan GetOneCTHDN(string id)
        {
            DataTable dt = db.GetData("SELECT * FROM chiTietHoaDonBan WHERE maHoaDonBan='" + id + "'");
            ChiTietHoaDonBan l = new ChiTietHoaDonBan();
            l.maHoaDonBan = int.Parse(dt.Rows[0][0].ToString());
            l.maSp = dt.Rows[0][1].ToString();
            l.soLuong = int.Parse(dt.Rows[0][2].ToString());
            l.giaBan = int.Parse(dt.Rows[0][3].ToString());
            return l;
        }
        public void themCTHDN(ChiTietHoaDonBan x)
        {
            string sql = "INSERT INTO chiTietHoaDonBan VALUES('" + x.maHoaDonBan + "','" + x.maSp + "','" + x.soLuong + "', '" + x.giaBan + "')";
            db.WriteData(sql);
        }
    }
}