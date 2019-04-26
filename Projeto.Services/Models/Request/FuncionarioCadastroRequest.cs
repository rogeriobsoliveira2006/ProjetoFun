using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Request
{
    public class FuncionarioCadastroRequest
    {
        [Required(ErrorMessage = "POR FAVOR, INFORME O NOME DO FUNCIONARIO !")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "POR FAVOR, INFORME O SALARIO DO FUNCIONARIO !")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "POR FAVOR, INFORME A DATA DE ADMISSÃO DO FUNCIONARIO !")]
        public DateTime DataAdmissao { get; set; }
    }
}
