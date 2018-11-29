using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Negocio
{
    public class AccesoMedico : AccesoConexion
    {
        public DataSet retornarConsulta(string rut)

        {
            try
            {
                Conexion.IntruccioneSQL = "fn_ObtenerConsultaTrabajador";
                Conexion.retornarConsulta(rut);
                return Conexion.DbDat;
            }
            catch (OracleException ex)
            {

                throw;
            }

        }

        


    }
}
