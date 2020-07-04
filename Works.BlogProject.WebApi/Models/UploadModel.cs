using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Works.BlogProject.WebApi.Enums;

namespace Works.BlogProject.WebApi.Models
{
    public class UploadModel
    {
        public string ImageName { get; set; }
        public string ErrorMessage { get; set; }
        public UploadState UploadState { get; set; }
    }
}
