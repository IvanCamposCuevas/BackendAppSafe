using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Negocio
{
    public class Supervisor : AccesoConexion
    {
        public bool crearPlanCapacitacion(string descPlan, int idEmpresa, string fechaPlan)
        {
            Conexion.abrirConexion();
            try
            {
                Conexion.variableSQL = new OracleCommand("PR_CREARPLAN", Conexion.DbConnection);
                Conexion.variableSQL.CommandType = CommandType.StoredProcedure;
                Conexion.variableSQL.Parameters.Add("desc_plan", descPlan);
                Conexion.variableSQL.Parameters.Add("fecha", OracleDbType.Date, fechaPlan, ParameterDirection.Input);
                Conexion.variableSQL.Parameters.Add("id_empresa", idEmpresa);
                Conexion.variableSQL.ExecuteNonQuery();
                Conexion.cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool crearCapacitacion(string descCapacitacion, decimal minParticipantes, string nomExpositor, string fecInicial, string fecFinal, int idPlanCapac)
        {
            Conexion.abrirConexion();
            try
            {
                Conexion.variableSQL = new OracleCommand("PR_CREARCAPACITACION", Conexion.DbConnection);
                Conexion.variableSQL.CommandType = CommandType.StoredProcedure;
                Conexion.variableSQL.Parameters.Add("desc_capacitacion", descCapacitacion);
                Conexion.variableSQL.Parameters.Add("min_participantes", minParticipantes);
                Conexion.variableSQL.Parameters.Add("nom_expositor", nomExpositor);
                Conexion.variableSQL.Parameters.Add("fecha_inicial", OracleDbType.Date, fecInicial, ParameterDirection.Input);
                Conexion.variableSQL.Parameters.Add("fecha_final", OracleDbType.Date, fecFinal, ParameterDirection.Input);
                Conexion.variableSQL.Parameters.Add("id_plan_capacitacion", idPlanCapac);
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
