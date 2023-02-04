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
        ThanhVien DangNhap(string email, string password);
        ThanhVien DangKyThanhVien(ThanhVien thanhvien);
        bool KickHoatTaiKhoan(string email);
        bool ThayDoiMatKhau(ThanhVien thanhvien);
        ThanhVien DocThongTin(int id);
    }
}
