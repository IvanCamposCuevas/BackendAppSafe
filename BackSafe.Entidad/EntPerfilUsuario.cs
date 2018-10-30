using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Entidad
{
    public class EntPerfilUsuario
    {

        public string id_perfil { get; set; }
        public string descripcion_perfil { get; set; }

        public EntPerfilUsuario()
        {
        }

        public EntPerfilUsuario(string id_perfil, string descripcion_perfil)
        {
            this.id_perfil = id_perfil;
            this.descripcion_perfil = descripcion_perfil;
        }
    }
}
