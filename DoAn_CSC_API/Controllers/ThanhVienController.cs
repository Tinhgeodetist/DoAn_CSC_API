using DoAn_CSC_API.Common;
using DoAn_CSC_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhVienController : ControllerBase
    {
        private readonly IThanhVienService _iThanhVien;
        public ThanhVienController(IThanhVienService iThanhVien)
        {
            _iThanhVien = iThanhVien;
        }

        [HttpPost("DangNhap")]
        public ThanhVienModel.Output.DangNhap DangNhap(ThanhVienModel.Input.DangNhap input)
        {
            ThanhVienModel.Output.DangNhap thongTinThanhVien = new();
            var tv = _iThanhVien.DangNhap(input.Email, input.MatKhau);

            if (tv != null && tv.Id > 0)
            {
                //thongTinThanhVien = new ThanhVienModel.Output.DangNhap
                //{
                //    HoTen = tv.HoTen,
                //    DienThoai = tv.DienThoai,
                //    Email = tv.Email,
                //    GioiTinh = tv.GioiTinh,
                //    Id = tv.Id,
                //    KichHoat = tv.KichHoat,
                //    MatKhau = tv.MatKhau,
                //    NgaySinh = tv.NgaySinh,
                //    SocialLogin = tv.SocialLogin,
                //    ThongBao = tv.SocialLogin
                //};
                Utilities.PropertyCopier<ThanhVien, ThanhVienModel.Output.DangNhap>.Copy(tv, thongTinThanhVien);
                // dùng hàm
            }
            return thongTinThanhVien;
        }
        [HttpPost("DangKyThanhVien")]
        public ThongBaoModel DangKyThanhVien(ThanhVienModel.Input.DangKyThanhVien input)
        {
            ThongBaoModel tb = new ThongBaoModel { Maso = 0, Noidung = "" };
            try
            {
                //var thanhvienmoi = new Service.Models.ThanhVien
                //{
                //    Email = input.Email,
                //    MatKhau = input.MatKhau,
                //    DienThoai = input.DienThoai,
                //    GioiTinh = input.GioiTinh,
                //    HoTen = input.HoTen,
                //    KichHoat = false,
                //    NgaySinh = input.NgaySinh,
                //    SocialLogin = input.SocialLogin
                //};
                var thanhvienmoi = new Service.Models.ThanhVien();
                Common.Utilities.PropertyCopier<ThanhVienModel.Input.DangKyThanhVien, Service.Models.ThanhVien>.Copy(input, thanhvienmoi);
                var ketqua = _iThanhVien.DangKyThanhVien(thanhvienmoi);
                if (ketqua == true)
                {
                    tb.Maso = 0;
                    tb.Noidung = "Đăng ký thành viên mới thành công. Vui lòng kiểm tra email để kích hoạt";
                }
                else
                {
                    tb.Maso = 1;
                    tb.Noidung = "Đăng ký không thành công vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                tb.Noidung = "Lỗi đăng ký: " +ex.Message;
                throw;
            }
            return tb;
        }

        [HttpPost("KichHoatTaiKhoan")]
        public ThongBaoModel KichHoatTaiKhoan(ThanhVienModel.Input.KichHoatTaiKhoan input)
        {
            ThongBaoModel tb = new ThongBaoModel { Maso = 0, Noidung = "" };
            try
            {
                var ketqua = _iThanhVien.KickHoatTaiKhoan(input.Email);
                if (ketqua == true)
                {
                    tb.Maso = 0;
                    tb.Noidung = "Kích hoạt thành viên mới thành công.";
                }
                else
                {
                    tb.Maso = 1;
                    tb.Noidung = "Kích hoạt không thành công vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                tb.Noidung = "Lỗi kích hoạt: " + ex.Message;
                throw;
            }
            return tb;
        }

        [HttpPost("DoiMatKhau")]
        public ThongBaoModel DoiMatKhau(ThanhVienModel.Input.ThayDoiMatKhau input)
        {
            ThongBaoModel tb = new ThongBaoModel { Maso = 0, Noidung = "" };
            try
            {
                var tv = _iThanhVien.DocThongTin(input.Id);
                if (tv != null && tv.MatKhau == input.MatKhauCu)
                {
                    tv.MatKhau = input.MatKhauMoi;
                    var ketqua = _iThanhVien.ThayDoiMatKhau(tv);
                    if (ketqua == true)
                    {
                        tb.Maso = 0;
                        tb.Noidung = "Thay đổi mật khẩu thành công";
                    }
                    else
                    {
                        tb.Maso = 1;
                        tb.Noidung = "Thay đổi mật khẩu không thành công";
                    }
                }
                else
                {
                    tb.Maso = 2;
                    tb.Noidung = "thông tin tài khoản khôn hợp lệ";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            tb.Noidung = "Lỗi";
            return tb;
        }
    }
}
