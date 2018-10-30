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
        public List<object> retornarListaExamenes(decimal idAtencion)
        {
            Conexion.IntruccioneSQL = "fn_verexman";
            Conexion.retornarDatosExamenes(idAtencion);
            List<object> listaExamenes = new List<object>();
            var sajdsa = Conexion.DbDat.Tables[Conexion.NombreTabla].AsEnumerable().ToList<object>();

            return sajdsa;
            //foreach (DataRow item in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            //{
               
            //}
        }
    }
}
