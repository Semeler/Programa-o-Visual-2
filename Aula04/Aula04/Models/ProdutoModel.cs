namespace Aula04.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public List<string> Tags { get; set; } = new();

        public int DiasNoSistema => (int)(DateTime.Now - DataCriacao).TotalDays;
    }
}