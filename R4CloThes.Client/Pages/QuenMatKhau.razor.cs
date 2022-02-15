using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using R4CloThes.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace R4CloThes.Client.Pages
{
    public partial class QuenMatKhau
    {
        public string email { get; set; }
        [Inject] public IAPIHelper _apiHelper { get; set; }
        [Inject] public ILocalStorageService _localStorage { get; set; }
        [Inject] public ISnackbar _snackBar { get; set; }
        protected override async Task OnInitializedAsync()
        {
            
        }
        private async Task xacnhan()
        {
            if (IsValid(email))
            {
                var res = await _apiHelper.PostRequestAsync("khachhangs/quenmk?email=" + email, null, null);
                if (res != "-1")
                {
                    if (res == "true")
                    {
                        _snackBar.Add("Đã gửi mật khẩu mới tới mail của bạn!", Severity.Success);
                    }
                    else
                    {
                        _snackBar.Add("Không tìm thấy tài khoản này!", Severity.Error);
                    }
                }
            }
            else
            {
                _snackBar.Add("Email không đúng", Severity.Error);
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
