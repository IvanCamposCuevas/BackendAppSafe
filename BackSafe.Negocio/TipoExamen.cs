using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Negocio
{
    public class TipoExamen : AccesoConexion
    {
        
        public DataSet obtenerTipoExamen()
        {
            Conexion.IntruccioneSQL = "fn_VerTipoExamen";
            Conexion.retornarDatosFunciones();
            return Conexion.DbDat;
        }
    }
}
