using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DoAn3DVH.Models
{
    public class NhaCungCapModel
    {
        Connection db = new Connection();

        public List<NhaCungCap> getAllNCC()
        {
            DataTable dt = db.GetData("SELECT * FROM NhaCungCap");
            List<NhaCungCap> li = new List<NhaCungCap>();
            foreach (DataRow i in dt.Rows)
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.maNCC = i[0].ToString();
                ncc.tenNCC = i[1].ToString();
                ncc.diaChi = i[2].ToString();
                ncc.SDT = i[3].ToString();
                li.Add(ncc);
            }
            return li;
        }
        public NhaCungCap GetOneNCC(string id)
        {
            DataTable dt = db.GetData("SELECT * FROM NhaCungCap WHERE maNhaCC='" + id + "'");
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.maNCC = dt.Rows[0][0].ToString();
                ncc.tenNCC = dt.Rows[0][1].ToString();
                ncc.diaChi = dt.Rows[0][2].ToString();
                ncc.SDT = dt.Rows[0][3].ToString();
                return ncc;
            } 
        }
        public void xoaNCC(string id)
        {
            db.WriteData("DELETE FROM NhaCungCap WHERE maNhaCC = '" + id + "'");
        }
        public void themNCC(NhaCungCap x)
        {
            string sql = "INSERT INTO NhaCungCap VALUES('" + x.maNCC + "',N'" + x.tenNCC + "',N'" + x.diaChi + "','" + x.SDT + "')";
            db.WriteData(sql);
        }
        public void suaNCC(NhaCungCap x)
        {
            string sql = "UPDATE NhaCungCap SET tenNhaCC = N'" + x.tenNCC + "', diaChi = N'" + x.diaChi + "', SDT = '" + x.SDT + "' WHERE maNhaCC = '" + x.maNCC+ "'";
            db.WriteData(sql);
        }
    }
}