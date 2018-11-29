using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;

namespace BackSafe.Negocio
{
    public class Medico : AccesoConexion
    {
        public DataSet obtenerMedico()
        {
            Conexion.IntruccioneSQL = "fn_verMedicos";
            Conexion.retornarDatosFunciones();

            return Conexion.DbDat;
        }

        public bool crearExamen(string desc_examen, string f_examen, decimal id_tipo_examen, decimal id_atencion)
        {

            Conexion.comprobarConexion();
            try
            {
                Conexion.variableSQL = new OracleCommand("PR_CREAREXAMEN", Conexion.DbConnection);
                Conexion.variableSQL.CommandType = CommandType.StoredProcedure;
                Conexion.variableSQL.Parameters.Add("desc_examen", desc_examen);
                Conexion.variableSQL.Parameters.Add("f_examen", OracleDbType.Date, f_examen, ParameterDirection.Input);
                Conexion.variableSQL.Parameters.Add("id_tipo_examen", id_tipo_examen);
                Conexion.variableSQL.Parameters.Add("id_atencion", id_atencion);
                Conexion.variableSQL.ExecuteNonQuery();
                Conexion.cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool crearAtencion(string desc_atencion, decimal id_ficha, decimal id_visita_medica)
        {
            Conexion.comprobarConexion();
            try
            {
                Conexion.variableSQL = new OracleCommand("PR_CREARATENCION", Conexion.DbConnection);
                Conexion.variableSQL.CommandType = CommandType.StoredProcedure;
                Conexion.variableSQL.Parameters.Add("desc_atencion", desc_atencion);
                Conexion.variableSQL.Parameters.Add("id_ficha", id_ficha);
                Conexion.variableSQL.Parameters.Add("id_visita_medica", id_visita_medica);
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
