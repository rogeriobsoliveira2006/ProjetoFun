using System;

namespace Projeto.Entities
{
    public class Dependente
    {
        public int DependenteId { get; set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }

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

        public void AddDaTaNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return $"ID: {DependenteId} | Nome: {Nome} | Data de Nascimento: {DataNascimento} .";
        }
    }
}
