using R4CloThes.Client.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Pages
{
    public partial class Cart
    {
        private bool isLoading = false;
        private List<SanPhamGioHang> listSanPham = null;
        private string id = null;
        protected override async Task OnInitializedAsync()
        {
            listSanPham = await localStorage.GetItemAsync<List<SanPhamGioHang>>("cart");
            id = await localStorage.GetItemAsync<string>("khachhangid");
        }
        private async Task UpdateCart(SanPhamGioHang sp)
        {
            int index = listSanPham.IndexOf(sp);
            listSanPham[index].SoLuong = sp.SoLuong;
            await localStorage.SetItemAsync("cart", listSanPham);
        }
        private double TinhTien(SanPhamGioHang sp)
        {
            return sp.SanPham.Gia * (double)sp.SoLuong;
        }
        private double TongTien()
        {
            double tt = 0;
            foreach (var item in listSanPham)
            {
                tt += item.SanPham.Gia * item.SoLuong;
            }
            return tt;
        }
        private async Task DatHang()
        {
            isLoading = true;
            var token = await localStorage.GetItemAsync<string>("token");
            GioHang giohang = new GioHang();
            giohang.MaKhachHang = int.Parse(id);
            giohang.ListViewCart = listSanPham;
            giohang.TongTien = TongTien();
            var res = await _apiHelper.PostRequestAsync("hoadons", giohang, token);
            if (res == "1")
            {
                nav.NavigateTo("/");
                await localStorage.RemoveItemAsync("cart");
            }
            isLoading = false;
        }
        private async Task xoasp(int idsanpham)
        {
            List<SanPhamGioHang> cart = await localStorage.GetItemAsync<List<SanPhamGioHang>>("cart");
            var itemrm = cart.Single(r => r.SanPham.Masanpham == idsanpham);
            cart.Remove(itemrm);
            if (cart.Count == 0)
            {
                listSanPham = null;
                await localStorage.RemoveItemAsync("cart");
            }
            else
            {
                await localStorage.SetItemAsync("cart", cart);
            }
            nav.NavigateTo("/cart", true);
        }
    }
}
