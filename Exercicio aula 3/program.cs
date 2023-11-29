using System;

//1

class Veiculo
{
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }

    public Veiculo(string modelo, int ano, string cor)
    {
        Modelo = modelo;
        Ano = ano;
        Cor = cor;
    }
}

class Program
{
    static void Main()
    {
        // Criando uma instância de Veiculo
        Veiculo meuCarro = new Veiculo("Toyota", 2023, "Azul");

        // Exibindo informações no console
        Console.WriteLine($"Modelo: {meuCarro.Modelo}");
        Console.WriteLine($"Ano: {meuCarro.Ano}");
        Console.WriteLine($"Cor: {meuCarro.Cor}");
    }
}

// 2

class Veiculo
{
    // ... outras propriedades ...

    public int IdadeVeiculo
    {
        get
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - Ano;
        }
    }

    // ... construtor e outras partes da classe ...
}

//3

using System;

class ContaBancaria
{
    private decimal _saldo;

    public decimal Saldo
    {
        get => _saldo;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Saldo não pode ser negativo");
            }
            _saldo = value;
        }
    }
}

// Exemplo de uso:
class Program
{
    static void Main()
    {
        ContaBancaria minhaConta = new ContaBancaria();
        minhaConta.Saldo = 1000; // Define o saldo
        Console.WriteLine($"Saldo: {minhaConta.Saldo}");
    }
}

//4

class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Aluno()
    {
        // Valores padrão
        Nome = "Sem Nome";
        Idade = 0;
    }
}

// Exemplo de uso:
class Program
{
    static void Main()
    {
        Aluno novoAluno = new Aluno();
        Console.WriteLine($"Nome: {novoAluno.Nome}");
        Console.WriteLine($"Idade: {novoAluno.Idade}");
    }
}

//5

class Agenda
{
    private string[] _contatos = new string[10]; // Tamanho arbitrário

    public string this[int indice]
    {
        get => _contatos[indice];
        set => _contatos[indice] = value;
    }
}

// Exemplo de uso:
class Program
{
    static void Main()
    {
        Agenda minhaAgenda = new Agenda();
        minhaAgenda[0] = "João";
        minhaAgenda[1] = "Maria";

        Console.WriteLine($"Contato 1: {minhaAgenda[0]}");
        Console.WriteLine($"Contato 2: {minhaAgenda[1]}");
    }
}

//6

