using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using BackSafe.Entidad;
using System.Data;

namespace BackSafe.Negocio
{
    public class Curso : AccesoConexion
    {
        public DataSet retornarCursos()
        {
            Conexion.IntruccioneSQL = "fn_vercurso";
            Conexion.retornarDatosFunciones();
            

            return Conexion.DbDat;
        }
    }
}
