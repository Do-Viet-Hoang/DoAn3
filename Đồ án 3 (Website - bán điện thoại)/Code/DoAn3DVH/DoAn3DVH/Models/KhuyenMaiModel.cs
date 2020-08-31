using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class KhuyenMaiModel
    {
        Connection db = new Connection();

        public List<KhuyenMai> GetAllKm()
        {
            DataTable dt = db.GetData("SELECT * FROM khuyenMai");
            List<KhuyenMai> li = new List<KhuyenMai>();
            foreach (DataRow dr in dt.Rows)
            {
                KhuyenMai l = new KhuyenMai();
                l.maKm = dr[0].ToString();
                l.maSp = dr[1].ToString();
                l.tenKm = dr[2].ToString();
                l.ngayBatDau = dr[3].ToString();
                l.ngayKetThuc = dr[4].ToString();
                li.Add(l);
            }
            return li;
        }
        public KhuyenMai GetOneKm(string id)
        {
            DataTable dt = db.GetData("SELECT * FROM khuyenMai WHERE maKm='" + id + "'");
            KhuyenMai l = new KhuyenMai();
            l.maKm = dt.Rows[0][0].ToString();
            l.maSp = dt.Rows[0][1].ToString();
            l.tenKm = dt.Rows[0][2].ToString();
            l.ngayBatDau = dt.Rows[0][3].ToString();
            l.ngayKetThuc = dt.Rows[0][4].ToString();
            return l;
        }
        public void xoaKm(string id)
        {
            db.WriteData("DELETE FROM khuyenMai WHERE maKm= '" + id + "'");
        }
        public void themKm(KhuyenMai x)
        {
            string sql = "INSERT INTO khuyenMai VALUES('" + x.maKm + "','" + x.maSp + "',N'" + x.tenKm + "' ,'" + getDate(x.ngayBatDau) + "','" + getDate(x.ngayKetThuc) + "')";
            db.WriteData(sql);
        }
        public void suaKm(KhuyenMai x)
        {
            string sql = "UPDATE khuyenMai SET maSp = '" + x.maSp + "', tenKm = N'" + x.tenKm + "' , ngayBatDau = '" + getDate(x.ngayBatDau) + "' , ngayKetThuc = '" + getDate(x.ngayKetThuc) + "' WHERE maKm = '" + x.maKm + "'";
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