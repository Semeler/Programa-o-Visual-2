namespace WebApplication1.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class Produto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }
    
    [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior ou igual a 0")]
    public decimal Preco { get; set; }
    
    public DateTime DataCriacao { get; set; }
    public string Categoria { get; set; }
    public bool Ativo { get; set; }
    public List<string> Tags { get; set; } = new List<string>();
    
    public int DiasNoSistema => (DateTime.Now - DataCriacao).Days;
}