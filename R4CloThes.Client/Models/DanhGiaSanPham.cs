using R4CloThes.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Client.Models
{
    public class DanhGiaSanPham
    {
        [Key]
        public int MaDanhGiaSanPham { get; set; }

        [Display(Name = "Mã khách hàng")]
        [ForeignKey("KhachHang")]
        [Required]
        public int Makhachhang { get; set; }
        
        [Display(Name = "Mã sản phẩm")]
        [ForeignKey("SanPham")]
        [Required]
        public int Masanpham { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Bạn cần chọn ngày."), Display(Name = "Ngày đặt")]
        public DateTime Thoigian { get; set; }

        [StringLength(250)]
        [Display(Name = "Nội dung")]
        public string Noidung { get; set; }
      
        public SanPhamViewModel SanPham { get; set; }
        public KhachHang KhachHang { get; set; }
    }
}
