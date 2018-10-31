using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BackSafe.Entidad;
using BackSafe.Negocio;

namespace BackSafe.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioAppEscritorio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioAppEscritorio.svc o ServicioAppEscritorio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioAppEscritorio : IServicioAppEscritorio
    {
        public bool crearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno, string direccion, decimal telefono, string email, decimal idPerfil)
        {
            return new Usuarios().crearUsuario(rut, contraseña, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil);
        }

        public bool modificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno, string direccion, decimal telefono, string email, decimal idPerfil)
        {
            return new Usuarios().modificarUsuario(rut, contraseña, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil);
        }

        public bool crearTipoEvaluacion(string descripcion)
        {
            return new TiposEvaluacion().crearTipoEvaluacion(descripcion);
        }

        public bool modificarTipoEvaluacion(decimal id_tipoeval, string descripcion)
        {
            return new TiposEvaluacion().modificarTipoEvaluacion(id_tipoeval, descripcion);
        }

        public bool eliminarTipoEvaluacion(decimal id_tipoeval)
        {
            return new TiposEvaluacion().eliminarTipoEvaluacion(id_tipoeval);
        }


        public List<EntUsuario> retornarUsuarios()
        {
            return new Usuarios().obtenerUsuarios();
        }

        public List<EntTipoEvaluacion> retornarTiposEvaluacion()
        {
            return new TiposEvaluacion().obtenerTipoEvaluacion();
        }

        public List<EntPerfilUsuario> retornarPerfilUsuarios()
        {
            return new PerfilUsuarios().obtenerPerfilUsuario();
        }

        public string login(decimal rut, string contraseña)
        {
            return new Usuarios().retornarLogin(rut, contraseña);
        }

        public bool crearUsuarioEmpresa(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil, string nomEmpresa, string runEmpresa)
        {
            return new Usuarios().crearUsuario(rut, contraseña, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil
                                                     , nomEmpresa, runEmpresa);
        }
    }
}
