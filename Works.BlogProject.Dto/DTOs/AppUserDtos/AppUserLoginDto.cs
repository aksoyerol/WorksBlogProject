using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.Interface;

namespace Works.BlogProject.Dto.DTOs.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
