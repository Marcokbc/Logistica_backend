using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Logistica.Application.DTOs;
using Logistica.Domain.Entities;

namespace Logistica.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Rota, RotaDTO>().ReverseMap();
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
        }
    }
}
