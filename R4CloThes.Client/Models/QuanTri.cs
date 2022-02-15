using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Client.Models
{
    public class QuanTri
    {
        [Key]
        public int Maquantri { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Bạn cần nhập tài khoản.")]
        public string Taikhoan { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Bạn cần nhập họ tên.")]
        [Column(TypeName = "nvarchar(100)")]
        public string Hoten { get; set; }

        [Display(Name = "Mật khẩu")]
        [Column(TypeName = "varchar")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Matkhau { get; set; }
    }
}
