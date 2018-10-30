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
        public List<EntContrato> retornarTodosLosContratos()
        {
            Conexion.IntruccioneSQL = "fn_vercontrato";
            Conexion.retornarDatosFunciones();
            List<EntContrato> listaContrato = new List<EntContrato>();
            foreach (DataRow fila in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            {
                listaContrato.Add(new EntContrato(fila["id"].ToString(), fila["contrato"].ToString(), fila["fecha_inicio_contrato"].ToString(), fila["estado"].ToString(), fila["empresa_id"].ToString()));
            }

            return listaContrato;
        }
    }
}
