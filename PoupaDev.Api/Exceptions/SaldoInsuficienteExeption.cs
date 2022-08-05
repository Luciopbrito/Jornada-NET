using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDev.Api.Exceptions {
    public class SaldoInsuficienteExpetion : Exception {
        public SaldoInsuficienteExpetion() : base("Saldo insuficiente!")
        {
            
        }
    }
}