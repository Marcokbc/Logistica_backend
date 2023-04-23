using Logistica.Application.DTOs;
using Logistica.Application.Interfaces;
using Logistica.Application.Pagination;
using Logistica.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Logistica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> 
            Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var pedidos = await _pedidoService.GetPedidos(pageNumber, pageSize);

            return Ok(pedidos);
        }

        [HttpGet("{id}", Name = "GetPedido")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _pedidoService.GetById(id);

            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }


        [HttpGet("codigo/{codigo}", Name = "GetPedidoByCodigo")]
        public async Task<ActionResult<Pedido>> GetPedidoByCodigo(string codigo)
        {
            var pedido = await _pedidoService.GetByCodigo(codigo);

            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PedidoDTO pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _pedidoService.Add(pedido);

            return CreatedAtRoute(nameof(GetPedido),
                new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PedidoDTO pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            await _pedidoService.Update(pedido);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> Delete(int id)
        {
            var pedidoDto = await _pedidoService.GetById(id);
            if (pedidoDto == null)
            {
                return NotFound();
            }
            await _pedidoService.Remove(id);
            return Ok(pedidoDto);
        }
    }
}
