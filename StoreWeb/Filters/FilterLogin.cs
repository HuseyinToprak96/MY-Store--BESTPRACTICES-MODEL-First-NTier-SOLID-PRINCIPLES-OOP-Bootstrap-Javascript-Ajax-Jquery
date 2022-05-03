using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Filters
{
    public class FilterLogin:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userID =context.HttpContext.Session.GetInt32("ID");
            if (!userID.HasValue)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{
                    {"action","KullaniciGiris" },
                    { "controller","Login"}
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
