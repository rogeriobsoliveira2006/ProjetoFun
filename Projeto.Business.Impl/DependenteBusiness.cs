using Projeto.Business.Contracts;
using Projeto.Entities;
using Projeto.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Business.Impl
{
    public class DependenteBusiness : BaseBusiness<Dependente>, IDependenteBusiness
    {
        private IDependenteRepository repository;

        public DependenteBusiness(IDependenteRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override void Cadastrar(Dependente obj)
        {
            DateTime hoje = DateTime.Now;
            int idade = hoje.Year - obj.DataNascimento.Year;

            //calculando a idade..
            if (obj.DataNascimento > hoje.AddYears(-idade)) idade--;

            if (idade < 18)
            {
                repository.Insert(obj);
            }
            else
            {
                throw new Exception("DEPENDENTE NÃO PODE SER MAIOR DE IDADE !");
            }
        }
    }
}
