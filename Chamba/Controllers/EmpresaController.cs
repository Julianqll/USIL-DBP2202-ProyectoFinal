using Microsoft.AspNetCore.Mvc;

namespace Chamba.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly chambaContext Context;
        public EmpresaController(chambaContext context)
        {
            Context = context;
        }
        [HttpGet, Route("/loginEmpresa")]
        public IActionResult LoginEmpresa()
        {
            return View();
        }

        [HttpGet, Route("/perfilEmpresa")]
        public IActionResult PerfilEmpresa()
        {
            return View();
        }

        [HttpGet, Route("/registroEmpresa")]
        public IActionResult RegistroEmpresa()
        {
            return View();
        }

        [HttpGet, Route("/crearPuestos")]
        public IActionResult CrearPuestos()
        {
            return View();
        }

        [HttpGet, Route("/postulaciones")]
        public IActionResult Postulaciones()
        {
            return View();
        }
    }
}
