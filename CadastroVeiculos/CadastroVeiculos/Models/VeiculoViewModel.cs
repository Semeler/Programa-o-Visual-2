
namespace CadastroVeiculos.Models
{
    
    using CadastroVeiculos.Validations;
using System.ComponentModel.DataAnnotations;

public class VeiculoViewModel
{
    [Required(ErrorMessage = "A Placa é obrigatória")]
    [RegularExpression(@"^[A-Z]{3}[0-9][A-Z][0-9]{2}$", 
        ErrorMessage = "A Placa deve estar no padrão Mercosul (ABC1D23)")]
    [PlacaUnica]
    public string Placa { get; set; }

    [Required(ErrorMessage = "O Renavam é obrigatório")]
    [RegularExpression(@"^\d{11}$", 
        ErrorMessage = "O Renavam deve conter exatamente 11 dígitos")]
    [RenavamValido]
    public string Renavam { get; set; }

    [Required(ErrorMessage = "O Chassi é obrigatório")]
    [RegularExpression(@"^[A-HJ-NP-Z0-9]{17}$", 
        ErrorMessage = "O Chassi deve conter 17 caracteres alfanuméricos e não pode conter as letras I, O ou Q")]
    public string Chassi { get; set; }

    [Required(ErrorMessage = "O Ano de Fabricação é obrigatório")]
    [Range(1980, 2025, ErrorMessage = "O Ano de Fabricação deve estar entre 1980 e o ano atual")]
    public int AnoFabricacao { get; set; }

    [Required(ErrorMessage = "O Ano do Modelo é obrigatório")]
    [AnoModeloValidacao]
    public int AnoModelo { get; set; }

    [Required(ErrorMessage = "O Tipo de Combustível é obrigatório")]
    public TipoCombustivel TipoCombustivel { get; set; }

    [RequiredIf("AnoModelo", 2010, ErrorMessage = "O Valor do Seguro é obrigatório para veículos após 2010")]
    [Range(500, double.MaxValue, ErrorMessage = "O Valor do Seguro deve ser no mínimo R$ 500,00")]
    public decimal? ValorSeguro { get; set; }

    [Required(ErrorMessage = "O Nome do Proprietário é obrigatório")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O Nome do Proprietário deve ter entre 6 e 100 caracteres")]
    [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]*$", 
        ErrorMessage = "O Nome do Proprietário deve conter apenas letras e espaços")]
    public string NomeProprietario { get; set; }
}

public enum TipoCombustivel
{
    Gasolina,
    Diesel,
    Etanol,
    Flex,
    Eletrico,
    GNV
}
}
