using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDev.Api.Entities;

namespace PoupaDev.Api.Persistence
{
    public class PoupaDevContext
    {
        public List<ObjetivoFinanceiro> Objetivos {get; set;}
        public PoupaDevContext() {
            Objetivos = new List<ObjetivoFinanceiro>();
        }
    }
}