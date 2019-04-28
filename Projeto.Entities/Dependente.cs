using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Entities
{
    public class Dependente
    {
        public int DependenteId { get; set; }

        [MaxLength(50)]
        public string Nome { get; private set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; private set; }

        public int FuncionarioId { get; set; }
        //TER-Um
        public Funcionario Funcionario { get; set; }

        public Dependente()
        {
            //Vazio...
        }

        public Dependente(int dependenteId, string nome, DateTime dataNascimento)
        {
            DependenteId = dependenteId;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public void AddNome(string nome)
        {
            Nome = nome;
        }

        public void AddDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return $"ID: {DependenteId} | Nome: {Nome} | Data de Nascimento: {DataNascimento} .";
        }
    }
}
