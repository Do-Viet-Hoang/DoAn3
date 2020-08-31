using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn3DVH.Models;


namespace DoAn3DVH.Controllers
{
    public class HomeController : Controller
    {
        SanPhamModel dtdt = new SanPhamModel();
        KhachHangModel kh = new KhachHangModel();
        LoaiDTModel ldt = new LoaiDTModel();
        HoaDonBanModel hdb = new HoaDonBanModel();
        CTHoaDonBanModel cthdb = new CTHoaDonBanModel();

        public ActionResult Index()
        {
            List<SanPham> dsdt = dtdt.getllDienThoai();
            List<SanPham> dssphot = dtdt.getSpHot();
            List<SanPham> dsspm = dtdt.getSpMoi();
            HomeModel m = new HomeModel();
            m.DanhSachSP = dsdt;
            m.SanPhamHot = dssphot;
            m.SanPhamMOi = dsspm;
            return View(m);
        }
        public ActionResult get1dt(string id)
        {
            var dsdt = dtdt.GetOneDT(id);
            return Json(dsdt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSpDetail(string id)
        {
            var loai = dtdt.getllDienThoai();
            ViewBag.loaiDT = loai;
            var ds = dtdt.GetOneDT(id);

            var dssp = dtdt.getSp_LoaiSp(ds.maLoaiDt).Where(s => s.maSp != ds.maSp).ToList();
            ViewBag.sptt = dssp;

            return View(ds);
        }
        // giỏ hàng
        public ActionResult MuaHang(string id)
        {
            // chưa có sản phẩm thì thêm vào giỏ hàng
            List<GioHang> gh = null;
            if (Session["giohang"] == null)
            {
                // khởi tạo giỏ hàng s
                GioHang s = new GioHang();
                // khai báo biến sp lưu trữ thông tin sản phẩm vào sản phẩm
                var sp = dtdt.GetOneDT(id); // gồm thuộc tính ở dưới
                s.id = sp.maSp;
                s.ten = sp.tenSp;
                s.anh = sp.hinhAnh;
                s.sl = 1;
                s.gia = sp.gia;
                gh = new List<GioHang>();
                // thêm sản p vào giỏ hàng
                gh.Add(s);
                // thêm dữ liệu vào biến seession
                Session["giohang"] = gh;
            }
            // khi sản phẩm trong giỏ hàng
            else
            {
                // đưa dữ liệu có sẵn từ biết session vào giỏ hàng
                gh = (List<GioHang>)Session["giohang"];
                // khai báo biến test kiểm tra có phải sản phẩm đang có trong giỏ hàng 
                var test = gh.Find(a => a.id == id);
                if (test == null)
                {
                    GioHang s = new GioHang();
                    // khai báo biến sp lưu trữ thông tin sản phẩm vào sản phẩm
                    var sp = dtdt.GetOneDT(id); // gồm thuộc tính ở dưới
                    s.id = sp.maSp;
                    s.ten = sp.tenSp;
                    s.anh = sp.hinhAnh;
                    s.sl = 1;
                    s.gia = sp.gia;
                    gh.Add(s);
                }
                else
                {
                    test.sl = int.Parse(test.sl.ToString()) + 1;
                }
                // đưa dữ liệu vào biến sesion
                Session["giohang"] = gh;
            }
            int tongtien = 0;
            int soLuong = 0;
            // duyệt lần lượt từng sản phẩm trong giỏ hàng, mỗi sản phẩm 
            foreach (GioHang x in gh)
            {
                tongtien += x.sl * x.gia; // tong tien= tt +(soluong x dongia)
            }
            // đưa ra số lượng trong giỏ hàng
            soLuong = gh.Count;
            return Json(new { giohang = gh, tongtien = tongtien, soLuong = soLuong }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult loadGioHang()
        {
            List<GioHang> gh = null;
            if (Session["giohang"] != null)
            {
                gh = (List<GioHang>)Session["giohang"];
            }
            int tongtien = 0;
            int soLuong = 0;
            if (gh != null)
            {
                foreach (GioHang x in gh)
                {
                    tongtien += x.sl * x.gia;
                }
                soLuong = gh.Count;
            }
            return Json(new { giohang = gh, tongtien = tongtien, soLuong = soLuong }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult thayDoiSoLuong(string id, int dori)
        {
            List<GioHang> gh = (List<GioHang>)Session["giohang"];
            int soLuong = 0;
            int tongTien = 0;
            //khai bao 1 sp test sao cho ma sp trung voi ma sp trong gio hang
            var test = gh.Find(s => s.id.ToString().Trim() == id.Trim());
            //neu sl >1
            if (test != null)
            {
                var mdt = dtdt.GetOneDT(id);
                if (dori == 1)
                {
                    //tang sl len 1
                    test.sl++;

                    int max = mdt.soLuong;
                    if (test.sl > max)
                        test.sl = max;
                } else
                {
                    test.sl--;
                    if (test.sl < 1)
                        test.sl = 1;
                }
                soLuong = test.sl;
                tongTien = soLuong * mdt.gia;
            }
            Session["giohang"] = gh;
            return Json(new { success = true , soluong = soLuong , tongtien = tongTien}, JsonRequestBehavior.AllowGet);
        }
        public ActionResult xoa1sp(string id)
        {
            List<GioHang> gh = null;
            gh = (List<GioHang>)Session["giohang"];
            //khai bao 1 sp test sao cho ma sp trung voi ma sp trong gio hang
            var test = gh.Find(s => s.id.ToString().Contains(id.Trim()));
            //neu sl >1
            if (test != null)
                gh.Remove(test);
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult xemgiohang(string id)
        {
            int tongtien = 0;
            List<GioHang> tt = null;
            ViewBag.tongtien = null;
            int count = 0;
            if (Session["giohang"] != null)
            {
                tt = (List<GioHang>)Session["giohang"];
                foreach (GioHang t in tt)
                {
                    tongtien += t.sl * t.gia;
                }
                count = tt.Count;
            }
            ViewBag.count = count;
            ViewBag.tongtien = tongtien;
            return View(tt);
        }

        // tìm kiếm

        public ActionResult DSTimkiem(string ten)
        {
            List<SanPham> dssp = dtdt.getllDienThoai();
            List<SanPham> result = new List<SanPham>();
            foreach (SanPham sp in dssp)
            {
                if (sp.tenSp.ToLower().IndexOf(ten.ToLower()) != -1)
                {
                    result.Add(sp);
                }
            }
            var loai = dtdt.getllDienThoai();//trả về kiểu danh sách
            ViewBag.loaisp = loai;
            return View(result);
        }

        public ActionResult DanhSachSanPham(string id)
        {
            var loai = ldt.GetAllLoai();

            var dt = loai.FirstOrDefault(s => s.maLoaiDT.ToString().Contains(id)).tenLoaiDT;
            ViewBag.tenLoaiDT = dt;

            List<SanPham> dssp = dtdt.getSp_LoaiSp(id);
            return View(dssp);
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult checkDangNhap(string taikhoan, string matkhau)
        {
            List<KhachHang> dskh = kh.getallKh();
            KhachHang khs = dskh.Find(mkh => mkh.tenTk.Trim() == taikhoan && mkh.matKhau.Trim() == matkhau);
            if(khs == null)
            {
                // kh k ton tai
                ViewBag.ThongBao = 1;
                return View("DangNhap");
            } else
            {
                Session["TaiKhoan"] = khs;
            }
            return Redirect("~/Home/Index");
        }

        public ActionResult checkLogin()
        {
            bool isLogin = false;
            if (Session["TaiKhoan"] != null)
                isLogin = true;
            return Json(new { isLogin = isLogin }, JsonRequestBehavior.AllowGet);
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
        public ActionResult addDN(string atenkh, string atenTk, string aMatKhau, string aDiaChi, string aSDT)
        {
            KhachHang dt = new KhachHang();
            dt.tenTk = atenTk;
            dt.matKhau = aMatKhau;
            dt.tenKh = atenkh;
            dt.diaChi = aDiaChi;
            dt.sdt = aSDT;
            kh.themKh(dt);
            return Redirect("~/Admin/KhachHang");
        }

        public ActionResult DatHang(string tentk, string ten, string sdt, string diaChi, string ChuThich)
        {
            HoaDonBan dt = new HoaDonBan();
            dt.tenTk = tentk;
            dt.tenNn = ten;
            dt.dcNn = diaChi;
            dt.sdtNn = sdt;
            dt.chuThich = ChuThich;
            hdb.themHDB(dt);

            int lastID = hdb.lastID();
            
            if (Session["giohang"] != null)
            {
                var tt = (List<GioHang>)Session["giohang"];
                foreach (GioHang t in tt)
                {
                    ChiTietHoaDonBan ct = new ChiTietHoaDonBan();
                    ct.maHoaDonBan = lastID;
                    ct.maSp = t.id;
                    ct.soLuong = t.sl;
                    ct.giaBan = t.gia;
                    cthdb.themCTHDN(ct);
                }
            }
            return Redirect("~/Home/Index");
        }
    }
}