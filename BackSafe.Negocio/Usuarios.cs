using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BackSafe.Negocio
{
    public class Usuarios : AccesoConexion
    {


        public DataSet obtenerUsuarios()
        {
            Conexion.IntruccioneSQL = "fn_VerUsuarios";
            Conexion.retornarDatosFunciones();
            return Conexion.DbDat;
        }

        public Boolean crearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil)
        {
            Conexion.IntruccioneSQL = "pr_CrearUsuario";
            return Conexion.conectarProcCrearUsuario(rut,contraseña, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil);
        }

        public Boolean modificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil)
        {
            Conexion.IntruccioneSQL = "pr_ModificarUsuario";
            return Conexion.conectarProcModificarUsuario(rut, contraseña, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil);
        }
    }
}
