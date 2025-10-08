namespace CadastroVeiculos.Validations
{
    using System.ComponentModel.DataAnnotations;

    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _dependentProperty;
        private readonly object _targetValue;

        public RequiredIfAttribute(string dependentProperty, object targetValue)
        {
            _dependentProperty = dependentProperty;
            _targetValue = targetValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_dependentProperty);
            
            if (property == null)
                throw new ArgumentException("Propriedade dependente não encontrada");

            var dependentValue = property.GetValue(validationContext.ObjectInstance);
            
            if (dependentValue is int intValue && intValue > (int)_targetValue)
            {
                if (value == null)
                    return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}