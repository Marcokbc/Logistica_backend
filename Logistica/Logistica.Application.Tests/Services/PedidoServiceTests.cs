using AutoMapper;
using Logistica.Application.DTOs;
using Logistica.Application.Services;
using Logistica.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logistica.Application.Tests.Services
{
    public class PedidoServiceTests
    {
        private PedidoService pedidoService;

        public PedidoServiceTests()
        {
            pedidoService = new PedidoService(new Mock<IPedidoRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public async Task Add_SendingValidObject()
        {
            var result = await pedidoService.Add(new PedidoDTO { Nome = "Marco", Origem = "Brumado", 
                Destino = "VCA", Status = Domain.Entities.StatusPedido.PedidoEfetuado, CodigoRastreio =  Guid.NewGuid().ToString() });
            Assert.True(result);
        }
    }
}
