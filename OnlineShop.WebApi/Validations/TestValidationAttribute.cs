using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.Validations
{
    public class TestValidationAttribute : IActionFilter
    {
        public int Counter { get; set; }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            ++Counter;
            var args = context.ActionArguments.ToList();
            //Next();
            context.Result = new ContentResult()
            {
                Content = $"You Counter is {Counter}"
            };
        }
    }
}
