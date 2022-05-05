using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AltKategoriController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAltKategoriService _altKategoriService;
        public AltKategoriController(IAltKategoriService altKategoriService, IMapper mapper)
        {
            _altKategoriService = altKategoriService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Listele()
        {
            return Ok(_mapper.Map<List<AltKategori>>(await _altKategoriService.getAllAsync()));
        }
        [HttpGet]
        public async Task<IActionResult> Bul(int id)
        {
            return Ok(_mapper.Map<AltKategori>(await _altKategoriService.getByIdAsync(id)));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _altKategoriService.Remove(await _altKategoriService.getByIdAsync(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Guncelle(AltKategoriDto altKategoriDto)
        {
            await _altKategoriService.Update(_mapper.Map<AltKategori>(altKategoriDto));
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> altKategoriEkle(AltKategoriDto altKategoriDto)
        {
            await _altKategoriService.AddAsync(_mapper.Map<AltKategori>(altKategoriDto));
            return Ok();
        }
    }
}
