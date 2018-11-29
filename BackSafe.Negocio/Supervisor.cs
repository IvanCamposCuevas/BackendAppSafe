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

        public DataSet retornarEvaluacionesSupervisor(decimal idEmpresa)
        {
            try
            {
                Conexion.IntruccioneSQL = "fn_verevaluacionessupervisor";
                Conexion.retornarEvaluacionesSupervisor(idEmpresa);
                return Conexion.DbDat;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public DataSet retornarInformesEvaluaciones(decimal idEmpresa)
        {
            try
            {
                Conexion.IntruccioneSQL = "fn_VerInformes";
                Conexion.retornarInformesPorEmpresa(idEmpresa);
                return Conexion.DbDat;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool actualizarEstadoEvaluacion(decimal idEvaluacion, int estadoEval, string motivo)
        {
            Conexion.abrirConexion();
            try
            {
                Conexion.variableSQL = new OracleCommand("pr_AprobarEvaluacion", Conexion.DbConnection);
                Conexion.variableSQL.CommandType = CommandType.StoredProcedure;
                Conexion.variableSQL.Parameters.Add("idEval", idEvaluacion);
                Conexion.variableSQL.Parameters.Add("estadoEval", estadoEval);
                Conexion.variableSQL.Parameters.Add("motivo", motivo);
                Conexion.variableSQL.ExecuteNonQuery();
                Conexion.cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool crearCurso(string descripcion, decimal capacitacionId)
        {
            try
            {
                Conexion.IntruccioneSQL = "PR_CREARCURSO";
                return Conexion.conectarProcCrearCurso(descripcion, capacitacionId);
            }
            catch (OracleException ex)
            {

                throw;
            }

        }

        public DataSet obtenerCapacitciones()
        {
            try
            {
                Conexion.IntruccioneSQL = "fn_VerCapac";
                Conexion.retornarDatosFunciones();
                return Conexion.DbDat;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public DataSet obtenerPlanCapacitacion()
        {
            try
            {
                Conexion.IntruccioneSQL = "fn_VerPlanCapac";
                Conexion.retornarDatosFunciones();
                return Conexion.DbDat;
            }
            catch (OracleException)
            {

                throw;
            }
        }
    }
}
