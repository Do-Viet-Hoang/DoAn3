using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn3DVH.Models;

namespace DoAn3DVH.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        NhaCungCapModel ncc = new NhaCungCapModel();
        LoaiDTModel ldt = new LoaiDTModel();
        SanPhamModel sp = new SanPhamModel();
        HoaDonBanModel hdb = new HoaDonBanModel();
        HoaDonNhapModel hdn = new HoaDonNhapModel();
        KhachHangModel kh = new KhachHangModel();
        KhuyenMaiModel km = new KhuyenMaiModel();

        public ActionResult IndexNCC()
        {
            List<NhaCungCap> dsncc = ncc.getAllNCC();
            return View(dsncc);
        }
        public ActionResult get1Ncc(string id)
        {
            var dsdt = ncc.GetOneNCC(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetNccDetail(string id)
        {
            var loai = ncc.getAllNCC();
            ViewBag.loaiDT = loai;
            var ds = ncc.GetOneNCC(id);
            return View(ds);
        }
        public ActionResult xoaNcc(string id)
        {
            ncc.xoaNCC(id);
            return Redirect("~/Admin/IndexNCC");
        }
        public ActionResult addNCC(string aoe, string aMaNcc, string aTenNcc, string aDiaChi, string aSDT)
        {
            NhaCungCap dt = new NhaCungCap();
            dt.maNCC = aMaNcc;
            dt.tenNCC = aTenNcc;
            dt.diaChi = aDiaChi;
            dt.SDT = aSDT;
            if (aoe == "1")
            {
                ncc.themNCC(dt);
            }
            else
            {
                ncc.suaNCC(dt);
            }
            return Redirect("~/Admin/IndexNCC");
        }

        // sản phẩm ---- Home Controllers
         
        public ActionResult SanPham()
        {
            List<SanPham> dsdt = sp.getllDienThoai();

            return View(dsdt);
        }
        public ActionResult Lay1Dt(string id)
        {
            var dsdt = sp.GetOneDT(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult get1Sp(string id)
        {
            var dsdt = sp.GetOneDT(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSpDetail(string id)
        {
            var loai = sp.getllDienThoai();
            ViewBag.loaiDT = loai;
            var ds = sp.GetOneDT(id);
            return View(ds);
        }
        public ActionResult XoaSp(string id)
        {
            sp.deleteOneNV(id);
            return Redirect("~/Admin/SanPham");
        }
        public ActionResult addSP(string aoe, string aMaSp, string aMaLoai, string atenSp, string ahangSp, int aGia, string amanHinh, string aheDieuhanh, string aCpu, string acamTr, string acamSau, string aRam, string aboNho, string aSim, string aPin, string atrangThai, HttpPostedFileBase aAnh)
        {
            SanPham dt = new SanPham();
            dt.maSp = aMaSp;
            dt.maLoaiDt = aMaLoai;
            dt.tenSp = atenSp;
            dt.hangSp = ahangSp;
            dt.gia = aGia;
            dt.manHinh = amanHinh;
            dt.heDieuhanh = aheDieuhanh;
            dt.CPU = aCpu;
            dt.cameraTruoc = acamTr;
            dt.cameraSau = acamSau;
            dt.RAM = aRam;
            dt.boNho = aboNho;
            dt.Sim = aSim;
            dt.Pin = aPin;
            dt.trangThai = atrangThai;
            if (aAnh.ContentLength > 0)
            {
                string path = Server.MapPath("~/Assets/anh") + "/" + aAnh.FileName;
                aAnh.SaveAs(path);
                dt.hinhAnh = aAnh.FileName;
            }
            if (aoe == "1")
            {
                sp.createDT(dt);
            }
            else
            {
                sp.editOneNV(dt);
            }

            return Redirect("~/Admin/SanPham");
        }

        // loại điện thoại

        public ActionResult LoaiSP()
        {
            List<LoaiDT> dsdt = ldt.GetAllLoai();

            return View(dsdt);
        }
        public ActionResult viewOneNV(string id)
        {
            var dsdt = sp.GetOneDT(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult get1Ldt(string id)
        {
            var dsdt = ldt.GetOneLoai(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XoaLdt(string id)
        {
            ldt.xoaLdt(id);
            return Redirect("~/Admin/LoaiSP");
        }
        public ActionResult addLdt(string aoe, string aML, string aMDN, string aten, int asoLuong, string angay)
        {
            LoaiDT dt = new LoaiDT();
            dt.maLoaiDT = aML;
            dt.maHoaDonNhap = aMDN;
            dt.tenLoaiDT = aten;
            dt.soLuong = asoLuong;
            dt.ngaySanXuat = angay;
            if (aoe == "1")
            {
                ldt.themLdt(dt);
            }
            else
            {
                ldt.suaLdt(dt);
            }

            return Redirect("~/Admin/LoaiSP");
        }

        // Hoá đơn bán

        public ActionResult HoaDonBan()
        {
            List<HoaDonBan> dsdt = hdb.GetAllHDB();

            return View(dsdt);
        }
        public ActionResult xem1HDB(string id)
        {
            var dsdt = hdb.GetOneHDB(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult get1HDB(string id)
        {
            var dsdt = hdb.GetOneHDB(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XoaHDB(string id)
        {
            hdb.xoaHDB(id);
            return Redirect("~/Admin/HoaDonBan");
        }
        public ActionResult addHDB(string aoe, string aMHDB, string atenTk, string angay)
        {
            HoaDonBan dt = new HoaDonBan();
            dt.maHoaDonBan = aMHDB;
            dt.tenTk = atenTk;
            dt.ngayBan = angay;
            if (aoe == "1")
            {
                hdb.themHDB(dt);
            }
            else
            {
                hdb.suaHDB(dt);
            }

            return Redirect("~/Admin/HoaDonBan");
        }

        // Hoá đơn Nhập

        public ActionResult HoaDonNHap()
        {
            List<HoaDonNhap> dsdt = hdn.GetAllHDN();

            return View(dsdt);
        }
        public ActionResult xem1HDN(string id)
        {
            var dsdt = hdn.GetOneHDN(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult get1HDN(string id)
        {
            var dsdt = hdn.GetOneHDN(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XoaHDN(string id)
        {
            hdn.xoaHDN(id);
            return Redirect("~/Admin/HoaDonNhap");
        }
        public ActionResult addHDN(string aoe, string aMHDN, string aMaNCC, string angay)
        {
            HoaDonNhap dt = new HoaDonNhap();
            dt.maHoaDonNhap = aMHDN;
            dt.maNhaCC = aMaNCC;
            dt.ngayBan = angay;
            if (aoe == "1")
            {
                hdn.themHDN(dt);
            }
            else
            {
                hdn.suaHDN(dt);
            }

            return Redirect("~/Admin/HoaDonNhap");
        }

        // Khách hàng

        public ActionResult KhachHang()
        {
            List<KhachHang> dsdt = kh.getallKh();

            return View(dsdt);
        }
        public ActionResult xem1Kh(string id)
        {
            var dsdt = kh.GetOneKh(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult get1Kh(string id)
        {
            var dsdt = kh.GetOneKh(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult addKh(string aoe, string atenkh, string atenTk, string aMatKhau, string aDiaChi, string aSDT)
        {
            KhachHang dt = new KhachHang();
            dt.tenTk = atenTk;
            dt.matKhau = aMatKhau;
            dt.tenKh = atenkh;
            dt.diaChi = aDiaChi;
            dt.sdt = aSDT;
            if (aoe == "1")
            {
                kh.themKh(dt);
            }

            return Redirect("~/Admin/KhachHang");
        }

        // Khuyến mại

        public ActionResult KhuyenMai()
        {
            List<KhuyenMai> dsdt = km.GetAllKm();

            return View(dsdt);
        }
        public ActionResult xem1Km(string id)
        {
            var dsdt = km.GetOneKm(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult get1Km(string id)
        {
            var dsdt = km.GetOneKm(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XoaKm(string id)
        {
            km.xoaKm(id);
            return Redirect("~/Admin/KhuyenMai");
        }
        public ActionResult addKm(string aoe, string aMaKm, string aMaSp, string aTenKm, string aNgayBd, string aNgayKt)
        {
            KhuyenMai dt = new KhuyenMai();
            dt.maKm = aMaKm;
            dt.maSp = aMaSp;
            dt.tenKm = aTenKm;
            dt.ngayBatDau = aNgayBd;
            dt.ngayKetThuc = aNgayKt;
            if (aoe == "1")
            {
                km.themKm(dt);
            }
            else
            {
                km.suaKm(dt);
            }
            return Redirect("~/Admin/KhuyenMai");
        }
    }
}