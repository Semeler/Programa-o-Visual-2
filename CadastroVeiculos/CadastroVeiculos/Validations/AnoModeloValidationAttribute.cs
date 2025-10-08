

namespace CadastroVeiculos.Validations
{
    using System.ComponentModel.DataAnnotations;
    using CadastroVeiculos.Models;

    public class AnoModeloValidacaoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var anoModelo = (int)value;
            var veiculo = (VeiculoViewModel)validationContext.ObjectInstance;
            var anoAtual = DateTime.Now.Year;

            if (anoModelo < veiculo.AnoFabricacao)
            {
                return new ValidationResult("O Ano do Modelo não pode ser menor que o Ano de Fabricação");
            }

            if (anoModelo > anoAtual + 1)
            {
                return new ValidationResult($"O Ano do Modelo não pode ser maior que {anoAtual + 1}");
            }

            return ValidationResult.Success;
        }
    }
}

