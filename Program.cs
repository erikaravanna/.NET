public class Pessoa
{
    protected string nome;
    protected DateTime dataNascimento;
    protected string cpf;

    public Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        this.nome = nome;
        this.dataNascimento = dataNascimento;
        this.cpf = cpf;
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public DateTime DataNascimento
    {
        get { return dataNascimento; }
        set { dataNascimento = value; }
    }

    public string Cpf
    {
        get { return cpf; }
        set { cpf = value; }
    }
}

public class Medico : Pessoa
{
    protected string crm;

    public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
        : base(nome, dataNascimento, cpf)
    {
        this.crm = crm;
    }

    public string Crm
    {
        get { return crm; }
        set { crm = value; }
    }
}

public class Paciente : Pessoa
{
    protected string sexo;
    protected string sintomas;

    public Paciente(string nome, DateTime dataNascimento, string cpf, string sexo, string sintomas)
        : base(nome, dataNascimento, cpf)
    {
        this.sexo = sexo;
        this.sintomas = sintomas;
    }

    public string Sexo
    {
        get { return sexo; }
        set { sexo = value; }
    }

    public string Sintomas
    {
        get { return sintomas; }
        set { sintomas = value; }
    }
}

// Requisitos

public class ConsultorioMedico
{
    private List<Medico> medicos = new List<Medico>();
    private List<Paciente> pacientes = new List<Paciente>();

    public ConsultorioMedico()
    {
    }

    public void AdicionarMedico(Medico medico)
    {
        if (!medicos.Any(m => m.Cpf == medico.Cpf))
        {
            medicos.Add(medico);
        }
    }

    public void AdicionarPaciente(Paciente paciente)
    {
        if (!pacientes.Any(p => p.Cpf == paciente.Cpf))
        {
            pacientes.Add(paciente);
        }
    }
}
public class Consultas
{
    public static IEnumerable<Medico> FiltrarMedicosPorIdade(int idadeMinima, int idadeMaxima)
    {
        return from medico in medicos
                where medico.DataNascimento.Year - medico.DataNascimento.Month * 12 - medico.DataNascimento.Day >= idadeMinima
                && medico.DataNascimento.Year - medico.DataNascimento.Month * 12 - medico.DataNascimento.Day <= idadeMaxima
                select medico;
    }

    public static IEnumerable<Paciente> FiltrarPacientesPorIdade(int idadeMinima, int idadeMaxima)
    {
        return from paciente in pacientes
                where paciente.DataNascimento.Year - paciente.DataNascimento.Month * 12 - paciente.DataNascimento.Day >= idadeMinima
                && paciente.DataNascimento.Year - paciente.DataNascimento.Month * 12 - paciente.DataNascimento.Day <= idadeMaxima
                select paciente;
    }

    public static IEnumerable<Paciente> FiltrarPacientesPorSexo(string sexo)
    {
        return from paciente in pacientes
                where paciente.Sexo == sexo
                select paciente;
    }

    public static IEnumerable<Paciente> OrdenarPacientesPorNome()
    {
        return from paciente in pacientes
        orderby paciente.Nome
        select paciente;
    }

    public static IEnumerable<Paciente> FiltrarPacientesPorSintomas(string sintomas)
    {
        return from paciente in pacientes
                where paciente.Sintomas.Contains(sintomas)
                select paciente;
    }

    public static IEnumerable<Pessoa> FiltrarAniversariantes(int mes)
    {
        return from pessoa in medicos.Concat(pacientes)
                where pessoa.DataNascimento.Month == mes
                select pessoa;
    }
}

var medicos = Consultas.FiltrarMedicosPorIdade(25, 35);

foreach (var medico in medicos)
{
    Console.WriteLine(medico.Nome);
}

var pacientes = Consultas.FiltrarPacientesPorIdade(18, 25);

foreach (var paciente in pacientes)
{
    Console.WriteLine(paciente.Nome);
}

var pacientes = Consultas.FiltrarPacientesPorSexo(Console.ReadLine());

foreach (var paciente in pacientes)
{
    Console.WriteLine(paciente.Nome);
}

var pacientes = Consultas.OrdenarPacientesPorNome();

foreach (var paciente in pacientes)
{
    Console.WriteLine(paciente.Nome);
}

var sintomas = Console.ReadLine();

var pacientes = Consultas.FiltrarPacientesPorSintomas(sintomas);

foreach (var paciente in pacientes)
{
    Console.WriteLine(paciente.Nome);
}