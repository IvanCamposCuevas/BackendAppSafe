using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSafe.Entidad;
using System.Data;

namespace BackSafe.Negocio
{
    public class Contrato : AccesoConexion
    {
        public DataSet retornarTodosLosContratos()
        {
            Conexion.IntruccioneSQL = "fn_vercontrato";
            Conexion.retornarDatosFunciones();

            return Conexion.DbDat;
        }
    }
}
