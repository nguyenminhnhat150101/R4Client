using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Helpers
{
    public interface IUploadImage
    {
        Task<string> GetUrlImage(IBrowserFile image);
    }
    public class UploadImage : IUploadImage
    {
        public Cloudinary _cloudinary;
        public UploadImage(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }
        public async Task<string> GetUrlImage(IBrowserFile image)
        {
            try
            {
                var result = await _cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(image.Name,
                        image.OpenReadStream())
                }).ConfigureAwait(false);
                return result.SecureUrl.AbsoluteUri;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
