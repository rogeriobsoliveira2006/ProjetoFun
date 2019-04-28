using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Projeto.Business.Contracts;
using Projeto.Entities;
using Projeto.Services.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioBusiness business;
        private List<string> erros;

        public FuncionarioController(IFuncionarioBusiness business)
        {
            this.business = business;
        }

        [HttpPost("cadastrar")] //requisição do tipo POST //URL:api/[controller]/cadastrar
        public ActionResult Cadastrar(FuncionarioCadastroRequest request)
        {
            //var response = new FuncionarioCadastroResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario f = new Funcionario();
                    f.AddNome(request.Nome);
                    f.AddSalario(Convert.ToDecimal(request.Salario));
                    f.AddDataAdmissao(Convert.ToDateTime(request.DataAdmissao));

                    business.Cadastrar(f);

                    return new ContentResult
                    {
                        Content = $"Funcionário {request.Nome} | Cadastrado com sucesso !",
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
        public ActionResult Atualizar(FuncionarioEdicaoRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario f = new Funcionario();
                    f.FuncionarioId = Convert.ToInt32(request.FuncionarioId);
                    f.AddNome(request.Nome);
                    f.AddSalario(Convert.ToDecimal(request.Salario));
                    f.AddDataAdmissao(Convert.ToDateTime(request.DataAdmissao));

                    business.Atualizar(f);

                    return new ContentResult
                    {
                        Content = $"Funcionário {request.Nome} | Atualizado com sucesso !",
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
            Funcionario f = business.ConsultarPorId(id);

            if (f != null)
            {
                try
                {
                    business.Excluir(f);

                    return new ContentResult
                    {
                        Content = $"Funcionário {f.Nome} | Excluido com sucesso !",
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
                    Content = "Funcionário não Encontrado !",
                    ContentType = "text/plain",
                    StatusCode = 400
                };
            }
        }

        [HttpGet("consultartodos")] //requisição do tipo GET //URL:api/[controller]/consultar
        public ActionResult<List<Funcionario>> ConsultarTodos()
        {
            List<Funcionario> lista = new List<Funcionario>();

            try
            {
                foreach (Funcionario f in business.ConsultarTodos())
                {
                    Funcionario fun = new Funcionario();

                    fun.FuncionarioId = f.FuncionarioId;
                    fun.AddNome(f.Nome);
                    fun.AddSalario(f.Salario);
                    fun.AddDataAdmissao(f.DataAdmissao);

                    lista.Add(fun);
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
        public ActionResult<Funcionario> ConsultarPorId(int id)
        {
            Funcionario f = business.ConsultarPorId(id);

            if (f != null)
            {
                try
                {
                    return f;
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
                    Content = "Funcionário não Encontrado !",
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