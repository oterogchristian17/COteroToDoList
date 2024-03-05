using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Tarea
    {
        public int IdTarea { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechadeVencimiento { get; set; }

        public List<object> Tareas { get; set; }

        public ML.Status Status { get; set; }
        public ML.Usuario Usuario { get; set; }
    }
}
