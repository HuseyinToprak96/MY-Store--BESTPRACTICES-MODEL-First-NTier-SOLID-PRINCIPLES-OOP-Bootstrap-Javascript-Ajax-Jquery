using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace StoreWeb.Filters
{
    public class FilterStatus : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string yetki = context.HttpContext.Session.GetString("Yetki");
            if (yetki != "Admin")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{
                    {"action","Index" },
                    { "controller","Page"}
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
