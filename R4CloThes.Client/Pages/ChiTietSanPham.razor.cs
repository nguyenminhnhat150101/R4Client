using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using R4CloThes.Client.Models.ViewModel;
using R4CloThes.Client.Models;
using MudBlazor;
using R4Clothes.Client.Models;

namespace R4CloThes.Client.Pages
{
    public partial class ChiTietSanPham
    {
        [Parameter]
        public string id { get; set; }
        [Inject] public IDialogService dialogService { get; set; }
        public string token { get; set; }
        public bool checkFav = false;
        public string idkhachhang { get; set; }
        public int soLuongMua { get; set; } = 1;
        public double SauGiamGia = 0;
        public SanPhamViewModel sanPham = new SanPhamViewModel();
        public List<DanhGiaSanPhamReturn> dsdanhgia = new List<DanhGiaSanPhamReturn>();

        protected override async Task OnInitializedAsync()
        {
            idkhachhang = await localStorage.GetItemAsync<string>("khachhangid");
            token = await localStorage.GetItemAsync<string>("token");
            if (idkhachhang != null)
            {
                var re = await _apihelper.PostRequestAsync("yeuthichs/checkyeuthich?makhachhang=" + idkhachhang + "&masanpham=" + id, null, token);
                if (re != "-1")
                {
                    if (re == "true")
                    {
                        checkFav = true;
                    }
                }
            }
            var res = await _apihelper.GetRequestAsync("sanphams/" + id, null);
            sanPham = JsonConvert.DeserializeObject<SanPhamViewModel>(res);
            SauGiamGia = sanPham.Gia - (sanPham.Gia * (double)sanPham.Giamgia / 100);

            var ros = await _apihelper.GetRequestAsync("DanhGiaSanPhams/" + id, null);
            if (ros != "-1")
            {
                dsdanhgia = JsonConvert.DeserializeObject<List<DanhGiaSanPhamReturn>>(ros);
            }
            else
            {
                nav.NavigateTo("/");
            }
        }
        private async Task AddToCart()
        {
            await _cartService.AddToCart(new SanPhamGioHang {SanPham = sanPham, SoLuong = soLuongMua });
        }
        private async Task chiase()
        {
        }
        private async Task OpenDialog()
        {
            await localStorage.SetItemAsync("sanpham", sanPham);
            dialogService.Show<DialogChiase>("Chia sẻ sản phẩm này đến với bạn bè của bạn");
        }
    }
}
