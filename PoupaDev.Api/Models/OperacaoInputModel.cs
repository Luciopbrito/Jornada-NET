using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDev.Api.Enums;
namespace PoupaDev.Api.Models
{
    public class OperacaoInputModel
    {
        public decimal Valor { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
    }
}