
using System.ComponentModel.DataAnnotations;

namespace Lab2.Validation
{
    public class CustomerValidation : ValidationAttribute
    {
        public CustomerValidation() { ErrorMessage = " The year of birth cannot greater than current year"; }


        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            int number = Int32.Parse(value.ToString());
            return number < 2023;
        }

    }
}
