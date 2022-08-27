namespace LetsCode_WebIII
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }

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
