namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using WebApplication1.Extensions;


public class ProdutoController : Controller
{
    private static readonly List<Produto> _produtos = new List<Produto>
    {
        new Produto 
        { 
            Id = 1, 
            Nome = "Smartphone XYZ", 
            Preco = 1299.99m, 
            Categoria = "Eletrônicos",
            DataCriacao = DateTime.Now.AddDays(-30),
            Ativo = true,
            Tags = new List<string> { "promo", "android" }
        },
        new Produto 
        { 
            Id = 2, 
            Nome = "Fone Bluetooth", 
            Preco = 299.99m, 
            Categoria = "Áudio",
            DataCriacao = DateTime.Now.AddDays(-15),
            Ativo = true,
            Tags = new List<string> { "bluetooth", "promo" }
        },
        // Adicione mais produtos MOCK aqui...
    };

    public IActionResult Lista(string? categoria, string? ordenarPor = "preco_asc")
    {
        var query = _produtos.AsQueryable();

        if (!string.IsNullOrEmpty(categoria))
        {
            query = query.Where(p => p.Categoria == categoria);
        }

        query = ordenarPor switch
        {
            "preco_desc" => query.OrderByDescending(p => p.Preco),
            "nome" => query.OrderBy(p => p.Nome),
            _ => query.OrderBy(p => p.Preco)
        };

        var viewModel = query.Select(p => p.ToListItemViewModel());
        return View(viewModel);
    }

    public IActionResult Detalhes(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return NotFound();

        var relacionados = _produtos
            .Where(p => p.Categoria == produto.Categoria && p.Id != produto.Id)
            .Take(3)
            .Select(p => p.Nome)
            .ToList();

        var viewModel = produto.ToDetalhesViewModel(relacionados);
        return View(viewModel);
    }
}