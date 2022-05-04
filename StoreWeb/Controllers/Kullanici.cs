using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.Filters;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    [AllowAnonymous]
    public class Kullanici : Controller
    {
        private readonly IUyeService _uyeService;
        public Kullanici(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [FilterLogin]
        public async Task<IActionResult> Profilim()
        {
            int id = HttpContext.Session.GetInt32("ID").Value;
            return View(await _uyeService.uyeDetay(id));
        }

    }
}
