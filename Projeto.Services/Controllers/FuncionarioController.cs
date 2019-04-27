using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Services.Models.Request;
using Projeto.Services.Models.Response;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [HttpPost("cadastrar")] //requisição do tipo POST //URL:api/[controller]/cadastrar
        public ActionResult Cadastrar(FuncionarioCadastroRequest request)
        {
            //var response = new FuncionarioCadastroResponse();

            if (ModelState.IsValid)
            {
                return new ContentResult
                {
                    Content = $"Funcionário {request.Nome} | Cadastrado com sucesso !",
                    ContentType = "text/plain",
                    StatusCode = 200
                };
            }
            else
            {
                return new ContentResult
                {
                    Content = "Ocorreram erros de validação.",
                    ContentType = "text/plain",
                    StatusCode = 400
                };
            }
        }
    }
}