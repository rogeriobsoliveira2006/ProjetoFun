using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Projeto.Business.Contracts;
using Projeto.Entities;
using Projeto.Services.Models.Dependente;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenteController : ControllerBase
    {
        private IDependenteBusiness business;
        private List<string> erros;

        public DependenteController(IDependenteBusiness business)
        {
            this.business = business;
        }

        [HttpPost("cadastrar")] //requisição do tipo POST //URL:api/[controller]/cadastrar
        public ActionResult Cadastrar(DependenteCadastroRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Dependente d = new Dependente();
                    d.AddNome(request.Nome);
                    d.AddDataNascimento(Convert.ToDateTime(request.DataNascimento));
                    d.FuncionarioId = Convert.ToInt32(request.FuncionarioId);
                    

                    business.Cadastrar(d);

                    return new ContentResult
                    {
                        Content = $"Dependente {d.Nome} | Cadastrado com sucesso !",
                        ContentType = "text/plain",
                        StatusCode = 200
                    };
                }
                catch (Exception e)
                {
                    return new ContentResult
                    {
                        Content = e.Message,
                        ContentType = "text/plain",
                        StatusCode = 400
                    };
                }

            }
            else
            {
                erros = ObterMensagensDeValidacao(ModelState);

                return new ContentResult
                {
                    Content = string.Join(",", erros),
                    ContentType = "text/plain",
                    StatusCode = 400
                };
            }
        }

        [HttpPut("atualizar")] //requisição do tipo PUT //URL:api/[controller]/atualizar
        public ActionResult Atualizar(DependenteEdicaoRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Dependente d = new Dependente();
                    d.DependenteId = Convert.ToInt32(request.DependenteId);
                    d.AddNome(request.Nome);
                    d.AddDataNascimento(Convert.ToDateTime(request.DataNascimento));
                    d.FuncionarioId = Convert.ToInt32(request.FuncionarioId);

                    business.Atualizar(d);

                    return new ContentResult
                    {
                        Content = $"Dependente {d.Nome} | Atualizado com sucesso !",
                        ContentType = "text/plain",
                        StatusCode = 200
                    };
                }
                catch (Exception e)
                {
                    return new ContentResult
                    {
                        Content = e.Message,
                        ContentType = "text/plain",
                        StatusCode = 400
                    };
                }
            }
            else
            {
                erros = ObterMensagensDeValidacao(ModelState);

                return new ContentResult
                {
                    Content = string.Join(",", erros),
                    ContentType = "text/plain",
                    StatusCode = 400
                };
            }
        }

        [HttpDelete("excluir")] //requisição do tipo DELETE //URL:api/[controller]/excluir
        public ActionResult Excluir(int id)
        {
            Dependente d = business.ConsultarPorId(id);

            if (d != null)
            {
                try
                {
                    business.Excluir(d);

                    return new ContentResult
                    {
                        Content = $"Dependente {d.Nome} | Excluido com sucesso !",
                        ContentType = "text/plain",
                        StatusCode = 200
                    };
                }
                catch (Exception e)
                {
                    return new ContentResult
                    {
                        Content = e.Message,
                        ContentType = "text/plain",
                        StatusCode = 400
                    };
                }
            }
            else
            {
                return new ContentResult
                {
                    Content = "Dependente não Encontrado !",
                    ContentType = "text/plain",
                    StatusCode = 400
                };
            }
        }

        [HttpGet("consultartodos")] //requisição do tipo GET //URL:api/[controller]/consultar
        public ActionResult<List<Dependente>> ConsultarTodos()
        {
            List<Dependente> lista = new List<Dependente>();

            try
            {
                foreach (Dependente d in business.ConsultarTodos())
                {
                    Dependente dep = new Dependente();
                    dep.Funcionario = new Funcionario();

                    dep.DependenteId = d.DependenteId;
                    dep.AddNome(d.Nome);
                    dep.AddDataNascimento(d.DataNascimento);
                    dep.FuncionarioId = d.FuncionarioId;

                    dep.Funcionario.FuncionarioId = d.Funcionario.FuncionarioId;
                    dep.Funcionario.AddNome(d.Funcionario.Nome);
                    dep.Funcionario.AddSalario(Convert.ToDecimal(d.Funcionario.Salario));
                    dep.Funcionario.AddDataAdmissao(Convert.ToDateTime(d.Funcionario.DataAdmissao));

                    lista.Add(dep);
                }

                return lista;
            }
            catch (Exception e)
            {
                return new ContentResult
                {
                    Content = e.Message,
                    ContentType = "text/plain",
                    StatusCode = 400
                };
            }
        }

        [HttpGet("consultarporid")] //requisição do tipo GET //URL:api/[controller]/consultarporid
        public ActionResult<Dependente> ConsultarPorId(int id)
        {
            Dependente d = business.ConsultarPorId(id);

            if (d != null)
            {
                try
                {
                    return d;
                }
                catch (Exception e)
                {
                    return new ContentResult
                    {
                        Content = e.Message,
                        ContentType = "text/plain",
                        StatusCode = 400
                    };
                }
            }
            else
            {
                return new ContentResult
                {
                    Content = "Dependente não Encontrado !",
                    ContentType = "text/plain",
                    StatusCode = 400
                };
            }
        }

        private List<string> ObterMensagensDeValidacao(ModelStateDictionary model)
        {
            List<string> erros = new List<string>();

            foreach (var m in model)
            {
                if (m.Value.Errors.Count > 0)
                {
                    erros.Add(m.Value.Errors.Select(s => s.ErrorMessage).FirstOrDefault());
                }
            }

            return erros;
        }
    }
}