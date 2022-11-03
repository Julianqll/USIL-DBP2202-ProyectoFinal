using Chamba.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Chamba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly chambaContext Context;

        public HomeController(ILogger<HomeController> logger, chambaContext context)
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
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(resultado));
                    var datosSesion = HttpContext.Session.GetString("usuario");
                    
                }
            }
            return View("Login");
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