using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            Dictionary<string, object> diccionario = BL.Usuario.GetByEmailPassword(email, password);
            bool resultado = (bool)diccionario["Resultado"];

            if (resultado == true)//el metodo funciono
            {
                ML.Usuario usuario = (ML.Usuario)diccionario["Usuario"];
              
                if (usuario.Email == email)
                {
                    if (usuario.Password == password)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "El usuario y/o contraseña no son válidos";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Mensaje = "El usuario y/o contraseña no son válidos";
                return PartialView("Modal");
            }
            return View();

        }


    }
}
