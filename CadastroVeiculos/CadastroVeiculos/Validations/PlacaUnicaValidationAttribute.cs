namespace CadastroVeiculos.Validations
{
    using System.ComponentModel.DataAnnotations;

    public class PlacaUnicaAttribute : ValidationAttribute
    {
        private static readonly HashSet<string> PlacasRegistradas = new();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            string placa = value.ToString();

            if (PlacasRegistradas.Contains(placa))
            {
                return new ValidationResult("Esta placa já está registrada no sistema.");
            }

            PlacasRegistradas.Add(placa);
            return ValidationResult.Success;
        }
    }
}


