using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Entidad
{
    public class EntUsuario
    {
        public string idUsuario { get; set; }
        public string rut { get; set; }
        public string contraseña { get; set; }
        public string nombre { get; set; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string fecRegistro { get; set; }
        public string idPerfil { get; set; }

        public EntUsuario()
        {
            
        }

        public EntUsuario(string idUsuario, string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, string telefono, string email, string fecRegistro, string idPerfil)
        {
            this.idUsuario = idUsuario;
            this.rut = rut;
            this.contraseña = contraseña;
            this.nombre = nombre;
            this.appaterno = appaterno;
            this.apmaterno = apmaterno;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.fecRegistro = fecRegistro;
            this.idPerfil = idPerfil;
        }
    }
}
