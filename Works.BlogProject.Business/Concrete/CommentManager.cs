using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.DataAccess.Interfaces;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.Business.Concrete
{
    public class CommentManager : GenericManager<Comment>,ICommentService
    {
        public CommentManager(IGenericDal<Comment> genericDal) : base(genericDal)
        {

        }
    }
}
