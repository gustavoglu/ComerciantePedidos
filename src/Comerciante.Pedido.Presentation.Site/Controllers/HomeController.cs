using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Comerciante.Pedido.Presentation.Site.Models;

namespace Comerciante.Pedido.Presentation.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("MeusPedidos", "Pedidos");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
