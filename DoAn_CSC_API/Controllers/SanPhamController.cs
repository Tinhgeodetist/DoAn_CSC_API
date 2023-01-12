using DoAn_CSC_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamService _iSanPhamService;
        public SanPhamController(ISanPhamService isanPhamService)
        {
            _iSanPhamService = isanPhamService;
        }

        [HttpPost("DanhSachSanPham")]
        public List<SanPhamModel.Output.ThongTinSanPham> DanhSachSanPham()
        {
            var model = _iSanPhamService.DocDanhSach().Select(x => new SanPhamModel.Output.ThongTinSanPham 
            {
                TenSanPham = x.TenSanPham,
                Id = x.Id,
                Gia = x.Gia,
                GiamGia= x.GiamGia,
                GiaSanPham = x.GiaSanPham,
                HinhSanPham = x.HinhSanPham,
                KhuyenMaiId = x.KhuyenMaiId,
                LoaiHangId = x.LoaiHangId,
                MaSanPham = x.MaSanPham,
                NgayCapNhat = x.NgayCapNhat,
                NgayTao = x.NgayTao,
                SoLuong = x.SoLuong,
                ThongTin = x.ThongTin,
                ThuongHieuId = x.ThuongHieuId,
                TrangThai = x.TrangThai,
                UserId = x.UserId
            }).ToList();
            return model;
            ///ashdkasd;a
        }

    }
}
