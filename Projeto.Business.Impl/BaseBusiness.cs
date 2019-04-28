using Projeto.Business.Contracts;
using Projeto.Repository.Contracts;
using System;
using System.Collections.Generic;

namespace Projeto.Business.Impl
{
    public abstract class BaseBusiness<T> : IBaseBusiness<T>
        where T : class
    {
        private IBaseRepository<T> repository;

        protected BaseBusiness(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Cadastrar(T obj)
        {
            repository.Insert(obj);
        }

        public virtual void Atualizar(T obj)
        {
            repository.Update(obj);
        }

        public virtual void Excluir(T obj)
        {
            repository.Delete(obj);
        }

        public virtual T ConsultarPorId(int id)
        {
            return repository.FindById(id);
        }

        public virtual List<T> ConsultarTodos()
        {
            return repository.FindAll();
        }
        
    }
}
