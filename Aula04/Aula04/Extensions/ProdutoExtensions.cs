using System.Globalization;
using Aula04.Models;
using Aula04.ViewModels;

namespace Aula04.Extensions
{
    public static class ProdutoExtensions
    {
        public static ProdutoListagemItemViewModel ToListItemViewModel(this Produto produto)
        {
            return new ProdutoListagemItemViewModel
            {
                Id = produto.Id,  // Adicionado
                Nome = produto.Nome,
                PrecoFormatado = produto.Preco.ToString("C", new CultureInfo("pt-BR")),
                Categoria = produto.Categoria,
                Status = produto.Ativo ? "Ativo" : "Inativo",
                TagsExibicao = string.Join(", ", produto.Tags),
                Badge = produto.Preco > 1000 ? "Premium" : null
            };
        }

        public static ProdutoDetalhesViewModel ToDetalhesViewModel(this Produto produto, IEnumerable<string> relacionados)
        {
            return new ProdutoDetalhesViewModel
            {
                NomeProduto = produto.Nome,
                PrecoFormatado = produto.Preco.ToString("C", new CultureInfo("pt-BR")),
                CategoriaExibicao = $"Categoria: {produto.Categoria}",
                StatusAtivo = produto.Ativo ? "Ativo" : "Inativo",
                TempoNoSistema = $"{produto.DiasNoSistema} dias no sistema",
                MensagemPromocional = produto.Preco > 100 ? "Produto Premium!" : "Oferta Especial!",
                TagsExibicao = string.Join(", ", produto.Tags),
                Relacionados = relacionados.ToList()
            };
        }
    }
}