using Logistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.DTOs
{
    public class PedidoDTO
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "Informe a origem")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Origem { get; private set; }

        [Required(ErrorMessage = "Informe o destino")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Destino { get; private set; }

        [Required(ErrorMessage = "Informe o status")]
        public int Status { get; private set; }
    }
}
