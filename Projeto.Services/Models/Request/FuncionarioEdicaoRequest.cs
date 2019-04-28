using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Models.Request
{
    public class FuncionarioEdicaoRequest
    {
        [Required(ErrorMessage = "POR FAVOR, INFORME O ID DO FUNCIONARIO !")]
        public string FuncionarioId { get; set; }

        [Required(ErrorMessage = "POR FAVOR, INFORME O NOME DO FUNCIONARIO !")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "POR FAVOR, INFORME O SALARIO DO FUNCIONARIO !")]
        public string Salario { get; set; }

        [Required(ErrorMessage = "POR FAVOR, INFORME A DATA DE ADMISSÃO DO FUNCIONARIO !")]
        public string DataAdmissao { get; set; }
    }
}
