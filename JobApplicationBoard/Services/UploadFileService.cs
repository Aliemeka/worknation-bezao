using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.Services
{
    // Upload file service is the service responsible for copying a file to a path in the folder and 
    // obtaining the filepath
    public class UploadFileService : IUploadFileService
    {
        private readonly IWebHostEnvironment webhostEnvironment;

        public UploadFileService(IWebHostEnvironment webhostEnvironment)
        {
            this.webhostEnvironment = webhostEnvironment;
        }

        // Method uploads file to assets folder and returns file path (string)
        public string UploadFile(IFormFile file)
        {
            string uploadFolder = Path.Combine(webhostEnvironment.WebRootPath, "assets");
            string fileName = file.FileName + "_" + Guid.NewGuid().ToString();
            string filePath = Path.Combine(uploadFolder, fileName);

            file.CopyTo(new FileStream(filePath, FileMode.Create));

            return filePath;
        }
    }
}
