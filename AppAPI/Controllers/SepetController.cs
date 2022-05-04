using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SepetController : ControllerBase
    {
        private readonly ISepetService _sepetService;

        public SepetController(ISepetService sepetService)
        {
            _sepetService = sepetService;
        }

        [HttpDelete]
        public IActionResult Sil(int id)
        {
            _sepetService.SepettenCikar(id);
            return Ok();
        }
    }
}
