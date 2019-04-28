﻿using Microsoft.EntityFrameworkCore;
using Projeto.Entities;
using Projeto.Repository.Contracts;
using Projeto.Repository.Impl.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Repository.Impl.Persistence
{
    public class DependenteRepository : BaseRepository<Dependente>, IDependenteRepository
    {
        public override List<Dependente> FindAll()
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Dependente.Include(d => d.Funcionario) //JOIN..
                        .ToList();
            }
        }

        public override Dependente FindById(int id)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Dependente.Include(d => d.Funcionario)
                        .FirstOrDefault(d => d.DependenteId == id);
            }
        }
    }
}
