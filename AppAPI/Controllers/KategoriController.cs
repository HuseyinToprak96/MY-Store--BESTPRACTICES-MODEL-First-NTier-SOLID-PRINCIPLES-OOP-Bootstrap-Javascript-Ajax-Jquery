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
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _service;
        private readonly IMapper _mapper;
        public KategoriController(IMapper mapper, IKategoriService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpPost]
        //public async Task<IActionResult> KategoriEkle(KategoriDto kategoriDto)
        public async Task<IActionResult> KategoriEkle(KategoriDto kategoriDto)
        {
            var kategori = _mapper.Map<Kategori>(kategoriDto);
            await _service.AddAsync(kategori);
            //return Ok();
            return Ok(kategoriDto);
        }
        [HttpGet]
        public async Task<IActionResult> KategoriListe()
        {
            var KategoriDto = _mapper.Map<List<KategoriDto>>(await _service.getAllAsync());
            return Ok(KategoriDto);
        }
        [HttpGet]
        public async Task<IActionResult> Bul(int id)
        {
            return Ok(_mapper.Map<KategoriDto>(await _service.getByIdAsync(id)));
        }

        [HttpDelete]
        public async Task<IActionResult> KategoriSil(int id)
        {
           await _service.Remove(await _service.getByIdAsync(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Guncelle(KategoriDto kategoriDto)
        {
            var kategori = _mapper.Map<Kategori>(kategoriDto);
           await _service.Update(kategori);
            return Ok();
        }

        public List<Kategori> GetAll() => _service.getAllAsync().Result.Select(p => new Kategori
        {
            KategoriAdi = "AA",
            Renk="blue"
        }).ToList();
    }
}
