using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
    }
}
