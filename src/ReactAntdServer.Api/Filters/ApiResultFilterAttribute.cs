﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReactAntdServer.Api.Models;
using ReactAntdServer.Model.Dto;

namespace ReactAntdServer.Api.Filters
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var objResult = context.Result as ObjectResult;
            if (context.Result is ValidationFailedResult)
            {
                context.Result = objResult;
            } 
            context.Result = new OkObjectResult(ResultWrapper.FromData(objResult.Value));
        }
    }
}
