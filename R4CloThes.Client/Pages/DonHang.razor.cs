using Newtonsoft.Json;
using R4Clothes.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Pages
{
    public partial class DonHang
    {
        private string token = null;
        private string id;
        private List<HoaDon> hoadon = new List<HoaDon>();
        protected override async Task OnInitializedAsync()
        {
            token = await localStorage.GetItemAsync<string>("token");
            id = await localStorage.GetItemAsync<string>("khachhangid");
             
            if (token == null)
            {
                nav.NavigateTo("/");
            }
            else
            {
                string url = "hoadons/khachhang/" + id;
                var res = await _apiHelper.GetRequestAsync(url, token);
                if (res != "-1")
                {
                    hoadon = JsonConvert.DeserializeObject<List<HoaDon>>(res);
                }
            }
        }
    }
}
