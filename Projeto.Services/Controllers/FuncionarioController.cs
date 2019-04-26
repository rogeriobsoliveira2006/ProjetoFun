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
        public HttpResponseMessage Cadastrar(FuncionarioCadastroRequest request)
        {
            var response = new FuncionarioCadastroResponse();

            if (ModelState.IsValid)
            {
                response.Mensagem = $"Funcionário {request.Nome} | Cadastrado com sucesso !";
                
                //retornar STATUS de erro (HTTP 200)
                return CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                response.Mensagem = "Ocorreram erros de validação.";
                
                //retornar STATUS de erro (HTTP 400)
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);

            }
        }
    }
}