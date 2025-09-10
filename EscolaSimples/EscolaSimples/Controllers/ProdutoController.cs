
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using EscolaSimples.Models;


public class ProdutoController : Controller
{
    private static readonly List<Produto> _produtos = new()
    {
        new Produto { Id = 1, Nome = "Smartphone", Preco = 2499.99M, Categoria = "Eletrônicos", EmEstoque = true, DataCadastro = DateTime.Now },
        new Produto { Id = 2, Nome = "Notebook", Preco = 4999.99M, Categoria = "Eletrônicos", EmEstoque = true, DataCadastro = DateTime.Now },
        new Produto { Id = 3, Nome = "Camiseta", Preco = 79.99M, Categoria = "Roupas", EmEstoque = true, DataCadastro = DateTime.Now },
        new Produto { Id = 4, Nome = "Calça", Preco = 149.99M, Categoria = "Roupas", EmEstoque = false, DataCadastro = DateTime.Now },
        new Produto { Id = 5, Nome = "Romance", Preco = 49.99M, Categoria = "Livros", EmEstoque = true, DataCadastro = DateTime.Now },
        new Produto { Id = 6, Nome = "Livro Técnico", Preco = 159.99M, Categoria = "Livros", EmEstoque = true, DataCadastro = DateTime.Now }
    };

    // ViewResult Actions
    public IActionResult Index()
    {
        return View(_produtos);
    }

    public IActionResult Detalhes(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return NotFound();
        return View(produto);
    }

    public IActionResult Categoria(string categoria)
    {
        var produtos = _produtos.Where(p => p.Categoria == categoria).ToList();
        ViewBag.Categoria = categoria;
        return View(produtos);
    }

    // JsonResult Actions
    public JsonResult ObterProdutosJson()
    {
        return Json(new { sucesso = true, dados = _produtos });
    }

    public JsonResult BuscarProduto(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        return Json(new { sucesso = produto != null, dados = produto });
    }

    public JsonResult ProdutosPorCategoria(string categoria)
    {
        var produtos = _produtos.Where(p => p.Categoria == categoria).ToList();
        return Json(new { sucesso = true, dados = produtos });
    }

    // FileResult Actions
    public FileResult ExportarCsv()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Id,Nome,Preço,Categoria,Em Estoque,Data Cadastro");
        
        foreach (var produto in _produtos)
        {
            sb.AppendLine($"{produto.Id},{produto.Nome},{produto.Preco},{produto.Categoria},{produto.EmEstoque},{produto.DataCadastro:yyyy-MM-dd}");
        }

        byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
        return File(bytes, "text/csv", "produtos.csv");
    }

    public FileResult RelatorioTxt()
    {
        var sb = new StringBuilder();
        sb.AppendLine("RELATÓRIO DE PRODUTOS");
        sb.AppendLine("====================");
        sb.AppendLine($"Total de Produtos: {_produtos.Count}");
        sb.AppendLine($"Produtos em Estoque: {_produtos.Count(p => p.EmEstoque)}");
        
        var categorias = _produtos.GroupBy(p => p.Categoria);
        sb.AppendLine("\nProdutos por Categoria:");
        foreach (var categoria in categorias)
        {
            sb.AppendLine($"- {categoria.Key}: {categoria.Count()} produtos");
        }

        byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
        return File(bytes, "text/plain", "relatorio.txt");
    }

    public FileResult ExportarJson()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(_produtos, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        byte[] bytes = Encoding.UTF8.GetBytes(json);
        return File(bytes, "application/json", "produtos.json");
    }
}