using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.Business.Tools.JwtTool;
using Works.BlogProject.Business.Tools.LogTool;
using Works.BlogProject.Dto.DTOs.AppUserDtos;

namespace Works.BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomLogger _logger;
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;
        public AuthController(IAppUserService appUserService, IJwtService jwtService, ICustomLogger logger)
        {
            _logger = logger;
            _appUserService = appUserService;
            _jwtService = jwtService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDto);

            if (user != null)
            {
                return Created("", _jwtService.GenerateJwt(user));
            }
            return BadRequest("Wrong username or password !");
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByNameAsync(User.Identity.Name);

            return Ok(new AppUserDto { Id = user.Id, Name = user.Name, LastName = user.LastName, UserName = user.UserName });

        }

        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"Hatanın oluştuğu yer :\n {errorInfo.Path}\n\n Hata Mesajı : \n {errorInfo.Error.Message}\n\n Stack Trace : \n {errorInfo.Error.StackTrace}");
            return Problem(detail: "Ooops! A problem has occurred.We notified our engineer to be repaired as soon as possible.");
        }
    }
}
