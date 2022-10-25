using Microsoft.AspNetCore.Mvc;

namespace Chamba.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly chambaContext Context;

        public UsuarioController(chambaContext context)
        {
            Context = context;
        }

        [HttpGet, Route("/loginUsuario")]
        public IActionResult LoginUsuario()
        {
            return View();
        }

    }
}
