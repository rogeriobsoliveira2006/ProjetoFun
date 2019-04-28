using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Dependente
{
    public class DependenteEdicaoRequest
    {
        [Required(ErrorMessage = "POR FAVOR, INFORME O ID DO DEPENDENTE !")]
        public string DependenteId { get; set; }

        [Required(ErrorMessage = "POR FAVOR, INFORME O NOME DO DEPENDENTE !")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "POR FAVOR, INFORME A DATA DE NASCIMENTO DO DEPENDENTE!")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "POR FAVOR, INFORME O FUNCIONARIO !")]
        public string FuncionarioId { get; set; }
    }
}
