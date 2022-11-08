using Chamba.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Chamba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly sql10550492Context Context;

        public HomeController(ILogger<HomeController> logger, sql10550492Context context)
        {
            _logger = logger;
            Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("/login")]
        public IActionResult LoginPost(Login login)
        {
            if (ModelState.IsValid)
            {

                var resultado = (from TablaLogin in Context.Logins
                                 where
                                 TablaLogin.Correo == login.Correo && TablaLogin.Contraseña == login.Contraseña
                                 select TablaLogin).FirstOrDefault();
                if (resultado != null)
                {
                    if (resultado.Rol == "U")
                    {
                        var usuario = (from TablaUsuarios in Context.Usuarios 
                                       where TablaUsuarios.CorreoUsuario == resultado.Correo 
                                       select TablaUsuarios).FirstOrDefault();
                        HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                        return Redirect("/perfilUsuario");
                    }
                    else 
                    {
                        var empresa = (from TablaEmpresas in Context.Empresas
                                       where TablaEmpresas.CorreoEmpresa == resultado.Correo
                                       select TablaEmpresas).FirstOrDefault();
                        HttpContext.Session.SetString("empresa", JsonConvert.SerializeObject(empresa));
                        return Redirect("/perfilEmpresa");
                    }
                    
                }
            }
            return View("Login");
        }

        [HttpGet, Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}