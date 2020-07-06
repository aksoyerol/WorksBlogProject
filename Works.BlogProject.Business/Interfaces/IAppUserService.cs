using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.Dto.DTOs.AppUserDtos;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto);
        Task<AppUser> FindByNameAsync(string userName);
    }
}
