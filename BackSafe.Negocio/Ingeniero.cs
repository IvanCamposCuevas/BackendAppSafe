using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Negocio
{
    public class Ingeniero : AccesoConexion
    {
        public DataSet obtenerEvaluacionesIngeniero()
        {
            try
            {
                Conexion.IntruccioneSQL = "fn_verevaluacionesingeniero";
                Conexion.retornarDatosFunciones();
                return Conexion.DbDat;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool crearInformeEvaluacion(string recomendacion, decimal usuarioId, decimal evalId)
        {
            Conexion.comprobarConexion();
            try
            {
                Conexion.variableSQL = new OracleCommand("pr_crearinforme", Conexion.DbConnection);
                Conexion.variableSQL.CommandType = CommandType.StoredProcedure;
                Conexion.variableSQL.Parameters.Add("recomendacion", recomendacion);
                Conexion.variableSQL.Parameters.Add("usuarioId", usuarioId);
                Conexion.variableSQL.Parameters.Add("evaluacionId", evalId);
                Conexion.variableSQL.ExecuteNonQuery();
                Conexion.cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }
    }
}
