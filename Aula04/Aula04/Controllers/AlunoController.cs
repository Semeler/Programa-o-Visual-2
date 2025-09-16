using Aula04.Models;
using Aula04.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aula04.Controllers;

public class AlunoController : Controller
{
    // GET
    public IActionResult Detalhes()
    {
        var aluno = new AlunoModel
        {
            id = 1,
            nome = "Lucas",
            sobrenome = "Silva",
            dataNascimento = new DateOnly(1999, 12, 12),
            email = "teste@gmail.com"

        };

        var vm = AlunoDetalhesViewModel.FromModel(aluno);
        
        return View(vm);
    }
}