using LetsCode_WebIII.Utils;
using System.ComponentModel.DataAnnotations;

namespace LetsCode_WebIII.Core.Models
{
    public class Cliente
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Cpf é obrigatório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe uma data.")]
        [CustomValidationData(ErrorMessage = "Informe uma data válida.")]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; private set; }
        public string Permissao { get; set; }

        public Cliente(long id, string cpf, string nome, DateTime dataNascimento, int idade, string permissao)
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = idade;
            Permissao = permissao;
        }
        public Cliente(string cpf, string nome, DateTime dataNascimento, int idade = 0)
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
