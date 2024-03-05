using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class TareasController : Controller
    {
       
        public IActionResult ToDoListGetAll()
        {
            Dictionary<string, object> resultado = BL.Tarea.GetAll();
            bool correct = (bool)resultado["Resultado"];
            if (correct)
            {
                ML.Tarea tarea = (ML.Tarea)resultado["Tarea"];
                return View(tarea);
            }
            return View();
        }

        public IActionResult GetAll()
        {
            Dictionary<string, object> resultado = BL.Tarea.GetAll();
            bool correct = (bool)resultado["Resultado"];
            if (correct)
            {
                ML.Tarea tarea = (ML.Tarea)resultado["Tarea"];
                return View(tarea);
            }
            return View();
        }
    }
}
