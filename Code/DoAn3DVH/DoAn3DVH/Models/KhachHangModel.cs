using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class KhachHangModel
    {
        Connection db = new Connection();

        public List<KhachHang> getallKh()
        {
            DataTable dt = db.GetData("select * from KhachHang");
            List<KhachHang> li = new List<KhachHang>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang dtt = new KhachHang();
                dtt.tenTk = dr[0].ToString();
                dtt.matKhau = dr[1].ToString();
                dtt.tenKh = dr[2].ToString();
                dtt.diaChi = dr[3].ToString();
                dtt.sdt = dr[4].ToString();
                dtt.loaiTk = int.Parse(dr[5].ToString());
                li.Add(dtt);
            }
            return li;
        }
        public KhachHang GetOneKh(string id)
        {
            DataTable dt = db.GetData("SELECT * FROM KhachHang WHERE tenTk='" + id + "'");
            {
                KhachHang kh = new KhachHang();
                kh.tenTk = dt.Rows[0][0].ToString();
                kh.matKhau = dt.Rows[0][1].ToString();
                kh.tenKh = dt.Rows[0][2].ToString();
                kh.diaChi = dt.Rows[0][3].ToString();
                kh.sdt = dt.Rows[0][4].ToString();
                kh.loaiTk = int.Parse(dt.Rows[0][5].ToString());
                return kh;
            }
        }
        public void createDt(KhachHang dt)
        {
            string sql = "Insert into KhachHang values('" + dt.tenTk + "', '" + dt.matKhau + "','" + dt.tenKh + "', '" + dt.diaChi + "', '" + dt.sdt + "', '" + dt.loaiTk + "')";
            db.WriteData(sql);
        }
        public void themKh(KhachHang x)
        {
            string sql = "INSERT INTO KhachHang VALUES('" + x.tenTk + "',N'" + x.matKhau + "',N'" + x.tenKh + "','" + x.diaChi + "','" + x.sdt + "','" + x.loaiTk + "')";
            db.WriteData(sql);
        }
        public void xoaKh(string id)
        {
            db.WriteData("DELETE FROM KhachHang WHERE tenTk = '" + id + "'");
        }
    }
}