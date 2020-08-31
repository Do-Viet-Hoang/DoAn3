using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class LoaiDTModel
    {
        Connection db = new Connection();

        public List<LoaiDT> GetAllLoai()
        {
            DataTable dt = db.GetData("SELECT * FROM loaiDT");
            List<LoaiDT> li = new List<LoaiDT>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiDT l = new LoaiDT();
                l.maLoaiDT = dr[0].ToString();
                l.maHoaDonNhap = dr[1].ToString();
                l.tenLoaiDT = dr[2].ToString();
                l.soLuong = int.Parse(dr[3].ToString());
                l.ngaySanXuat = dr[4].ToString();
                li.Add(l);
            }
            return li;
        }
        public LoaiDT GetOneLoai(string id)
        {
            DataTable dt = db.GetData("SELECT * FROM loaiDT WHERE maLoaiDT='" + id + "'");
            LoaiDT l = new LoaiDT();
            l.maLoaiDT = dt.Rows[0][0].ToString();
            l.maHoaDonNhap = dt.Rows[0][1].ToString();
            l.tenLoaiDT = dt.Rows[0][2].ToString();
            l.soLuong = int.Parse(dt.Rows[0][3].ToString());
            l.ngaySanXuat = dt.Rows[0][4].ToString();
            return l;
        }
        public void xoaLdt(string id)
        {
            db.WriteData("DELETE FROM loaiDT WHERE maLoaiDT= '" + id + "'");
        }
        public void themLdt(LoaiDT x)
        {
            string sql = "INSERT INTO loaiDT VALUES('" + x.maLoaiDT + "','" + x.maHoaDonNhap + "',N'" + x.tenLoaiDT + "','" + x.soLuong + "','" + getDate(x.ngaySanXuat) + "')";
            db.WriteData(sql);
        }
        public void suaLdt(LoaiDT x)
        {
            string sql = "UPDATE loaiDT SET maHoaDonNhap = N'" + x.maHoaDonNhap + "', tenLoaiDT = N'" + x.tenLoaiDT + "', soLuong = '" + x.soLuong + "', ngaySanXuat = '" + getDate(x.ngaySanXuat) + "' WHERE maLoaiDT = '" + x.maLoaiDT + "'";
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