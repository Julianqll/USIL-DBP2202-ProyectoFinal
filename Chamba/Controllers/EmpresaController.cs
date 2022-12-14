using Chamba.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Chamba.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly sql10550492Context Context;
        public EmpresaController(sql10550492Context context)
        {
            Context = context;
        }

        [HttpGet, Route("/perfilEmpresa")]
        public IActionResult PerfilEmpresa()
        {
            String? sesion = HttpContext.Session.GetString("empresa");
            if (sesion != null)
            {
                var sesionJson = JsonConvert.DeserializeObject<Empresa>(sesion);
                return View(sesionJson);
            }
            else
            {
                return Redirect("/login");
            }
        }

        [HttpGet, Route("/registroEmpresa")]
        public IActionResult RegistroEmpresa()
        {
            return View();
        }

        [HttpPost, Route("/registroEmpresa")]
        public IActionResult RegistroEmpresaPost(Empresa empresa)
        {
            if (ModelState.IsValid)
            {

                Context.Empresas.Add(empresa);
                Context.SaveChanges();
                Login login = new Login();
                login.Correo = empresa.CorreoEmpresa;
                login.Contraseña = Request.Form["contrasenaField"];
                login.Rol = "E";
                Context.Logins.Add(login);
                Context.SaveChanges();
                return Redirect("/login");

            }
            return View("RegistroEmpresa");
        }

        [HttpGet, Route("/crearPuestos")]
        public IActionResult CrearPuestos()
        {
            String? sesion = HttpContext.Session.GetString("empresa");
            var sesionJson = JsonConvert.DeserializeObject<Empresa>(sesion);
            var puestos = (from TablaPuestos in Context.Puestos
                           where
                           TablaPuestos.Empresa == sesionJson.IdEmpresa
                           select TablaPuestos).AsEnumerable();
            ViewBag.Puestos = puestos;
            return View();
        }

        [HttpPost, Route("/crearPuestos")]
        public IActionResult CrearPuestosPost(Puesto puesto)
        {
            if (ModelState.IsValid)
            {

                String? sesion = HttpContext.Session.GetString("empresa");
                var sesionJson = JsonConvert.DeserializeObject<Empresa>(sesion);
                puesto.Salario = Convert.ToDouble(puesto.Salario);
                puesto.Empresa = sesionJson.IdEmpresa;
                Context.Puestos.Add(puesto);
                Context.SaveChanges();
                return Redirect("/crearPuestos");

            }
            return View("CrearPuestos");
        }

        [HttpGet, Route("/postulaciones")]
        public IActionResult Postulaciones()
        {
            String? sesion = HttpContext.Session.GetString("empresa");
            var sesionJson = JsonConvert.DeserializeObject<Empresa>(sesion);
            var postulaciones = (from TablaPostulaciones in Context.Postulacions
                                 join TablaPuestos in Context.Puestos
                                 on TablaPostulaciones.Puesto equals TablaPuestos.IdPuesto
                                 join TablaUsuarios in Context.Usuarios
                                 on TablaPostulaciones.Postulante equals TablaUsuarios.IdUsuario
                                 where
                                 TablaPuestos.Empresa == sesionJson.IdEmpresa
                                 select new
                                 {
                                     Id = TablaPostulaciones.Puesto,
                                     Nombre = TablaUsuarios.NombresUsuario,
                                     Apellido = TablaUsuarios.ApellidosUsuario,
                                     Comentario = TablaPostulaciones.ComentarioPostulante,
                                     Puesto = TablaPuestos.NombrePuesto,
                                     Vacantes = TablaPuestos.VacantesPuesto,
                                 }).AsEnumerable();
            ViewBag.Postulaciones = postulaciones;
            return View();
        }

        [HttpPost, Route("/editarPerfilEmpresa")]
        public IActionResult EditarPerfil()
        {
            String? sesion = HttpContext.Session.GetString("empresa");
            var sesionJson = JsonConvert.DeserializeObject<Empresa>(sesion);
            var resultado = (from TablaEmpresas in Context.Empresas
                             where TablaEmpresas.IdEmpresa == sesionJson.IdEmpresa
                             select TablaEmpresas).Single();
            resultado.ApodoEmpresa = Request.Form["apodoEmpresa"];
            resultado.NombreEmpresa = Request.Form["nombreEmpresa"];
            resultado.CorreoEmpresa = Request.Form["correoEmpresa"];
            resultado.BiografiaEmpresa = Request.Form["bioEmpresa"];
            resultado.FotoPerfilEmpresa = Request.Form["fotoEmpresa"];
            Context.SaveChanges();
            var empresa = (from TablaEmpresas in Context.Empresas
                           where TablaEmpresas.CorreoEmpresa == sesionJson.CorreoEmpresa
                           select TablaEmpresas).FirstOrDefault();
            HttpContext.Session.SetString("empresa", JsonConvert.SerializeObject(empresa));
            return Redirect("/perfilEmpresa");
        }
    }
}
