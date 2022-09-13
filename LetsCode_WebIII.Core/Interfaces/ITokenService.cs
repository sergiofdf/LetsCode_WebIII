namespace LetsCode_WebIII.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateTokenProdutos(string nome, string permissao);
        string GenerateTokenEventos(string nome, string permissao);
    }
}
