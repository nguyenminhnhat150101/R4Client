using R4Clothes.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Models.ViewModel
{
    public class SanPhamGioHang
    {
        public SanPhamViewModel SanPham { get; set; }
        public int SoLuong { get; set; }
    }
    public class GioHang
    {
        public int MaKhachHang { get; set; }
        public List<SanPhamGioHang> ListViewCart { get; set; }
        public double TongTien { get; set; }
    }
}
