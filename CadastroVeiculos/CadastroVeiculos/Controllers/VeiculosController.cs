namespace CadastroVeiculos.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using CadastroVeiculos.Models;

    public class VeiculosController : Controller
    {
        public VeiculosController()
        {
        }

        // GET: Veiculos
        public IActionResult Index()
        {
            return View();
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            return View(new VeiculoViewModel());
        }

        // POST: Veiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VeiculoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Aqui você implementaria a lógica para salvar o veículo
            // Por exemplo, adicionar ao banco de dados

            TempData["Sucesso"] = "Veículo cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}