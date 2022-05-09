using AutoMapper;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisService _service;
        private readonly ISepetService _sepetService;
        public SiparisController(ISiparisService service, ISepetService sepetService)
        {
            _service = service;
            _sepetService = sepetService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Siparis siparis)
        {
            await _service.AddAsync(siparis);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _service.getAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            return Ok(await _service.getByIdAsync(id));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(await _service.getByIdAsync(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Siparis siparis)
        {
            await _service.Update(siparis);
            return Ok();
        }
        [HttpGet] 
        public async Task<IActionResult> New()
        {
         var siparisler=  await _service.Siparisler(0);
            return Ok(siparisler);
        }
        [HttpPost]
        public async Task<IActionResult> SiparisOlustur(int id)
        {
            //int id = HttpContext.Session.GetInt32("ID").Value;
            var sepet = await _sepetService.MusterininSepeti(id);
            await _service.SiparisOlustur(id);
            int siparisId = await _service.SiparisBul(id);
            await _service.SiparisleriEkle(sepet.SepetDetay, siparisId);
            await _sepetService.SepetiTemizle(sepet.Id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Puanla(int puan, int id)
        {
           await _service.Puanla(puan, id);
            return Ok();
        }
    }
}
