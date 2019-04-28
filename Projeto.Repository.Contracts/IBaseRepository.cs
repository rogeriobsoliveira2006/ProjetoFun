﻿using System;
using System.Collections.Generic;

namespace Projeto.Repository.Contracts
{
    public interface IBaseRepository<T>
        where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> FindAll();
        T FindById(int id);
    }
}
