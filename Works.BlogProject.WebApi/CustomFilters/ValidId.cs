using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.Entities.Interfaces;

namespace Works.BlogProject.WebApi.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity:class,ITable,new()
    {
        private readonly IGenericService<TEntity> _genericService;
        public ValidId(IGenericService<TEntity> genericService)  
        {
            _genericService = genericService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(x => x.Key == "id").FirstOrDefault();
            var id = int.Parse(dictionary.Value.ToString());
            var entity = _genericService.GetByIdAsync(id).Result;
            if (entity == null)
                context.Result = new NotFoundObjectResult($"Invalid id -> {id}");

        }
    }
}
