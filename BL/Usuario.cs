using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string, object> GetByEmailPassword(string email, string password)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Usuario", null } };
            try
            {
                using (DL.CoteroToDoListContext context = new DL.CoteroToDoListContext())
                {
                    var registro = (from usario in context.Usuarios

                                    where usario.Email == email

                                    select new
                                    {

                                        Email = usario.Email,
                                        Password = usario.Password

                                    }).FirstOrDefault();

                    if (registro != null)
                    {
                        ML.Usuario user = new ML.Usuario();

                        user.Email = registro.Email;
                        user.Password = registro.Password;

                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = user;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }

    }
}
