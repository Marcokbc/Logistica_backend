using Logistica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logistica.Domain.Entities
{
    public sealed class Pedido : Entity
    {
        public Pedido(string nome, string origem, string destino, Status status) 
        {
            ValidateDomain(nome, origem, destino, status);
        }

        public Pedido(int id, string nome, string origem, string destino, Status status)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(nome, origem, destino, status);
        }

        public string Nome { get; private set; }
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public Status Status { get; private set; }
        public ICollection<Rota>? Rotas { get; private set; }

        private void ValidateDomain(string nome, string origem, string destino, Status status)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(origem),
                "Origem inválida. Origem é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(destino),
                "Destino inválido. Destino é obrigatório");

            Nome = nome;
            Origem = origem;
            Destino = destino;
            Status = status;
        }
    }
}
