using Blazored.LocalStorage;
using MudBlazor;
using R4CloThes.Client.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Helpers
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(SanPhamGioHang sanPhamGioHang);
    }
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly ISnackbar _snackBar;

        public CartService(ILocalStorageService localStorage, ISnackbar snackBar)
        {
            _localStorage = localStorage;
            _snackBar = snackBar;
        }

        public event Action OnChange;

        public async Task AddToCart(SanPhamGioHang sanPhamGioHang)
        {
            bool check = false;
            var cart = await _localStorage.GetItemAsync<List<SanPhamGioHang>>("cart");
            if (cart == null)
            {
                cart = new List<SanPhamGioHang>();
                cart.Add(sanPhamGioHang);
                await _localStorage.SetItemAsync("cart", cart);
            }
            else
            {
                foreach(var item in cart)
                {
                    if (item.SanPham.Masanpham == sanPhamGioHang.SanPham.Masanpham)
                    {
                        item.SoLuong += sanPhamGioHang.SoLuong;
                        check = true;
                    }
                }
                if (!check)
                {
                    cart.Add(sanPhamGioHang);
                }
                await _localStorage.SetItemAsync("cart", cart);
            }
            _snackBar.Add($"Đã thêm {sanPhamGioHang.SanPham.Tensanpham} vào giỏ hàng!", Severity.Success);
            OnChange.Invoke();
        }
    }
}
