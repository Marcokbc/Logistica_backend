﻿using Logistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.DTOs
{
    public class RotaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string NomeCidade { get; set; }

        [Required(ErrorMessage = "Informe a data da rota")]
        public DateTime DataRota { get; set; }
        public int IdPedido { get;  set; }
    }
}
