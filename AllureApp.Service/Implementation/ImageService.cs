using AllureApp.Repository.Interface;
using AllureApp.Service.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Implementation
{
    public class ImageService: I_ImageService
    {
        private readonly I_ImageRepo _imageRepo;
        public ImageService(I_ImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }
        public bool SaveImage(IFormFile file, int productId)
        {
            return _imageRepo.SaveImage(file, productId);
        }
    }
}
