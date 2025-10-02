using Microsoft.AspNetCore.Mvc;
using AtividadeCliqueSimples.Models;

namespace AtividadeCliqueSimples.Controllers
{
    public class HomeController : Controller
    {
        private static int _contadorDeCliques = 0;

        public IActionResult Index()
        {
            var modelo = new ContadorModel
            {
                Cliques = _contadorDeCliques
            };
            
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Contar()
        {
            _contadorDeCliques++;
            return RedirectToAction(nameof(Index));
        }
    }
}