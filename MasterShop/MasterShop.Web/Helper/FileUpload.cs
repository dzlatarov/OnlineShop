
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Helper
{
    public class FileUpload
    {
        private readonly IWebHostEnvironment env;

        public FileUpload(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public string UploadFile(IFormFile file)
        {
            string fileName = null;
            if(file != null)
            {
                string uploadDir = Path.Combine(env.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
