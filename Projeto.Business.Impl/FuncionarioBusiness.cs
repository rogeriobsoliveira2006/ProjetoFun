using Projeto.Business.Contracts;
using Projeto.Entities;
using Projeto.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Business.Impl
{
    public class FuncionarioBusiness : BaseBusiness<Funcionario>, IFuncionarioBusiness
    {
        private IFuncionarioRepository repository;

        public FuncionarioBusiness(IFuncionarioRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public List<Funcionario> ConsultarPorNome(string nome)
        {
            return repository.FindByNome(nome);
        }
    }
}
