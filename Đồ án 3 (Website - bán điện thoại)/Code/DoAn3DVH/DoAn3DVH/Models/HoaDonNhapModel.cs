using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class HoaDonNhapModel
    {
        Connection db = new Connection();

        public List<HoaDonNhap> GetAllHDN()
        {
            DataTable dt = db.GetData("SELECT * FROM HoaDonNhap");
            List<HoaDonNhap> li = new List<HoaDonNhap>();
            foreach (DataRow dr in dt.Rows)
            {
                HoaDonNhap l = new HoaDonNhap();
                l.maHoaDonNhap = dr[0].ToString();
                l.maNhaCC = dr[1].ToString();
                l.ngayBan = dr[2].ToString();
                li.Add(l);
            }
            return li;
        }
        public HoaDonNhap GetOneHDN(string id)
        {
            DataTable dt = db.GetData("SELECT * FROM HoaDonNhap WHERE maHoaDonNhap='" + id + "'");
            HoaDonNhap l = new HoaDonNhap();
            l.maHoaDonNhap = dt.Rows[0][0].ToString();
            l.maNhaCC = dt.Rows[0][1].ToString();
            l.ngayBan = dt.Rows[0][2].ToString();
            return l;
        }
        public void xoaHDN(string id)
        {
            db.WriteData("DELETE FROM HoaDonNhap WHERE maHoaDonNhap= '" + id + "'");
        }
        public void themHDN(HoaDonNhap x)
        {
            string sql = "INSERT INTO HoaDonNhap VALUES('" + x.maHoaDonNhap + "','" + x.maNhaCC + "','" + getDate(x.ngayBan) + "')";
            db.WriteData(sql);
        }
        public void suaHDN(HoaDonNhap x)
        {
            string sql = "UPDATE HoaDonNhap SET maNhaCC = N'" + x.maNhaCC + "', ngayBan = '" + getDate(x.ngayBan) + "' WHERE maHoaDonNhap = '" + x.maHoaDonNhap + "'";
            db.WriteData(sql);
        }

        public string getDate(string t)
        {
            DateTime dt = Convert.ToDateTime(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
    }
}