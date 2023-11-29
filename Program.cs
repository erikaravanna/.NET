﻿using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        // Exemplo de utilização das classes
        Medico medico = new Medico("Dr. Silva", new DateTime(1980, 5, 15), "12345678901", "CRM12345");
        Paciente paciente = new Paciente("Maria", new DateTime(1990, 8, 22), "98765432109", Sexo.Feminino, "Dor de cabeça");

        // Adicionando pacientes ao médico
        medico.AdicionarPaciente(paciente);

        // Exibindo relatório de pacientes do médico
        medico.GerarRelatorioPacientes();

        // Outros exemplos de operações...
    }
}

// Enum para representar o sexo do paciente
public enum Sexo
{
    Masculino,
    Feminino
}

// Classe base para pessoa
public abstract class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    public Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
    }
}

// Classe Médico herda de Pessoa
public class Medico : Pessoa
{
    public string CRM { get; set; }
    private List<Paciente> pacientes;

    public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
        : base(nome, dataNascimento, cpf)
    {
        CRM = crm;
        pacientes = new List<Paciente>();
    }

    public void AdicionarPaciente(Paciente paciente)
    {
        pacientes.Add(paciente);
    }

    public void GerarRelatorioPacientes()
    {
        Console.WriteLine($"Relatório de Pacientes do Dr. {Nome} (CRM: {CRM}):");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine($"- Nome: {paciente.Nome}, CPF: {paciente.CPF}");
        }
    }
}

// Classe Paciente herda de Pessoa
public class Paciente : Pessoa
{
    public Sexo Sexo { get; set; }
    public string Sintomas { get; set; }

    public Paciente(string nome, DateTime dataNascimento, string cpf, Sexo sexo, string sintomas)
        : base(nome, dataNascimento, cpf)
    {
        Sexo = sexo;
        Sintomas = sintomas;
    }
}
