using Microsoft.AspNetCore.Mvc;
using Aula04.Models;
using Aula04.ViewModels;
using Aula04.Extensions;
using System.Collections.Generic;
using System.Linq;


namespace Aula04.Controllers
{
    public class ProdutoController : Controller
    {
        private static readonly List<Produto> _produtos = new()
        {
            new Produto
            {
                Id = 1,
                Nome = "Smartphone XYZ",
                Preco = 1299.99m,
                DataCriacao = DateTime.Now.AddDays(-30),
                Categoria = "Eletrônicos",
                Ativo = true,
                Tags = new List<string> { "promo", "android" }
            },
            new Produto
            {
                Id = 2,
                Nome = "Fone Bluetooth ABC",
                Preco = 299.99m,
                DataCriacao = DateTime.Now.AddDays(-15),
                Categoria = "Áudio",
                Ativo = true,
                Tags = new List<string> { "bluetooth", "promo" }
            },
            new Produto
            {
                Id = 3,
                Nome = "Smart TV LED 55\"",
                Preco = 2499.99m,
                DataCriacao = DateTime.Now.AddDays(-45),
                Categoria = "Eletrônicos",
                Ativo = true,
                Tags = new List<string> { "smart", "4k" }
            },
            new Produto
            {
                Id = 4,
                Nome = "Caixa de Som Portátil",
                Preco = 199.99m,
                DataCriacao = DateTime.Now.AddDays(-5),
                Categoria = "Áudio",
                Ativo = true,
                Tags = new List<string> { "bluetooth", "portátil" }
            },
            new Produto
            {
                Id = 5,
                Nome = "Tablet Pro",
                Preco = 1599.99m,
                DataCriacao = DateTime.Now.AddDays(-60),
                Categoria = "Eletrônicos",
                Ativo = false,
                Tags = new List<string> { "tablet", "premium" }
            },
            new Produto
            {
                Id = 6,
                Nome = "Fone de Ouvido Pro",
                Preco = 899.99m,
                DataCriacao = DateTime.Now.AddDays(-25),
                Categoria = "Áudio",
                Ativo = true,
                Tags = new List<string> { "premium", "noise-canceling" }
            }
        };


        public IActionResult Lista(string? categoria, string? ordenarPor = "preco_asc")
        {
            var query = _produtos.AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(p => p.Categoria == categoria);

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
            if (produto == null)
                return NotFound();

            var relacionados = _produtos
                .Where(p => p.Categoria == produto.Categoria && p.Id != produto.Id)
                .Take(3)
                .Select(p => p.Nome)
                .ToList();

            return View(produto.ToDetalhesViewModel(relacionados));
        }
    }
}