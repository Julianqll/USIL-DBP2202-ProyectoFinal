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

        [HttpGet, Route("/perfilUsuario")]
        public IActionResult PerfilUsuario()
        {
            return View();
        }

        [HttpGet, Route("/registroUsuario")]
        public IActionResult RegistroUsuario()
        {
            return View();
        }
    }
}
