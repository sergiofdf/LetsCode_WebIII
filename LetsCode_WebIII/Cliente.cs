using LetsCode_WebIII.Utils;
using System.ComponentModel.DataAnnotations;

namespace LetsCode_WebIII
{
    public class Cliente
    {
        [Required(ErrorMessage = "Cpf é obrigatório.")]
        [CustomValidationCpf(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; private set; }

        public Cliente(string cpf, string nome, DateTime dataNascimento)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = ObterIdade();
        }

        public int ObterIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
    }
}
