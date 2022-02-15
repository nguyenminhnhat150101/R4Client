using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Models.ViewModel
{
    public class DanhGiaSanPhamReturn
    {
        public int MaKhachHang { get; set; }
        public string Tenkhachhang { get; set; }
        public string Hinh { get; set; }
        public DateTime Thoigian { get; set; }
        public string NoiDung { get; set; }
    }
}
