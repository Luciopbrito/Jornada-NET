using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoupaDev.Api.Models;
using PoupaDev.Api.Persistence;
using PoupaDev.Api.Entities;

namespace PoupaDev.Api.Controllers
{
    [ApiController]
    [Route("api/objetivos-financeiros")]
    public class ObjetivosFinanceirosController : ControllerBase
    {
        private readonly PoupaDevContext _context;
        public ObjetivosFinanceirosController(PoupaDevContext context) {
            _context = context; // campos privados utiliza-se _ para acesse-los
        }

        // GET api/objetivos-financeiros
        [HttpGet]
        public IActionResult GetTodos() {
            var obejtivos = _context.Objetivos;
            return Ok();
        }
        // GET api/objetivos-financeiros/1
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id) {
            // Se não achar, retornar NotFound();
            var objetivo = _context.Objetivos.SingleOrDefault(n => n.Id == id);
            if (objetivo == null) {
                return NotFound();
            }
            return Ok(objetivo);
        }
        // POST api/objetivos-financeiros
        [HttpPost]
        public IActionResult Post(ObjetivoFinanceiroInputModel model) {
            // Se dados de entrada estiverem inválidos retornar BadRequest()
            var objetivo = new ObjetivoFinanceiro(
                model.Titulo,
                model.Descricao,
                model.ValorObjetivo);

                _context.Objetivos.Add(objetivo);

            var id = objetivo.Id;
            return CreatedAtAction(
                "GetPorId",
                new { id = id },
                model
            );
        }
        // POST api/objetivos-financeiros/1/operacoes
        [HttpPost("{id}/operacoes")]
        public IActionResult PostOperacao(int id, OperacaoInputModel model){
            var operacao = new Operacao(model.Valor, model.TipoOperacao);
            
            var objetivo = _context.Objetivos.SingleOrDefault(n => n.Id == id);
            
            if (objetivo == null) {
                return NotFound();
            }

            objetivo.RealizarOperacao(operacao);

            return NoContent();
        }
    }
}