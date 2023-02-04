using Service.IServices;
using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ThanhVienService : Repository<ThanhVien>, IThanhVienService
    {
        public ThanhVienService(QLShopContext context) : base(context) { }
        public ThanhVien DangKyThanhVien(ThanhVien thanhvien)
        {
            var tv = _context.ThanhViens.FirstOrDefault(x => x.Email.Equals(thanhvien.Email));
            if (tv != null) return null;
            try
            {
                var thanhvienmoi = base.Them(thanhvien);
                return thanhvienmoi;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ThanhVien DangNhap(string email, string password)
        {
            var thanh_vien = _context.ThanhViens.FirstOrDefault(x => x.Email.Equals(email)
                                                                    && x.MatKhau.Equals(password));
            var ketqua = thanh_vien != null ? thanh_vien : new ThanhVien();
            return ketqua;

        }

        public ThanhVien DocThongTin(int id)
        {
            var thanh_vien = _context.ThanhViens.FirstOrDefault(x => x.Id.Equals(id));
            return thanh_vien;
        }

        public bool KickHoatTaiKhoan(string email)
        {
            var thanhvien_kichhoat = _context.ThanhViens.FirstOrDefault(x => x.Email.Equals(email));
            if (thanhvien_kichhoat != null)
            {
                thanhvien_kichhoat.KichHoat = true;
                var ketqua = base.Sua(thanhvien_kichhoat);
                return ketqua;
            }
            return false;
        }

        public bool ThayDoiMatKhau(ThanhVien thanhvien)
        {
            var thanhvien_doimk = _context.ThanhViens.FirstOrDefault(x => x.Id.Equals(thanhvien.Id)
                                                                && x.Email.Equals(thanhvien.Email));
            if(thanhvien_doimk != null)
            {
                thanhvien_doimk.MatKhau = thanhvien.MatKhau;
                var ketqua = base.Sua(thanhvien_doimk);
                return ketqua;
            }
            return false;
        }
    }
}
