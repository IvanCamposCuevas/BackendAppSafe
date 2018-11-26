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

        public List<EntContrato> obtenerContratos()
        {
            Conexion.IntruccioneSQL = "fn_vercontrato";
            Conexion.retornarDatosFunciones();
            List<EntContrato> listaContrato = new List<EntContrato>();
            foreach (DataRow item in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            {
                listaContrato.Add(new EntContrato(item["id"].ToString(), item["contrato"].ToString(), item["fecha_inicio_contrato"].ToString(), item["estado"].ToString(), item["empresa_id"].ToString()));
            }
            return listaContrato;
        }
    }
}
