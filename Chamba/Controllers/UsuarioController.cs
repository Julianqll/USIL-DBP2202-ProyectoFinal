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

        [HttpPost, Route("/registroUsuario")]
        public IActionResult RegistroUsuarioPost(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Context.Usuarios.Add(usuario);
                Context.SaveChanges();
                Login login = new Login();
                login.Correo = usuario.CorreoUsuario;
                login.Contraseña = Request.Form["contrasenaField"];
                login.Rol = "U";
                Context.Logins.Add(login);
                Context.SaveChanges();
                return Redirect("/login");

            }
            return View("RegistroUsuario");
        }

        [HttpGet, Route("/buscarPuestos")]
        public IActionResult BuscarPuestos()
        {
            return View();
        }

        [HttpGet, Route("/misPostulaciones")]
        public IActionResult MisPostulaciones()
        {
            return View();
        }
    }
}
