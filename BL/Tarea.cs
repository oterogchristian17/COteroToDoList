using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Tarea
    {
        public static Dictionary<string, object> GetAll()
        {
            ML.Tarea tar = new ML.Tarea();
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Tarea", tar }, { "Exepcion", excepcion }, { "Resultado", false } };

            try
            {
                using (DL.CoteroToDoListContext context = new DL.CoteroToDoListContext())

                {
                    var registros =

                    //LINQ

                    (from Tarea in context.Tareas
                     select new
                     {
                         IdTarea = Tarea.IdTarea,
                         IdStatus = Tarea.IdStatus,
                         IdUsuario = Tarea.IdUsuario,
                         Descripcion = Tarea.Descripcion,
                         FechadeVencimiento = Tarea.FechadeVencimiento
                    

                     }).ToList();

                    if (registros != null)
                    {
                        tar.Tareas = new List<Object>();
                        foreach (var registro in registros)
                        {
                            //Instanciar el objeto
                            ML.Tarea tarea = new ML.Tarea();

                            tarea.IdTarea = registro.IdTarea;
                            tarea.Descripcion = registro.Descripcion;
                            tarea.FechadeVencimiento = (DateTime) registro.FechadeVencimiento;

                            //AQUI VA LA PROPIEDAD DE NAVEGACION

                            tarea.Status = new ML.Status();
                            tarea.Status.IdStatus = (int)registro.IdStatus.Value;

                            tarea.Usuario = new ML.Usuario();
                            tarea.Usuario.IdUsuario = (int)registro.IdUsuario.Value;

                            tar.Tareas.Add(tarea);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = tar;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }

    }
}
