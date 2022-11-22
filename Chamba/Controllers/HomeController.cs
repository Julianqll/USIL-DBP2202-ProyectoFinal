using Chamba.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Mime;
using System.Text;

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
        public async Task<ActionResult> LoginPost(Login login)
        {
            if (ModelState.IsValid)
            {
                var httpCliente = new HttpClient();
                String loginString = JsonConvert.SerializeObject(login);
                var httpContent = new StringContent(loginString, Encoding.UTF8, "application/json");
                var response = await httpCliente.PostAsync("https://localhost:7280/api/login/type", httpContent);
                var responseInfo = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine(responseInfo);
                if (responseInfo == "U")
                {
                    var newresponse = await httpCliente.PostAsync("https://localhost:7280/api/login", httpContent);
                    var newresponseInfo = await newresponse.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("usuario", newresponseInfo);
                    return Redirect("/perfilUsuario");
                }
                else 
                {
                    var newresponse = await httpCliente.PostAsync("https://localhost:7280/api/login", httpContent);
                    var newresponseInfo = await newresponse.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("empresa", newresponseInfo);
                    return Redirect("/perfilEmpresa");
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