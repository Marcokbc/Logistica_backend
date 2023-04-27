using AutoMapper;
using Logistica.Application.DTOs;
using Logistica.Application.Mappings;
using Logistica.Application.Services;
using Logistica.Domain.Entities;
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

        [Fact]
        public void GetPedidos_ValidatingObject()
        {
            List<Pedido> _pedidos = new List<Pedido>();
            _pedidos.Add(new Pedido
            (
                100,
                "Marco",
                "Brumado",
                "VCA",
                Domain.Entities.StatusPedido.PedidoEfetuado
            ));

            var _pedidoRepository = new Mock<IPedidoRepository>();
            _pedidoRepository.Setup(x => x.GetPedidosAsync()).ReturnsAsync(_pedidos);

            var _autoMapperProfile = new DomainToDTOMappingProfile();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            pedidoService = new PedidoService(_pedidoRepository.Object, _mapper);
            var result = pedidoService.GetPedidos(1, 1);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void GetById_ValidatingObject()
        {
            var _pedido = new Pedido
           (
               100,
               "Marco",
               "Brumado",
               "VCA",
               Domain.Entities.StatusPedido.PedidoEfetuado
           );

            var _pedidoRepository = new Mock<IPedidoRepository>();
            _pedidoRepository.Setup(x => x.GetByIdAsync(100)).ReturnsAsync(_pedido);

            var _autoMapperProfile = new DomainToDTOMappingProfile();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            pedidoService = new PedidoService(_pedidoRepository.Object, _mapper);
            var result = pedidoService.GetById(100);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public async Task Update_ValidObject()
        {
            var pedido = new Pedido
            (
                100,
                "Marco",
                "Brumado",
                "VCA",
                Domain.Entities.StatusPedido.PedidoEfetuado
            );

            var _pedidoRepository = new Mock<IPedidoRepository>();
            _pedidoRepository.Setup(x => x.UpdateAsync(pedido)).ReturnsAsync(pedido);
            var _autoMapperProfile = new DomainToDTOMappingProfile();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);
            pedidoService = new PedidoService(_pedidoRepository.Object, _mapper);

            var pedidoDto = _mapper.Map<PedidoDTO>(pedido);

            var result = await pedidoService.Update(pedidoDto);

            Assert.True(result);
        }

        [Fact]
        public async Task Delete_ValidObject()
        {
            var pedido = new Pedido
            (
                100,
                "Marco",
                "Brumado",
                "VCA",
                Domain.Entities.StatusPedido.PedidoEfetuado
            );

            var _pedidoRepository = new Mock<IPedidoRepository>();
            _pedidoRepository.Setup(x => x.RemoveAsync(pedido)).ReturnsAsync(pedido);

            var _autoMapperProfile = new DomainToDTOMappingProfile();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            pedidoService = new PedidoService(_pedidoRepository.Object, _mapper);

            var pedidoDto = _mapper.Map<PedidoDTO>(pedido);

            var result = await pedidoService.Remove(100);

            Assert.True(result);
        }
    }
}
