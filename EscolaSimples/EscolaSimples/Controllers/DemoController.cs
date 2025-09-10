using EscolaSimples.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaSimples.Controllers;

public class DemoController : Controller
{
    
    //Lista para demonstracao
    private static List<DemoModel> _dados = new List<DemoModel>()
    {
        new DemoModel
        {
            Id = 1, Nome = "Item1", Descricao = "Primeira Demonstracao",
            DataCriacao = DateTime.Now.AddDays(-5), Ativo = true
        },
        new DemoModel
        {
            Id = 2, Nome = "Item1", Descricao = "Primeira Demonstracao",
            DataCriacao = DateTime.Now.AddDays(-5), Ativo = true
        },
        new DemoModel
        {
            Id = 3, Nome = "Item1", Descricao = "Primeira Demonstracao",
            DataCriacao = DateTime.Now.AddDays(-5), Ativo = true
        }
    };
    
    // GET
    public IActionResult Index()
    {
        return View(_dados);
    }

    public IActionResult Detalhes(int Id)
    {
        var item = _dados.FirstOrDefault(x => x.Id == Id) ?? 
                   new DemoModel {Id = 0, Descricao = "não encontrado", Nome = "não encontrado"};;

        return View(item);
    }
}