using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using R4Clothes.Client.Models;
using R4CloThes.Client.Helpers;
using R4CloThes.Client.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace R4CloThes.Client.Pages
{
    public partial class Login
    {
        private string email = "";
        private string password = "";
        private string infomation = "";
        private bool _processes = false;
        CheckLogin checkLogin = new CheckLogin();

        protected override async Task OnInitializedAsync()
        {
            string token = await localStorage.GetItemAsStringAsync("token");
            if (token != null)
            {
                navigationManager.NavigateTo("/", false);
            }
        }
        public async Task DangNhap()
        {
            checkLogin.User = email;
            checkLogin.Password = password;
            _processes = true;
            string res = await _apiHelper.PostRequestAsync("tokens", checkLogin, null);
            if (res != "-1")
            {
                TokenModel token = JsonConvert.DeserializeObject<TokenModel>(res);
                await localStorage.SetItemAsync<string>("khachhangid", token.KhachhangId.ToString());
                await localStorage.SetItemAsync<string>("token", token.Token);
                navigationManager.NavigateTo("/", true);
            }
            else
            {
                infomation = "Sai tài khoản hoặc mật khẩu";
            }
            _processes = false;
           
        }
    }
}