using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Newtonsoft.Json;
using R4Clothes.Client.Models;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Pages
{
    public partial class ThongTinKhachHang
    {
        MudDatePicker _picker;
        DateTime? date = DateTime.Today;
        bool success = false;
        bool isLoading = false;
        private string id = null;
        private string token = null;
        private string url;
        public int sex = 0;
        private string image = "";
        public KhachHang kh = new KhachHang();
        IList<IBrowserFile> files = new List<IBrowserFile>();

        protected override async Task OnInitializedAsync()
        {
            id = await localStorage.GetItemAsync<string>("khachhangid");
            token = await localStorage.GetItemAsync<string>("token");
            if (token != null)
            {
                string res = await _apiHelper.GetRequestAsync("khachhangs/" + id, token);
                if (res != "-1")
                {
                    kh = JsonConvert.DeserializeObject<KhachHang>(res);
                    sex = kh.Gioitinh ?? default(int);
                    image = "https://res.cloudinary.com/r4clothes/image/upload/" + kh.Hinh;
                }
                else
                {
                    nav.NavigateTo("/");
                }
            }
            else
            {
                nav.NavigateTo("/");
            }
        }

        private void OnValidSubmit(EditContext context)
        {
            success = true;
            StateHasChanged();
        }
        public async Task edit()
        {
            kh.Hinh = image.Substring(50);
            kh.Gioitinh = sex;

            var res = await _apiHelper.PutRequestAsync("khachhangs/" + id, kh, token);
            if (res != "-1")
            {
                _snachBar.Add("Đã chỉnh sửa!", Severity.Success);
            }
            else
            {
                _snachBar.Add("Có lỗi xảy ra!", Severity.Error);
            }
        }
        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                files.Add(file);
                // process loading
                isLoading = true;
                image = await _uploadImage.GetUrlImage(file);
                isLoading = false;
            }
            //TODO upload the files to the server
        }
    }
}
