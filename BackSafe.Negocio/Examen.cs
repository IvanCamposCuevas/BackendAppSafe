using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Negocio
{
    public class Examen : AccesoConexion
    {
        public DataSet retornarListaExamenes(decimal idAtencion)
        {
            Conexion.IntruccioneSQL = "fn_verexamen";
            Conexion.retornarDatosExamenes(idAtencion);

            return Conexion.DbDat;
        }
    }
}
