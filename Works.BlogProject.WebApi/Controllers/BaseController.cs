using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Works.BlogProject.WebApi.Enums;
using Works.BlogProject.WebApi.Models;

namespace Works.BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadFormFileAsync(IFormFile file, string contentType, string imageNameHeader = "image")
        {
            UploadModel uploadModel = new UploadModel();
            if (file != null)
            {
                if (file.ContentType == contentType)
                {
                    var imageName = $"{imageNameHeader}_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + imageName);
                    using var fileStream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(fileStream);

                    uploadModel.ImageName = imageName;
                    uploadModel.UploadState = UploadState.Success;
                    return uploadModel;
                }
                else
                {
                    uploadModel.ErrorMessage = "Invalid content type";
                    uploadModel.UploadState = UploadState.Error;
                }
            }
            uploadModel.ErrorMessage = "File is null";
            uploadModel.UploadState = UploadState.NotExists;
            return uploadModel;
        }
    }
}
