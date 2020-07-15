using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Works.BlogProject.Business.Concrete;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.WebApi
{
    public static class DataInitilazier
    {
        public static async Task SeedData(IAppUserService appUserManager)
        {
            var user = await appUserManager.FindByNameAsync("pcparticle");
            if (user == null)
            {
                await appUserManager.InsertAsync(new AppUser
                {
                    Name = "Erol",
                    Email = "pcparticle@outlok.com",
                    LastName = "Aksoy",
                    Password = "123",
                    UserName = "pcparticle"
                });

            }


        }
    }
}
