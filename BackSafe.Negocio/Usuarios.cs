using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;

namespace BackSafe.Negocio
{
    public class Usuarios : AccesoConexion
    {


        public System.Data.DataSet obtenerUsuarios()
        {
            Conexion.IntruccioneSQL = "fn_VerUsuarios";
            Conexion.retornarUsuarios();
            return Conexion.DbDat;
        }


    }
}
