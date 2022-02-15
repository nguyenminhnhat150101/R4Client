using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using R4Clothes.Client.Models;
using R4CloThes.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace R4CloThes.Client.Helpers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public ILocalStorageService _localStorageService { get; }
        public IAPIHelper _apiHelper;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, IAPIHelper apiHelper)
        {
            _localStorageService = localStorageService;
            _apiHelper = apiHelper;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var khachhangid = await _localStorageService.GetItemAsync<string>("khachhangid");

            ClaimsIdentity identity;

            if (khachhangid != null && khachhangid != string.Empty)
            {
                string res = await _apiHelper.GetRequestAsync("khachhangs/{khachhangid}", null);
                KhachHang khachhang = JsonConvert.DeserializeObject<KhachHang>(res);
                identity = GetClaimsIdentity(khachhang);
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        public async Task MarkUserAsAuthenticated(TokenModel token)
        {
            await _localStorageService.SetItemAsync("token", token.Token);
            await _localStorageService.SetItemAsync("khachhangid", token.KhachhangId.ToString());

            string res = await _apiHelper.GetRequestAsync("khachhangs/{khachhangid}", null);
            KhachHang khachhang = JsonConvert.DeserializeObject<KhachHang>(res);
            var identity = GetClaimsIdentity(khachhang);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _localStorageService.RemoveItemAsync("token");
            await _localStorageService.RemoveItemAsync("khachhangid");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity GetClaimsIdentity(KhachHang khachhang)
        {
            var claimsIdentity = new ClaimsIdentity();

            if (khachhang.Email != null)
            {
                claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name, khachhang.Tenkhachhang),
                                    new Claim(ClaimTypes.Email, khachhang.Email),
                                    new Claim(ClaimTypes.Role, "user"),
                                }, "apiauth_type");
            }
            return claimsIdentity;
        }
    }
}
