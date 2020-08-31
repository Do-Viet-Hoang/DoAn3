using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DoAn3DVH.Models;

namespace DoAn3DVH.Models
{
    public class SanPhamModel
    {

        // khoie tạo một đối tượng thuộc lớp dataconnection
        Connection db = new Connection();

        //lấy tất cả nhân viên trong bảng nhân viên

        public List<SanPham> getSpHot()
        {
            DataTable dt = db.GetData("SELECT * FROM DienThoai WHERE trangThai LIKE 'hot'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham nv = new SanPham();
                nv.maSp = dr[0].ToString();
                nv.maLoaiDt = dr[1].ToString();
                nv.tenSp = dr[2].ToString();
                nv.hangSp = dr[3].ToString();
                nv.gia = int.Parse(dr[4].ToString());
                nv.manHinh = dr[5].ToString();
                nv.heDieuhanh = dr[6].ToString();
                nv.CPU = dr[7].ToString();
                nv.cameraTruoc = dr[8].ToString();
                nv.cameraSau = dr[9].ToString();
                nv.RAM = dr[10].ToString();
                nv.boNho = dr[11].ToString();
                nv.Sim = dr[12].ToString();
                nv.Pin = dr[13].ToString();
                nv.trangThai = dr[14].ToString();
                nv.hinhAnh = dr[15].ToString();
                li.Add(nv);
            }
            return li;
        }
        public List<SanPham> getSpMoi()
        {
            DataTable dt = db.GetData("SELECT * FROM DienThoai WHERE trangThai LIKE 'new'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham nv = new SanPham();
                nv.maSp = dr[0].ToString();
                nv.maLoaiDt = dr[1].ToString();
                nv.tenSp = dr[2].ToString();
                nv.hangSp = dr[3].ToString();
                nv.gia = int.Parse(dr[4].ToString());
                nv.manHinh = dr[5].ToString();
                nv.heDieuhanh = dr[6].ToString();
                nv.CPU = dr[7].ToString();
                nv.cameraTruoc = dr[8].ToString();
                nv.cameraSau = dr[9].ToString();
                nv.RAM = dr[10].ToString();
                nv.boNho = dr[11].ToString();
                nv.Sim = dr[12].ToString();
                nv.Pin = dr[13].ToString();
                nv.trangThai = dr[14].ToString();
                nv.hinhAnh = dr[15].ToString();
                li.Add(nv);
            }
            return li;
        }
        public List<SanPham> getllDienThoai()
        {
            DataTable dt = db.GetData("Select * from DienThoai");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham nv = new SanPham();
                nv.maSp = dr[0].ToString();
                nv.maLoaiDt = dr[1].ToString();
                nv.tenSp = dr[2].ToString();
                nv.hangSp = dr[3].ToString();
                nv.gia = int.Parse(dr[4].ToString());
                nv.manHinh = dr[5].ToString();
                nv.heDieuhanh = dr[6].ToString();
                nv.CPU = dr[7].ToString();
                nv.cameraTruoc = dr[8].ToString();
                nv.cameraSau = dr[9].ToString();
                nv.RAM = dr[10].ToString();
                nv.boNho = dr[11].ToString();
                nv.Sim = dr[12].ToString();
                nv.Pin = dr[13].ToString();
                nv.trangThai = dr[14].ToString();
                nv.hinhAnh = dr[15].ToString();
                li.Add(nv);
            }
            return li;
        }

        public SanPham GetOneDT(string id)
        {
            DataTable dt = db.GetData("Select * from DienThoai where maSp='" + id + "'");

            {
                SanPham nv = new SanPham();
                nv.maSp = dt.Rows[0][0].ToString();
                nv.maLoaiDt = dt.Rows[0][1].ToString();
                nv.tenSp = dt.Rows[0][2].ToString();
                nv.hangSp = dt.Rows[0][3].ToString();
                nv.gia = int.Parse(dt.Rows[0][4].ToString());
                nv.manHinh = dt.Rows[0][5].ToString();
                nv.heDieuhanh = dt.Rows[0][6].ToString();
                nv.CPU = dt.Rows[0][7].ToString();
                nv.cameraTruoc = dt.Rows[0][8].ToString();
                nv.cameraSau = dt.Rows[0][9].ToString();
                nv.RAM = dt.Rows[0][10].ToString();
                nv.boNho = dt.Rows[0][11].ToString();
                nv.Sim = dt.Rows[0][12].ToString();
                nv.Pin = dt.Rows[0][13].ToString();
                nv.trangThai = dt.Rows[0][14].ToString();
                nv.hinhAnh = dt.Rows[0][15].ToString();
                return nv;
            }
        }

        public List<SanPham> getSp_LoaiSp(string id)
        {
            DataTable dt = db.GetData("select * from DienThoai WHERE maLoaiDT = '" + id + "'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham nv = new SanPham();
                nv.maSp = dr[0].ToString();
                nv.maLoaiDt = dr[1].ToString();
                nv.tenSp = dr[2].ToString();
                nv.hangSp = dr[3].ToString();
                nv.gia = int.Parse(dr[4].ToString());
                nv.manHinh = dr[5].ToString();
                nv.heDieuhanh = dr[6].ToString();
                nv.CPU = dr[7].ToString();
                nv.cameraTruoc = dr[8].ToString();
                nv.cameraSau = dr[9].ToString();
                nv.RAM = dr[10].ToString();
                nv.boNho = dr[11].ToString();
                nv.Sim = dr[12].ToString();
                nv.Pin = dr[13].ToString();
                nv.trangThai = dr[14].ToString();
                nv.hinhAnh = dr[15].ToString();
                li.Add(nv);
            }
            return li;
        }

        public void deleteOneNV(string id)
        {
            db.WriteData("DELETE FROM DienThoai WHERE maSp='" + id + "'");
        }

        public void createDT(SanPham x)
        {
            string sql = "INSERT INTO DienThoai VALUES('" + x.maSp + "', N'" + x.maLoaiDt + "', '" + x.tenSp + "', N'" + x.hangSp + "', '" + x.gia + "', '" + x.manHinh + "', '" + x.heDieuhanh + "', '" + x.CPU + "', '" + x.cameraTruoc + "', '" + x.cameraSau + "', '" + x.RAM + "', '" + x.boNho + "', '" + x.Sim + "', '" + x.Pin + "', '" + x.trangThai + "', '" + x.hinhAnh + "')";
            db.WriteData(sql);
        }

        public void editOneNV(SanPham x)
        {
            string sql = "UPDATE DienThoai SET tenSp = N'" + x.tenSp + "', hangSp = '" + x.hangSp + "', gia = '" + x.gia + "', manHinh = '" + x.manHinh + "', heDieuhanh = '" + x.heDieuhanh + "', CPU = '" + x.CPU + "', cameraTruoc = '" + x.cameraTruoc + "' , cameraSau = '" + x.cameraSau + "' , RAM = '" + x.RAM + "', boNho = '" + x.boNho + "', Sim = '" + x.Sim + "', Pin = '" + x.Pin + "', trangThai = '" + x.trangThai + "' , hinhAnh = '" + x.hinhAnh + "' WHERE maSp = '" + x.maSp + "'";
            
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