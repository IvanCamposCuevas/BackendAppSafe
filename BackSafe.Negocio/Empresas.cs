using BackSafe.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Negocio
{
    public class Empresas : AccesoConexion
    {

        public Boolean crearEmpresa(decimal usuarioId, string nomEmpresa, string runEmpresa)
        {
            Conexion.IntruccioneSQL = "pr_CrearEmpresa";
            return Conexion.conectarProcCrearEmpresa(usuarioId, nomEmpresa, runEmpresa);
        }

        public Boolean modificarEmpresa(decimal usuarioId, string nomEmpresa, string runEmpresa)
        {
            Conexion.IntruccioneSQL = "PR_MODIFICAREMPRESA";
            return Conexion.conectarProcModificarEmpresa(usuarioId, nomEmpresa, runEmpresa);
        }

        public Boolean eliminarEmpresa(decimal run_empresa)
        {
            Conexion.IntruccioneSQL = "pr_EliminarEmpresa";
            return Conexion.conectarProcEliminarEmpresa(run_empresa);
        }

        public List<EntEmpresa> obtenerEmpresas()
        {
            Conexion.IntruccioneSQL = "FN_VEREMPRESA";
            Conexion.retornarDatosFunciones();
            List<EntEmpresa> listaEmpresa = new List<EntEmpresa>();
            foreach (DataRow item in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            {
                listaEmpresa.Add(new EntEmpresa(item["USUARIO_ID"].ToString(), item["NOMBRE_EMPRESA"].ToString(), item["RUN_EMPRESA"].ToString()));
            }
            return listaEmpresa;

            
        }
    }
}
