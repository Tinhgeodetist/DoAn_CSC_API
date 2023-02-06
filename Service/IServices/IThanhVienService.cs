using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IThanhVienService : IRepository<ThanhVien> 
    {
        ThongTinThanhVien DangNhap(string TenDangNhap, string MatKhau);
        ThongBao DangKyThanhVien(ThanhVien thanh_vien_moi);
        ThanhVien TimThanhVien(string Email);
        ThongBao ThayDoiMatKhau(int Id, string Username, string MatKhauCu, string MatKhauMoi);
        ThanhVien DocThongTinThanhVien(int Id);
        ThongBao ThemThanhVien(ThanhVien thanh_vien_moi);
        ThongBao KichHoatTaiKhoan(string email);
    }
}
