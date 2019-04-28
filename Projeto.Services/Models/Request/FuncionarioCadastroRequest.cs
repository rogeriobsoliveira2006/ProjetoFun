using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Request
{
    public class FuncionarioCadastroRequest
    {
        [Required(ErrorMessage = "POR FAVOR, INFORME O NOME DO FUNCIONARIO !")]
        public string Nome { get; set; }

        
        [Required(ErrorMessage = "POR FAVOR, INFORME O SALARIO DO FUNCIONARIO !")]
        public string Salario { get; set; }

        [Required(ErrorMessage = "POR FAVOR, INFORME A DATA DE ADMISSÃO DO FUNCIONARIO !")]
        public string DataAdmissao { get; set; }
    }
}
