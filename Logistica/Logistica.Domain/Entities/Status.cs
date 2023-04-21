using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Domain.Entities
{
    public class Status
    {
        private readonly string _value;

        public static readonly Status PedidoEfetuado = new Status("Pedido Efetuado");
        public static readonly Status Enviado = new Status("Enviado");
        public static readonly Status Transito = new Status("Transito");
        public static readonly Status Despachado = new Status("Despachado");
        public static readonly Status Retirado = new Status("Retirado");

        public Status(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(Status status)
        {
            return status._value;
        }

        public static explicit operator Status(int value)
        {
            switch (value)
            {
                case 0:
                    return PedidoEfetuado;
                case 1:
                    return Enviado;
                case 2:
                    return Transito;
                case 3:
                    return Despachado;
                case 4:
                    return Retirado;
                default:
                    throw new ArgumentException($"'{value}' is not a valid LogisticsStatus value.");
            }
        }
    }
}

