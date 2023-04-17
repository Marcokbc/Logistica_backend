using Logistica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Domain.Entities
{
    public sealed class Rota : Entity
    {
        public Rota(string nomeCidade, DateTime dataRota, int idPedido)
        {
            ValidateDomain(nomeCidade, dataRota, idPedido);
        }

        public Rota(int id, string nomeCidade, DateTime dataRota, int idPedido)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(nomeCidade, dataRota, idPedido);
        }
        public string NomeCidade { get; private set; }
        public DateTime DataRota { get; private set; }
        public int IdPedido { get; private set; }
        public Pedido Pedido { get; private set; }

        private void ValidateDomain(string nomeCidade, DateTime dataRota, int idPedido)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeCidade),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nomeCidade.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");

            NomeCidade = nomeCidade;
            DataRota = dataRota;
            IdPedido = idPedido;

        }

    }
}
