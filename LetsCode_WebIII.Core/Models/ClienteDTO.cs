using LetsCode_WebIII.Utils;
using System.ComponentModel.DataAnnotations;

namespace LetsCode_WebIII.Core.Models
{
    public class ClienteDTO
    {
        [Required(ErrorMessage = "Cpf é obrigatório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe uma data.")]
        [CustomValidationData(ErrorMessage = "Informe uma data válida.")]
        public DateTime DataNascimento { get; set; }
    }
}
