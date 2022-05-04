using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StoreWeb.Filters
{
    public class FilterStatus : IAuthorizationFilter
    {
        string _rol;
        public FilterStatus(string rol)
        {
            _rol = rol;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string yetki = context.HttpContext.Session.GetString("Yetki");
            if (yetki == "False")
            {

            }
        }
    }
}
