using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDev.Api.Models
{
    public class ObjetivoFinanceiroInputModel
    {
        public string? Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public decimal? ValorObjetivo { get; private set; }
    }
}