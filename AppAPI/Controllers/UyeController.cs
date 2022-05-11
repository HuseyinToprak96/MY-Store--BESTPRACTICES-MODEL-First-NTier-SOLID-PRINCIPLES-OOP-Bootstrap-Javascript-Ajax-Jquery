using AutoMapper;
using CoreLayer.Dtos;
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
    public class UyeController : ControllerBase
    {
        private readonly IUyeService _service;
        private readonly IMapper _mapper;
        public UyeController(IUyeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Uye uye)
        {
            //var urun = _mapper.Map<Urun>(urunDto);
            await _service.AddAsync(uye);
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
        public async Task<IActionResult> Update(Uye uye)
        {
            await _service.Update(uye);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDto(UyeGuncelleDto uyeGuncelleDto)
        {
            var uye = _mapper.Map<Uye>(uyeGuncelleDto);
            await _service.Update(uye);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> MailFind(int id)
        {
            string mail = await _service.MailBul(id);
            return Ok(mail);
        }
    }
}
