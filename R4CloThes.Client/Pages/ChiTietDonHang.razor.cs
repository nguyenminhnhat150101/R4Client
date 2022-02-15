using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using R4CloThes.Client.Models.ViewModel;
using Newtonsoft.Json;

namespace R4CloThes.Client.Pages
{
    public partial class ChiTietDonHang
    {
        [Parameter]
        public string id { get; set; }
        private string token = null;
        private string idkhachhang;
        private List<SanPhamCT> sanPhamCTs = new List<SanPhamCT>();
        protected override async Task OnInitializedAsync()
        {
            token = await localStorage.GetItemAsync<string>("token");
            idkhachhang = await localStorage.GetItemAsync<string>("khachhangid");

            if (token == null)
            {
                nav.NavigateTo("/");
            }
            else
            {
                string url = "chitiethoadons/hoadon/" + id;


                var res = await _apiHelper.GetRequestAsync(url, token);
                if (res != "-1")
                {
                    sanPhamCTs = JsonConvert.DeserializeObject<List<SanPhamCT>>(res);

                }
            }
        }
    }
}
