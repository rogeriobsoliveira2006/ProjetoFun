using Projeto.Entities;
using Projeto.Repository.Contracts;
using Projeto.Repository.Impl.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Repository.Impl.Persistence
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public List<Funcionario> FindByNome(string nome)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Funcionario.Where(f => f.Nome.Contains(nome))
                        .OrderBy(f => f.Nome)
                        .ToList();
            }
        }
    }
}
