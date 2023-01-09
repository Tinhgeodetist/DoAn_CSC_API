using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.DTO
{
    public class ThanhVienModel
    {
        public class ThanhVienBase
        {
            public int Id { get; set; }
            public string HoTen { get; set; }
            public bool GioiTinh { get; set; }
            public DateTime NgaySinh { get; set; }
            public string Email { get; set; }
            public string DienThoai { get; set; }
            public string MatKhau { get; set; }
            public bool KichHoat { get; set; }
            public string SocialLogin { get; set; }
        }
        public class Input
        {
            public class DangNhap
            {
                public string Email { get; set; }
                public string MatKhau { get; set; }
            }
            public class DangKyThanhVien : ThanhVienBase { }
                
            public class ThayDoiMatKhau
            {
                public int Id { get; set; }
                public string Email { get; set; }
                public string MatKhauMoi { get; set; }
                public string MatKhauCu { get; set; }
            }
            public class KichHoatTaiKhoan
            {
                public string Email { get; set; }
            }
        }
        public class Output
        {
            public class DangNhap : ThanhVienBase 
            { 
                public string ThongBao { get; set; }            
            }
        }
    }
}
