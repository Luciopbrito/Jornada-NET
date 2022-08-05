using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDev.Api.Entities
{
    using PoupaDev.Api.Enums;
    using PoupaDev.Api.Exceptions;
    public class ObjetivoFinanceiro
    {
        public ObjetivoFinanceiro(string? titulo, string? descricao, decimal? valorObjetivo)
        {
            Id = new Random().Next(0, 1000);
            Titulo = titulo;
            ValorObjetivo = valorObjetivo;
            Descricao = descricao;

            DataCriacao = DateTime.Now;

            Operacoes = new List<Operacao>();
        }

        public int Id { get; private set; }
        public string? Titulo { get; private set; }
        public decimal? ValorObjetivo { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public List<Operacao> Operacoes { get; private set; }
        public decimal Saldo => ObterSaldo();

        public void RealizarOperacao(Operacao operacao) {
            if (operacao.Tipo == TipoOperacao.Saque && operacao.Valor > Saldo)
                throw new SaldoInsuficienteExpetion();
            Operacoes.Add(operacao);
        }

        public decimal ObterSaldo()
        {
            var totalDeposito = Operacoes
                .Where(o => o.Tipo == TipoOperacao.Deposito)
                .Sum(o => o.Valor);
            var totalSaque = Operacoes
                .Where(o => o.Tipo == TipoOperacao.Saque)
                .Sum(o => o.Valor);
            return totalDeposito - totalSaque;
        }

        public virtual void ImprimirResumo()
        {
            Console.WriteLine($"Objetivo {Titulo}, Valor: {ValorObjetivo}, com Saldo Atual: R${Saldo}");
        }
    }
}