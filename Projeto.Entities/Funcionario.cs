using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; private set; }
        public decimal Salario { get; private set; }
        public DateTime DataAdmissao { get; private set; }

        //TER-Muitos
        public List<Dependente> Dependentes { get; set; }

        public Funcionario()
        {
            //Vazio...
        }

        public Funcionario(int funcionarioId, string nome, decimal salario, DateTime dataAdmissao)
        {
            FuncionarioId = funcionarioId;
            Nome = nome;
            Salario = salario;
            DataAdmissao = dataAdmissao;
        }

        public void AddNome(string nome)
        {
            Nome = nome;
        }

        public void AddSalario(decimal salario)
        {
            Salario = salario;
        }

        public void AddDataAdmissao(DateTime dataAdmissao)
        {
            DataAdmissao = dataAdmissao;
        }

        public override string ToString()
        {
            return $"ID: {FuncionarioId} | Nome: {Nome} | Salário: {Salario} | Data de Admissão: {DataAdmissao} .";
        }
    }
}
