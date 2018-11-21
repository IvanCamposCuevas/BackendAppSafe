using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Negocio
{
    public class Tecnico : AccesoConexion
    {
        public bool crearEvaluacion(string fecEval, string descEval, decimal tipoEvalId, decimal empresaId, decimal usuarioId)
        {
            Conexion.comprobarConexion();
            try
            {
                Conexion.variableSQL = new OracleCommand("pr_CrearEvaluacion", Conexion.DbConnection);
                Conexion.variableSQL.CommandType = CommandType.StoredProcedure;
                Conexion.variableSQL.Parameters.Add("fecEval", OracleDbType.Date, fecEval, ParameterDirection.Input);
                Conexion.variableSQL.Parameters.Add("descEval", descEval);
                Conexion.variableSQL.Parameters.Add("tipoEvalId", tipoEvalId);
                Conexion.variableSQL.Parameters.Add("empresaId", empresaId);
                Conexion.variableSQL.Parameters.Add("usuarioId", usuarioId);
                Conexion.variableSQL.ExecuteNonQuery();
                Conexion.cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public DataSet obtenerEvaluacionTecnico()
        {
            try
            {
                Conexion.IntruccioneSQL = "fn_verevaluaciones";
                Conexion.retornarDatosFunciones();
                return Conexion.DbDat;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
