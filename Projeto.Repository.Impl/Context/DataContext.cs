using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entities;

namespace Projeto.Repository.Impl.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=CoreDB;User Id=sa;Password=admin123!@#;");
        }

        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
