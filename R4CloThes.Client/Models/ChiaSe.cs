using R4Clothes.Client.Models;
using R4CloThes.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4CloThes.Client.Models
{
    public class ChiaSe
    {
        [Key]
        public int MaChiaSe { get; set; }
        
        [ForeignKey("KhachHang")]
        public int MaKhachHang { get; set; }
        [Required]
        public string EmailNguoiNhan { get; set; }

        [ForeignKey("SanPham")]
        public int MaSanPham { get; set; }
        [Required]
        public string HoTen { get; set; }

        [Required]
        [StringLength(100)]
        public string LinkSP { get; set; }

        public DateTime ThoiGian { get; set; }
        public KhachHang KhachHang { get; set; }
        public SanPhamViewModel SanPham { get; set; }
    }
}
