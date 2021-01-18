using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.Services
{
    public interface IUploadFileService
    {
        string UploadFile(IFormFile file);
    }
}
