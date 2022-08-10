using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIP.Web.Controllers
{
    public class AuthController : BaseController
    {
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string username, string password)
        {
            var objUsuario = Contexto.Usuarios
                .FirstOrDefault(x => x.Usuario == username && x.Contraseña == password);

            if (objUsuario != null)
            {
                if ((bool)objUsuario.Bloqueado)
                {
                    ViewBag.MensajeLogin = "El usuario se encuentra bloqueado.";
                    return View();
                }

                Session["IdUsuario"] = objUsuario.IdUsuario;
                Session["Rol"] = objUsuario.Roles.Nombre;
                Session["Nombre"] = $"{objUsuario.Datos}";

                return RedirectToAction("Index", "Home");
            }

            ViewBag.MensajeLogin = "El usuario o contraseña son incorrectos.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
