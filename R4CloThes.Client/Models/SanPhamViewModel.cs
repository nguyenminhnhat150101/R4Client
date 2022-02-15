using R4Clothes.Client.Models;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;

namespace R4CloThes.Client.Models
{
    public class SanPhamViewModel
    {
        public int Masanpham { get; set; }
        public int Maquantri { get; set; }
        public string Tensanpham { get; set; }

        public int Maloai { get; set; }
        public int Soluong { get; set; }
        public double Gia { get; set; }
        public string Hinh { get; set; }
        public int Soluotxem { get; set; }
        public DateTime Ngaynhap { get; set; }
        public int? Giamgia { get; set; }
        public string Mota { get; set; }
        public bool Trangthai { get; set; }

        public bool Dacbiet { get; set; }
        public QuanTri QuanTris { get; set; } = null;
        public LoaiSanPham LoaiSanPhams { get; set; } = null;
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null;




    }
}