using R4Clothes.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Pages
{
    public partial class DangKy
    {
        DateTime? date = DateTime.Today;
        public string confirmpwd;
        public string info;
        public KhachHang khachhang = new KhachHang();

        public async Task Regis()
        {
            if (confirmpwd != khachhang.Matkhau)
            {
                info = "Mật khẩu không trùng khớp";
            }
            else
            {
                khachhang.Makhachhang = 0;
                khachhang.Hinh = "string";
                khachhang.Gioitinh = 0;
                khachhang.Diachi = "string";
                khachhang.Trangthai = true;
                khachhang.Ngaysinh = date;
                var res = await _apiHelper.PostRequestAsync("khachhangs", khachhang, null);
                if (res == "-1")
                {
                    info = "Email đã tồn tại, hãy sử dụng email khác!";
                }
                else
                {
                    _snackBar.Add("Đã tạo 1 tài khoản", MudBlazor.Severity.Success);
                }
            }
        }

    }
}
