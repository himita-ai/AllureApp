using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Interface
{
    public interface I_ImageService
    {
        bool SaveImage(IFormFile file, int productId);
    }
}
