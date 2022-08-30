using System.ComponentModel.DataAnnotations;

namespace LetsCode_WebIII.Utils
{
    public class CustomValidationCpf : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;
            return ValidaCpf.IsCpfValid(value.ToString());
        }
    }
}
