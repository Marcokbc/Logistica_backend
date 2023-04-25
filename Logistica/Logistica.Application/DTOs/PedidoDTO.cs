using Logistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logistica.Application.DTOs
{
    public class PedidoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a origem")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Origem { get; set; }

        [Required(ErrorMessage = "Informe o destino")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Informe o status")]
        public StatusPedido Status { get; set; }

        [JsonIgnore]
        public ICollection<RotaDTO>? Rotas { get; set; }
    }
}
