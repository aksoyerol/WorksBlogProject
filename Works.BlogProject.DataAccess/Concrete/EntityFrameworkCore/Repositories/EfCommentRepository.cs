using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.DataAccess.Interfaces;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCommentRepository : EfGenericRepository<Comment>,ICommentDal
    {
    }
}
