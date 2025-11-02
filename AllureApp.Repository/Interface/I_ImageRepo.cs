using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Interface
{
    public interface I_ImageRepo
    {
        bool SaveImage(IFormFile file, int productId);
    }
}
