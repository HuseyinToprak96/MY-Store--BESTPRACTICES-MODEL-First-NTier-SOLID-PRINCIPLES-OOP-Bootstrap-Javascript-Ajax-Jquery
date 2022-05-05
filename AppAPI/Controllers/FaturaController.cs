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
    public class FaturaController : ControllerBase
    {
        private readonly IFaturaService _service;
        private readonly IMapper _mapper;
        public FaturaController(IFaturaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Fatura fatura)
        {
          
            await _service.AddAsync(fatura);
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
        public async Task<IActionResult> Update(Fatura fatura)
        {
            await _service.Update(fatura);
            return Ok();
        }
    }
}
