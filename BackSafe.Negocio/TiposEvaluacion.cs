using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSafe.Entidad;

namespace BackSafe.Negocio
{
    public class TiposEvaluacion : AccesoConexion
    {

        public List<EntTipoEvaluacion> obtenerTipoEvaluacion()
        {
            Conexion.IntruccioneSQL = "fn_VerTipoDeEvaluacion";
            Conexion.retornarDatosFunciones();
            List<EntTipoEvaluacion> listaTipoEvaluacion = new List<EntTipoEvaluacion>();
            foreach (DataRow item in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            {
                listaTipoEvaluacion.Add(new EntTipoEvaluacion(item["id"].ToString(), item["descripcion"].ToString()));
            }
            return listaTipoEvaluacion;
        }

        public Boolean crearTipoEvaluacion(string descripcion)
        {
            Conexion.IntruccioneSQL = "pr_CrearTipoDeEvaluacion";
            return Conexion.conectarProcCrearTipoEval(descripcion);
        }

        public Boolean modificarTipoEvaluacion(decimal id_tipoeval, string descripcion)
        {
            Conexion.IntruccioneSQL = "pr_ModificarTipoEvaluacion";
            return Conexion.conectarProcModificarTipoEval(id_tipoeval, descripcion);
        }
    }
}
