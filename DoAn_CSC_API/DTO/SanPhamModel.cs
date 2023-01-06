using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.DTO
{
    public class SanPhamModel
    {
        public class SanPhamBase
        {
            public int Id { get; set; }
            public int? UserId { get; set; }
            public int ThuongHieuId { get; set; }
            public int LoaiHangId { get; set; }
            public int? KhuyenMaiId { get; set; }
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int GiaSanPham { get; set; }
            public string HinhSanPham { get; set; }
            public DateTime NgayTao { get; set; }
            public DateTime NgayCapNhat { get; set; }
            public double GiamGia { get; set; }
            public int SoLuong { get; set; }
            public string ThongTin { get; set; }
            public bool? TrangThai { get; set; }
            public int Gia { get; set; }

        }
        public class Input
        {
            public class ThongTinSanPham : SanPhamBase
            {

            }

            public class DocThongTinSanPham
            {
                public int ID { set; get; }
            }
            public class SanPhamTheoThuongHieu
            {
                public int ThuongHieuID { get; set; }
                public int CurrentPage { get; set; }
                public int PageSize { get; set; }
            }
        }

        public class Output
        {
            public class ThongTinSanPham : SanPhamBase
            {
                public ThuongHieuModel.ThuongHieuBase ThuongHieu { get; set; }
                // cần gì thêm vô
                public ThongTinSanPham()
                {
                    ThuongHieu = new();
                }
            }
            public class SanPhamThuongHieu
            {
                public ThuongHieuModel.ThuongHieuBase ThuongHieuHienHanh { get; set; }
                public List<ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public List<SanPhamModel.Output.ThongTinSanPham> DanhSachSanPham { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public SanPhamThuongHieu()
                {
                    ThuongHieuHienHanh = new();
                    DanhSachSanPham = new();
                    DanhSachThuongHieu = new();
                }
            }
        }
    }
}
