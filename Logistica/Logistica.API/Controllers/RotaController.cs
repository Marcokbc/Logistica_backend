using Logistica.Application.DTOs;
using Logistica.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private readonly IRotaService _rotaService;

        public RotaController(IRotaService rotaService)
        {
            _rotaService = rotaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RotaDTO>>> Get()
        {
            var rotas = await _rotaService.GetRotas();
            return Ok(rotas);
        }

        [HttpGet("{id}", Name = "GetRota")]
        public async Task<ActionResult<RotaDTO>> Get(int id)
        {
            var rota = await _rotaService.GetById(id);

            if(rota == null)
            {
                return NotFound();
            }
            return Ok(rota);
        }

        [HttpPost]
        public ActionResult Post([FromBody]RotaDTO rota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _rotaService.Add(rota);

            return new CreatedAtRouteResult("GetRota",
                new {id = rota.Id}, rota);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]RotaDTO rota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != rota.Id)
            {
                return BadRequest();
            }

            _rotaService.Update(rota);
            return Ok(rota);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RotaDTO>> Delete(int id)
        {
            var rotaDto = await _rotaService.GetById(id);
            if(rotaDto == null)
            {
                return NotFound();
            }
            await _rotaService.Remove(id);
            return Ok(rotaDto);
        }
    }
}
