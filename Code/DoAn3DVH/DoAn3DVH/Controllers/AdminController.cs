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
        CTHoaDonBanModel ct = new CTHoaDonBanModel();

        public ActionResult IndexNCC()
        {
            if(Session["TaiKhoan"] == null)
            {
                return Redirect("~/Admin/login");
            }
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
            if (Session["TaiKhoan"] == null)
            {
                return Redirect("~/Admin/login");
            }

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
            if (Session["TaiKhoan"] == null)
            {
                return Redirect("~/Admin/login");
            }

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
            if (Session["TaiKhoan"] == null)
            {
                return Redirect("~/Admin/login");
            }

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
        public ActionResult addHDB(string aMaHD, string aTrangThai)
        {
            HoaDonBan dt = new HoaDonBan();
            dt.maHoaDonBan = aMaHD;
            dt.trangThai = aTrangThai;
            hdb.suaHDB(dt);
            return Redirect("~/Admin/HoaDonBan");
        }

        // chi tiết hoá đơn bán

        public ActionResult getChiTietHD(string id)
        {
            var dsct = ct.GetListChiTiet(id);
            List<ChiTietHoaDonBan> list = new List<ChiTietHoaDonBan>();

            foreach(var ct in dsct)
            {
                var cta = list.Find(mct => mct.maSp == ct.maSp);
                if (cta != null)
                {
                    cta.soLuong += ct.soLuong;
                    cta.giaBan = cta.soLuong * ct.giaBan;
                }
                else
                {
                    ct.giaBan *= ct.soLuong;
                    list.Add(ct);
                }
            }

            int TongTien = 0;
            int SoLuong = 0;
            foreach(var ct in list)
            {
                TongTien += ct.giaBan;
                SoLuong += ct.soLuong;
            }

            return Json(new { danhSach = list, tongTien = TongTien, soLuong = SoLuong }, JsonRequestBehavior.AllowGet);
        }

        // Hoá đơn nhập

        public ActionResult HoaDonNHap()
        {
            if (Session["TaiKhoan"] == null)
            {
                return Redirect("~/Admin/login");
            }

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
            if (Session["TaiKhoan"] == null)
            {
                return Redirect("~/Admin/login");
            }

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
            dt.loaiTk = 1;
            dt.sdt = aSDT;
            if (aoe == "1")
            {
                kh.themKh(dt);
            }

            return Redirect("~/Admin/KhachHang");
        }

        // đăng nhập

        public ActionResult xoaKh(string id)
        {
            kh.xoaKh(id);   
            return Redirect("~/Admin/KhachHang");
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult checkDangNhap(string taikhoan, string matkhau)
        {
            List<KhachHang> dskh = kh.getallKh();
            KhachHang khs = dskh.Find(mkh => mkh.tenTk.Trim() == taikhoan && mkh.matKhau.Trim() == matkhau && mkh.loaiTk == 0);
            if (khs == null)
            {
                // kh k ton tai
                ViewBag.ThongBao = 1;
                return View("DangNhap");
            }
            else
            {
                Session["TaiKhoan"] = khs;
            }
            return Redirect("~/Admin/IndexNCC");
        }
        public ActionResult checkLogin()
        {
            bool isLogin = false;
            if (Session["TaiKhoan"] != null)
                isLogin = true;
            return Json(new { isLogin = isLogin }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult addDN(string atenTk, string aMatKhau, string atenkh, string aDiaChi, string aSDT)
        {
            List<KhachHang> dskh = kh.getallKh();

            if (dskh.Find(mkh => mkh.tenTk.ToLower().Trim() == atenTk.ToLower().Trim()) != null)
            {
                ViewBag.ThongBao = 2;
                return View("login");
            }

            KhachHang dt = new KhachHang();
            dt.tenTk = atenTk;
            dt.matKhau = aMatKhau;
            dt.tenKh = atenkh;
            dt.diaChi = aDiaChi;
            dt.sdt = aSDT;
            dt.loaiTk = 0;
            kh.themKh(dt);
            return Redirect("~/Home/DangNhap");
        }
        public ActionResult getOneCtHDB(string id)
        {
            var dsdt = ct.GetOneCTHDN(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }

        // thống kê

        [HttpGet]
        public ActionResult ThongKeNgay()
        {
            if (Session["TaiKhoan"] == null)
            {
                return Redirect("~/Admin/login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult ThongKeNgay(string ngay, string thang, string nam)
        {
            var list = hdb.Thongke(ngay, thang, nam);

            int TongTien = 0;
            int SoLuong = 0;
            foreach (var ct in list)
            {
                TongTien += ct.giaBan;
                SoLuong += ct.soLuong;
            }

            return Json(new { danhSach = list, tongTien = TongTien, soLuong = SoLuong }, JsonRequestBehavior.AllowGet);
        }

    }
}
