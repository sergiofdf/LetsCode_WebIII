using System.ComponentModel.DataAnnotations;

namespace LetsCode_WebIII.Utils
{
    public class CustomValidationData : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dataConvertida;
            bool conversaoValida = DateTime.TryParse(value.ToString(), out dataConvertida);
            if (!conversaoValida || dataConvertida == DateTime.MinValue)
            {
                return false;
            }
            return true;
        }
    }
}
