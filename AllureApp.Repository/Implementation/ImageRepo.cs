using AllureApp.Core.DBContext;
using AllureApp.Core.Entities;
using AllureApp.Repository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Implementation
{

    public class ImageRepo : Repository<Product>, I_ImageRepo
    {
        private readonly AllureAppContext _context;

        public ImageRepo(AllureAppContext context) : base(context)
        {
            _context = context;
        }

        public bool SaveImage(IFormFile file, int productId)
        {
            bool result = false;
            try
            {
                var productExist = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (productExist != null)
                {
                    FileInfo setDrive = new FileInfo("C:");
                    DriveInfo drive = new DriveInfo(setDrive.Directory.Root.FullName);
                    var fullPath = Path.Combine(drive + "Users\\91982\\Downloads\\Pizza_imgs\\Uploaded_Images\\");
                    string fileName = file.FileName;
                    if (!System.IO.Directory.Exists(fullPath))
                    {
                        System.IO.Directory.CreateDirectory(fullPath);
                    }
                    var extension = Path.GetExtension(fileName);
                    var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    if (!allowedExtensions.Contains(extension.ToLower()))
                    {
                        var newExtension = fileName.Replace(extension, ".png");
                        fileName = newExtension;
                    }
                    var imagePath = fullPath + fileName;
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        if (stream.Length > 0)
                        {
                            BinaryReader reader = new BinaryReader(stream);
                            byte[] bytes = reader.ReadBytes((int)stream.Length);

                        }
                        productExist.ImageUrl = imagePath;
                        _context.SaveChanges();
                        result = true;
                    }


                }
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}


