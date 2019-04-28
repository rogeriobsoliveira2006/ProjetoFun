using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Repository.Contracts
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        List<Funcionario> FindByNome(string nome);
    }
}
