namespace WebApplication1.ViewModels;
public class ProdutoListagemItemViewModel
{
    public int Id { get; set; }  // Adicione esta propriedade
    public string Nome { get; set; }
    public string PrecoFormatado { get; set; }
    public string Categoria { get; set; }
    public string Status { get; set; }
    public string TagsExibicao { get; set; }
    public string Badge { get; set; }
}


public class ProdutoDetalhesViewModel
{
    public string NomeProduto { get; set; }
    public string PrecoFormatado { get; set; }
    public string CategoriaExibicao { get; set; }
    public string StatusAtivo { get; set; }
    public string TempoNoSistema { get; set; }
    public string MensagemPromocional { get; set; }
    public string TagsExibicao { get; set; }
    public List<string> Relacionados { get; set; }
}