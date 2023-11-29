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

    public void GerarRelatorio1(int idadeMinima, int idadeMaxima)
    {
        Console.WriteLine("Médicos com idade entre {0} e {1}", idadeMinima, idadeMaxima);
        foreach (var medico in medicos.Where(m => m.DataNascimento.Year - m.DataNascimento.Month * 12 - m.DataNascimento.Day >= idadeMinima &&
                                                m.DataNascimento.Year - m.DataNascimento.Month * 12 - m.DataNascimento.Day <= idadeMaxima))
        {
            Console.WriteLine(medico.Nome);
        }
    }

    public void GerarRelatorio2(int idadeMinima, int idadeMaxima)
    {
        Console.WriteLine("Pacientes com idade entre {0} e {1}", idadeMinima, idadeMaxima);
        foreach (var paciente in pacientes.Where(p => p.DataNascimento.Year - p.DataNascimento.Month * 12 - p.DataNascimento.Day >= idadeMinima &&
                                                p.DataNascimento.Year - p.DataNascimento.Month * 12 - p.DataNascimento.Day <= idadeMaxima))
        {
            Console.WriteLine(paciente.Nome);
        }
    }

    public void GerarRelatorio3(string sexo)
