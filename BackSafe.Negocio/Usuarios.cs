﻿using System;
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
                listaUsuarios.Add(new EntUsuario(item["id"].ToString(), item["rut_usuario"].ToString(), item["contrasena"].ToString(), item["nombre"].ToString(), item["ape_paterno"].ToString(), item["ape_materno"].ToString(), item["direccion"].ToString(), item["telefono"].ToString(), item["email"].ToString(), item["registro"].ToString(), item["estado"].ToString(), item["perfil_usuario_id"].ToString(), item["empresa_id"].ToString()));
            }
            return listaUsuarios;
        }

        /// <summary>
        /// Crea un usuario con atributos generales, donde se encuentran:
        /// Administrador,
        /// Tecnico,
        /// Ingeniero y
        /// Supervisor
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="contraseña"></param>
        /// <param name="nombre"></param>
        /// <param name="appaterno"></param>
        /// <param name="apmaterno"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <param name="idPerfil"></param>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public Boolean crearUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa)
        {
            string contrasEncript = Encriptador.Encrypt(contraseña);
            Conexion.IntruccioneSQL = "pr_CrearUsuario";
            return Conexion.conectarProcCrearUsuario(rut, contrasEncript, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil, idEmpresa);
        }

        /// <summary>
        /// Crea un usuario y le asigna el perfil de medico, junto con sus atributos propios.
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="contraseña"></param>
        /// <param name="nombre"></param>
        /// <param name="appaterno"></param>
        /// <param name="apmaterno"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <param name="idPerfil"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="disponibilidad"></param>
        /// <param name="mailPrivado"></param>
        /// <param name="telefonoPriv"></param>
        /// <returns></returns>
        public Boolean crearUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa, string disponibilidad, string mailPrivado, decimal telefonoPriv)
        {
            string contrasEncript = Encriptador.Encrypt(contraseña);
            Conexion.IntruccioneSQL = "pr_CrearUsuarioMedico";
            return Conexion.conectarProcCrearUsuario(rut, contrasEncript, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil, idEmpresa, disponibilidad, mailPrivado, telefonoPriv);
        }

        /// <summary>
        /// Asigna los atributos de usuario y trabajador, y los guarda en la Base de Datos.
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="contraseña"></param>
        /// <param name="nombre"></param>
        /// <param name="appaterno"></param>
        /// <param name="apmaterno"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <param name="idPerfil"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="mailPrivado"></param>
        /// <param name="telPrivado"></param>
        /// <param name="estadoRiesgo"></param>
        /// <param name="contratoId"></param>
        /// <returns></returns>
        public Boolean crearUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa, string mailPrivado, decimal telPrivado,
                                    string estadoRiesgo, decimal contratoId)
        {
            string contrasEncript = Encriptador.Encrypt(contraseña);
            Conexion.IntruccioneSQL = "pr_CrearUsuarioTrabajador";

            return Conexion.conectarProcCrearUsuario(rut, contrasEncript, nombre, appaterno, apmaterno, direccion, telefono, email, idPerfil, idEmpresa, mailPrivado, telPrivado, estadoRiesgo, contratoId);
        }

        public Boolean modificarUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email)
        {
            string contrasEncript = Encriptador.Encrypt(contraseña);
            Conexion.IntruccioneSQL = "pr_ModificarUsuario";
            return Conexion.conectarProcModificarUsuario(rut, contrasEncript, nombre, appaterno, apmaterno, direccion, telefono, email);
        }

        public Boolean eliminarUsuario(string rut)
        {
            Conexion.IntruccioneSQL = "pr_EliminarUsuario";
            return Conexion.conectarProcEliminarEmpresa(rut);
        }

        public DataSet retornarLogin(string rut, string contraseña)
        {
            string contrasEncript = Encriptador.Encrypt(contraseña);
            Conexion.IntruccioneSQL = "fn_login";
            Conexion.retornarConfirmacionLogin(rut, contrasEncript);
            return Conexion.DbDat;
        }

        public string descContraseña (string rut)
        {
            Conexion.IntruccioneSQL = string.Format("SELECT contrasena FROM usuario WHERE rut_usuario = '{0}'", rut);
            Conexion.EsSelect = true;
            Conexion.conectar();

            string cont = Conexion.DbDat.Tables[Conexion.NombreTabla].Rows[0]["contrasena"].ToString();
            return Encriptador.Decrypt(cont);
        }
    }
}
