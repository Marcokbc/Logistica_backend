using Logistica.Application.DTOs;
using Logistica.Application.Interfaces;
using Logistica.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> Get()
        {
            var pedidos = await _pedidoService.GetPedidos();
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
