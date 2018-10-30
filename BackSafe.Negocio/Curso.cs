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
        public List<EntCurso> retornarCursos()
        {
            Conexion.IntruccioneSQL = "fn_vercurso";
            Conexion.retornarDatosFunciones();
            List<EntCurso> listaCurso = new List<EntCurso>();
            foreach (DataRow item in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            {
                listaCurso.Add(new EntCurso(item["id"].ToString(), item["descripcion"].ToString(), item["capacitacion_id"].ToString()));
            }

            return listaCurso;
        }
    }
}
