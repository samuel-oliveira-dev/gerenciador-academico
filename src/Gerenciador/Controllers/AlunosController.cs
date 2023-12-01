using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Controllers
{
    public class AlunosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
