



namespace CadastroVeiculos.Validations
{
    using System.ComponentModel.DataAnnotations;

    public class RenavamValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            string renavam = value.ToString();

            if (renavam.Length != 11 || !renavam.All(char.IsDigit))
                return new ValidationResult("Renavam inválido");

            int[] multiplicadores = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += (renavam[i] - '0') * multiplicadores[i];
            }

            int dv = (soma * 10) % 11;
            dv = dv == 10 ? 0 : dv;

            if (dv != (renavam[10] - '0'))
            {
                return new ValidationResult("Dígito verificador do Renavam inválido");
            }

            return ValidationResult.Success;
        }
    }
}


