using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSafe.AccesoDatos;
using System.Data.Objects;

namespace BackSafe.Negocio
{
    public class Usuarios
    {


        public Boolean crearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno, string direccion, decimal telefono, string email,DateTime fecRegisto, decimal tipoUsuario)
        {
            using (EntitiesSafe accesoBd = new EntitiesSafe())
            {
                if (accesoBd.PR_CREARUSUARIO(rut, contraseña, nombre, appaterno, apmaterno, direccion, telefono, email, fecRegisto, tipoUsuario) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ObjectResult<USUARIO> verUsuario()
        {
            using (EntitiesSafe accesoBd = new EntitiesSafe())
            {
                return accesoBd.FN_VERUSUARIOS();
            }
        }

        public Boolean modificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno, string direccion, decimal telefono, string email, DateTime fecRegisto, decimal tipoUsuario)
        {
            using (EntitiesSafe accesoBd = new EntitiesSafe())
            {
                if (accesoBd.PR_MODIFICARUSUARIO(rut, contraseña, nombre, appaterno, apmaterno, direccion, telefono, email, fecRegisto, tipoUsuario) == 1)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }


    }
}
