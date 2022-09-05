using System.Text.RegularExpressions;

namespace LetsCode_WebIII.Utils
{
    public static class ValidaCpf
    {
        public static bool IsCpfValid(string cpf)
        {
            Regex RgxCpf = new(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$");
            if (!RgxCpf.Match(cpf).Success)
            {
                return false;
            }
            return true;
        }
    }
}
