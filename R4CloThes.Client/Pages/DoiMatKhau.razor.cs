using Microsoft.AspNetCore.Components;
using MudBlazor;
using R4Clothes.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Pages
{
    public partial class DoiMatKhau
    {
        private string id = null;
        private string token = null;
        private KhachHang khachhang = null;
        private string matkhaucu = null;
        private string matkhaumoi = null;
        private string xacnhanmatkhau = null;
        private string Thongtin = null;
        public bool process = false;
        [Inject]public ISnackbar _snackBar { get; set; }
        protected override async Task OnInitializedAsync()
        {
            token = await _LocalService.GetItemAsync<string>("token");
            id = await _LocalService.GetItemAsync<string>("khachhangid");

            if(token == null)
            {
                _Nav.NavigateTo("/");
            }
            
        }
        private async Task doimatkhau()
        {
            process = true;
            if (matkhaumoi != xacnhanmatkhau)
            {
                _snackBar.Add("Nhập lại mật khẩu không khớp!", Severity.Error);
                process = false;
            }
            else
            {
                string url = "khachhangs/doimatkhau?idkhachhang=" + id + "&oldpwd=" + matkhaucu + "&newpwd=" + matkhaumoi;
                var res = await _IAPIHelper.PostRequestAsync(url, null, token);
                if (res != "-1")
                {
                    if (res == "true")
                    {
                        _snackBar.Add("Đã đổi mật khẩu", Severity.Success);
                    }
                    else
                    {
                        _snackBar.Add("Mật khẩu cũ không khớp!", Severity.Error);
                    }
                    process = false;
                }
                process = false;
            }
        }
    }
}
