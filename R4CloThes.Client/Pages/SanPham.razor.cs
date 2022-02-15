using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using R4CloThes.Client.Helpers;
using R4CloThes.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Pages
{
    public partial class SanPham
    {
        public string loaisp { get; set; }
        public string giamgia { get; set; }
        List<SanPhamViewModel> dssp = null;
        [Inject] public IAPIHelper _apiHelper { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var res = await _apiHelper.GetRequestAsync("Sanphams/dssanpham", null);
            if (res != "-1")
            {
                dssp = JsonConvert.DeserializeObject<List<SanPhamViewModel>>(res);
            }
        }
        private async Task LocLoaiSanPham()
        {
            var res = await _apiHelper.GetRequestAsync("sanphams/splienquan?loaisp=" + loaisp, null);
            if (res != "-1")
            {
                dssp = JsonConvert.DeserializeObject<List<SanPhamViewModel>>(res);
            }
        }
        private async Task LocGiamGia()
        {
            var res = await _apiHelper.GetRequestAsync("sanphams/spgiamgia?giamgia=" + giamgia, null);
            if (res != "-1")
            {
                dssp = JsonConvert.DeserializeObject<List<SanPhamViewModel>>(res);
            }
            StateHasChanged();
        }

    }
}
