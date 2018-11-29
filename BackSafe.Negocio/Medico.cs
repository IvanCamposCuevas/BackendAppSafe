using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using System.Net.Mail;
using System.Net;

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

        public bool crearAtencion(string desc_atencion, string rut, decimal id_visita_medica, string fechaAtencion)
        {
            Conexion.comprobarConexion();
            try
            {
                Conexion.IntruccioneSQL = "PR_CREARATENCION";
                return Conexion.conectarProcCrearAtencion(desc_atencion, rut, id_visita_medica, fechaAtencion);
            }
            catch (OracleException ex)
            {

                throw;
            }
        }


        public void EnviarMail(MailMessage mensaje)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.googlemail.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("mar.faundez@alumnos.duoc.cl", "udechile*");
                client.Send(mensaje);
            }
            catch (SmtpException ex)
            {
                throw new Exception("Error al enviar el mensaje", ex.InnerException);

            }
            catch (Exception ex)
            {
                throw new Exception("Error: ", ex.InnerException);
            }

        }
    }
}
