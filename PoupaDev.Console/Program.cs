// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Digite o seu nome.");

// var nome = Console.ReadLine();

// Console.WriteLine("Hello, " + nome); 
// Console.WriteLine($"Hello, {nome}");

// string segundoNome = "Oliveria";
// int numeroInt = 5;
// float numeroFloat = 5.4f;
// double numeroDouble = 5.4;
// decimal numeroDecimal = 5.3m;
// int[] matriz = new int[3] {1, 2, 3};
// char caractere = 'a';
// DateTime hoje = DateTime.Now;
// DateTime aniversario = new DateTime(2003, 5, 18);

// // if - else
// Console.WriteLine("Digite um opção entre 1 e 3");
// var opcao = Console.ReadLine();

// if (opcao == "1") {
//     Console.WriteLine("if-else: Opção 1 selecionada");
// } else if (opcao == "2") {
//     Console.WriteLine("if-else: Opção 2 selecionada");
// } else if (opcao == "3") {
//     Console.WriteLine("if-else: Opção 3 selecionada");
// } else {
//     Console.WriteLine("if-else: Opção inválida.");
// }

// // switch-case
// switch (opcao) {
//     case "1":
//         Console.WriteLine("switch-case: Opção 1 selecionada");
//         break;
//     case "2":
//         Console.WriteLine("switch-case: Opção 2 selecionada");
//         break;
//     case "3":
//         Console.WriteLine("switch-case: Opção 3 selecionada");
//         break;
//     default:
//         Console.WriteLine("switch-case: Opção inválida.");
//         break;
// }

// var valores = Console.ReadLine(); // "1 2 3 4 5"
// var matrizValores = valores.Split(" "); // 0, 1, 2, 3, 4


// Console.WriteLine("utilizando While");
// var contador = 0;
// while (contador < matrizValores.Length) {
//     Console.WriteLine(matrizValores[contador]);
//     contador++;
// }

// var notasTurma = new List<int> {10, 5, 2, 3, 10, 4, 3, 2, 7, 2, 5, 1, 4};

// // utilizando LINQ
// var existeNota = notasTurma.Any(n => n == 1); // retorna bool
// var primeiroNota10 = notasTurma.First(n => n == 10); // retorna bool
// var singleNota1 = notasTurma.Single(n => n == 1); // retorna bool
// var max1 = notasTurma.Max(); // retorna um int
// var min = notasTurma.Min(); // retorna um int
// var sum = notasTurma.Sum(); // retorna um int
// var media = notasTurma.Average(); // retorna um int
// var ordered = notasTurma.OrderBy(n => n); // ordena de forma crescente
// //var orderedObj = notasTurma.OrderBy(n => n.idade); // ordena de forma crescente as propriedades idade de cada pessoa
// foreach (var nota in ordered) {
//     Console.WriteLine(nota);
// }
Console.WriteLine("---- PoupaDev ----");

var objetivos = new List<ObjetivoFinanceiro>{
    new ObjetivoFinanceiro("Viagem a Orlando", 25000),
    new ObjetivoFinanceiroComPrazo(new DateTime(2023, 10, 1), "Viagem a Orlando com Prazo", 25000)
};

foreach (var objetivo in objetivos) {
    objetivo.ImprimirResumo();
}

ExibirMenu();

var opcao = Console.ReadLine();

while (opcao != "0")
{
    switch (opcao)
    {
        case "1":
            CadastrarObjetivo();
            break;
        case "2":
            // deposito
            RealizarOperacao(TipoOperacao.Deposito);
            break;
        case "3":
            // saque
            RealizarOperacao(TipoOperacao.Saque);
            break;
        case "4":
            // detalhes
            ObterDetalhes();
            break;
        default:
            // opcao invalida
            Console.WriteLine("Opção inválida");
            break;
    }
    ExibirMenu();

    opcao = Console.ReadLine();

}

void CadastrarObjetivo() {
    Console.WriteLine("Digite um Título.");
    var titulo = Console.ReadLine();

    Console.WriteLine("Digite um valor de objetivo.");
    var valorLido = Console.ReadLine();
    var valor = decimal.Parse(valorLido);

    var objetivo = new ObjetivoFinanceiro(titulo, valor);

    objetivos.Add(objetivo);
    Console.WriteLine($"Objetivo ID: {objetivo.Id} foi criado com sucesso"); 
}

void RealizarOperacao(TipoOperacao tipo) {
    Console.WriteLine("Digite o ID do objetivo");
    var id = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor da operação:");
    var valorLido = Console.ReadLine();
    var valor = decimal.Parse(valorLido);

    var operacao = new Operacao(valor, tipo, id);

    var objetivo = objetivos.SingleOrDefault(o => o.Id == id);

    objetivo.Operacoes.Add(operacao);
}

void ObterDetalhes() {
    Console.WriteLine("Digite o ID do objetivo");
    var id = int.Parse(Console.ReadLine());

    var objetivo = objetivos.SingleOrDefault(o => o.Id == id);

    objetivo.ImprimirResumo();
}

void ExibirMenu()
{
    Console.WriteLine("Digite 1 para Cadastro de objetivo");
    Console.WriteLine("Digite 2 para Realizar um Depósito");
    Console.WriteLine("Digite 3 para Saque");
    Console.WriteLine("Digite 4 para Exibir Detalhes de um objetivo");
    Console.WriteLine("Digite 0 para encerrar");
}

public enum TipoOperacao
{
    Saque = 0,
    Deposito = 1
}

public class Operacao
{
    public Operacao(decimal valor, TipoOperacao tipo, int idObjetivo)
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
public class ObjetivoFinanceiro
{
    public ObjetivoFinanceiro(string titulo, decimal? valorObjetivo)
    {
        Id = new Random().Next(0, 1000);
        Titulo = titulo;
        ValorObjetivo = valorObjetivo;
        Operacoes = new List<Operacao>(); 
    }

    public int Id { get; private set; }
    public string? Titulo { get; private set; }
    public decimal? ValorObjetivo { get; private set; }
    public List<Operacao> Operacoes { get; private set; }
    public decimal Saldo => ObterSaldo();

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

public class ObjetivoFinanceiroComPrazo : ObjetivoFinanceiro
{
    public ObjetivoFinanceiroComPrazo(DateTime prazo, string? titulo, decimal? valorObjetivo) : base(titulo, valorObjetivo) {
        Prazo = prazo;
    }
    
    public DateTime Prazo { get; private set; }

    public override void ImprimirResumo()
    {
        base.ImprimirResumo();
        var diasRestantes = (Prazo - DateTime.Now.Date).TotalDays;
        var valorRestante = ValorObjetivo - Saldo;

        Console.WriteLine($"Faltam {diasRestantes} para o prazo do seu objetivo, e faltam R${valorRestante} para completar.");
    }
}