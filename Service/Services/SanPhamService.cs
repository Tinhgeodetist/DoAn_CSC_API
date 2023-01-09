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

    public class SanPhamService : Repository<Sanpham>, ISanPhamService
    {
        public SanPhamService(QLShopContext context) : base(context) { }

        public Sanpham ThongTinSanPham(string id)
        {
            var model = _context.Sanphams.FirstOrDefault(x => x.Id.Equals(id));
            return model;
        }
    }
}
