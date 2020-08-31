using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class HoaDonBanModel
    {
        Connection db = new Connection();

        public List<HoaDonBan> GetAllHDB()
        {
            DataTable dt = db.GetData("SELECT * FROM HoaDonBan");
            List<HoaDonBan> li = new List<HoaDonBan>();
            foreach (DataRow dr in dt.Rows)
            {
                HoaDonBan l = new HoaDonBan();
                l.maHoaDonBan = dr[0].ToString();
                l.tenTk = dr[1].ToString();
                l.ngayBan = dr[2].ToString();
                l.tenNn = dr[3].ToString();
                l.dcNn = dr[4].ToString();
                l.sdtNn = dr[5].ToString();
                l.trangThai = dr[6].ToString();
                l.chuThich = dr[7].ToString();
                li.Add(l);
            }
            return li;
        }
        public HoaDonBan GetOneHDB(string id)
        {
            DataTable dt = db.GetData("SELECT * FROM HoaDonBan WHERE maHoaDonBan='" + id + "'");
            HoaDonBan l = new HoaDonBan();
            l.maHoaDonBan = dt.Rows[0][0].ToString();
            l.tenTk = dt.Rows[0][1].ToString();
            l.ngayBan = dt.Rows[0][2].ToString();
            l.tenNn = dt.Rows[0][3].ToString();
            l.dcNn = dt.Rows[0][4].ToString();
            l.sdtNn = dt.Rows[0][5].ToString();
            l.trangThai = dt.Rows[0][6].ToString();
            l.chuThich = dt.Rows[0][7].ToString();
            return l;
        }

        public int lastID()
        {
            int id = 1;
            try
            {
                DataTable dt = db.GetData("SELECT TOP 1 maHoaDonBan FROM HoaDonBan ORDER BY maHoaDonBan DESC");
                id = int.Parse(dt.Rows[0][0].ToString());
            }
            catch (Exception) { }
            return id;
        }

        public void xoaHDB(string id)
        {
            db.WriteData("DELETE FROM HoaDonBan WHERE maHoaDonBan= '" + id + "'");
        }
        public void themHDB(HoaDonBan x)
        {
            string sql = "INSERT INTO HoaDonBan VALUES('" + x.tenTk + "','" + getDate(x.ngayBan) + "','" + x.tenNn + "','" + x.dcNn + "','" + x.sdtNn + "','" + x.trangThai + "','" + x.chuThich + "')";
            db.WriteData(sql);
        }
        public void suaHDB(HoaDonBan x)
        {
            string sql = "UPDATE HoaDonBan SET trangThai = N'" + x.trangThai + "', WHERE maHoaDonBan = '" + x.maHoaDonBan + "'";
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