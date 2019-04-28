﻿using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Business.Contracts
{
    public interface IFuncionarioBusiness : IBaseBusiness<Funcionario>
    {
        List<Funcionario> ConsultarPorNome(string nome);
    }
}
