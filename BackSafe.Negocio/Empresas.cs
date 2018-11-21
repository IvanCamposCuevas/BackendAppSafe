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

        public Boolean crearEmpresa(string nomEmpresa, string runEmpresa, string dirEmpresa, decimal telEmpresa, string corEmpresa)
        {
            Conexion.IntruccioneSQL = "pr_CrearEmpresa";
            return Conexion.conectarProcCrearEmpresa(nomEmpresa, runEmpresa, dirEmpresa, telEmpresa, corEmpresa);
        }

        public Boolean modificarEmpresa(decimal idEmpresa, string nomEmpresa, string runEmpresa, string dirEmpresa, decimal telEmpresa, string corEmpresa)
        {
            Conexion.IntruccioneSQL = "PR_MODIFICAREMPRESA";
            return Conexion.conectarProcModificarEmpresa(idEmpresa, nomEmpresa, runEmpresa, dirEmpresa, telEmpresa, corEmpresa);
        }

        public Boolean eliminarEmpresa(string rutempresa)
        {
            Conexion.IntruccioneSQL = "pr_EliminarEmpresa";
            return Conexion.conectarProcEliminarEmpresa(rutempresa);
        }

        public List<EntEmpresa> obtenerEmpresas()
        {
            Conexion.IntruccioneSQL = "FN_VEREMPRESA";
            Conexion.retornarDatosFunciones();
            List<EntEmpresa> listaEmpresa = new List<EntEmpresa>();
            foreach (DataRow item in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            {
                listaEmpresa.Add(new EntEmpresa(item["ID"].ToString(), item["NOMBRE_EMPRESA"].ToString(), item["RUT_EMPRESA"].ToString(), item["DIRECCION"].ToString(), item["TELEFONO"].ToString(), item["CORREO"].ToString(), item["ESTADO"].ToString()));
            }
            return listaEmpresa;

            
        }

        public DataSet obtenerEmpresasDs()
        {
            Conexion.IntruccioneSQL = "FN_VEREMPRESA";
            Conexion.retornarDatosFunciones();
            return Conexion.DbDat;
        }
    }
}
