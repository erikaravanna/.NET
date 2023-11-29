using System;
using System.Collections.Generic;
using System.Linq;

namespace POGDevConsultorio
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string CPF { get; private set; }

        public Pessoa(string nome, DateTime dataNascimento, string cpf)
        {
            if (cpf.Length != 11)
            {
                throw new ArgumentException("O CPF deve ter 11 dígitos.");
            }

            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }

        public virtual void Apresentar()
        {
            Console.WriteLine($"Nome: {Nome}, Data de Nascimento: {DataNascimento.ToShortDateString()}, CPF: {CPF}");
        }
    }

    public enum Sexo
    {
        Masculino,
        Feminino
    }

    public class Paciente : Pessoa
    {
        public Sexo Sexo { get; private set; }
        public string Sintomas { get; private set; }

        public Paciente(string nome, DateTime dataNascimento, string cpf, Sexo sexo, string sintomas)
            : base(nome, dataNascimento, cpf)
        {
            Sexo = sexo;
            Sintomas = sintomas;
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Paciente - Sexo: {Sexo}, {base.Nome}, {base.DataNascimento.ToShortDateString()}, CPF: {base.CPF}, Sintomas: {Sintomas}");
        }
    }

    public class Medico : Pessoa
    {
        public string CRM { get; private set; }

        public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
            : base(nome, dataNascimento, cpf)
        {
            CRM = crm;
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Médico - CRM: {CRM}, {base.Nome}, {base.DataNascimento.ToShortDateString()}, CPF: {base.CPF}");
        }
    }

    public class Consultorio
    {
        private List<Medico> medicos;
        private List<Paciente> pacientes;

        public Consultorio()
        {
            medicos = new List<Medico>();
            pacientes = new List<Paciente>();
        }

        public void AdicionarMedico(Medico medico)
        {
            if (medicos.Any(m => m.CRM == medico.CRM))
            {
                throw new ArgumentException($"Médico com CRM {medico.CRM} já cadastrado.");
            }

            medicos.Add(medico);
        }

        public void AdicionarPaciente(Paciente paciente)
        {
            if (pacientes.Any(p => p.CPF == paciente.CPF))
            {
                throw new ArgumentException($"Paciente com CPF {paciente.CPF} já cadastrado.");
            }

            pacientes.Add(paciente);
        }

        public void GerarRelatorioPessoas()
        {
            Console.WriteLine("Relatório de Médicos:");
            medicos.ForEach(m => m.Apresentar());

            Console.WriteLine("\nRelatório de Pacientes:");
            pacientes.ForEach(p => p.Apresentar());
        }

        public IEnumerable<Medico> MedicosComIdadeEntre(int idadeMinima, int idadeMaxima)
        {
            return medicos.Where(m => CalculaIdade(m.DataNascimento) >= idadeMinima && CalculaIdade(m.DataNascimento) <= idadeMaxima);
        }

        public IEnumerable<Paciente> PacientesComIdadeEntre(int idadeMinima, int idadeMaxima)
        {
            return pacientes.Where(p => CalculaIdade(p.DataNascimento) >= idadeMinima && CalculaIdade(p.DataNascimento) <= idadeMaxima);
        }

        private int CalculaIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.Month < dataNascimento.Month || (DateTime.Now.Month == dataNascimento.Month && DateTime.Now.Day < dataNascimento.Day))
            {
                idade--;
            }
            return idade;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Consultorio consultorio = new Consultorio();

                Medico medico1 = new Medico("Dra. Erika", new DateTime(2000, 7, 7), "08527907510", "CRM54321");
                Medico medico2 = new Medico("Dr. Fernando", new DateTime(1999, 8, 10), "74927230597", "CRM76541");
                Medico medico3 = new Medico("Dra. Julia", new DateTime(1977, 5, 13), "98765436821", "CRM89123");
                Medico medico4 = new Medico("Dr. Luis", new DateTime(1978, 7, 4), "12514368791", "CRM78965");

                Paciente paciente1 = new Paciente("Lara", new DateTime(2010, 7, 8), "25725678321", Sexo.Feminino, "Cólica");
                Paciente paciente2 = new Paciente("Carlos", new DateTime(2000, 11, 15), "98764578976", Sexo.Masculino, "Dor de Cabeça");
                Paciente paciente3 = new Paciente("Raissa", new DateTime(2000, 3, 16), "08578936572", Sexo.Feminino, "Dor de Barriga");
                Paciente paciente4 = new Paciente("Lucas", new DateTime(1978, 8, 24), "22346789642", Sexo.Feminino, "Febre");

                consultorio.AdicionarMedico(medico1);
                consultorio.AdicionarMedico(medico2);
                consultorio.AdicionarMedico(medico3);
                consultorio.AdicionarMedico(medico4);

                consultorio.AdicionarPaciente(paciente1);
                consultorio.AdicionarPaciente(paciente2);
                consultorio.AdicionarPaciente(paciente3);
                consultorio.AdicionarPaciente(paciente4);

                // Relatórios
                Console.WriteLine("Médicos com idade entre 30 e 40 anos:");
                consultorio.MedicosComIdadeEntre(30, 40).ToList().ForEach(m => m.Apresentar());

                Console.WriteLine("\nPacientes com idade entre 20 e 30 anos:");
                consultorio.PacientesComIdadeEntre(20, 30).ToList().ForEach(p => p.Apresentar());

                // Adicione mais relatórios conforme necessário...

                consultorio.GerarRelatorioPessoas();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
