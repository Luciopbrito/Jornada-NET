using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDev.Api.Entities {
    using PoupaDev.Api.Enums;
    public class Operacao
    {
        public Operacao(decimal valor, TipoOperacao tipo)
        {
            id = new Random().Next(0, 1000);
            Valor = valor;
            Tipo = tipo;
            this.idObjetivo = idObjetivo;
        }

        public int id { get; private set; }
        public decimal Valor { get; private set; }
        public TipoOperacao Tipo { get; private set; }
        public int idObjetivo { get; private set; }
    }
}
