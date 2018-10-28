using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BackSafe.Entidad;

namespace BackSafe.Negocio
{
    
    public class Usuarios : AccesoConexion
    {

        public List<EntUsuario> obtenerUsuarios()
        {
            Conexion.IntruccioneSQL = "fn_VerUsuarios";
            Conexion.retornarDatosFunciones();
            List<EntUsuario> listaUsuarios = new List<EntUsuario>();
            foreach (DataRow item in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            {
                listaUsuarios.Add(new EntUsuario(item["id"].ToString(), item["rut_usuario"].ToString(), item["contrasena"].ToString(), item["nombre"].ToString(), item["ape_paterno"].ToString(), item["ape_materno"].ToString(), item["direccion"].ToString(), item["telefono"].ToString(), item["email"].ToString(), item["registro"].ToString(), item["perfil_usuario_id"].ToString()));
            }
            return listaUsuarios;
        }

        public Boolean crearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil)
        {
            string contrasEncript = Encriptador.Encrypt(contraseña);
            Conexion.IntruccioneSQL = "pr_CrearUsuario";
            return Conexion.conectarProcCrearUsuario(rut, contrasEncript, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil);
        }

        public Boolean modificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil)
        {
            string contrasEncript = Encriptador.Encrypt(contraseña);
            Conexion.IntruccioneSQL = "pr_ModificarUsuario";
            return Conexion.conectarProcModificarUsuario(rut, contrasEncript, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil);
        }

        public string retornarLogin(decimal rut, string contraseña)
        {
            string contrasEncript = Encriptador.Encrypt(contraseña);
            Conexion.IntruccioneSQL = "fn_login";
            return Conexion.retornarConfirmacionLogin(rut, contrasEncript);
        }
    }
}
